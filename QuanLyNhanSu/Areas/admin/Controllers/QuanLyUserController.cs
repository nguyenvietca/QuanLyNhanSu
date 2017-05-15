using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;
using System.Web.Security;

namespace QuanLyNhanSu.Areas.admin.Controllers
{
    public class QuanLyUserController : AuthorController
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        //
        // GET: /admin/QuanLyUser/
        public ActionResult Index()
        {
            var user = db.NhanViens.Where(x => x.MaNhanVien != "admin" && x.TrangThai == true).ToList();
            return View(user);
        }


        public ActionResult XoaUser(String id)
        {
            var a = db.NhanViens.Where(x => x.MaNhanVien == id).SingleOrDefault();
            a.TrangThai = false;
            var hd = db.HopDongs.Where(x => x.MaHopDong == id).SingleOrDefault();
            var luong = db.Luongs.Where(x => x.MaNhanVien == id).SingleOrDefault();
            var ctLuong = db.ChiTietLuongs.Where(x => x.MaNhanVien == id).SingleOrDefault();
            if (hd != null)
            {
                db.HopDongs.Remove(hd);
                db.NhanViens.Remove(a);
                db.Luongs.Remove(luong);
                db.ChiTietLuongs.Remove(ctLuong);
                
            }
            db.SaveChanges();
            return Redirect("~/admin/QuanLyUser");
        }
        [HttpGet]
        public ActionResult UpdateUser(String id)
        {
            var user = db.NhanViens.Where(n => n.MaNhanVien == id).FirstOrDefault();
            UserValidate userVal = new UserValidate();

            userVal.MaNhanVien = user.MaNhanVien;
            userVal.HoTen = user.HoTen;
            userVal.MatKhau = user.MatKhau;
            userVal.GioiTinh = user.GioiTinh;

            userVal.MaChucVuNV = user.MaChucVuNV;
            userVal.QueQuan = user.QueQuan;
            userVal.HinhAnh = user.HinhAnh;
            userVal.DanToc = user.DanToc;
            userVal.sdt_NhanVien = user.sdt_NhanVien;
            userVal.MaHopDong = user.MaHopDong;

            userVal.NgaySinh = user.NgaySinh;
            userVal.TrangThai = user.TrangThai;
            userVal.MaChuyenNganh = user.MaChuyenNganh;
            userVal.MaTrinhDoHocVan = user.MaTrinhDoHocVan;
            userVal.MaPhongBan = user.MaPhongBan;

            userVal.CMND = user.CMND;
            userVal.XacNhanMatKhau = user.MatKhau;

            return View(userVal);
            //  return View(user);
        }
        [HttpPost]
        public ActionResult UpdateUser(UserValidate upUser)
        {
            var us = db.NhanViens.Where(n => n.MaNhanVien == upUser.MaNhanVien).FirstOrDefault();
            if (ModelState.IsValid)
            {
                //var us = db.NhanViens.Where(n => n.MaNhanVien == upUser.MaNhanVien).FirstOrDefault();
                if (us != null)
                {
                    us.MaNhanVien = upUser.MaNhanVien;
                    us.HoTen = upUser.HoTen;
                    us.MatKhau = upUser.MatKhau;
                    us.GioiTinh = upUser.GioiTinh;

                    us.MaChucVuNV = upUser.MaChucVuNV;
                    us.QueQuan = upUser.QueQuan;
                    us.HinhAnh = upUser.HinhAnh;
                    us.DanToc = upUser.DanToc;
                    us.sdt_NhanVien = upUser.sdt_NhanVien;
                    us.MaHopDong = upUser.MaHopDong;

                    us.NgaySinh = upUser.NgaySinh;
                    us.TrangThai = upUser.TrangThai;
                    us.MaChuyenNganh = upUser.MaChuyenNganh;
                    us.MaTrinhDoHocVan = upUser.MaTrinhDoHocVan;
                    us.MaPhongBan = upUser.MaPhongBan;
                    us.CMND = upUser.CMND;


                    db.SaveChanges();
                    return Redirect("/admin/QuanLyUser");

                }
            }
            return View(upUser);

        }//end update

        [HttpGet]

        public ActionResult ThemUser()
        {
            var chucvu = db.ChucVuNhanViens.ToList();
            var phongban = db.PhongBans.ToList();
            var hopdong = db.HopDongs.ToList();
            var chuyennganh = db.ChuyenNganhs.ToList();
            var trinhdo = db.TrinhDoHocVans.ToList();
            List<ChucVuNhanVien> list = chucvu;

            return View(new UserValidate());
        }


        [HttpPost]
        public ActionResult ThemUser(UserValidate nv)
        {
            nv.XacNhanMatKhau = nv.MatKhau;
            if (ModelState.IsValid)
            {
                ViewBag.err = String.Empty;
                var checkMaNhanVien = db.NhanViens.Any(x => x.MaNhanVien == nv.MaNhanVien);

                if (checkMaNhanVien)
                {
                    ViewBag.err = "tài khoản đã tồn tại";
                    //ModelState.AddModelError("MaNhanVien", "Mã tài khoản đã tồn tại");
                    return View(nv);
                }
                else
                {
                    Luong luong = new Luong();
                    HopDong hd = new HopDong();
                    NhanVien nvAdd = new NhanVien();
                    nvAdd.MaNhanVien = nv.MaNhanVien;
                    nvAdd.MatKhau = nv.MatKhau;
                    nvAdd.HoTen = nv.HoTen;
                    nvAdd.NgaySinh = nv.NgaySinh;
                    nvAdd.QueQuan = nv.QueQuan;
                    nvAdd.GioiTinh = nv.GioiTinh;
                    nvAdd.DanToc = nv.DanToc;
                    nvAdd.MaChucVuNV = nv.MaChucVuNV;
                    nvAdd.MaPhongBan = nv.MaPhongBan;
                    nvAdd.MaChuyenNganh = nv.MaChuyenNganh;
                    nvAdd.MaTrinhDoHocVan = nv.MaTrinhDoHocVan;
                    nvAdd.MaHopDong = nv.MaNhanVien;
                    nvAdd.TrangThai = true;
                    nvAdd.HinhAnh = "icon.jpg";

                    //add hop dong
                        hd.MaHopDong = nv.MaNhanVien;
                        hd.NgayBatDau = DateTime.Now.Date;
                   
                    //tao bang luong
                    luong.MaNhanVien = nv.MaNhanVien;
                    luong.LuongCoBan = 5000000;


                    // tmp.Image = "~/Content/images/icon.jpg";
                    db.NhanViens.Add(nvAdd);
                    db.HopDongs.Add(hd);

                    db.Luongs.Add(luong);
                    // @ViewBag.add = "Đăng ký thành công";
                    db.SaveChanges();
                    //xác thực tài khoản trong ứng dụng
                    FormsAuthentication.SetAuthCookie(nvAdd.MaNhanVien, false);
                    //trả về trang quản lý

                    return Redirect("/admin/QuanLyUser");
                }
            }
            else
            {

                return View(nv);
            }
        }//end add nhan vien





    }   //end lass
}