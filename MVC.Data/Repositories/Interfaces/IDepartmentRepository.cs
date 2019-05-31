using MVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.Repositories.Interfaces
{
    public interface IDepartmentRepository : IDisposable 
    {
        IEnumerable<Department> GetObjectsList();
        Department GetObject(int id);
        void Create(Department item);
        void Update(Department item);
        void Delete(int id);
        void Save();
    }
}
