using System.Web;
using System.Web.Optimization;

namespace MK_KupSkorer.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new Bundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new Bundle("~/bundles/datatables").Include(
            "~/Scripts/DataTables/jquery.dataTables.js",
            "~/Scripts/DataTables/jquery.dataTables.min.js",
            "~/Scripts/DataTables/dataTables.bootstrap.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new Bundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/Content/datatable").Include(
                  "~/Content/DataTables/css/dataTables.bootstrap.css"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/moment.min.js",
                      "~/Scripts/bootstrap-sortable.js"));

            bundles.Add(new Bundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstratp-sortable.css",
                      "~/Content/site.css"));
        }
    }
}
