using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Controllers
{
    public class AuthenController : Controller
    {
        //
        // GET: /Authen/
        public AuthenController()
        {
            String session = System.Web.HttpContext.Current.Session["MaNhanVien"] as String;
            if (System.Web.HttpContext.Current.Session["MaNhanVien"] == null)
            {

                System.Web.HttpContext.Current.Response.Redirect("~/");

            }

        }
	}
}