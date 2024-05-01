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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext dbContext;
        public DepartmentRepository(AppDbContext _AppDbContext)
        {
            dbContext = _AppDbContext;
        }
        public int Create(Department NewDepartment)
        {
            dbContext.Add(NewDepartment);
            return dbContext.SaveChanges();
        }

        public int Delete(Department department)
        {
            dbContext.Remove(department);
            return dbContext.SaveChanges();
        }

        public Department Get(int id)
        {
            return dbContext.Find<Department>(id);
        }

        public IEnumerable<Department> GetAll()
        {
            return dbContext.Departments.AsNoTracking().ToList();
        }

        public int Update(Department UpdatedDept)
        {
            dbContext.Departments.Update(UpdatedDept);
            return dbContext.SaveChanges();
        }
    }
}
