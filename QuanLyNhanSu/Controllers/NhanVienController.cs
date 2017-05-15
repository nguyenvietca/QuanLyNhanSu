using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Controllers
{
    public class NhanVienController : Controller
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        //
        // GET: /NhanVien/
        public ActionResult Index()
        {
            var id = Session["MaNhanVien"] as string;
            var chitiet = db.ChiTietLuongs.Where(n => n.MaNhanVien == id).ToList();
            return View(chitiet);
        }
    }
}