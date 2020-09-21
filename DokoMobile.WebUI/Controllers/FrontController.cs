using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DokoMobile.WebUI.Controllers
{
    public class FrontController : Controller
    {
        // GET: Front
        public ActionResult MainPage()
        {
            return View();
        }
    }
}