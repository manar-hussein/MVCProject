using Microsoft.AspNetCore.Mvc;
using BL.Interfaces;
using System.Collections.Generic;
using DAL.Models;

namespace MVCProject.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository deptReop;

        public DepartmentController (IDepartmentRepository departmentRepository)
        {
            deptReop = departmentRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Department> Departments = deptReop.GetAll();
            return View(Departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Department());
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {

            if(department == null)
            {
                return View(new Department());
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var index = deptReop.Create(department);
                    if (index > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View(department);
            }
        }

        public IActionResult GetDepartment(int? id , string viewName = "GetDepartment")
        {
            if(!id.HasValue)
            {
                return BadRequest(ModelState);
            }
            Department department = deptReop.Get(id.Value);
            if(department == null)
            {
                return NotFound();
            }
            return View(viewName, department);
        }

        public IActionResult Edit(int id)
        {
            return GetDepartment(id , "Edit");
        }

        [HttpPost]
        public IActionResult Edit(Department dept)
        {
            if(ModelState.IsValid)
            {
                deptReop.Update(dept);
                return RedirectToAction(nameof(Index));
            }
            return View(dept);
            
        }

        public IActionResult Delete(int id)
        {
            Department dept = deptReop.Get(id);
            deptReop.Delete(dept);
            return RedirectToAction(nameof(Index));

        }


    }
}
