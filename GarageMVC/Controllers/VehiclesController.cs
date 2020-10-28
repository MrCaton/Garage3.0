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
using GarageMVC.Common;
using System.Net.WebSockets;
using Microsoft.Extensions.Options;

namespace GarageMVC.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly GarageMVCContext _context;
        private readonly IMapper mapper;
        private readonly IOptions<GarageSettings> garageSettings;

        public VehiclesController(GarageMVCContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehicles.ToListAsync());
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

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
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

            parked.Add(maxGarageSize); // add garage wall as a "parking spot"

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
                _context.Spots.Add(new Spot()
                {
                    SpotNr = spot.Value + i,
                    VehicleId = vehicle.Id
                });
            }
            _context.SaveChanges();
            return new GarageResult(true, "Vehicle parked successfully!");
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
    }
}
