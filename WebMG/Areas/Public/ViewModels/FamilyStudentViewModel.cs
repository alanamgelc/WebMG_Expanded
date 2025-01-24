using MG.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace MGWeb.Areas.Public.ViewModels
{
    public class FamilyStudentViewModel
    {
        public int SelectedFamilyId { get; set; }
        public int SelectedStudentId { get; set; }

        public int? SelectedParentId { get; set; }

        public int SelectedEmployeeId { get; set; }
        public List<SelectListItem> Families { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Students { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> Parents { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> Employees { get; set; } = new List<SelectListItem>();


        public DateOnly SchoolDay { get; set; }

        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }

        public bool IsPresent { get; set; }


        public int StuId { get; set; }

        public Stu Stu { get; set; }


        public int? ParId { get; set; }
        public Par? Par { get; set; }



        public int EmpId { get; set; }
        public Emp Emp { get; set; }
        //this really will function as an absent reason
        public string Notes { get; set; }

        public AttendCard AttendCard { get; set; } // This holds the form data

    }
}
