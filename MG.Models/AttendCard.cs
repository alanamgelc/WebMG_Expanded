using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MG.Models
{
    public class AttendCard
    {
        [Key]
        public int Id { get; set; }
        //date is required
        public DateOnly SchoolDay { get; set; }
        //timein and out might not apply if this kid is absent
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        //this is required , there should be a record for every kid enrolled on every day of the school year
        public bool IsPresent { get; set; }

        //i want a drop down that only shows those Ss who arent check in yet
        [ForeignKey("Stu")]
        public int StuId { get; set; }

        public Stu Stu { get; set; }

        //this is optional bc if the kid is absent, the teacher will mark them as such 
        [ForeignKey("Par")]
        public int? ParId { get; set; }
        public Par? Par { get; set; }


        [ForeignKey("Emp")]

        //this is required bc Teacher has to intake them or mark absent w/ a reason

        public int? EmpId { get; set; }
        public Emp? Emp { get; set; }
        //this really will function as an absent reason
        public string? Notes { get; set; }
    }
}
