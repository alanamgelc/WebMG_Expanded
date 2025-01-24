using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MG.Models
{
    public class Emp
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool Teach { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        // One-to-many relationship: A student has many attendance cards
        public ICollection<AttendCard> AttendCards { get; set; } = new List<AttendCard>();
        // One-to-many relationship: A student has many attendance cards
        public ICollection<TimeCard> TimeCards { get; set; } = new List<TimeCard>();

        public int Pin { get; set; }

        public int? CenterId { get; set; }
        [ForeignKey("CenterId")]
        [ValidateNever]
        public Center? Center { get; set; }
    }
}
