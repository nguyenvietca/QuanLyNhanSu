using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Areas.admin.Controllers
{
    public class SlideImagesController : Controller
    {
        private QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();

        // GET: admin/SlideImages
        public ActionResult Index()
        {
            return View(db.SlideImages.ToList());
        }

        // GET: admin/SlideImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SlideImage slideImage = db.SlideImages.Find(id);
            if (slideImage == null)
            {
                return HttpNotFound();
            }
            return View(slideImage);
        }

        // GET: admin/SlideImages/Create
        public ActionResult Create()
        {
            return View(new SlideImage());
        }

        // POST: admin/SlideImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,filePost,alt,title,create_date,update_date")] SlideImage slideImage, HttpPostedFileBase imgFile)
        {
            if (ModelState.IsValid)
            {
                //if (file.ContentLength > 0)
                //{
                //    var fileName = Path.GetFileName(file.FileName);
                //    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                //    file.SaveAs(path);
                //}

                //if (us.HinhAnh != null)
                //{
                //    HinhAnh.SaveAs(HttpContext.Server.MapPath("~/Content/images/")
                //                                             + HinhAnh.FileName);
                //    up.HinhAnh = HinhAnh.FileName;
                //    us.HinhAnh = HinhAnh.FileName;
                //    //user.Image = userVal.Image;
                //}

                //var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), slideImage.src);
                imgFile.SaveAs(HttpContext.Server.MapPath("~/Content/images/") + imgFile.FileName);

                slideImage.src = imgFile.FileName;
                db.SlideImages.Add(slideImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slideImage);
        }

        // GET: admin/SlideImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SlideImage slideImage = db.SlideImages.Find(id);
            if (slideImage == null)
            {
                return HttpNotFound();
            }
            return View(slideImage);
        }

        // POST: admin/SlideImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,src,alt,title,create_date,update_date")] SlideImage slideImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slideImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slideImage);
        }

        //// GET: admin/SlideImages/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SlideImage slideImage = db.SlideImages.Find(id);
        //    if (slideImage == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(slideImage);
        //}

        // POST: admin/SlideImages/Delete/5
        [ ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SlideImage slideImage = db.SlideImages.Find(id);
            db.SlideImages.Remove(slideImage);
            db.SaveChanges();
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
