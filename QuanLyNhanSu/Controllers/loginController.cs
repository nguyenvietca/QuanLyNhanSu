using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;
using System.Web.Security;

namespace QuanLyNhanSu.Controllers
{
    public class loginController : Controller
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        //
        // GET: /login/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.err = "";
            return View();
        }
        [HttpPost]
        public ActionResult Login(NhanVien user)
        {
            
            //check email da ton tai chua
            var checkaccount = db.NhanViens.Any(x => x.MaNhanVien == user.MaNhanVien &&
                x.MatKhau == user.MatKhau && x.TrangThai == true);
            var checkadmin = db.NhanViens.Any(x => x.MaNhanVien == user.MaNhanVien &&
                    x.MaNhanVien == "admin" &&
                    x.MatKhau == user.MatKhau
                );

            if (checkaccount)
            {
                ViewBag.err = "";

                Session["MaNhanVien"] = user.MaNhanVien;

                FormsAuthentication.SetAuthCookie(user.MaNhanVien, false);
                if (checkadmin)
                {
                    return Redirect("~/admin/Admin/Index");
                }
                else
                {
                    return Redirect("/");
                }
            }

            else
            {
                Session["user"] = null;
                ViewBag.err = "Tài khoản hoặc mật khẩu không đúng";
                //  ModelState.AddModelError("Account", "Tài khoản hoặc mật khẩu không đúng...!");
                return View();
            }

        }

        [HttpGet]
        public ActionResult UpDateUser()
        {
            UserValidate up = new UserValidate();
            var id = Session["MaNhanVien"] as String;
            var us = db.NhanViens.Where(n => n.MaNhanVien == id).FirstOrDefault();
               if(us!=null){
            up.MaNhanVien = us.MaNhanVien;
            up.HinhAnh = us.HinhAnh;
            up.MatKhau = us.MatKhau;
            up.XacNhanMatKhau = us.MatKhau;
            up.HoTen = us.HoTen;
            up.NgaySinh = us.NgaySinh;
            up.QueQuan = us.QueQuan;
            up.GioiTinh = us.GioiTinh;
            up.DanToc = us.DanToc;
            up.sdt_NhanVien = us.sdt_NhanVien;
            up.MaChuyenNganh = us.MaChuyenNganh;
            up.MaTrinhDoHocVan = us.MaTrinhDoHocVan;
            up.CMND = us.CMND;

            return View(up);
               }
               return Redirect("~/");
        }
        [HttpPost]
        public ActionResult UpDateUser(UserValidate us, HttpPostedFileBase HinhAnh)
        {
            if (ModelState.IsValid)
            {
                var up = db.NhanViens.Where(n => n.MaNhanVien == us.MaNhanVien).FirstOrDefault();
                up.MaNhanVien = us.MaNhanVien;
                
                up.MatKhau = us.MatKhau;
                up.MatKhau = us.XacNhanMatKhau;
                up.HoTen = us.HoTen;
                up.NgaySinh = us.NgaySinh;
                up.QueQuan = us.QueQuan;
                up.GioiTinh = us.GioiTinh;
                up.DanToc = us.DanToc;
                up.sdt_NhanVien = us.sdt_NhanVien;
                up.MaChuyenNganh = us.MaChuyenNganh;
                up.MaTrinhDoHocVan = us.MaTrinhDoHocVan;
                up.CMND = us.CMND;

                if (us.HinhAnh != null)
                {
                    HinhAnh.SaveAs(HttpContext.Server.MapPath("~/Content/images/")
                                                             + HinhAnh.FileName);
                    up.HinhAnh = HinhAnh.FileName;
                    us.HinhAnh = HinhAnh.FileName;
                    //user.Image = userVal.Image;
                }
                else
                {
                    us.HinhAnh = up.HinhAnh;
                }

                db.SaveChanges();
                return View(us);
            }
            else
            {
                return View(us);
            }
        }
        public ActionResult DangXuat()
        {
            //Đăng xuất khỏi ứng dụng
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            //Về trang chủ
            return Redirect("/");
        }
    }
}