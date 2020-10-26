using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageMVC.Data;
using GarageMVC.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using GarageMVC.ViewModels;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.EntityFrameworkCore.Internal;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using System.Text;

namespace GarageMVC.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private readonly GarageMVCContext _context;
        private readonly IOptions<PriceSettings> priceSettings;
        private readonly Dictionary<VehicleType, int> vehicleWidth;
        private readonly IOptions<GarageSettings> garageSettings;
        //private const int garageSize = 50;

        public ParkedVehiclesController(GarageMVCContext context, IOptions<PriceSettings> priceSettings, IOptions<GarageSettings> garageSettings)
        {
            _context = context;
            this.priceSettings = priceSettings;
            this.garageSettings = garageSettings;
            vehicleWidth = new Dictionary<VehicleType, int>
            {
                { VehicleType.Car, 1 },
                { VehicleType.Motorcycle, 1 },
                { VehicleType.Bus, 2 },
                { VehicleType.Airplane, 3 },
                { VehicleType.Boat, 3 }
            };
        }

        // GET: ParkedVehicles
        public async Task<IActionResult> Index()
        {
            var list = await _context.ParkedVehicle.ToListAsync();
            var simpleList = list.Select(v =>
                new SimpleVehicle
                {
                    Id = v.Id,
                    VehicleType = v.VehicleType.ToString(),
                    LicenceNr = v.LicenceNr,
                    ArrivalTime = v.ArrivalTime,
                    StartLocation = GetParkingSpots(v),
                    ParkedHours = Convert.ToInt32((DateTime.Now - v.ArrivalTime).TotalHours)
                });

            return View(simpleList.ToList());
        }

        // GET: ParkedVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public IActionResult Create()
        {
            ViewBag.VehicleSelect = GetVehicleTypeSelectList();
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(ParkedVehicle parkedVehicle)
        {
            bool LicenceNrExists = _context.ParkedVehicle.Any
                (v => v.LicenceNr == parkedVehicle.LicenceNr);
            if (LicenceNrExists)
            {
                ModelState.AddModelError("LicenceNr", "Licence number already exists");
            }
            else
            {
                var slotIndex = GetFreeSlot(parkedVehicle.VehicleType);
                if (slotIndex == null)
                {
                    ModelState.AddModelError("LicenceNr", "No free slots for vehicle type");
                }
                else
                {
                    parkedVehicle.StartLocation = slotIndex.Value;

                    parkedVehicle.ArrivalTime = DateTime.Now;
                    if (ModelState.IsValid)
                    {
                        _context.Add(parkedVehicle);
                        await _context.SaveChangesAsync();
                        //return RedirectToAction(nameof(Index));
                        return RedirectToAction(nameof(LandingPageCreate));
                    }
                }
            }
            return View(parkedVehicle);
        }

        public List<SelectListItem> GetVehicleTypeSelectList()
        {
            var selectList = new List<SelectListItem>();
            foreach (var v in Enum.GetValues(typeof(VehicleType)).Cast<VehicleType>())
            {
                bool isNotChoosable = (GetFreeSlot(v) == null);
                selectList.Add(new SelectListItem(v.ToString(), ((int)v).ToString(), false, isNotChoosable));
            }
            return selectList;
        }

        // GET: ParkedVehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Type,LicenceNr,Color,Brand,Model,NrOfWheels,ArrivalTime")] ParkedVehicle parkedVehicle)
        public async Task<IActionResult> Edit(int id, ParkedVehicle parkedVehicle)
        {
            if (id != parkedVehicle.Id)
            {
                return NotFound();
            }



            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkedVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkedVehicleExists(parkedVehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return RedirectToAction(nameof(LandingPageEdit));
            }
            return View(parkedVehicle);
        }

        public async Task<IActionResult> Receipt(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle.FirstOrDefaultAsync(m => m.Id == id);

            if (parkedVehicle == null)
            {
                return NotFound();
            }

            var receipt = new SimpleVehicle
            {
                Id = parkedVehicle.Id,
                VehicleType = parkedVehicle.VehicleType.ToString(),
                LicenceNr = parkedVehicle.LicenceNr,
                ArrivalTime = parkedVehicle.ArrivalTime,
                DepartureTime = DateTime.Now,
                ParkedHours = Convert.ToInt32((DateTime.Now - parkedVehicle.ArrivalTime).TotalHours),
                Price = priceSettings.Value.Price * Convert.ToInt32((DateTime.Now - parkedVehicle.ArrivalTime).TotalHours) * vehicleWidth[parkedVehicle.VehicleType],
                StartLocation = GetParkingSpots(parkedVehicle)
            };

            

            _context.ParkedVehicle.Remove(parkedVehicle);
            await _context.SaveChangesAsync();

            return View(receipt);
        }

        private bool ParkedVehicleExists(int id)
        {
            return _context.ParkedVehicle.Any(e => e.Id == id);
        }

        // GET: ParkedVehicles
        public async Task<IActionResult> Search()
        {
            var list = await _context.ParkedVehicle.ToListAsync();
            var simpleList = list.Select(v =>
                new SimpleVehicle
                {
                    Id = v.Id,
                    VehicleType = v.VehicleType.ToString(),
                    LicenceNr = v.LicenceNr,
                    ArrivalTime = v.ArrivalTime,
                    ParkedHours = Convert.ToInt32((DateTime.Now - v.ArrivalTime).TotalHours)
                });
            return View(simpleList.ToList());
        }

        public async Task<IActionResult> Filter(string licenseNrContains)
        {
            var filteredVehicles = (string.IsNullOrWhiteSpace(licenseNrContains)) ?
                _context.ParkedVehicle :
                _context.ParkedVehicle.Where(v => v.LicenceNr.Contains(licenseNrContains));

            var filteredSimpleVehicles = filteredVehicles
                .Select(v => new SimpleVehicle
                {
                    Id = v.Id,
                    VehicleType = v.VehicleType.ToString(),
                    LicenceNr = v.LicenceNr,
                    ArrivalTime = v.ArrivalTime,
                    ParkedHours = Convert.ToInt32((DateTime.Now - v.ArrivalTime).TotalHours)
                });

            var model = await filteredSimpleVehicles.ToListAsync();

            return View(nameof(Search), model);
        }

        public async Task<IActionResult> Statistics()
        {
            var vehicles = await _context.ParkedVehicle.ToListAsync();

            var model = new ViewModels.Statistics();
            model.ParkedCars = vehicles.Where(v => v.VehicleType == VehicleType.Car).Count();
            model.ParkedMotorcycles = vehicles.Where(v => v.VehicleType == VehicleType.Motorcycle).Count();
            model.ParkedBuses = vehicles.Where(v => v.VehicleType == VehicleType.Bus).Count();
            model.ParkedAirplanes = vehicles.Where(v => v.VehicleType == VehicleType.Airplane).Count();
            model.ParkedBoats = vehicles.Where(v => v.VehicleType == VehicleType.Boat).Count();

            model.TotalNrOfWheels = vehicles.Sum(v => v.NrOfWheels);

            var now = DateTime.Now;
            var totalHours = vehicles.Sum(v => Convert.ToInt32((now - v.ArrivalTime).TotalHours));
            var totalParkedSpots = GetGarage().Count(x => x != null);
            model.ParkingValuePending = totalHours * priceSettings.Value.Price * totalParkedSpots;

            return View(model);
        }

        // Returns first index of first free parking slot
        // that has enough number of free adjoining slots
        // for the vehicle type to fit.
        private int? GetFreeSlot(VehicleType type)
        {
            var width = vehicleWidth[type];
            int? index = null;
            var garage = GetGarage();
            int nulls = 0;
            for(int i=0; i < garage.Length; i++)
            {
                if (garage[i] == null)
                {
                    nulls++;
                    if (nulls == width)
                    {
                        index = i - width + 1;
                        break;
                    }
                }
                else
                {
                    nulls = 0;
                }
            }
            return index;
        }

        // Returns an array with nullable integers, representing
        // all the parking slots in the garage. Each slot will
        // either have the VehicleType of the parked vehicle,
        // or "null" if the slot is vacant.
        private int?[] GetGarage()
        {
            var garage = new int?[garageSettings.Value.Size];
            var vehicles = _context.ParkedVehicle.ToList();
            foreach (var v in vehicles)
            {
                for (int i = 0; i < vehicleWidth[v.VehicleType]; i++)
                {
                    garage[v.StartLocation + i] = (int)v.VehicleType;
                }
            }
            return garage;
        }
        



        public async Task<IActionResult> Parking()
        {
            var model = new Parking() ;
            model.FreeSlots = GetGarage();

            //if (model.FreeSlots == null)
            //{
            //    model.FreeSlots = "Empty";
            //}
                //var slotIndex = GetFreeSlot(parkedVehicle.VehicleType);
                //if (FreeSlots == null)
                //{
                //    parkedVehicle.FreeSlot = slotIndex.Value;
                //     if (ModelState.IsValid)
                //     {
                //        _context.Add(parkedVehicle);
                //        await _context.SaveChangesAsync();
                //        return RedirectToAction(nameof(Index));
                //     }
                //}


                return View(model);
        }
        




        private string GetParkingSpots(ParkedVehicle parkedVehicle)
        {
            var sb = new StringBuilder(parkedVehicle.StartLocation.ToString());

            for (int i = 1; i < vehicleWidth[parkedVehicle.VehicleType]; i++)
            {
                var next = parkedVehicle.StartLocation + i;
                sb.Append($", {next}");
            }

            return sb.ToString();
        }

        public async Task<IActionResult> LandingPageCreate()
        {
            return View();
        }

        public IActionResult LandingPageEdit()
        {
            return View();
        }
    }
}
