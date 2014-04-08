using System.Web;
using System.Web.Optimization;

namespace DigitalResourcesLibrary
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/Bootstrap/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/audioplayer").Include(
                        "~/Scripts/audioplayer.js",
                        "~/Scripts/jquery.autocomplete.js",
                        "~/Scripts/ul-drop.js"));

            bundles.Add(new ScriptBundle("~/bundles/loadpage").Include(
                        "~/Scripts/LoadPage.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/themes/bootstrap/bootstrap.css",
                        "~/Content/themes/bootstrap/audio.css",
                        "~/Content/Site.css",
                        "~/Content/Style.css"));

        }
    }
}