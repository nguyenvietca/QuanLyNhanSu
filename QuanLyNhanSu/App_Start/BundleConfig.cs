using System.Web;
using System.Web.Optimization;

namespace QuanLyNhanSu
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // datatable
            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                      "~/Scripts/dataTable/datatables.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/customjs/activedatatable.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/bootstrap.min.css",
                     "~/Content/bootstrap.css.map",
                     "~/Content/boostrap.min.css.map",
                     "~/Content/css/font-awesome.min.css",
                     "~/Content/css/account.css",
                     "~/Content/site.css",
                     "~/Content/css/index.css"));
            bundles.Add(new StyleBundle("~/Content/Admin/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap.min.css",
                        "~/Content/bootstrap.css.map",
                        "~/Content/boostrap.min.css.map",
                        "~/Content/datatables.min.css",
                        "~/Content/css/font-awesome.min.css",
                        "~/Content/sb-admin.css"));

        }
    }
}
