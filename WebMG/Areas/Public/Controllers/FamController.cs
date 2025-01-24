using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebMG.Data;
using WebMG.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using MG.Models;
using MGWeb.Areas.Public.Interfaces;
using MGWeb.Areas.Public.ViewModels;

namespace MGWeb.Areas.Public.Controllers
{
    [Area("Public")]
    public class FamController : Controller
    {
        private readonly MGDbContext _context;
        private readonly IFamRepository _famRepository;
        private readonly IStuRepository _stuRepository;

        public FamController(MGDbContext context, IFamRepository famRepository, IStuRepository stuRepository)
        {
            _context = context;
            _famRepository = famRepository;
            _stuRepository = stuRepository;
        }

        public IActionResult Index()
        {
            //var fams = _context.Fams.ToList();
            //return View(fams);
            var viewModel = new FamStuViewModel
            {
                Fams = _context.Fams.ToList(),
                Stus = new List<Stu>() // Empty list initially
            };

            return View(viewModel);
        }

        //public IActionResult FilterByFam(FamStuViewModel viewModel)
        //{
        //    // Retrieve the filtered students based on the selected family ID
        //    viewModel.Fams = _context.Fams.ToList();
        //    viewModel.Stus = _context.Stus
        //        .Where(s => s.FamId == viewModel.SelectedFamId)
        //        .ToList();

        //    return View("Index", viewModel); // Return to the same view with filtered students
        //}
        [HttpPost]
        public IActionResult FilterByFamilies(FamStuViewModel viewModel)
        {
            if (viewModel.SelectedFamIds.Any())
            {
                // Filter students based on selected family IDs
                viewModel.Stus = _context.Stus
                    .Where(s => viewModel.SelectedFamIds.Contains(s.FamId))
                    .ToList();
            }
            else
            {
                viewModel.Stus = new List<Stu>();  // No students if no families selected
            }

            // Fetch the families again to repopulate the checkboxes
            viewModel.Fams = _context.Fams.ToList();

            return View("Index", viewModel);
        }
        //public IActionResult Create()
        //{
        //    // You can pass any necessary data to the view (like dropdowns) here
        //    return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Fam fam)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Fams.Add(fam);
        //        _context.SaveChanges();
        //        return RedirectToAction(nameof(Index)); // Redirect to the index after creation
        //    }
        //    return View(fam); // Return the view with the model if validation fails
        //}

        public IActionResult addFam()
        {

            // ViewBag.getFam = _context.Fams.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult addFam(Fam s)
        {
            _context.Fams.Add(s);
            _context.SaveChanges();
            ModelState.Clear();
            ViewBag.sucess = "Family has been added.";
            return RedirectToAction("addStu", "Stu");
        }


    }
}
