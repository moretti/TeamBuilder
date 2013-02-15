using System.Web;
using System.Web.Optimization;

namespace TeamBuilder
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/main-js").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootstrap-datepicker.js",
                "~/Scripts/main.js"));

            bundles.Add(new StyleBundle("~/bundles/main-css").Include(
                "~/Content/bootstrap.css",
                "~/Content/datepicker.css",
                "~/Content/main.css",
                "~/Content/bootstrap-responsive.css"));
        }
    }
}