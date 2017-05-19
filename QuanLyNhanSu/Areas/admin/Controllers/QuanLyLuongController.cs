using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using System.Data;

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
        public ActionResult SuaBangLuong(Luong luong, CapNhatLuong up)
        {
            var l = db.Luongs.Where(n => n.MaNhanVien == luong.MaNhanVien).FirstOrDefault();
            if (l != null)
            {
                l.MaNhanVien = luong.MaNhanVien;
                l.LuongCoBan = up.LuongSauCapNhat;
                l.BHXH = luong.BHXH;
                l.PhuCap = luong.PhuCap;
                l.ThueThuNhap = luong.ThueThuNhap;

                //tao table luu lai moi lan cap nhat luong
                CapNhatLuong capNhat = new CapNhatLuong();
                capNhat.NgayCapNhat = DateTime.Now.Date;
                capNhat.MaNhanVien = luong.MaNhanVien;
                capNhat.LuongHienTai = luong.LuongCoBan;
                capNhat.LuongSauCapNhat = up.LuongSauCapNhat;
                capNhat.BHXH = luong.BHXH;
                capNhat.PhuCap = luong.PhuCap;
                capNhat.ThueThuNhap = luong.ThueThuNhap;

                db.CapNhatLuongs.Add(capNhat);
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

                int tienthue = 0, tong = 0; ;

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
        public ActionResult XuatFileLuong()
        {
            var ds = db.ChiTietLuongs.ToList();
            //===================================================
            DataTable dt = new DataTable();
            //Add Datacolumn
            DataColumn workCol = dt.Columns.Add("Mã nhân viên", typeof(String));
            dt.Columns.Add("Lương cơ bản", typeof(String));
            dt.Columns.Add("BHXH", typeof(String));
            dt.Columns.Add("Phụ cấp", typeof(String));
            dt.Columns.Add("Thuế thu nhập", typeof(String));
            dt.Columns.Add("Ngày nhận lương", typeof(String));
            dt.Columns.Add("Thực lãnh", typeof(String));

            //Add in the datarow
         

            foreach (var item in ds)
            {
                DataRow newRow = dt.NewRow();
                newRow["Mã nhân viên"] = item.MaNhanVien;
                newRow["Lương cơ bản"] = item.LuongCoBan;
                newRow["BHXH"] = item.BHXH;
                newRow["Phụ cấp"] = item.PhuCap;
                newRow["Thuế thu nhập"] = item.ThueThuNhap;
                newRow["Ngày nhận lương"] = item.NgayNhanLuong;
                newRow["Thực lãnh"] = item.TongTienLuong;
               

                dt.Rows.Add(newRow);
            }
               
            //====================================================
            var gv = new GridView();
            //gv.DataSource = ds;
            gv.DataSource = dt;
            gv.DataBind();

            Response.ClearContent();
            Response.Buffer = true;

            Response.AddHeader("content-disposition", "attachment; filename=danh-sach-luong.xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return Redirect("/admin/QuanLyLuong");
        }

    }   //end class
}