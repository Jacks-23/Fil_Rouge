using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quizz.Mvc.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConnexionAdmin()
        {

            return View();
        }

        public ActionResult ConnexionRecruteur()
        {

            return View();
        }

        public ActionResult MenuAdmin()
        {

            return View();
        }

        public ActionResult MenuRecruteur()
        {

            return View();
        }
    }
}