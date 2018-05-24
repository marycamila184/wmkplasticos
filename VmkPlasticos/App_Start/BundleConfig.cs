using System.Web;
using System.Web.Optimization;

namespace VmkPlasticos
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/assetscss").Include(
                      "~/Content/assets/css/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/style").Include(
                      "~/Content/style.css"));

            bundles.Add(new StyleBundle("~/Content/csscolors").Include(
                     "~/Content/css/colors.css"));

            bundles.Add(new StyleBundle("~/Content/csscolors").Include(
                     "~/Content/css/custom.css"));


            bundles.Add(new StyleBundle("~/Content/royalslidercss").Include(
                   "~/Content/royalslider/royalslider.css",
                   "~/Content/royalslider/skins/default-inverted/rs-default-inverted.css"));

            bundles.Add(new StyleBundle("~/Content/layerslidercss").Include(
                   "~/Content/layerslider/css/layerslider.css"));

            bundles.Add(new StyleBundle("~/Content/layersliderskin").Include(
                 "~/Content/layerslider/skins/v5/skin.css"));

            //Import JS files
            bundles.Add(new ScriptBundle("~/bundles/jsjquery").Include(
                        "~/Content/js/jquery.js",
                        "~/Content/js/bootstrap.js",
                        "~/Content/js/fhmm.js",
                        "~/Content/js/jquery.parallax.js",
                        "~/Content/js/jquery.fitvids.js",
                        "~/Content/js/jquery.unveilEffects.js",
                        "~/Content/js/retina-1.1.0.js",
                        "~/Content/js/jquery.jigowatt.js",
                        "~/Content/js/jquery.simple-text-rotator.js",
                        "~/Content/js/application.js"));

            //LayerSlider script files
            bundles.Add(new ScriptBundle("~/bundles/layersliderjs").Include(
                      "~/Content/layerslider/js/greensock.js",
                      "~/Content/layerslider/js/layerslider.transitions.js",
                      "~/Content/layerslider/js/layerslider.kreaturamedia.jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/assets/js/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/assets/js/modernizr-*"));


        }
    }
}
