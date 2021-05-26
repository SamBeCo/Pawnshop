using System.Web;
using System.Web.Optimization;

namespace PawnshopUnchuMVC
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundle.min.js",
                      "~/Scripts/jquery.dataTables.js",
                      "~/Scripts/jquery.easing.compatibility.js",
                      "~/Scripts/jquery.easing.min.js",
                      "~/Scripts/jquery.easing.js",
                      "~/Scripts/Chart.bundle.js",
                      "~/Scripts/site.js",
                      "~/Scripts/sb-admin.min.js",
                      "~/Scripts/chart-area-demo.js",
                      "~/Scripts/datatables-demo.js",
                      "~/Scripts/sweetalert.min.js",
                      "~/Scripts/dataTables.bootstrap4.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",                   
                      "~/Content/Site.css",
                      "~/Content/all.css",
                      "~/Content/sweetalert.css",
                      "~/Content/all.min.css",
                      "~/Content/dataTables.bootstrap4.css",
                      "~/Content/sb-admin.css",
                      "~/Content/bootstrap.min.css"
                      ));
        }
    }
}
