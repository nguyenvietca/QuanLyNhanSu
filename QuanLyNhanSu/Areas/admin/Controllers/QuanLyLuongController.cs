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
                //  l.MaNhanVien = luong.MaNhanVien;
                if (int.Parse(up.LuongSauCapNhat.ToString()) != 0)
                {
                    l.LuongToiThieu = up.LuongSauCapNhat;
                }

                l.BHXH = luong.BHXH == null ? 0 : luong.BHXH;
                l.BHYT = luong.BHYT == null ? 0 : luong.BHYT;
                l.BHTN = luong.BHTN == null ? 0 : luong.BHTN;
             //   l.PhuCap = luong.PhuCap;
                l.ThueThuNhap = luong.ThueThuNhap;
                l.HeSoLuong = luong.HeSoLuong;

                //tao table luu lai moi lan cap nhat luong
                CapNhatLuong capNhat = new CapNhatLuong();
                capNhat.NgayCapNhat = DateTime.Now.Date;
                capNhat.MaNhanVien = luong.MaNhanVien;
                capNhat.LuongHienTai = luong.LuongToiThieu;
                capNhat.LuongSauCapNhat = up.LuongSauCapNhat;
                capNhat.BHXH = luong.BHXH;
                capNhat.BHYT = luong.BHYT;
                capNhat.BHTN = luong.BHTN;
              //  capNhat.PhuCap = luong.PhuCap;
                capNhat.ThueThuNhap = luong.ThueThuNhap;
                capNhat.HeSoLuong = luong.HeSoLuong;

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

                double tienthue = 0, phucap = 0;
                double tong = 0;
                item.HeSoLuong = item.HeSoLuong == null ? 0 : item.HeSoLuong;
                ct.LuongCoBan = item.LuongToiThieu * (double)item.HeSoLuong;

                item.BHXH = item.BHXH == null ? 0 : item.BHXH;
                ct.BHXH = item.BHXH * item.LuongToiThieu / 100;

                item.BHYT = item.BHYT == null ? 0 : item.BHYT;
                ct.BHYT = item.BHYT * item.LuongToiThieu / 100;

                item.BHTN = item.BHTN == null ? 0 : item.BHTN;
                ct.BHTN = item.BHTN * item.LuongToiThieu / 100;


                item.PhuCap = item.PhuCap == null ? 0 : item.PhuCap;
                phucap = item.LuongToiThieu * (double)item.PhuCap;
                ct.PhuCap = phucap;


                item.ThueThuNhap = item.ThueThuNhap == null ? 0 : item.ThueThuNhap;
                tienthue = item.LuongToiThieu * (int)item.ThueThuNhap / 100;
                ct.ThueThuNhap = tienthue;

                ct.NgayNhanLuong = DateTime.Now.Date;
                ct.TienThuong = 0;
                ct.TienPhat = 0;
                tong = tong + ct.LuongCoBan - (double)(ct.BHXH + ct.BHYT + ct.BHTN) - (double)ct.ThueThuNhap + (double)ct.PhuCap;
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
                double tienthue = 0, tong = 0, phucap = 0;

                ct.MaChiTietBangLuong = "t" + now.Month.ToString();
                ct.MaNhanVien = luongthang.MaNhanVien;

                ct.LuongCoBan = luongthang.LuongToiThieu * (double)luongthang.HeSoLuong;

                luongthang.BHXH = luongthang.BHXH == null ? 0 : luongthang.BHXH;
                ct.BHXH = luongthang.BHXH * luongthang.LuongToiThieu / 100;

                luongthang.BHYT = luongthang.BHYT == null ? 0 : luongthang.BHYT;
                ct.BHYT = luongthang.BHYT * luongthang.LuongToiThieu / 100;

                luongthang.BHTN = luongthang.BHTN == null ? 0 : luongthang.BHTN;
                ct.BHTN = luongthang.BHTN * luongthang.LuongToiThieu / 100;

                luongthang.PhuCap = luongthang.PhuCap == null ? 0 : luongthang.PhuCap;
                phucap = luongthang.LuongToiThieu * (double)luongthang.PhuCap;
                ct.PhuCap = phucap;


                luongthang.ThueThuNhap = luongthang.ThueThuNhap == null ? 0 : luongthang.ThueThuNhap;
                tienthue = (double)luongthang.LuongToiThieu * (double)luongthang.ThueThuNhap / 100;
                ct.ThueThuNhap = (double)tienthue;
                ct.NgayNhanLuong = DateTime.Now.Date;
                ct.TienThuong = 0;
                ct.TienPhat = 0;
                tong = tong + ct.LuongCoBan - (double)(ct.BHXH + ct.BHYT + ct.BHTN) - (double)ct.ThueThuNhap + (double)ct.PhuCap;
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
        public ActionResult XuatFileLuong(String id)
        {
            //var l = db.ChiTietLuongs.Where(n => n.MaChiTietBangLuong == id).ToList();
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


        public ActionResult QuaTrinhTangLuong(String id)
        {
            var tangluong = db.CapNhatLuongs.Where(n => n.MaNhanVien == id).ToList();
            if (tangluong != null)
            {
                return View(tangluong);
            }
            return Redirect("/admin/QuanLyLuong");
        }// EndEv
    }   //end class
}
