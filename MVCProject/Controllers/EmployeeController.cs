using BL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Security.Principal;

namespace MVCProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IRepository<Employee> repository;
        public EmployeeController(IRepository<Employee> _repository)
        {
            repository = _repository;
        }

        public IActionResult Index()
        {
            IEnumerable AllEmployees = repository.GetAll();
            return View(AllEmployees);
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee NewEmployee)
        {
            if(ModelState.IsValid)
            {
                repository.Add(NewEmployee);
                return RedirectToAction(nameof(Index));
            }
            return View(NewEmployee);
        }

        public IActionResult Details(int id)
        {
            Employee employee = repository.Get(id);
            if(employee == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        public IActionResult Update(int id)
        {
            Employee employee = repository.Get(id);
            if (employee == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Update(Employee NewEmployee)
        {
            if(ModelState.IsValid)
            {
                repository.Update(NewEmployee);
                return RedirectToAction(nameof(Index));
            }
            return View(NewEmployee);
        }

        public IActionResult Delete(int id)
        {
            Employee emp = repository.Get(id);
            if(emp == null)
            {
                return BadRequest();
            }else
            {
                repository.Delete(emp);
                return RedirectToAction(nameof(Index));
            }
            
        }


    }
}
