using MG.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MGWeb.Areas.Public.ViewModels
{
    public class FamWithStuVM
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public int Size { get; set; }

        public required string Par1 { get; set; }
        public string? Par2 { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public int Pin { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }

        public DateOnly? DOB { get; set; }

        public ClassCategory? ClassCategory { get; set; }

        public bool? Active { get; set; }
    }
}
