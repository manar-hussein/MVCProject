using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IRepository<T> where T:BaseModel
    {
        public IQueryable<T> GetAll();
        public T Get(int id);
        public int Update(T entity);
        public int Delete(T entity);
        public int Add(T entity);


    }
}
