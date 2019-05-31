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
    public class TeacherService : ITeacherService
    {
        ITeacherRepository _repository;

        public TeacherService(ITeacherRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _repository.GetObjectsList();
        }

        public Teacher GetById(int id)
        {
            return _repository.GetObjectsList().FirstOrDefault(p => p.TeacherId == id);
        }

        public void Add(Teacher item)
        {
            _repository.Create(item);
        }

        public void Edit(Teacher item)
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
