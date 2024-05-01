using BL.Interfaces;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repository
{
    public class GenericRepository <T>: IRepository<T> where T : BaseModel
    {
        private protected readonly AppDbContext appDbContext;
        public GenericRepository(AppDbContext _AppDbContext)
        {
            appDbContext = _AppDbContext;

        }
        public int Add(T entity)
        {
             appDbContext.Set<T>().Add(entity);
            return appDbContext.SaveChanges();
                
        }

        public int Delete(T entity)
        {
            appDbContext.Remove(entity);
            return appDbContext.SaveChanges();
        }

        public T Get(int id)
        {
            return appDbContext.Find<T>(id);
        }

        public IQueryable<T> GetAll()
        {
            return appDbContext.Set<T>().AsNoTracking();
        }

        public int Update(T entity)
        {
            appDbContext.Update(entity);
            return appDbContext.SaveChanges();
        }
    }
}
