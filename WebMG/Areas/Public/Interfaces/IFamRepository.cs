using MG.Models;
using Microsoft.EntityFrameworkCore;
using MG.DataAccess.Repository;

namespace MGWeb.Areas.Public.Interfaces
{
    public interface IFamRepository
    {
        //Task<IEnumerable<Fam>> GetAll();
        Task<Fam?> GetByIdAsync(int id);

        Task<Fam?> GetByIdAsyncNoTracking(int id);
        bool Add(Fam fam);

        bool Update(Fam fam);

        bool Delete(Fam fam);

        bool Save();

        Task<List<Stu>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
  string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000);

    }
}
