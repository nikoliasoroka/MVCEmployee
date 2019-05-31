using MVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.Repositories.Interfaces
{
    public interface IEmployeeRepository : IDisposable
    {
        IEnumerable<Employee> GetObjectsList();
        Employee GetObject(int? id);
        void Create(Employee item);
        void Update(Employee item);
        void Delete(int id);
        void Save();
    }
}
