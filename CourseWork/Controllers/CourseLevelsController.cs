using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseWork.Models;

namespace CourseWork.Controllers
{
    public class CourseLevelsController : Controller
    {
        private CourseContext db = new CourseContext();

        // GET: CourseLevels
        public async Task<ActionResult> Index()
        {
            return View(await db.CourseLevels.ToListAsync());
        }

        // GET: CourseLevels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseLevel courseLevel = await db.CourseLevels.FindAsync(id);
            if (courseLevel == null)
            {
                return HttpNotFound();
            }
            return View(courseLevel);
        }

        // GET: CourseLevels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseLevels/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Level_Name")] CourseLevel courseLevel)
        {
            if (string.IsNullOrEmpty(courseLevel.Level_Name))
            {
                ModelState.AddModelError("Level Name", "ENTER LEVEL NAME");
            }
            if (ModelState.IsValid)
            {
                db.CourseLevels.Add(courseLevel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(courseLevel);
        }

        // GET: CourseLevels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseLevel courseLevel = await db.CourseLevels.FindAsync(id);
            if (courseLevel == null)
            {
                return HttpNotFound();
            }
            return View(courseLevel);
        }

        // POST: CourseLevels/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Level_Name")] CourseLevel courseLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseLevel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(courseLevel);
        }

        // GET: CourseLevels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseLevel courseLevel = await db.CourseLevels.FindAsync(id);
            if (courseLevel == null)
            {
                return HttpNotFound();
            }
            return View(courseLevel);
        }

        // POST: CourseLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CourseLevel courseLevel = await db.CourseLevels.FindAsync(id);
            db.CourseLevels.Remove(courseLevel);
            await db.SaveChangesAsync();
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
}
