using MVC.Data.Models;
using MVC.Data.Repositories;
using MVC.Data.Repositories.Interfaces;
using MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Services
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _repository.GetObjectsList();
        }

        public Employee GetById(int? id)
        {
            return _repository.GetObject(id);
        }

        public void Add(Employee item)
        {
            _repository.Create(item);
        }

        public void Edit(Employee item)
        {
            _repository.Update(item);
        }

        public void Remove(int id)
        {
            _repository.Delete(id);
        }

        public void SaveChanges()
        {
            _repository.Save();
        }
    }
}