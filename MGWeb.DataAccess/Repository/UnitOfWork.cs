using MG.Models;
using MGWeb.Interfaces;
using WebMG.Data;
using WebMG.Repository;
using ICenterRepository = MG.DataAccess.Repository.IRepository.ICenterRepository;

namespace MGWeb.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private MGDbContext _db;
        public ICenterRepository Center { get; private set; }
        public UnitOfWork(MGDbContext db)
        {
            _db = db;
            Center = new CenterRepository(_db);
            // ApplicationUser = new ApplicationUserRepository(_db);
        }

        // public IApplicationUserRepository ApplicationUser { get; private set; }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
