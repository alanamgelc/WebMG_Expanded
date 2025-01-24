using System.ComponentModel.DataAnnotations.Schema;

namespace MG.Models
{
    public class TimeCard
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public string? Notes { get; set; }

        public TimeCategory TimeCategory { get; set; }

        [ForeignKey("Emp")]
        public int EmpId { get; set; }
        public required Emp Emp { get; set; }
    }
}
