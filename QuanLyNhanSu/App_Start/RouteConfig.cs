using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuanLyNhanSu
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


                routes.MapRoute(
                    name: "Đăng nhập",
                    url: "dang-nhap",
                    defaults: new { controller = "login", action = "Login", id = UrlParameter.Optional }
                );

               routes.MapRoute(
                    name: "Cập nhật thông tin",
                    url: "tai-khoan/cap-nhat-thong-tin",
                    defaults: new { controller = "login", action = "UpDateUser", id = UrlParameter.Optional }
                );

               routes.MapRoute(
                    name: "Xem lương",
                    url: "tai-khoan/chi-tiet-luong",
                    defaults: new { controller = "NhanVien", action = "Index", id = UrlParameter.Optional }
                );
            /*
                        routes.MapRoute(
                          name: "Đăng nhập",
                          url: "dang-nhap/{metatitle}-{id}",
                          defaults: new { controller = "login", action = "Login", id = UrlParameter.Optional }
                      );
                        */

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
