using MVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAll();
        Course GetById(int Id);
        void Add(Course item);
        void Edit(Course item);
        void Remove(int id);
        void SaveChanges();
    }
}
