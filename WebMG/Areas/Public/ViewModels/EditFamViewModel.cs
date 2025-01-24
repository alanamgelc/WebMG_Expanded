using MG.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MGWeb.Areas.Public.ViewModels
{
    public class EditFamViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }

        //i dont understand this
        public Stu Stu { get; set; }

        //i dont understand this
        public Par Par { get; set; }

    }
}
