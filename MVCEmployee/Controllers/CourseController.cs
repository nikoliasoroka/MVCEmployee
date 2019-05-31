using MVC.Data.Models;
using MVC.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEmployee.Controllers
{
    public class CourseController : Controller
    {
        ICourseService _service;

        public CourseController(ICourseService service)
        {
            this._service = service;
        }

        // GET: Course
        public ActionResult Index()
        {
            var courses = _service.GetAll();

            return View("Courses", courses);
        }

        public string GetCourses()
        {
            var courses = _service.GetAll();

            return JsonConvert.SerializeObject(courses, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            Course course = _service.GetById(id);

            return View(course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(Course course)
        {
            if(ModelState.IsValid)
            {
                _service.Add(course);
                _service.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            Course course = _service.GetById(id);

            return View(course);
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if(ModelState.IsValid)
            {
                _service.Edit(course);
                _service.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            Course course = _service.GetById(id);

            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _service.Remove(id);
                _service.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
