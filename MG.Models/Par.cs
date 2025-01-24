using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MG.Models
{
    public class Par
    {
        [Key]
        public int Id { get; set; }
        public required string Par1 { get; set; }
        public string? Par2 { get; set; }

        public required string Emg { get; set; }
        public string? Emg1 { get; set; }
        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? EmgEmail { get; set; }

        public string EmgPhone { get; set; }


        public string? Emg1Email { get; set; }

        public string? Emg1Phone { get; set; }

        public int Pin { get; set; }

        // One-to-many relationship: A student has many attendance cards
        public ICollection<AttendCard> AttendCards { get; set; } = new List<AttendCard>();

        //[ForeignKey("Family")]
        //public required int FamId { get; set; }
    }
}
