using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VmkPlasticos.Controllers
{
    public class ProductsKaController : Controller
    {
        // GET: ProductsKa
        public ActionResult Index(string product = null, string line = null)
        {
            if (line != null)
            {
                if (product == null)
                {
                    var path = "~/Views/ProductsKa/" + line + "/" + line + ".cshtml";
                    return View(path);
                }
                else
                {
                    var path = "~/Views/ProductsKa/" + line + "/";
                    path += product + ".cshtml";
                    return View(path);
                }
            }
            return View();
        }
    }
}