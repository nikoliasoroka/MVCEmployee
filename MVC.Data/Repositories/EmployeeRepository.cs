using MVC.Data.Models;
using MVC.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private Context _db;

        public EmployeeRepository(Context context)
        {
            this._db = context;
        }

        public IEnumerable<Employee> GetObjectsList()
        {
            return _db.Employees.ToList();
        }

        public Employee GetObject(int? id)
        {
            return _db.Employees.Find(id);
        }

        public void Create(Employee employee)
        {
            _db.Employees.Add(employee);
        }
        public void Update(Employee employee)
        {
            var exists = _db.Employees.Find(employee.EmpId);
            _db.Entry(exists).State = EntityState.Detached;
            _db.Entry(employee).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Employee employee = _db.Employees.Find(id);
            if (employee != null)
                _db.Employees.Remove(employee);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}