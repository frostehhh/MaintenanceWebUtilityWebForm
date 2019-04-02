using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace MaintenanceWebUtilityWebForm2
{
    public class BundleConfig
    {
        // For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/Scripts/WebForms/WebForms.js",
                            "~/Scripts/WebForms/WebUIValidation.js",
                            "~/Scripts/WebForms/MenuStandards.js",
                            "~/Scripts/WebForms/Focus.js",
                            "~/Scripts/WebForms/GridView.js",
                            "~/Scripts/WebForms/DetailsView.js",
                            "~/Scripts/WebForms/TreeView.js",
                            "~/Scripts/WebForms/WebParts.js"));

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/fontawesome").Include(
                            "~/Scripts/fontawesome/all.js"
                            /*"~/Scripts/fontawesome/brands.js",
                            "~/Scripts/fontawesome/fontawesome.js",
                            "~/Scripts/fontawesome/regular.js",
                            "~/Scripts/fontawesome/solid.js",
                            "~/Scripts/fontawesome/v4-shims.js"*/
                            ));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                            "~/Scripts/jquery.easing.js",
                            "~/Scripts/jquery-3.3.1.min.js"
                            ));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                            "~/Scripts/bootstrap.bundle.min.js"
                            ));
            bundles.Add(new ScriptBundle("~/bundles/sb-admin").Include(
                            "~/Scripts/sb-admin.js"
                            ));
            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                            "~/Scripts/site.js"
                            ));
        }
    }
}