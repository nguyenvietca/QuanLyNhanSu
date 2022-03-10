using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;
using System.Web.Security;
//using cExcel = Microsoft.Office.Interop.Excel;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyNhanSu.Areas.admin.Controllers
{
    public class QuanLyUserController : AuthorController
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        public CreateMd5Hash md5Hash = new CreateMd5Hash();
        public const int Minluong = 1150000;
        public const double BHXH = 8;
        public const double BHYT = 1.5;
        public const double BHTN = 1;
        //
        // GET: /admin/QuanLyUser/
        public ActionResult Index()
        {
            var user = db.NhanViens.Where(x => x.MaNhanVien != "admin" && x.TrangThai == true).ToList();
            return View(user);
        }


        public ActionResult XoaUser(String id)
        {

            var nv = db.NhanViens.Where(x => x.MaNhanVien == id).SingleOrDefault();
            var hd = db.HopDongs.Where(x => x.MaHopDong == id).SingleOrDefault();
            var luong = db.Luongs.Where(x => x.MaNhanVien == id).SingleOrDefault();
            var ctLuong = db.ChiTietLuongs.Where(x => x.MaNhanVien == id).ToList();
            foreach (var item in ctLuong)
            {
                db.ChiTietLuongs.Remove(item);
            }

            db.Luongs.Remove(luong);
            db.NhanViens.Remove(nv);
            db.HopDongs.Remove(hd);

            db.SaveChanges();
            return Redirect("~/admin/QuanLyUser");
        }
        [HttpGet]
        public ActionResult UpdateUser(String id)
        {
            var user = db.NhanViens.Where(n => n.MaNhanVien == id).FirstOrDefault();
            UserValidate userVal = new UserValidate();

            String matKhau = md5Hash.CreateMD5Hash(user.MatKhau);
            userVal.MaNhanVien = user.MaNhanVien;
            userVal.HoTen = user.HoTen;
            userVal.MatKhau = matKhau;
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
            userVal.XacNhanMatKhau = matKhau;

            return View(userVal);
            //  return View(user);
        }
        [HttpPost]
        public ActionResult UpdateUser(UserValidate upUser)
        {
            String matKhau = md5Hash.CreateMD5Hash(upUser.MatKhau);
            upUser.XacNhanMatKhau = matKhau;
            if (ModelState.IsValid)
            {
                var us = db.NhanViens.Where(n => n.MaNhanVien == upUser.MaNhanVien).FirstOrDefault();
                if (us != null)
                {

                    CapNhatTrinhDoHocVan capNhat = new CapNhatTrinhDoHocVan();
                    capNhat.MaNhanVien = upUser.MaNhanVien;
                    capNhat.NgayCapNhat = DateTime.Now.Date;
                    capNhat.MaTrinhDoTruoc = us.MaTrinhDoHocVan;
                    capNhat.MaTrinhDoCapNhat = upUser.MaTrinhDoHocVan;

                    us.MaNhanVien = upUser.MaNhanVien;
                    us.HoTen = upUser.HoTen;
                    us.MatKhau = matKhau;
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

                    var trinhdo = db.TrinhDoHocVans.Where(n => n.MaTrinhDoHocVan.Equals(us.MaTrinhDoHocVan)).FirstOrDefault();

                    var luong = db.Luongs.Where(n => n.MaNhanVien.Equals(us.MaNhanVien)).FirstOrDefault();

                    if (trinhdo.HeSoBac != null)
                    {
                        luong.HeSoLuong = luong.HeSoLuong < (double)trinhdo.HeSoBac ? (double)trinhdo.HeSoBac : luong.HeSoLuong;
                    }
                    else
                    { luong.HeSoLuong = 1; }



                    db.CapNhatTrinhDoHocVans.Add(capNhat);

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
            String matKhau = md5Hash.CreateMD5Hash(nv.MatKhau);
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
                    nvAdd.MatKhau = matKhau;
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

                    luong.LuongToiThieu = Minluong;
                    luong.BHXH = BHXH;
                    luong.BHYT = BHYT;
                    luong.BHTN = BHTN;
                    var trinhdo = db.TrinhDoHocVans.Where(n => n.MaTrinhDoHocVan.Equals(nv.MaTrinhDoHocVan)).FirstOrDefault();
                    var chucvu = db.ChucVuNhanViens.Where(n => n.MaChucVuNV.Equals(nv.MaChucVuNV)).SingleOrDefault();

                    if (trinhdo.MaTrinhDoHocVan.Equals(nv.MaTrinhDoHocVan))
                    {
                        luong.HeSoLuong = (double)trinhdo.HeSoBac;
                    }


                    if (chucvu.MaChucVuNV.Equals(nv.MaChucVuNV))
                    {
                        if (chucvu.HSPC != null)
                        {
                            luong.PhuCap = (double)chucvu.HSPC;
                        }
                        else
                        { luong.PhuCap = 0; }
                    }

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

            nv.XacNhanMatKhau = String.Empty;
            return View(nv);
        }//end add nhan vien

        public ActionResult QuaTrinhCongTac(String id)
        {
            var ds = db.LuanChuyenNhanViens.Where(n => n.MaNhanVien == id).ToList();
            return View(ds);
        }

        public ActionResult XuatFileExel()
        {

            var ds = db.NhanViens.Where(n => n.MaNhanVien != "admin" && n.MaHopDong != null).ToList();
            var phong = db.PhongBans.ToList();
            var gv = new GridView();
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
            gv.DataSource = dt;
            gv.DataBind();

            ExportDataFileController export = new ExportDataFileController();
            export.XuatFileExel(gv, (HttpResponseWrapper)Response, "Nhanh vien");

            return Redirect("/admin/QuanLyUser");
        }

        public ActionResult QuaTrinhHoc(String id)
        {
            var ht = db.CapNhatTrinhDoHocVans.Where(n => n.MaNhanVien == id).ToList();
            return View(ht);
        }
        public string CreateMD5Hash(string input)
        {
            // Step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                //X2 to UPPERCASE TEXT
                //x2 to lowercase text
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

    }   //end lass
}