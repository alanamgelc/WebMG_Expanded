using MG.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MGWeb.Areas.Public.ViewModels
{
    public class UpdateTimeCardVM
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public string? Notes { get; set; }

        public TimeCategory TimeCategory { get; set; }


        public int EmpId { get; set; }

    }
}
