using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MG.Models
{


    public class Stu
    {
        [Key]
        public int Id { get; set; }

        // Required fields
        public string? FName { get; set; }
        public string? LName { get; set; }

        public int FamId { get; set; }

        // Foreign key to Family (Fam)
        [ForeignKey("FamId")]
        public virtual Fam Fam { get; set; }

        // Date of birth
        public DateOnly? DOB { get; set; }

        // Class category
        public ClassCategory? ClassCategory { get; set; }

        // One-to-many relationship: A student has many attendance cards
        public ICollection<AttendCard> AttendCards { get; set; } = new List<AttendCard>();

        // Optional status and disenrollment date
        public bool Active { get; set; }
        public DateOnly? Disenroll { get; set; }

    }


}
