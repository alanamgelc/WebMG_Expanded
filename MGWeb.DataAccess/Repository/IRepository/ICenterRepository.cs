using MG.Models;
using MGWeb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.DataAccess.Repository.IRepository
{
    public interface ICenterRepository: IRepository<Center>
    {
        void Update(Center obj);
        // void Save();
    }
}
