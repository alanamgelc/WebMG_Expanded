using MG.DataAccess.Repository.IRepository;
using MG.Models;
using MGWeb.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMG.Data;
using WebMG.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MGWeb.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CenterController : Controller
    {
        //  private readonly MGDbContext _db;
        // private readonly ICenterRepository _centerRepo;

        private readonly IUnitOfWork _unitOfWork;
        public CenterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public CenterController(ICenterRepository db)
        //{
        //    _centerRepo = db;
        //}
        public IActionResult Index()
        {
            // List<Center> objCenterList = _unitOfWork.Centers.GetAll().ToList();
            //return View(objCenterList);
            List<Center> objCenterList = _unitOfWork.Center.GetAll().ToList();
            return View(objCenterList);
        }
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //public IActionResult Upsert(int? id)
        //{

        //    if (id == null || id == 0)
        //    {
        //        //create
        //        return View(new Center());
        //    }
        //    else
        //    {
        //        //update
        //        Center centerObj = _unitOfWork.Center.Get(u => u.Id == id);
        //        return View(centerObj);
        //    }
        //}
        //[HttpPost]
        //public IActionResult Upsert(Center CenterObj)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        if (CenterObj.Id == 0)
        //        {
        //            _unitOfWork.Center.Add(CenterObj);
        //        }
        //        else
        //        {
        //            _unitOfWork.Center.Update(CenterObj);
        //        }

        //        _unitOfWork.Save();
        //        TempData["success"] = "Company created successfully";
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {

        //        return View(CenterObj);
        //    }
        //}
        //public IActionResult Create(Center obj)
        //{
        //    if (obj.Name == obj.DisplayOrder.ToString())
        //    {
        //        ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Center.Add(obj);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Center created successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View();

        //}
        ////public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Center? centerFromDb = _unitOfWork.Center.Get(u => u.Id == id);
        //    //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
        //    //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

        //    if (centerFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(centerFromDb);
        //}

        //[HttpPost]
        //public IActionResult Edit(Center obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Center.Update(obj);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Center updated successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View();

        //}

        //  [HttpPost, ActionName("Delete")]
        //public IActionResult DeletePOST(int? id)
        //{
        //    Center? obj = _unitOfWork.Center.Get(u => u.Id == id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.Center.Remove(obj);
        //    _unitOfWork.Save();
        //    TempData["success"] = "Center deleted successfully";
        //    return RedirectToAction("Index");
        //}
        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Center> objCompanyList = _unitOfWork.Center.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }
        #endregion

    }
}
