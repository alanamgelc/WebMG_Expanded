using MG.Models;
using MGWeb.Areas.Public.Interfaces;
using Microsoft.EntityFrameworkCore;
using MG.DataAccess.Repository;
using WebMG.Data;

namespace MGWeb.Areas.Public.Repository
{
    public class FamRepository : IFamRepository
    {
        private readonly MGDbContext _context;

        public FamRepository(MGDbContext context)
        {
            _context = context;
        }




        public bool Add(Fam fam)
        {
            _context.Add(fam);
            return Save();
        }

        public bool Delete(Fam fam)
        {
            _context.Remove(fam);
            return Save();
        }

        public Task<List<Stu>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            throw new NotImplementedException();
        }

        public async Task<Fam?> GetByIdAsync(int id)
        {
            return await _context.Fams.Include(i => i.Par).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Fam?> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Fams.Include(i => i.Par).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Fam fam)
        {
            _context.Update(fam);
            return Save();
        }





    }
}
