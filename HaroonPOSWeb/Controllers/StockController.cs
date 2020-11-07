using HaroonPOSWeb.Extensions;
using HaroonPOSWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaroonPOSWeb.Controllers
{
    public class StockController : BaseController
    {
        // GET: Stock
        public ActionResult Index()
        {
            return View();
        }


        #region stock data


        [HttpGet]
        public ActionResult StockDataList()
        {
            checkUserAdmin();
            if (Session["LogedAdminUserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            var stockDataList = db.StockDatas.ToList();

            List<StockDataModel> stockDataModelList = new List<StockDataModel>();
            if (stockDataList != null)
            {
                foreach (var item in stockDataList)
                {
                    stockDataModelList.Add(new StockDataModel
                    {
                        StockDataId = item.StockDataId,
                        ItemName = item.ItemName,
                        Date = item.Date,
                        Quantity = item.Quantity,
                        Rate = item.Rate,                        
                        CreateDate = item.CreateDate.Value,
                        IsActive = item.IsActive.Value
                    });
                }
            }


            return View(stockDataModelList);

        }


        [HttpGet]
        public ActionResult StockDataSetup()
        {
            if (Session["LogedAdminUserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult StockDataSetup(StockDataModel model)
        {
            System.Random random = new System.Random();
            StockData stockData = db.StockDatas.Where(a => a.StockDataId.Equals(model.StockDataId)).FirstOrDefault();
            if (stockData == null)
            {
                StockData stockDataadd = new StockData();
                stockDataadd.ItemName = model.ItemName;
                stockDataadd.Date = model.Date;
                stockDataadd.Quantity = model.Quantity;
                stockDataadd.Rate = model.Rate;
                stockDataadd.CreateDate = DateTime.Now;
                stockDataadd.IsActive = true;
                db.StockDatas.Add(stockDataadd);
                db.SaveChanges();
                ModelState.Clear();
                model = null;
                this.AddNotification("Thats great! Successfully Saved.", NotificationType.SUCCESS);
            }
            else
            {
                stockData.ItemName = model.ItemName;
                stockData.Date = model.Date;
                stockData.Quantity = model.Quantity;
                stockData.Rate = model.Rate;
                db.SaveChanges();
                model = null;
                this.AddNotification("Thats great! Successfully Edited.", NotificationType.SUCCESS);
            }
            return RedirectToAction("StockDataList");
        }


        [HttpGet]
        public ActionResult StockDataEditView(int StockDataId)
        {

            StockDataModel model = new StockDataModel();
            StockData newFitCat = db.StockDatas.Where(a => a.StockDataId.Equals(StockDataId)).FirstOrDefault();
            if (newFitCat != null)
            {
                model.StockDataId = newFitCat.StockDataId;
                model.ItemName = newFitCat.ItemName;
                model.Date = newFitCat.Date;
                model.Quantity = newFitCat.Quantity;
                model.Rate = newFitCat.Rate;
            }
            return View("StockDataSetup", model);
        }


        public ActionResult ViewStockData(int StockDataId)
        {
            List<StockData> listitem = db.StockDatas.Where(x => x.StockDataId == StockDataId).ToList();
            List<StockDataModel> list = new List<StockDataModel>();
            foreach (var item in listitem)
            {
                list.Add(new StockDataModel()
                {
                    ItemName = item.ItemName,
                    Date = item.Date,
                    Quantity = item.Quantity,
                    Rate = item.Rate
                });
            }

            ViewBag.ViewStockDataList = list;
            return PartialView("_ViewStockData");

        }

        [HttpPost]
        public ActionResult DeleteStockData(int StockDataId)
        {
            StockData newFitCat = db.StockDatas.Where(a => a.StockDataId.Equals(StockDataId)).FirstOrDefault();
            if (newFitCat != null)
            {
                db.Entry(newFitCat).State = EntityState.Deleted;
                db.SaveChanges();
                ModelState.Clear();
                return Json(new { success = true, message = "Data Delete" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { error = true, message = "Unsuccessfull" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
    }
}