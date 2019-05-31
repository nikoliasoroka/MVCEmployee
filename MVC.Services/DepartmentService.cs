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
    public class DepartmentService : IDepartmentService
    {
        IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            this._repository = repository;
        }
        public IEnumerable<Department> GetAll()
        {
            return _repository.GetObjectsList();
        }

        public Department GetById(int id)
        {
            return _repository.GetObjectsList().SingleOrDefault(p => p.DeptId == id);
        }

        public void Add(Department item)
        {
            _repository.Create(item);
        }

        public void Edit(Department item)
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