using Microsoft.AspNetCore.Mvc.Rendering;

namespace MGWeb.Areas.Public.ViewModels
{
    public class AttendCardVM
    {
        public int StuId { get; set; }
        public int EmpId { get; set; }
        public int ParId { get; set; }
        public DateOnly SchoolDay { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public bool IsPresent { get; set; }
        public string? Notes { get; set; }

        // For Dropdowns

        public List<SelectListItem> Students { get; set; }
        public List<SelectListItem> Parents { get; set; }
        public List<SelectListItem> Employees { get; set; }
        public List<SelectListItem> Families { get; set; } = new List<SelectListItem>();
        public int SelectedFamilyId { get; set; }
        public int SelectedStudentId { get; set; }

        public int? SelectedParentId { get; set; }
        public int? SelectedEmployeeId { get; set; }
    }
}
