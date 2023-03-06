using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CargoManagement.Models;

namespace CargoManagement.Controllers
{
    public class AccountsController : Controller
    {

        public ActionResult Login()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            using (CargoDB context = new CargoDB())
            {
                bool IsValidUser = context.login.Any(user => user.UserName.ToLower() ==
                     model.UserName.ToLower() && user.UserPassword == model.UserPassword);

                if (IsValidUser)
                {

                    // FormsAuthentication.SetAuthCookie(model.UserName, false);

                    FormsAuthentication.SetAuthCookie(model.UserName, true);
                    if (User.IsInRole("Customer") || User.IsInRole("User"))
                    {
                        //FormsAuthentication.SetAuthCookie(model.UserName, false);
                        return RedirectToAction("Display", "Customers");
                    }
                    else if (User.IsInRole("Employee") || User.IsInRole("User"))
                    {
                        //FormsAuthentication.SetAuthCookie(model.UserName, false);
                        return RedirectToAction("Display", "Employees");
                    }
                    else if (User.IsInRole("Admin") || User.IsInRole("User"))
                    {
                        return RedirectToAction("Display", "Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Username or Password");
                        return View();
                    }
                       
                }

                ModelState.AddModelError("", "You Must Sign Up First");
                return View();
            }
        }
        
        public ActionResult GetRole()
        {
            return View();

        }
        public ActionResult GetUser()
        {
            using ( CargoDB context = new CargoDB())
            {
                var user = context.login.Max();
                ViewBag.newuserId = user.ID;

            }
            return View();
        }

        [HttpGet]
        public ActionResult SetRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SetRole(FormCollection f)
        {
            if (Convert.ToInt32(f["Rolename"]) == 1)
            {
                TempData["roleId"] = 1;
                TempData.Keep();
                TempData["Roleselected"] = "Admin :";
                return RedirectToAction("SignUp");

            }
            else if (Convert.ToInt32(f["Rolename"]) == 2)
            {
                TempData["roleId"] = 2;
                TempData.Keep();
                TempData["Roleselected"] = "User :";
                return RedirectToAction("SignUp");
            }
            else
            {
                TempData["roleId"] = 3;
                TempData.Keep();
                TempData["Roleselected"] = "Customer : ";
                return RedirectToAction("SignUp");
            }
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(login model)
        {
            using(CargoDB context = new CargoDB())
            {
                context.login.Add(model);
                context.SaveChanges();
                var maxId = context.login.Max(e => e.ID);
                ViewBag.newuserId = maxId;
                userRolesMapping usermap = new userRolesMapping();
                usermap.ID = maxId;
                usermap.RoleID = Convert.ToInt32(TempData["roleId"]);
                usermap.UserID = maxId;
                context.userRolesMapping.Add(usermap);
                context.SaveChanges();
            }

            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}