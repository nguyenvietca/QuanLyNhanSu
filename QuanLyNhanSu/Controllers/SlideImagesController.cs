using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Controllers
{
    public class SlideImagesController : Controller
    {
        private QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();

        // GET: SlideImages
        public async Task<ActionResult> Index()
        {
            return View(await db.SlideImages.ToListAsync());
        }

        // GET: SlideImages/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SlideImage slideImage = await db.SlideImages.FindAsync(id);
            if (slideImage == null)
            {
                return HttpNotFound();
            }
            return View(slideImage);
        }

        // GET: SlideImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SlideImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,src,alt,title,create_date,update_date")] SlideImage slideImage)
        {
            if (ModelState.IsValid)
            {
                db.SlideImages.Add(slideImage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(slideImage);
        }

        // GET: SlideImages/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SlideImage slideImage = await db.SlideImages.FindAsync(id);
            if (slideImage == null)
            {
                return HttpNotFound();
            }
            return View(slideImage);
        }

        // POST: SlideImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,src,alt,title,create_date,update_date")] SlideImage slideImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slideImage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(slideImage);
        }

        // GET: SlideImages/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SlideImage slideImage = await db.SlideImages.FindAsync(id);
            if (slideImage == null)
            {
                return HttpNotFound();
            }
            return View(slideImage);
        }

        // POST: SlideImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SlideImage slideImage = await db.SlideImages.FindAsync(id);
            db.SlideImages.Remove(slideImage);
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
