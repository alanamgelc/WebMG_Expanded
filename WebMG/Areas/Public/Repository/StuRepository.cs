using MG.Models;
using MGWeb.Areas.Public.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using WebMG.Data;

namespace MGWeb.Areas.Public.Repository
{
    public class StuRepository : IStuRepository
    {
        private readonly MGDbContext _context;

        public StuRepository(MGDbContext context)
        {
            _context = context;
        }
        public bool Add(Stu stu)
        {
            _context.Add(stu);
            return Save();
        }

        public bool Delete(Stu stu)
        {
            _context.Remove(stu);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Stu stu)
        {
            _context.Update(stu);
            return Save();
        }

        public async Task AddAsync(Stu stu)
        {
            _context.Stus.Add(stu);
            await _context.SaveChangesAsync();
        }





    }
}
