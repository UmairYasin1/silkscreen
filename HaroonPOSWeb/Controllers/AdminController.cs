using HaroonPOSWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HaroonPOSWeb.Controllers
{
    public class AdminController : BaseController
    {

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        // GET: Admin Login
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            checkUserAdmin();
            if (Session["LogedAdminUserID"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("AdminDashboard", "Home");
            }
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var adminUsers = db.AdminUsers.Where(a => a.UserEmail.Equals(model.Email)
                && a.Password.Equals(model.Password) && a.IsUserActive.Value.Equals(true)).FirstOrDefault();

            if (adminUsers != null)
            {
                //var usrRights = db.UserRights.Where(a => a.CRMUserId.Value.Equals(crmUsers.CRMUser_ID)).FirstOrDefault();
                Session["LogedAdminUserID"] = adminUsers.UserId.ToString();
                Session["LogedAdminRoleName"] = adminUsers.UserRoleName.ToString();
                Session.Timeout = 60;
                Response.Cookies["UserCookies"]["LogedAdminUserID"] = adminUsers.UserId.ToString();
                Response.Cookies["UserCookies"].Expires = DateTime.Now.AddHours(1);

                LoginViewModel modelforFile = new LoginViewModel();
                modelforFile.UserId = adminUsers.UserId;
                modelforFile.Email = adminUsers.UserEmail;
                modelforFile.UserRoleId = adminUsers.UserRoleId;

                DataController data = new DataController();
                data.SaveModelAdminUser(modelforFile, "user_" + adminUsers.UserId.ToString() + ".json");

                return RedirectToAction("AdminDashboard", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session["LogedAdminUserID"] = null;
            Session["LogedAdminRoleName"] = null;
            Response.Cookies["UserCookies"]["LogedAdminUserID"] = null;
            Response.Cookies.Clear();
            Session.Abandon();

            checkIfUserFileExistAdmin();
            return RedirectToAction("Login", "Admin");
        }
    }
}