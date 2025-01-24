using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMG.Data;
using WebMG.Migrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MG.Models;
using MG.DataAccess.Repository.IRepository;
using MGWeb.Areas.Public.ViewModels;

namespace MGWeb.Areas.Public.Controllers
{
    [Area("Public")]
    public class TimeCardsController : Controller
    {
        private readonly MGDbContext _context;



        public TimeCardsController(MGDbContext context)
        {
            _context = context;

        }

        // GET: TimeCards
        public IActionResult Index()
        {
            var atts = _context.TimeCards.Include(tc => tc.Emp).ToList();
            return View(atts);


        }

        // GET: TimeCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeCard = await _context.TimeCards
                .Include(t => t.Emp)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeCard == null)
            {
                return NotFound();
            }

            return View(timeCard);
        }

        // GET: TimeCards/Create
        public IActionResult Create()
        {
            ViewBag.getEs = _context.Emps.ToList();
            return View();
        }

        // POST: TimeCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Create(TimeCard ac)
        {
            _context.TimeCards.Add(ac);
            _context.SaveChanges();
            ModelState.Clear();
            ViewBag.sucess = "Timesheet has been added.";
            return RedirectToAction("Index");
        }

        // GET: TimeCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var timeCard = await _context.TimeCards.FindAsync(id);
            //if (timeCard == null)
            //{
            //    return NotFound();
            //}
            //ViewData["EmpId"] = new SelectList(_context.Emps, "Id", "Id", timeCard.EmpId);
            //return View(timeCard);
            var tc = await _context.TimeCards.FirstOrDefaultAsync(x => x.Id == id);
            if (tc != null)
            {
                var viewModel = new UpdateTimeCardVM()
                {
                    Id = tc.Id,
                    Start = tc.Start,
                    Finish = tc.Finish,
                    Notes = tc.Notes,
                    TimeCategory = tc.TimeCategory,
                    EmpId = tc.EmpId
                };
                return View(viewModel);
            }
            return RedirectToAction("Index");
        }

        // POST: TimeCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateTimeCardVM model)
        {
            var tc = await _context.TimeCards.FindAsync(model.Id);
            if (tc != null)
            {

                tc.Start = model.Start;
                tc.Finish = model.Finish;
                tc.Notes = model.Notes;
                tc.TimeCategory = model.TimeCategory;
                // tc.EmpId = model.EmpId;

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: TimeCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeCard = await _context.TimeCards
                .Include(t => t.Emp)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeCard == null)
            {
                return NotFound();
            }

            return View(timeCard);
        }

        // POST: TimeCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeCard = await _context.TimeCards.FindAsync(id);
            if (timeCard != null)
            {
                _context.TimeCards.Remove(timeCard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeCardExists(int id)
        {
            return _context.TimeCards.Any(e => e.Id == id);
        }
    }
}
