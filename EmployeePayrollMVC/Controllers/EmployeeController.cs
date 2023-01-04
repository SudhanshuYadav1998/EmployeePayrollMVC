using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Services;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayrollMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmpRegBL empRegBL;
        public EmployeeController(IEmpRegBL empRegBL)
        {
            this.empRegBL = empRegBL;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<EmployeeModel> lstEmployee = new List<EmployeeModel>();
            lstEmployee = empRegBL.GetAllEmployees().ToList();

            return View(lstEmployee);
        }

        public IActionResult Indexnew()
        {
            List<EmployeeModel> lstEmployee = new List<EmployeeModel>();
            lstEmployee = empRegBL.GetAllEmployees().ToList();

            return View(lstEmployee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind] EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                empRegBL.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpPost]

        public JsonResult Createjson(EmployeeModel employee)
        {
            empRegBL.AddEmployee(employee);
            return Json(employee);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = empRegBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind] EmployeeModel employee)
        {
            if (id != employee.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                empRegBL.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = empRegBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        public JsonResult GetAll()
        {
            List<EmployeeModel> lstEmployee = new List<EmployeeModel>();
            lstEmployee = empRegBL.GetAllEmployees().ToList();

            return Json(lstEmployee);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = empRegBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            empRegBL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
