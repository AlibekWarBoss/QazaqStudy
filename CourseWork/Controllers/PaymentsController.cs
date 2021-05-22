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
    public class PaymentsController : Controller
    {
        private CourseContext db = new CourseContext();

        // GET: Payments
        public async Task<ActionResult> Index()
        {
            var payments = db.Payments.Include(p => p.Course).Include(p => p.Price).Include(p => p.Student).OrderBy(p=>p.dateOfPay);
            return View(await payments.ToListAsync());
        }

        // GET: Payments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Payment payment = await db.Payments.FindAsync(id);
            Payment payment = await db.Payments.Include(c=>c.Course).FirstOrDefaultAsync(c=>c.Id==id);
            payment = await db.Payments.Include(p => p.Price).FirstOrDefaultAsync(p => p.Id == id);
            payment = await db.Payments.Include(s => s.Student).FirstOrDefaultAsync(s => s.Id == id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: Payments/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Course_Name");
            ViewBag.PriceId = new SelectList(db.Prices, "Id", "Id");
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name");
            return View();
        }

        // POST: Payments/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,StudentId,CourseId,PriceId, dateOfPay")] Payment payment)
        {
            //DateTime date = DateTime.Today;
            if (ModelState.IsValid)
            {
                //payment.dateOfPay = date;
                db.Payments.Add(payment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Course_Name", payment.CourseId);
            ViewBag.PriceId = new SelectList(db.Prices, "Id", "Id", payment.PriceId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", payment.StudentId);
            return View(payment);
        }

        // GET: Payments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = await db.Payments.FindAsync(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Course_Name", payment.CourseId);
            ViewBag.PriceId = new SelectList(db.Prices, "Id", "Id", payment.PriceId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", payment.StudentId);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,StudentId,CourseId,PriceId,dateOfPay")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Course_Name", payment.CourseId);
            ViewBag.PriceId = new SelectList(db.Prices, "Id", "Id", payment.PriceId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", payment.StudentId);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Payment payment = await db.Payments.FindAsync(id);
            Payment payment = await db.Payments.Include(c => c.Course).FirstOrDefaultAsync(c => c.Id == id);
            payment = await db.Payments.Include(p => p.Price).FirstOrDefaultAsync(p => p.Id == id);
            payment = await db.Payments.Include(s => s.Student).FirstOrDefaultAsync(s => s.Id == id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Payment payment = await db.Payments.FindAsync(id);
            db.Payments.Remove(payment);
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
