using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MG.Models
{
    public class Fam
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Size { get; set; }

        public ICollection<Stu> Stus { get; set; }

        [ForeignKey("Parent")]
        public int ParId { get; set; }
        public required Par Par { get; set; }

    }

}
