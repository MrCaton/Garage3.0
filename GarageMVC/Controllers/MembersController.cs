using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageMVC.Data;
using GarageMVC.ViewModels;
using GarageMVC.Models;
using GarageMVC.Models.Entities;
using AutoMapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;

namespace GarageMVC.Controllers
{
    public class MembersController : Controller
    {
        private readonly GarageMVCContext _context;
        private readonly IMapper mapper;
        public MembersController(GarageMVCContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: Members
        public async Task<IActionResult> Index(string input)
        {
            var member = string.IsNullOrWhiteSpace(input) ?
                _context.Members :
                _context.Members.Where(v => v.UserName.StartsWith(input.ToUpper()));

            var vehicles = await _context.ParkedVehicle.ToListAsync();
            var model = member.Select(o => MemberVehicle(o, vehicles));
            return View(await _context.Members.ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }
            var model = new Member
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                UserName = member.UserName,
                Email = member.Email,
                Vehicles = member.Vehicles
                //Vehicles = await _context.ParkedVehicle.Where(o => o.Id == member.Id).ToListAsync()
            };

            return View(model);
            //return View(member);

        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Member member)
        {
            bool EmailExists = _context.Members.Any
                (v => v.Email == member.Email);
            bool UserExists = _context.Members.Any
                (v => v.UserName == member.UserName);
            if (EmailExists)
            {
                ModelState.AddModelError("Email", "Email already exists");
            }
            else if (UserExists)
            {
                ModelState.AddModelError("UserName", "User name already exists");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _context.Add(member);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
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
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Members.FindAsync(id);
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.Id == id);
        }

        static public VehicleMember MemberVehicle(Member member, IEnumerable<ParkedVehicle> vehicles)
        {
            return new VehicleMember
            {
                VehicleId = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                UserName = member.UserName,
                VehicleCount = vehicles.Where(v => v.Id == member.Id).Count()
            };
        }
        public async Task<IActionResult> Profile(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           var profile = await _context.Members
                .Include(m => m.Vehicles)
                .Select(m => new ProfileViewModel
                {
                    Id = m.Id,
                    UserName = m.UserName,
                    Vehicles = m.Vehicles
                })
                .FirstOrDefaultAsync(m => m.Id == id);
           
            


            return View(profile);
        }

    }
}
