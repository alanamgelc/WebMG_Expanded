using MG.Models;
using MGWeb.Areas.Public.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebMG.Data;

namespace MGWeb.Areas.Public.Controllers
{
    [Area("Public")]
    public class StuController : Controller
    {
        private readonly MGDbContext _context;
        private readonly IStuRepository _stuRepository;
        private readonly IFamRepository _famRepository;

        public StuController(MGDbContext context, IStuRepository stuRepository, IFamRepository famRepository)
        {
            _context = context;
            _stuRepository = stuRepository;
            _famRepository = famRepository;
        }
        public IActionResult Index()
        {
            var stus = _context.Stus.ToList();
            return View(stus);

        }

        public IActionResult addStu()
        {
            ViewBag.getFam = _context.Fams.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult addStu(Stu s)
        {
            _context.Stus.Add(s);
            _context.SaveChanges();
            ModelState.Clear();
            ViewBag.sucess = "Student has been added.";
            return RedirectToAction("Index");
        }
    }
}
