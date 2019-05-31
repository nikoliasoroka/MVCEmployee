using MVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.Interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAll();
        //IEnumerable<Product> Get(Expression<Func<Product, Boolean>> filter);
        Department GetById(int Id);
        void Add(Department item);
        void Edit(Department item);
        void Remove(int id);
        void SaveChanges();
    }
}
