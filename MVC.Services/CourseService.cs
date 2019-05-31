using MVC.Data.Models;
using MVC.Data.Repositories.Interfaces;
using MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services
{
    public class CourseService : ICourseService
    {
        ICourseRepository _repository;

        public CourseService(ICourseRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Course> GetAll()
        {
            return _repository.GetObjectsList();
        }

        public Course GetById(int id)
        {
            return _repository.GetObjectsList().FirstOrDefault(p => p.CourseId == id);
        }

        public void Add(Course item)
        {
            _repository.Create(item);
        }

        public void Edit(Course item)
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
