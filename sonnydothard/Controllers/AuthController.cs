using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using sonnydothard.Models;

namespace sonnydothard.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
       [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new Users
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(Users model)
        {
            return View(model);
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Auth");
        }
    }
}