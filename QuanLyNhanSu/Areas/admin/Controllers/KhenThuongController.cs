using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Areas.admin.Controllers
{
    public class KhenThuongController : Controller
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        //
        // GET: /admin/KhenThuong/
        public ActionResult Index()
        {
            var t = db.KhenThuongs.ToList();
            return View(t);
        }
        [HttpGet]
        public ActionResult khen()
        {
            var nv = db.NhanViens.ToList();
        
            return View(new KhenThuong());
        }
        [HttpPost]
        public ActionResult khen(KhenThuong kt)
        {
            //var ct = db.ChiTietLuongs.Where(n => n.MaNhanVien == kt.MaNhanVien).FirstOrDefault();
                     
            KhenThuong ad = new KhenThuong();
            ad.MaNhanVien = kt.MaNhanVien;
            ad.ThangThuong = kt.ThangThuong;
            ad.TienThuong = kt.TienThuong;
            ad.LyDo = kt.LyDo;

            db.KhenThuongs.Add(ad);
            db.SaveChanges();
            return Redirect("/admin/KhenThuong"); 
        }
	}
}