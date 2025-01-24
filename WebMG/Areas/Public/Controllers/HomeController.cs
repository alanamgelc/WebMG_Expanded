using MG.Models;
using MGWeb.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebMG.Data;

namespace MGWeb.Areas.Public.Controllers
{
    [Area("Public")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MGDbContext _context;

        public HomeController(ILogger<HomeController> logger, MGDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //var fams= _context.Fams.ToList();
            //var stus= _context.Stus.ToList();

            //var viewModel = new FamStuViewModel
            //{
            //    Fams = fams,
            //    Stus = stus
            //};
            //return View(viewModel);

            var viewModel = new FamStuViewModel
            {
                Fams = _context.Fams.ToList(),
                Stus = new List<Stu>() // Empty list initially
            };

            return View(viewModel);
        }



        public IActionResult GetStudents(List<int> famIds, List<int> stuIds)
        {

            var students = _context.Stus
                .Where(p => famIds.Contains(p.FamId) && stuIds.Contains(p.Id))
                .ToList();

            return Ok(students);
        }

        [HttpPost]
        //i dont understand partial views yet
        //public IActionResult GetFilteredStus(int[] famIds)
        //{
        //    var students= _context.Stus
        //        .Where(p=> famIds.Contains(p.FamId))
        //        .ToList();

        //    return PartialView("_StudentList", students);
        //}


        public IActionResult FilterByClassCategory(FamStuViewModel viewModel)
        {
            // Filter students based on selected class category
            if (viewModel.SelectedClassCategory.HasValue)
            {
                viewModel.Stus = _context.Stus
                    .Where(s => s.ClassCategory == viewModel.SelectedClassCategory)
                    .ToList();
            }
            else
            {
                viewModel.Stus = new List<Stu>(); // No students if no category selected
            }

            return View("Index", viewModel); // Return to the same view with the filtered students
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
