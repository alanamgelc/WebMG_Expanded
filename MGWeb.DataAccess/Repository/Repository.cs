using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MG.DataAccess.Repository.IRepository;
using MGWeb.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebMG.Data;

namespace MG.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
            private readonly MGDbContext _db;
            internal DbSet<T> dbSet;
        public Repository(MGDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            //  _db.Products.Include(u => u.Category).Include(u => u.CategoryId);
        }
        //    public void Add(T entity)
        //    {
        //      dbSet.Add(entity);

        //    }

        //    public T Get(Expression<Func<T, bool>> filter)
        //    {
        //        IQueryable<T> query = dbSet;
        //        query= query.Where(filter);
        //        return query.FirstOrDefault();
        //    }



        //    public IEnumerable<T> GetAll()
        //    {
        //        IQueryable<T> query = dbSet;
        //        return query.ToList();
        //    }



        //    public void Remove(T entity)
        //    {
        //      dbSet.Remove(entity);
        //    }

        //    public void RemoveRange(IEnumerable<T> entity)
        //    {
        //        dbSet.RemoveRange(entity);
        //    }


        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
                   return query.ToList();
        }


    }
}
