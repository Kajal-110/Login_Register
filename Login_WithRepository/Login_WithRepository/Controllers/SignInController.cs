using Login_WithRepository.Models.Models;
using Login_WithRepository.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_WithRepository.Controllers
{
    public class SignInController : Controller
    {
        IUser UserInterface;
        public SignInController( IUser UserInterface)
        {
            this.UserInterface = UserInterface;
        }


        // GET: SignIn
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login( UserModel userModel)
        {
            string Login = UserInterface.Login(userModel);
            if (Login == "Invalid Email" || Login == "Invalid Password" || Login == "invalid email and Password")
            {
                TempData["Error"] = Login;
                return View();
            }
            else
            {
                Session["Email"] = Login;
                return RedirectToAction("Index", "DashBoard");
            }
        }
        public ActionResult Logout()
        {
            try
            {
                Session.Abandon();
                return RedirectToAction("Login");
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
    }
}