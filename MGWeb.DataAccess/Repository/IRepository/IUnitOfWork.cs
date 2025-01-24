using MG.DataAccess.Repository.IRepository;
using ICenterRepository = MG.DataAccess.Repository.IRepository.ICenterRepository;

namespace MGWeb.Interfaces
{
    public interface IUnitOfWork
    {
        ICenterRepository Center { get; }
        //  IApplicationUserRepository ApplicationUser { get; }
        void Save();
    }
}
