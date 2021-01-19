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
    public class PaymentController : BaseController
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

        #region material in payment


        [HttpGet]
        public ActionResult MaterialInPaymentList()
        {
            checkUserAdmin();
            if (Session["LogedAdminUserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            var materialInPaymentList = db.MaterialInPayments.ToList();

            List<MaterialInPaymentModel> materialInPaymentModelList = new List<MaterialInPaymentModel>();
            if (materialInPaymentList != null)
            {
                foreach (var item in materialInPaymentList)
                {
                    materialInPaymentModelList.Add(new MaterialInPaymentModel
                    {
                        MaterialInPayId = item.MaterialInPayId,
                        MatInPurchaserId = item.MatInPurchaserId.Value,
                        Payment = item.Payment.Value,
                        Debit = item.Debit.Value,
                        Credit = item.Credit.Value,
                        ShortDescription = item.ShortDescription,
                        CreateDate = item.CreateDate.Value
                    });
                }
            }


            return View(materialInPaymentModelList);

        }


        [HttpGet]
        public ActionResult MaterialInPaymentSetup()
        {
            if (Session["LogedAdminUserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                GetMaterialInPurchaserList();
                return View();
            }
        }


        [HttpPost]
        public ActionResult MaterialInPaymentSetup(MaterialInPaymentModel model)
        {
            MaterialInPayment materialInPayment = db.MaterialInPayments.Where(a => a.MaterialInPayId.Equals(model.MaterialInPayId)).FirstOrDefault();
            if (materialInPayment == null)
            {
                MaterialInPayment newMaterialInPaymentadd = new MaterialInPayment();
                newMaterialInPaymentadd.MatInPurchaserId = model.MatInPurchaserId.Value;
                newMaterialInPaymentadd.Payment = model.Payment.Value;
                newMaterialInPaymentadd.Debit = false;
                newMaterialInPaymentadd.Credit = true;
                newMaterialInPaymentadd.CreateDate = DateTime.Now;
                newMaterialInPaymentadd.ShortDescription = model.ShortDescription;
                newMaterialInPaymentadd.LongDescription = model.LongDescription;
                db.MaterialInPayments.Add(newMaterialInPaymentadd);
                db.SaveChanges();
                ModelState.Clear();
                model = null;
                this.AddNotification("Thats great! Successfully Saved.", NotificationType.SUCCESS);
            }
            else
            {
                materialInPayment.MatInPurchaserId = model.MatInPurchaserId.Value;
                materialInPayment.Payment = model.Payment.Value;
                materialInPayment.ShortDescription = model.ShortDescription;
                materialInPayment.LongDescription = model.LongDescription;
                db.SaveChanges();
                model = null;
                this.AddNotification("Thats great! Successfully Edited.", NotificationType.SUCCESS);
            }
            return RedirectToAction("MaterialInPaymentList");
        }


        [HttpGet]
        public ActionResult MaterialInPaymentEditView(int MaterialInPayId)
        {
            GetMaterialInPurchaserList();
            MaterialInPaymentModel model = new MaterialInPaymentModel();
            MaterialInPayment newFitCat = db.MaterialInPayments.Where(a => a.MaterialInPayId.Equals(MaterialInPayId)).FirstOrDefault();
            if (newFitCat != null)
            {
                model.MatInPurchaserId = newFitCat.MatInPurchaserId.Value;
                model.Payment = newFitCat.Payment.Value;
                model.ShortDescription = newFitCat.ShortDescription;
                model.LongDescription = newFitCat.LongDescription;
            }
            return View("MaterialInPaymentSetup", model);
        }


        public ActionResult ViewMaterialInPayment(int MaterialInPayId)
        {
            List<MaterialInPayment> listitem = db.MaterialInPayments.Where(x => x.MaterialInPayId == MaterialInPayId).ToList();
            List<MaterialInPaymentModel> list = new List<MaterialInPaymentModel>();
            foreach (var item in listitem)
            {
                var purchaserName = db.MaterialInPurchasers.Where(x => x.MatInPurchaserId.Equals(item.MatInPurchaserId.Value)).FirstOrDefault();

                list.Add(new MaterialInPaymentModel()
                {
                    MaterialInPayId = item.MaterialInPayId,
                    MatInPurchaserId = item.MatInPurchaserId.Value,
                    Payment = item.Payment.Value,
                    MatInPurchaserName = purchaserName.Name,
                    ShortDescription = item.ShortDescription,
                    LongDescription = item.LongDescription
                });
            }
            ViewBag.ViewMaterialInPaymentDataList = list;
            return PartialView("_ViewMaterialInPayment");

        }

        [HttpPost]
        public ActionResult DeleteMaterialInPayment(int MaterialInPayId)
        {
            MaterialInPayment newFitCat = db.MaterialInPayments.Where(a => a.MaterialInPayId.Equals(MaterialInPayId)).FirstOrDefault();
            if (newFitCat != null)
            {
                db.Entry(newFitCat).State = EntityState.Deleted;
                db.SaveChanges();
                ModelState.Clear();
                return Json(new { success = true, message = "Payment Delete" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { error = true, message = "Unsuccessfull" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
    }
}