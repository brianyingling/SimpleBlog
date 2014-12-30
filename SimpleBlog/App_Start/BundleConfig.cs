using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SimpleBlog.App_Start

    // comes with a script bundle and a style bundle
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new StyleBundle("~/admin/styles")
                    .Include("~/Content/Styles/bootstrap.css")
                    .Include("~/Content/Styles/admin.css"));

            bundles.Add(new StyleBundle("~/Styles")
                    .Include("~/Content/Styles/bootstrap.css")
                    .Include("~/Content/Styles/Site.css"));

            bundles.Add(new ScriptBundle("~/admin/scripts")
                    .Include("~/Scripts/jquery-2.1.1.js")
                    .Include("~/Scripts/jquery.validate.js")
                    .Include("~/Scripts/jquery.validate.unobtrusive.js")
                    .Include("~/Scripts/bootstrap.js")
                    .Include("~/areas/admin/scripts/forms.js"));


            bundles.Add(new ScriptBundle("~/scripts")
                    .Include("~/Scripts/jquery-2.1.1.js")
                    .Include("~/Scripts/jquery.validate.js")
                    .Include("~/Scripts/jquery.validate.unobtrusive.js")
                    .Include("~/Scripts/bootstrap.js"));
        }
    }
}