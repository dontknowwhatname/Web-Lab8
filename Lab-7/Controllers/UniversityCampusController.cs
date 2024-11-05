using Lab_7.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

public class UniversityCampusController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    // GET: UniversityCampus
    public ActionResult Index()
    {
        var campuses = db.UniversityCampuses.Include("Students").ToList();
        return View(campuses);
    }

    // GET: UniversityCampus/Details/5
    public ActionResult Details(int id)
    {
        var campus = db.UniversityCampuses
            .Include(c => c.Students)
            .SingleOrDefault(c => c.ID == id);

        if (campus == null)
        {
            return HttpNotFound();
        }
        return View(campus);
    }

    // GET: UniversityCampus/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: UniversityCampus/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(UniversityCampus campus)
    {
        if (ModelState.IsValid)
        {
            db.UniversityCampuses.Add(campus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(campus);
    }

    // GET: UniversityCampus/Edit/5
    public ActionResult Edit(int id)
    {
        var campus = db.UniversityCampuses.SingleOrDefault(c => c.ID == id);
        if (campus == null)
        {
            return HttpNotFound();
        }
        return View(campus);
    }

    // POST: UniversityCampus/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(UniversityCampus campus)
    {
        if (ModelState.IsValid)
        {
            db.Entry(campus).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(campus);
    }

    // GET: UniversityCampus/Delete/5
    public ActionResult Delete(int id)
    {
        var campus = db.UniversityCampuses.SingleOrDefault(c => c.ID == id);
        if (campus == null)
        {
            return HttpNotFound();
        }
        return View(campus);
    }

    // POST: UniversityCampus/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        var campus = db.UniversityCampuses.SingleOrDefault(c => c.ID == id);
        if (campus != null)
        {
            db.UniversityCampuses.Remove(campus);
            db.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            db.Dispose();
        }
        base.Dispose(disposing);
    }
}
