using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
namespace QuanLyNhanSu.Areas.admin.Controllers
{
    public class QuanLyPhongBanController : AuthorController
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        //
        // GET: /admin/QuanLyPhongBan/
        public ActionResult Index()
        {
            var phongban = db.PhongBans.ToList();
            return View(phongban);
        }
        [HttpGet]
        public ActionResult SuaPhongBan(String id)
        {
            var pb = db.PhongBans.Where(n => n.MaPhongBan == id).FirstOrDefault();
            if (pb != null)
            {
                PhongBanValidation tmp = new PhongBanValidation();
                tmp.MaPhongBan = pb.MaPhongBan;
                tmp.TenPhongBan = pb.TenPhongBan;
                tmp.sdt_PhongBan = pb.sdt_PhongBan;
                tmp.DiaChi = pb.DiaChi;
                return View(tmp);
            }
            else
            {
                return Redirect("/");
            }
        }
        [HttpPost]
        public ActionResult SuaPhongBan(PhongBanValidation pb)
        {
            if (ModelState.IsValid)
            {

                var tmp = db.PhongBans.Where(n => n.MaPhongBan == pb.MaPhongBan).FirstOrDefault();
                if (tmp != null)
                {
                    tmp.MaPhongBan = pb.MaPhongBan;
                    tmp.TenPhongBan = pb.TenPhongBan;
                    tmp.sdt_PhongBan = pb.sdt_PhongBan;
                    tmp.DiaChi = pb.DiaChi;
                    db.SaveChanges();
                    return Redirect("/admin/QuanLyPhongBan");
                }
            }
            return View(pb);
        }//end update
        [HttpGet]
        public ActionResult ThemPhongBan()
        {
            return View(new PhongBanValidation());
        }
        [HttpPost]
        public ActionResult ThemPhongBan(PhongBanValidation pb)
        {
            if (ModelState.IsValid)
            {
                var checkPB = db.PhongBans.Any(x => x.MaPhongBan == pb.MaPhongBan);

                if (checkPB == false)
                {
                    PhongBan add = new PhongBan();
                    add.MaPhongBan = pb.MaPhongBan;
                    add.TenPhongBan = pb.TenPhongBan;
                    add.DiaChi = pb.DiaChi;
                    add.sdt_PhongBan = pb.sdt_PhongBan;
                    db.PhongBans.Add(add);
                    db.SaveChanges();
                    return Redirect("/admin/QuanLyPhongBan");
                }
                else
                {
                    ViewBag.err = "mã phòng ban đã tồn tại ";
                    return View(pb);
                }
            }
            else
            {
                return View(pb);
            }
        }//end them

        public ActionResult DanhSachNhanVien(String id)
        {
            var name = db.PhongBans.Where(n => n.MaPhongBan == id).SingleOrDefault().TenPhongBan;
            ViewBag.ten = name.ToString();

            var list = db.NhanViens.Where(n => n.MaPhongBan == id).ToList();
            ViewBag.id = id;
            return View(list);
        }
        [HttpGet]
        public ActionResult ChuyenNhanVien(String id)
        {
            var nv = db.NhanViens.Where(n => n.MaNhanVien == id).FirstOrDefault();

            if (nv != null)
            {
                return View(nv);
            }
            else
            {
                return Redirect("/admin/QuanLyPhongBan");
            }
        }
        [HttpPost]
        public ActionResult ChuyenNhanVien(NhanVien nv, LuanChuyenNhanVien fl)
        {
            var nvChuyen = db.NhanViens.Where(n => n.MaNhanVien == nv.MaNhanVien).FirstOrDefault();

            nvChuyen.MaNhanVien = nv.MaNhanVien;
            nvChuyen.HoTen = nv.HoTen;
            nvChuyen.MaChucVuNV = nv.MaChucVuNV;
            nvChuyen.MaPhongBan = fl.PhongBanDen;

            nvChuyen.MatKhau = nv.MatKhau;
            nvChuyen.GioiTinh = nv.GioiTinh;
            nvChuyen.QueQuan = nv.QueQuan;
            nvChuyen.HinhAnh = nv.HinhAnh;
            nvChuyen.DanToc = nv.DanToc;
            nvChuyen.sdt_NhanVien = nv.sdt_NhanVien;
            nvChuyen.MaHopDong = nv.MaHopDong;
            nvChuyen.NgaySinh = nv.NgaySinh;
            nvChuyen.TrangThai = nv.TrangThai;
            nvChuyen.MaChuyenNganh = nv.MaChuyenNganh;
            nvChuyen.MaTrinhDoHocVan = nv.MaTrinhDoHocVan;
            nvChuyen.CMND = nv.CMND;

            //add vao bang luan chuyen nhan vien
            LuanChuyenNhanVien tableChuyen = new LuanChuyenNhanVien();
            tableChuyen.MaNhanVien = nv.MaNhanVien;
            tableChuyen.NgayChuyen = DateTime.Now.Date;
            tableChuyen.PhongBanChuyen = nv.MaPhongBan; //

            tableChuyen.PhongBanDen = fl.PhongBanDen;
            tableChuyen.LyDoChuyen = fl.LyDoChuyen;
            //cap nhat lại phụ cấp chức vụ
            var luong = db.Luongs.Where(n => n.MaNhanVien.Equals(nv.MaNhanVien)).SingleOrDefault();
            var chucvu = db.ChucVuNhanViens.Where(n => n.MaChucVuNV.Equals(nv.MaChucVuNV)).SingleOrDefault();

            if (chucvu.HSPC != null)
            {
                luong.PhuCap = chucvu.HSPC;

            }
            else
            {
                luong.PhuCap = 0;
            }


            //add vao csdl quá trình công tác
            db.LuanChuyenNhanViens.Add(tableChuyen);
            db.SaveChanges();
            return Redirect("/admin/QuanLyPhongBan");
        }


        public ActionResult XoaPhongBan(String id)
        {
            var pb = db.PhongBans.Where(n => n.MaPhongBan == id).FirstOrDefault();

            // những nhân viên phòngban
            var nv = db.NhanViens.Where(n => n.MaPhongBan == id).ToList();

            //danh sách hợp đồng
            var hd = db.HopDongs.ToList();

            /*
             * mã phòng ban
             * mã hợp đồng = mã nhân viên
             */

            foreach (var item in hd)
            {
                foreach (var i in nv)
                {
                    if (item.MaHopDong == i.MaHopDong)
                    {
                        db.NhanViens.Remove(i);
                        db.SaveChanges();
                    }

                }
                db.HopDongs.Remove(item);
                db.SaveChanges();
            }
            if (pb != null)
            {
                db.PhongBans.Remove(pb);
                db.SaveChanges();
            }
            return Redirect("/admin/QuanLyPhongBan");
        }// end xoa phong ban

        [HttpGet]
        public ActionResult CapNhatPhuCap()
        {
            var pbcv = db.ChucVuNhanViens.ToList();
            return View(pbcv);
        }
        [HttpPost]
        public ActionResult CapNhatPhuCap(ChucVuNhanVien cv, String id, FormCollection f)
        {
            var pc = db.ChucVuNhanViens.Where(n => n.MaChucVuNV.Equals(id)).FirstOrDefault();
            //pc.MaChucVuNV = cv.MaChucVuNV;
            var x = f["HSPC"];
            pc.HSPC = x == null ? 0 : double.Parse(x.ToString());
            db.SaveChanges();

            return RedirectToAction("CapNhatPhuCap", "QuanLyPhongBan");
        }

        public ActionResult XuatFileExel(String id)
        {
            //xXuatFileExel danh sach phong ABC
            var ds = db.NhanViens.Where(n => n.MaPhongBan == id).ToList();
            var phong = db.PhongBans.ToList();

            //===================================================
            DataTable dt = new DataTable();
            //Add Datacolumn
            DataColumn workCol = dt.Columns.Add("Họ tên", typeof(String));

            dt.Columns.Add("Phòng ban", typeof(String));
            dt.Columns.Add("Chức vụ", typeof(String));
            dt.Columns.Add("Học vấn", typeof(String));
            dt.Columns.Add("Chuyên ngành", typeof(String));

            //Add in the datarow
            foreach (var item in ds)
            {
                DataRow newRow = dt.NewRow();
                newRow["Họ tên"] = item.HoTen;
                newRow["Phòng ban"] = item.PhongBan.TenPhongBan;
                newRow["Chức vụ"] = item.ChucVuNhanVien.TenChucVu;
                newRow["Học vấn"] = item.TrinhDoHocVan.TenTrinhDo;
                newRow["Chuyên ngành"] = item.ChuyenNganh.TenChuyenNganh;

                dt.Rows.Add(newRow);
            }

            //====================================================
            var gv = new GridView();
            gv.DataSource = dt.AsDataView();
            // gv.DataSource = ds;
            gv.DataBind();

            Response.ClearContent();
            Response.Buffer = true;

            Response.AddHeader("content-disposition", "attachment; filename=danh-sach.xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

            gv.RenderControl(objHtmlTextWriter);

            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return Redirect("/admin/QuanLyPhongBan");
        }// xuat file nhan vien
    }//end classs
}