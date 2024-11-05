using Lab_7.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_7.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string studentName, int? campusID)
        {
            var viewModel = new SearchStudentViewModel
            {
                Campuses = db.UniversityCampuses.ToList(),
                Students = db.Students.Include(s => s.Campus).ToList()
            };

            if (!string.IsNullOrEmpty(studentName))
            {
                viewModel.Students = viewModel.Students.Where(s => s.Name.Contains(studentName)).ToList();
            }

            if (campusID.HasValue)
            {
                viewModel.Students = viewModel.Students.Where(s => s.CampusID == campusID.Value).ToList();
            }

            return View(viewModel);
        }



        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            var student = db.Students.Include(s => s.Campus).SingleOrDefault(s => s.ID == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.Campuses = new SelectList(db.UniversityCampuses, "ID", "Name");
            return View();
        }


        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Campuses = new SelectList(db.UniversityCampuses, "ID", "Name", student.CampusID);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Campuses = new SelectList(db.UniversityCampuses.ToList(), "ID", "Name", student.CampusID);

            return View(student);
        }



        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Campuses = new SelectList(db.UniversityCampuses, "ID", "Name", student.CampusID);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
