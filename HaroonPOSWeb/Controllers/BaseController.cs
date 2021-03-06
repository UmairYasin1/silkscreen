﻿using HaroonPOSWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaroonPOSWeb.Controllers
{
    public class BaseController : Controller
    {
        public HaroonPOSWebEntities db = new HaroonPOSWebEntities();        

        public string checkUserAdmin()
        {
            var userId = "";
            if (Request.Cookies.AllKeys.Contains("UserCookies"))
            {
                userId = Request.Cookies["UserCookies"]["LogedAdminUserID"];
            }
            else
            {
                userId = "0";
            }
            DataController data = new DataController();
            LoginViewModel test = data.LoadModelAdminUser<LoginViewModel>("user_" + userId + ".json");
            if (test != null)
            {
                Session["LogedAdminUserID"] = test.UserId.ToString();
                return test.UserId.ToString();
            }
            else
            {
                Session["LogedAdminUserID"] = null;
                return null;
            }

        }

        public bool checkIfUserFileExistAdmin()
        {
            try
            {
                string adminLoginJsonFolder = ConfigurationManager.AppSettings["AdminLoginJsonFolder"];
                var userId = Request.Cookies["UserCookies"]["LogedAdminUserID"];
                string loginJsonFile = "user_" + userId + ".json";
                string path = System.Web.HttpContext.Current.Server.MapPath(adminLoginJsonFolder);

                if (System.IO.File.Exists(Path.Combine(path, loginJsonFile)))
                {
                    System.IO.File.Delete(Path.Combine(path, loginJsonFile));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public void GetMaterialInPurchaserList()
        {
            List<MaterialInPurchaser> listMatInPurchaser = db.MaterialInPurchasers.ToList();
            ViewBag.MatInPurchaserList = new SelectList(listMatInPurchaser, "MatInPurchaserId", "Name");
        }

        public void GetMonthList()
        {
            List<Month> listMonth = db.Months.ToList();
            ViewBag.MonthList = new SelectList(listMonth, " MonthId", "MonthName");
        }

        public void GetYearList()
        {
            List<Year> listYear = db.Years.ToList();
            ViewBag.YearList = new SelectList(listYear, "YearId", "YearName");
        }

        public void GetMaterialOutPartyList()
        {
            List<MaterialOutParty> listMatOutParty = db.MaterialOutParties.ToList();
            ViewBag.MaterialOutPartiesList = new SelectList(listMatOutParty, "MatOutPartyId", "Name");
        }

        public void GetMaterialOutItemList()
        {
            List<MaterialOutItem> listMatOutItems = db.MaterialOutItems.ToList();
            ViewBag.MaterialOutItemsList = new SelectList(listMatOutItems, "MaterialOutItemId", "Name");
        }
    }
}