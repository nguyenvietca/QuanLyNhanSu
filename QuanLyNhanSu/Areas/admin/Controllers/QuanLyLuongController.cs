using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Areas.admin.Controllers
{
    public class QuanLyLuongController : AuthorController
    //     public class QuanLyLuongController : AuthorController
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        //
        // GET: /admin/QuanLyLuong/
        public ActionResult Index()
        {
            var list = db.Luongs.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult SuaBangLuong(String id)
        {
            var luong = db.Luongs.Where(n => n.MaNhanVien == id).SingleOrDefault();
            return View(luong);
        }
        [HttpPost]
        public ActionResult SuaBangLuong(Luong luong)
        {
            var l = db.Luongs.Where(n => n.MaNhanVien == luong.MaNhanVien).FirstOrDefault();
            if (l != null)
            {
                l.MaNhanVien = luong.MaNhanVien;
                l.LuongCoBan = luong.LuongCoBan;
                l.BHXH = luong.BHXH;
                l.PhuCap = luong.PhuCap;
                l.ThueThuNhap = luong.ThueThuNhap;
                db.SaveChanges();
            }

            return Redirect("/admin/QuanLyLuong");
        }
        //end update lương

        public ActionResult ThanhToanLuong()
        {
            var luong = db.Luongs.ToList();

            DateTime now = DateTime.Now;
            foreach (var item in luong)
            {
                ChiTietLuong ct = new ChiTietLuong();
                ct.MaChiTietBangLuong = "t" + now.Month.ToString();
                ct.MaNhanVien = item.MaNhanVien;
                var ctl = db.ChiTietLuongs.Where(n => n.MaNhanVien == ct.MaNhanVien).FirstOrDefault();
                //ct.MaChiTietBangLuong = t+dem.ToString();

                int tienthue = 0,tong=0; ;
               
                ct.LuongCoBan = item.LuongCoBan;

                item.BHXH = item.BHXH == null ? 0 : item.BHXH;
                ct.BHXH = item.BHXH;

                item.PhuCap = item.PhuCap == null ? 0 : item.PhuCap;
                ct.PhuCap = item.PhuCap;

                item.ThueThuNhap = item.ThueThuNhap == null ? 0 : item.ThueThuNhap;
                tienthue = item.LuongCoBan * (int)item.ThueThuNhap / 100;
                ct.ThueThuNhap = tienthue;

                ct.NgayNhanLuong = DateTime.Now.Date;
                ct.TienThuong = 0;
                ct.TienPhat = 0;
                tong = tong + ct.LuongCoBan - (int)ct.BHXH - (int)ct.ThueThuNhap + (int)ct.PhuCap;
                ct.TongTienLuong = tong.ToString();
                if (ctl == null)
                {
                    db.ChiTietLuongs.Add(ct);
                }
                ViewBag.ok = "thanh toán thành công";
                db.SaveChanges();
            }
            return Redirect("/admin/QuanLyLuong");
        }


        public ActionResult ThanhToanMotNhanVien(String id)
        {
            var nv = db.NhanViens.Where(n => n.MaNhanVien == id).FirstOrDefault();
            if (nv != null)
            {
                //tim xem da co trong chi tiet lương chưa
                var ctl = db.ChiTietLuongs.Where(n => n.MaNhanVien == id).FirstOrDefault();
                //tìm bảng lương tương ứng với nhân viên
                var luongthang = db.Luongs.Where(n => n.MaNhanVien == id).FirstOrDefault();
                ChiTietLuong ct = new ChiTietLuong();
                DateTime now = DateTime.Now;
                int tienthue = 0, tong = 0;

                ct.MaChiTietBangLuong = "t" + now.Month.ToString();
                ct.MaNhanVien = luongthang.MaNhanVien;

                ct.LuongCoBan = luongthang.LuongCoBan;
                luongthang.BHXH = luongthang.BHXH == null ? 0 : luongthang.BHXH;
                ct.BHXH = luongthang.BHXH;

                luongthang.PhuCap = luongthang.PhuCap == null ? 0 : luongthang.PhuCap;
                ct.PhuCap = luongthang.PhuCap;


                luongthang.ThueThuNhap = luongthang.ThueThuNhap == null ? 0 : luongthang.ThueThuNhap;
                tienthue = luongthang.LuongCoBan * (int)luongthang.ThueThuNhap / 100;
                ct.ThueThuNhap = (double)tienthue;
                ct.NgayNhanLuong = DateTime.Now.Date;
                ct.TienThuong = 0;
                ct.TienPhat = 0;
                tong = tong + ct.LuongCoBan - (int)ct.BHXH - (int)ct.ThueThuNhap + (int)ct.PhuCap;
                ct.TongTienLuong = tong.ToString();
                if (ctl == null)
                {
                    ViewBag.ok = "thanh toán thành công";
                    db.ChiTietLuongs.Add(ct);
                }
                db.SaveChanges();

            }
            return Redirect("/admin/QuanLyLuong");
        }

        public ActionResult DanhSachNhanLuong()
        {
            var list = db.ChiTietLuongs.ToList();
            return View(list);
        }

    }   //end class
}