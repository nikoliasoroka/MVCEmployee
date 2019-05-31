using MVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        //IEnumerable<Product> Get(Expression<Func<Product, Boolean>> filter);
        Employee GetById(int? Id);
        void Add(Employee item);
        void Edit(Employee item);
        void Remove(int id);
        void SaveChanges();
    }
}
