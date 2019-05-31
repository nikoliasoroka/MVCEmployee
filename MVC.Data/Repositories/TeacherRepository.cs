using MVC.Data.Models;
using MVC.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private Context _db;

        public TeacherRepository(Context context)
        {
            this._db = context;
        }

        public IEnumerable<Teacher> GetObjectsList()
        {
            return _db.Teachers.ToList();
        }

        public Teacher GetObject(int id)
        {
            return _db.Teachers.Find(id);
        }

        public void Create(Teacher item)
        {
            _db.Teachers.Add(item);
        }

        public void Update(Teacher item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Teacher teacher = _db.Teachers.Find(id);
            if (teacher != null)
                _db.Teachers.Remove(teacher);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
