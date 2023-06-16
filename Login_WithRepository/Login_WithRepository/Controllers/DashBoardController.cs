using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_WithRepository.Controllers
{
    public class DashBoardController : Controller
    {
        [LoginAction]
        // GET: DashBoard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LocalStorge()
        {
            return View();
        }
    }
}