using WebMG.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MG.Models;
using MG.DataAccess.Repository;
using MG.DataAccess.Repository.IRepository;

namespace WebMG.Repository
{
    public class CenterRepository : Repository<Center>, ICenterRepository
    {
            private MGDbContext _db;
        public CenterRepository(MGDbContext db) : base(db)
        {
            _db = db;
        }



        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(Center obj)
        {
            _db.Centers.Update(obj);
        }


    }
    }
