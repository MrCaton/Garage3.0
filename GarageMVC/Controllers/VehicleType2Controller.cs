using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageMVC.Data;
using GarageMVC.Models.Entities;

namespace GarageMVC.Controllers
{
    public class VehicleType2Controller : Controller
    {
        private readonly GarageMVCContext _context;

        public VehicleType2Controller(GarageMVCContext context)
        {
            _context = context;
        }

        // GET: VehicleType2
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleType2s.ToListAsync());
        }

        // GET: VehicleType2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleType2 = await _context.VehicleType2s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleType2 == null)
            {
                return NotFound();
            }

            return View(vehicleType2);
        }

        // GET: VehicleType2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleType2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Size")] VehicleType2 vehicleType2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleType2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleType2);
        }

        // GET: VehicleType2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleType2 = await _context.VehicleType2s.FindAsync(id);
            if (vehicleType2 == null)
            {
                return NotFound();
            }
            return View(vehicleType2);
        }

        // POST: VehicleType2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Size")] VehicleType2 vehicleType2)
        {
            if (id != vehicleType2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleType2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleType2Exists(vehicleType2.Id))
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
            return View(vehicleType2);
        }

        // GET: VehicleType2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleType2 = await _context.VehicleType2s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleType2 == null)
            {
                return NotFound();
            }

            return View(vehicleType2);
        }

        // POST: VehicleType2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleType2 = await _context.VehicleType2s.FindAsync(id);
            _context.VehicleType2s.Remove(vehicleType2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleType2Exists(int id)
        {
            return _context.VehicleType2s.Any(e => e.Id == id);
        }
    }
}
