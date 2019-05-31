using MVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.Repositories.Interfaces
{
    public interface ITeacherRepository : IDisposable
    {
        IEnumerable<Teacher> GetObjectsList();
        Teacher GetObject(int id);
        void Create(Teacher item);
        void Update(Teacher item);
        void Delete(int id);
        void Save();
    }
}
