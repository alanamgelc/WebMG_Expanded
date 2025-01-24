using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;
using System.Drawing;
using WebMG.Data;
using MG.Models;
using MGWeb.Areas.Public.ViewModels;

namespace MGWeb.Areas.Public.Controllers
{
    [Area("Public")]
    public class AttendCardController : Controller
    {
        private readonly MGDbContext _context;

        public AttendCardController(MGDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            //     var attendCards = await _context.AttendCards
            //.Include(ac => ac.Stu) // Assumes AttendCard has a Stu navigation property
            //.ToListAsync();

            //     return View(attendCards);
            var today = DateTime.Today; // Today's date without the time portion
            var attendCards = await _context.AttendCards
                .Include(ac => ac.Stu) // Include student data
                .Where(ac => ac.TimeIn >= today) // Filter for entries from today
                .ToListAsync();

            return View(attendCards);
        }
        public IActionResult Class()
        {


            var model = new ClassWStusViewModel
            {
                AttendCards = _context.AttendCards.Include(ac => ac.Stu).ToList()
            };
            return View(model);
        }
        public IActionResult FilterByClassCategory(ClassWStusViewModel vM)
        {
            //var model = new ClassWStusViewModel
            //{
            //    ClassCategories = Enum.GetValues(typeof(ClassCategory))
            // .Cast<ClassCategory>()
            // .Select(c => new SelectListItem { Value = c.ToString(), Text = c.ToString() })
            // .ToList(),
            //    AttendCards = selectedCategory.HasValue
            // ? _context.AttendCards.Include(ac => ac.Stu)
            //     .Where(ac => ac.Stu.ClassCategory == selectedCategory.Value)
            //     .ToList()
            // : _context.AttendCards.Include(ac => ac.Stu).ToList()
            //};
            if (vM.SelectedClassCategory.HasValue)
            {
                vM.AttendCards = _context.AttendCards
                    .Where(ac => ac.Stu.ClassCategory == vM.SelectedClassCategory)
                    .ToList();
            }
            else
            {
                vM.AttendCards = new List<AttendCard>();
            }

            return View("Class", vM);
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.getSs = _context.Stus.ToList();
            ViewBag.getPs = _context.Pars.ToList();
            ViewBag.getEs = _context.Emps.ToList();
            return View();

        }
        public IActionResult AddTime()
        {
            var model = new FamilyStudentViewModel
            {
                Families = _context.Fams.Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = f.Name
                }).ToList()

            };
            ViewBag.getEs = _context.Emps.ToList();

            return View(model);
        }
        public async Task<IActionResult> CreateAttendCard()
        {
            //var employees  = await _context.Emps.ToListAsync();

            //var model = new AttendCardVM
            //{
            //    Families = _context.Fams.Select(f => new SelectListItem
            //    {
            //        Value = f.Id.ToString(),
            //        Text = f.Name
            //    }).ToList()

            //};

            //ViewBag.getEs = employees;
            //return View(model);

            var model = new AttendCardVM();

            // Fetch families asynchronously
            var families = await _context.Fams.ToListAsync();
            model.Families = families.Select(f => new SelectListItem
            {
                Value = f.Id.ToString(),
                Text = f.Name
            }).ToList();

            // Fetch employees asynchronously
            var employees = await _context.Emps.ToListAsync();
            ViewBag.getEs = employees.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Name
            }).ToList();

            return View(model); // Pass the view model to the view
        }
        [HttpPost]
        public async Task<IActionResult> AddTime(FamilyStudentViewModel addACRequest)
        {
            var model = new FamilyStudentViewModel
            {
                Families = _context.Fams.Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = f.Name
                }).ToList()

            };
            ViewBag.getEs = _context.Emps.ToList();


            var ac = new AttendCard()
            {
                SchoolDay = addACRequest.SchoolDay,
                TimeIn = addACRequest.TimeIn,
                IsPresent = addACRequest.IsPresent,
                StuId = addACRequest.StuId,
                ParId = addACRequest.ParId,
                EmpId = addACRequest.EmpId,
                Notes = addACRequest.Notes
            };
            await _context.AttendCards.AddAsync(ac);
            await _context.SaveChangesAsync();
            return RedirectToAction("AddTime");



        }

        public async Task<IActionResult> Add(AddAttendCardVM addACRequest)
        {//this worked!!!
            var ac = new AttendCard()
            {
                SchoolDay = addACRequest.SchoolDay,
                TimeIn = addACRequest.TimeIn,
                IsPresent = addACRequest.IsPresent,
                StuId = addACRequest.StuId,
                ParId = addACRequest.ParId,
                EmpId = addACRequest.EmpId,
                Notes = addACRequest.Notes
            };
            await _context.AttendCards.AddAsync(ac);
            await _context.SaveChangesAsync();
            return RedirectToAction("Add");
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAttendCard(AttendCardVM viewModel)
        {
            if (ModelState.IsValid)
            {
                // Map ViewModel to Domain Model (AttendCard)
                var attendCard = new AttendCard
                {
                    StuId = viewModel.StuId,
                    EmpId = viewModel.EmpId,
                    ParId = viewModel.ParId,
                    SchoolDay = viewModel.SchoolDay,
                    TimeIn = viewModel.TimeIn,
                    //TimeOut = viewModel.TimeOut,
                    IsPresent = viewModel.IsPresent,
                    Notes = viewModel.Notes
                };

                // Add the AttendCard to the database
                _context.AttendCards.Add(attendCard);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            // Reload dropdown data in case of validation failure
            viewModel.Families = _context.Fams.Select(f => new SelectListItem
            {
                Value = f.Id.ToString(),
                Text = f.Name
            }).ToList();

            viewModel.Students = _context.Stus.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.FName
            }).ToList();

            viewModel.Parents = _context.Pars.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Par1
            }).ToList();

            //viewModel.Employees = _context.Emps.Select(e => new SelectListItem
            //{
            //    Value = e.Id.ToString(),
            //    Text = e.Name
            //}).ToList();
            // Fetch employees asynchronously
            var employees = _context.Emps.ToList();
            ViewBag.getEs = employees.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Name
            }).ToList();

            // Return the view with the view model if validation fails
            return View(viewModel);
        }

        public JsonResult GetStudents(int FamilyId)
        {
            var students = _context.Stus
                .Where(s => s.FamId == FamilyId) // Assuming Stu has a FamId property
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.FName // or any other relevant property
                })
                .ToList();
            return Json(students);
        }

        public JsonResult GetParents(int familyId)
        {


            var parents = _context.Pars
                .Where(p => _context.Fams.Any(f => f.ParId == p.Id && f.Id == familyId))
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Par1 + p.Par2 + p.Emg,

                })

                .ToList();
            return Json(parents);
        }

        public IActionResult Create2(AttendCard ac)
        {
            _context.AttendCards.Add(ac);
            _context.SaveChanges();
            ModelState.Clear();
            ViewBag.sucess = "Attendance has been added.";
            return RedirectToAction("Index");
        }
        public IActionResult Create3(FamilyStudentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Map or Convert DTO to Domain Model
                var attendCard = new AttendCard
                {
                    StuId = viewModel.StuId,
                    EmpId = viewModel.EmpId,
                    ParId = viewModel.ParId,
                    SchoolDay = viewModel.SchoolDay,
                    TimeIn = viewModel.TimeIn,
                    TimeOut = viewModel.TimeOut,
                    IsPresent = viewModel.IsPresent,
                    Notes = viewModel.Notes
                };
                // Add the new AttendCard to the database
                _context.AttendCards.Add(attendCard);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Index);
        }

    }






}
