using System.Web;
using System.Web.Optimization;

namespace Medicaldrugstore
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //------------ Styles Bundles-------------------------///
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/nprogress.css",
                      "~/Content/jquery.mCustomScrollbar.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/custom").Include(
                      "~/Content/custom.css",
                      "~/Content/site.css"
                      ));

            //Styled Bundle for Kendo 
            bundles.Add(new StyleBundle("~/Content/kendo/2017.1.118/kendo").Include(
                      "~/Content/kendo/2017.1.118/kendo.common.min.css",
                      "~/Content/kendo/2017.1.118/kendo.mobile.all.min.css",
                      "~/Content/kendo/2017.1.118/kendo.dataviz.min.css",
                      "~/Content/kendo/2017.1.118/kendo.drug.min.css",
                      "~/Content/kendo/2017.1.118/kendo.dataviz.default.min.css"));



            //------------ Scripts Bundles-------------------------///
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        /*"~/Scripts/jquery-{version}.js"*/
                        "~/Scripts/jquery-2.2.4.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //Theme
            bundles.Add(new ScriptBundle("~/bundles/theme").Include(
                        "~/Scripts/fastclick.js",
                        "~/Scripts/nprogress.js",
                        "~/Scripts/jquery.mCustomScrollbar.concat.min.js",
                        "~/Scripts/custom.js"
                        ));

            //Own JavaScripts
            bundles.Add(new ScriptBundle("~/bundles/own").Include(
                        "~/Scripts/site.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //Kendo Scripts
            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                        //"~/Scripts/kendo/2016.2.714/jquery.min.js",
                        "~/Scripts/kendo/2017.1.118/jszip.min.js",
                        "~/Scripts/kendo/2017.1.118/kendo.all.min.js",
                        "~/Scripts/kendo/2017.1.118/kendo.aspnetmvc.min.js",
                        "~/Scripts/kendo.modernizr.custom.js"
                        ));


           
        }
    }
}
