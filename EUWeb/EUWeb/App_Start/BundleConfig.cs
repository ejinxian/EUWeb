using System.Web;
using System.Web.Optimization;

namespace EUWeb
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/jquery-ui-1.11.4.js",
                         "~/Scripts/comm.js",
                        "~/Scripts/ajaxAutoSearch.js" ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                     // "~/Content/themes/base/all.css",
                     "~/image/global/css/components.css",
                     //"~/Content/site.css",
                      "~/Content/index01.css"));

            //经销商
            bundles.Add(new StyleBundle("~/Content/dealer").Include(
                     "~/Content/dealerSite.css"));
            bundles.Add(new ScriptBundle("~/bundles/dealer").Include(
                     "~/Scripts/dealer/dealer.js"));
            //供应商
            bundles.Add(new StyleBundle("~/Content/supplier").Include(
                     "~/Content/supplierSite.css"));
            bundles.Add(new ScriptBundle("~/bundles/supplier").Include(
                     "~/Scripts/supplier/supplier.js"));
        }
    }
}
