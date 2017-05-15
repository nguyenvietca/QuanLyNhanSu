using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Areas.admin.Controllers
{
    public class AuthorController : Controller
    {

        public AuthorController()
        {
            String session = System.Web.HttpContext.Current.Session["MaNhanVien"] as String;
            if (System.Web.HttpContext.Current.Session["MaNhanVien"] == null || session != "admin")
            {

                System.Web.HttpContext.Current.Response.Redirect("~/");

            }

        }
        //
        // GET: /admin/Author/

    }
}