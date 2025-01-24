using MG.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MGWeb.Areas.Public.ViewModels
{
    public class ClassWStusViewModel
    {
        public ClassCategory? SelectedClassCategory { get; set; }
        public List<SelectListItem> ClassCategories { get; set; } = new List<SelectListItem>();

        public List<Stu> Stus { get; set; } = new List<Stu>();
        public List<AttendCard> AttendCards { get; set; } = new List<AttendCard>();
    }
}
