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
    public class CourseRepository : ICourseRepository
    {
        private Context _db;

        public CourseRepository(Context context)
        {
            this._db = context;
        }

        public IEnumerable<Course> GetObjectsList()
        {
            return _db.Courses.ToList();
        }

        public Course GetObject(int id)
        {
            return _db.Courses.Find(id);
        }

        public void Create(Course item)
        {
            _db.Courses.Add(item);
        }

        public void Update(Course item)
        {
            var exists = _db.Courses.Find(item.CourseId);
            _db.Entry(exists).State = EntityState.Detached;
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Course course = _db.Courses.Find(id);
            if (course != null)
                _db.Courses.Remove(course);
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
