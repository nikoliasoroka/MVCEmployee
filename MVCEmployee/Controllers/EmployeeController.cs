using MVC.Data.Models;
using MVC.Services;
using MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using MVCEmployee.ViewModels;

namespace MVCEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeService _service;
        IDepartmentService _deptService;

        public EmployeeController(IEmployeeService service, IDepartmentService deptService)
        {
            _service = service;
            _deptService = deptService;
        }

        public ActionResult Index(int id)
        {
            List<Employee> employee = _service.GetAll().Where(emp => emp.DeptId == id).ToList();

            return View(employee);
        }

        public ActionResult IndexAll()
        {
            var employee = _service.GetAll();

            return View(employee);
        }

        public string GetAllEmployees()
        {
            var employees = _service.GetAll();

            return JsonConvert.SerializeObject(employees, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            Employee employee = _service.GetById(id);

            return View(employee);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var dept = _deptService.GetAll();
            var model = new EmployeeViewModel()
            {
                Departments = dept.Select(m => new LookupItem()
                {
                    Id = m.DeptId,
                    Name = m.Name
                }).ToList()
            };

            return View(model);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeViewModel);
            }

            Employee employee = new Employee()
            {
                Name = employeeViewModel.Name,
                Address = employeeViewModel.Address,
                PhoneNumber = employeeViewModel.PhoneNumber,
                DeptId = employeeViewModel.SelectedDepartmentId 
            };
            _service.Add(employee);
            _service.SaveChanges();

            return RedirectToAction("IndexAll", "Employee");
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null && id == 0)
            {
                return HttpNotFound();
            }

            Employee employee = _service.GetById(id);
            var dept = _deptService.GetAll();

            var model = new EmployeeViewModel()
            {
                Id = employee.EmpId,
                Name = employee.Name,
                Address = employee.Address,
                PhoneNumber = employee.PhoneNumber,
                SelectedDepartmentId = employee.DeptId,
                Departments = dept.Select(m => new LookupItem()
                {
                    Id = m.DeptId,
                    Name = m.Name,
                }).ToList()
            };

            return View(model);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _service.GetById(employeeViewModel.Id);

                if(employee == null)
                {
                    return HttpNotFound();
                }

                employee.Name = employeeViewModel.Name;
                employee.Address = employeeViewModel.Address;
                employee.PhoneNumber = employeeViewModel.PhoneNumber;
                employee.DeptId = employeeViewModel.SelectedDepartmentId;

                _service.Edit(employee);
                _service.SaveChanges();

                return RedirectToAction("IndexAll", "Employee");
            }

            return View(employeeViewModel);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            Employee employee = _service.GetById(id);

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _service.Remove(id);
                _service.SaveChanges();

                return RedirectToAction("IndexAll");
            }
            catch
            {
                return View();
            }
        }
    }
}
