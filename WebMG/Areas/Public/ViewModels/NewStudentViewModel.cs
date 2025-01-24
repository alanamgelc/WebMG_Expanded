using MG.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MGWeb.Areas.Public.ViewModels
{
    public class NewStudentViewModel
    {
        public int Id { get; set; } //apparently this can represent the familyid

        public string? FName { get; set; }
        public string? LName { get; set; }

        // public int FamId { get; set; }

        public DateOnly? DOB { get; set; }

        public ClassCategory? ClassCategory { get; set; }

        public bool? Active { get; set; }

    }
}
