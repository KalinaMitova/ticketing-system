namespace TicketingSystem.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            RegisterScriptBundles(bundles);
            RegisterContentBundles(bundles);

            BundleTable.EnableOptimizations = false; 
        }

        private static void RegisterContentBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(                   
                     "~/Content/bootstrap.css",
                     "~/Content/bootstrap-table.min.css"));

            bundles.Add(new StyleBundle("~/Content/custom").Include(
                     "~/Content/site.css"));
        }

        private static void RegisterScriptBundles(BundleCollection bundles) 
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/kendo/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/scripts/bootstrap-table/bootstrap-table.min.js",
                      "~/Scripts/respond.js"));        
        }
    }
}
