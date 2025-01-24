
using MG.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MGWeb.Areas.Public.ViewModels
{
    public class FamStuViewModel
    {
        public List<int> SelectedFamIds { get; set; } = new List<int>();  // List of selected family IDs

        //  public int SelectedFamId { get; set; } // This will store the selected family ID from the dropdown
        public ClassCategory? SelectedClassCategory { get; set; }  // Nullable to allow no selection initially

        public List<Fam> Fams { get; set; }
        public List<Stu> Stus { get; set; }


    }
}
