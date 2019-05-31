using MVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.Interfaces
{
    public interface ITeacherService
    {
        IEnumerable<Teacher> GetAll();
        Teacher GetById(int Id);
        void Add(Teacher item);
        void Edit(Teacher item);
        void Remove(int id);
        void SaveChanges();
    }
}
