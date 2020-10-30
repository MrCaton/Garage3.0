using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageMVC.Data;
using GarageMVC.Models.Entities;
using AutoMapper;
using GarageMVC.ViewModels;
using Microsoft.Extensions.Options;
using GarageMVC.Common;
using System.Net.WebSockets;
using System.Text;
using Microsoft.Extensions.Options;

namespace GarageMVC.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly GarageMVCContext _context;
        private readonly IOptions<PriceSettings> priceSettings;
        private readonly IOptions<GarageSettings> garageSettings;
        private readonly IMapper mapper;

        public VehiclesController(GarageMVCContext context, IMapper mapper, IOptions<PriceSettings> priceSettings, IOptions<GarageSettings> garageSettings)
        {
            _context = context;
            this.priceSettings = priceSettings;
            this.garageSettings = garageSettings;
            this.mapper = mapper;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            var list = await _context.Vehicles.ToListAsync();
            var indexList = list.Select(v => 
            new VehicleIndexViewModel 
            { 
                Id = v.Id,
                UserName = _context.Members.FirstOrDefaultAsync(m => m.Id == v.MemberId).Result.UserName,
                VehicleType = _context.VehicleType2s.FirstOrDefaultAsync(t => t.Id == v.VehicleType2Id).Result.Name,
                LicenceNr = v.LicenceNr,
                ParkedHours = Convert.ToInt32((DateTime.Now - v.ArrivalTime).TotalHours)
            });

            return View(indexList.ToList());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            // SelectListItem binda till VehicleType2.Name
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleAddViewModel viewModel)
        {
            
            if (ModelState.IsValid)
            {

                var vehicle = mapper.Map<Vehicle>(viewModel);
                vehicle.ArrivalTime = DateTime.Now;

                _context.Add(vehicle);
                await _context.SaveChangesAsync();

                // Try to park this vehicle
                var v = _context.Vehicles.Where(v => v.LicenceNr == viewModel.LicenceNr).Single();
                var result1 = ParkVehicle(v);
                // We now have a success-flag and a message (in result1)

                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LicenceNr,Color,Brand,Model,NrOfWheels,ArrivalTime")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Parking()
        {
            var vTypes = _context.VehicleType2s.ToList();
            var model = new Parking();
            var parked = _context.Spots.Include(s => s.Vehicle).OrderBy(s => s.SpotNr);
            var spotList = new List<SpotDto>();
            var lastVehicleId = -1;
            for(int i=0; i<garageSettings.Value.Size; i++)
            {
                var spot = parked.Where(x => x.SpotNr == i).SingleOrDefault();
                if (spot != null) 
                {
                    if(spot.VehicleId != lastVehicleId)
                    {
                        VehicleType2 vType = vTypes.Where(v => v.Id == spot.Vehicle.VehicleType2Id).Single();
                        spotList.Add(new SpotDto(i, vType.Size, vType.Name));
                        lastVehicleId = spot.VehicleId.Value;
                    }
                    else
                    {
                        spotList.Add(new SpotDto(i, 0, null));
                    }
                }
                else
                {
                    spotList.Add(new SpotDto(i, 0, "free"));
                }
            }
            model.Spots = spotList.ToArray();
            return View(model);
        }
        public async Task<IActionResult> Search()
        {
            var list = await _context.Vehicles.Include(v => v.VehicleType2).ToListAsync();
            var simpleList = list.Select(v =>
                new Vehicle
                {
                    Id = v.Id,
                    //VehicleType = v.VehicleType2.Name.ToString(),
                    LicenceNr = v.LicenceNr,
                    ArrivalTime = v.ArrivalTime,
                });
            return View(simpleList.ToList());
        }

        public async Task<IActionResult> Filter(string licenseNrContains)
        {
            var filteredVehicles = (string.IsNullOrWhiteSpace(licenseNrContains)) ?
                _context.Vehicles.Include(v => v.VehicleType2) :
                _context.Vehicles.Include(v => v.VehicleType2)
                                 .Where(v => v.LicenceNr.Contains(licenseNrContains));

            var filteredSimpleVehicles = filteredVehicles
                .Select(v => new Vehicle
                {
                    Id = v.Id,
                    VehicleType2Id = v.VehicleType2Id,
                    LicenceNr = v.LicenceNr,
                    ArrivalTime = v.ArrivalTime,
                });

            var model = await filteredSimpleVehicles.ToListAsync();

            return View(nameof(Search), model);
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }


        public async Task<IActionResult> Receipt(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
            {
                return NotFound();
            }

            var member = await _context.Members.FirstOrDefaultAsync(m => m.Id == vehicle.MemberId);

            if (member == null)
            {
                return NotFound();
            }

            var type = await _context.VehicleType2s.FirstOrDefaultAsync(t => t.Id == vehicle.VehicleType2Id);

            var receipt = mapper.Map<ReceiptViewModel>(vehicle);

            receipt.UserName = member.UserName;
            receipt.DepartureTime = DateTime.Now;
            receipt.ParkedHours = Convert.ToInt32((DateTime.Now - vehicle.ArrivalTime).TotalHours);
            receipt.Price = priceSettings.Value.Price * Convert.ToInt32((DateTime.Now - vehicle.ArrivalTime).TotalHours) * type.Size;
            
            // Use Linq and StringBuilder to pass a string with all the parkingspots that the vehicle occupies.
            var spotlist = _context.Spots.Where(s => s.VehicleId == vehicle.Id).Select(s => s.SpotNr).ToList();
            var sb = new StringBuilder();
            sb.Append($"{spotlist[0]}");

            if (spotlist.Count > 1)
            {
                foreach (var item in spotlist.Skip(1))
                {
                    sb.Append($", {item}");
                }
            }
            receipt.SpotNr =  sb.ToString();

            var result = UnparkVehicle(vehicle);

            if (result.Success)
            {
                return View(receipt);
            }


            //_context.Vehicles.Remove(vehicle);
            //await _context.SaveChangesAsync();

            Console.WriteLine($"{result.Message}");

            return NotFound();
        }

        // Returns true only if the vehicle is parked in the garage
        private bool VehicleIsParked(int id)
        {
            return _context.Spots.Any(s => s.Vehicle.Id == id);
        }

        // Returns first index of first free parking slot
        // that has enough number of free adjoining slots
        // for the vehicle type to fit.
        private int? GetFreeSpot(Vehicle vehicle)
        {
            int maxGarageSize = garageSettings.Value.Size;

            int width = _context.VehicleType2s
                        .Where(v => v.Id == vehicle.VehicleType2Id)
                        .Single().Size;

            var parked = _context.Spots
                         .OrderBy(s => s.SpotNr)
                         .Select(s => s.SpotNr)
                         .ToList();

            parked.Add(maxGarageSize); // add garage wall as a "taken spot"

            var testSpot = 0;
            foreach(var parkedSpot in parked)
            {
                if((parkedSpot - testSpot) >= width)
                {
                    return testSpot; // found enough free spots in a row
                }
                testSpot = parkedSpot + 1;
            }
            return null; // no space found
        }

        private GarageResult ParkVehicle(Vehicle vehicle)
        {
            var vType = _context.VehicleType2s
                        .Where(v => v.Id == vehicle.VehicleType2Id)
                        .Single();

            var spot = GetFreeSpot(vehicle);
            if (spot == null)
            {
                return new GarageResult(false, $"{vType.Name} cannot be parked! No more room in the garage.");
            }

            // Park the vehicle
            for (int i = 0; i < vType.Size; i++)
            {
                _context.Spots.Add(new Models.Entities.Spot()
                {
                    SpotNr = spot.Value + i,
                    VehicleId = vehicle.Id
                });
            }
            _context.SaveChanges();
            return new GarageResult(true, "Vehicle parked successfully!");
        }

        public async Task<IActionResult> Statistics()
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            var types = await _context.VehicleType2s.ToListAsync();

            var model = new ViewModels.Statistics();
            var createdVehicleStats = new Dictionary<string, int>();

            foreach(var type in types)
            {
                var nrOf = vehicles.Count(v => v.VehicleType2Id == type.Id);
                createdVehicleStats.Add(type.Name, nrOf);
            }

            model.NrOfCreatedVehicles = createdVehicleStats;

            model.TotalNrOfWheels = vehicles.Sum(v => v.NrOfWheels);

            var now = DateTime.Now;
            var totalHours = vehicles.Sum(v => Convert.ToInt32((now - v.ArrivalTime).TotalHours));

            return View(model);
        }

        private GarageResult UnparkVehicle(Vehicle vehicle)
        {
            if (VehicleIsParked(vehicle.Id))
            {
                var range = _context.Spots.Where(s => s.VehicleId == vehicle.Id);
                _context.Spots.RemoveRange(range);
                _context.SaveChanges();

                return new GarageResult(true, $"Vehicle {vehicle.LicenceNr} was unparked successfully!");
            }
            return new GarageResult(false, "Cannot find that vehicle in the garage!");
        }

        public IActionResult LPCreated()
        {
            // This checks if they want to park the vehicle after it has been created
            return View();
        }
    }
}
