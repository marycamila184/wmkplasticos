using System.Web.Mvc;

namespace VmkPlasticos.Controllers
{
    public class ProductsVmkController : Controller
    {
        public ActionResult Index(string product = null, string line = null)
        {
            if (line != null)
            {
                var path = "~/Views/ProductsVmk/" + line + "/";
                path += product + ".cshtml";
                return View(path);
            }
            return View();
        }
    }
}