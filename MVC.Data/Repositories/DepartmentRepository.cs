using MVC.Data.Models;
using MVC.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC.Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private Context _db;

        public DepartmentRepository(Context context)
        {
            this._db = context;
        }

        public IEnumerable<Department> GetObjectsList()
        {
            return _db.Departments.ToList();
        }

        public Department GetObject(int id)
        {
            return _db.Departments.Find(id);
        }

        public void Create(Department department)
        {
            _db.Departments.Add(department);
        }
        public void Update(Department department)
        {
            _db.Entry(department).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Department department = _db.Departments.Find(id);
            if (department != null)
                _db.Departments.Remove(department);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}