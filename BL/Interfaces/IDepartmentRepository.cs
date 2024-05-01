using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAll();
        public Department Get(int id);
        public int Update(Department UpdatedDept);
        public int Delete(Department department);
        public int Create(Department NewDepartment);
    }
}
