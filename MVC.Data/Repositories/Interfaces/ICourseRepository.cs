using MVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.Repositories.Interfaces
{
    public interface ICourseRepository : IDisposable
    {
        IEnumerable<Course> GetObjectsList();
        Course GetObject(int id);
        void Create(Course item);
        void Update(Course item);
        void Delete(int id);
        void Save();
    }
}
