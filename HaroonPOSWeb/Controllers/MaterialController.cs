﻿using HaroonPOSWeb.Extensions;
using HaroonPOSWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaroonPOSWeb.Controllers
{
    public class MaterialController : BaseController
    {
        // GET: Material
        public ActionResult Index()
        {
            return View();
        }


        #region Material

        //[HttpGet]
        //public ActionResult MaterialList()
        //{
        //    checkUserAdmin();
        //    if (Session["LogedAdminUserID"] == null)
        //    {
        //        return RedirectToAction("Login", "Admin");
        //    }

        //    var materialList = db.Materials.ToList();

        //    List<MaterialModel> materialModelList = new List<MaterialModel>();
        //    if (materialList != null)
        //    {
        //        foreach (var item in materialList)
        //        {
        //            materialModelList.Add(new MaterialModel
        //            {
        //                MaterialId = item.MaterialId,
        //                MaterialNo = item.MaterialNo,
        //                Name = item.Name,
        //                Quantity = item.Quantity,
        //                Price = decimal.Truncate(item.Price.Value),
        //                CreateDate = item.CreateDate.Value

        //            });
        //        }
        //    }


        //    return View(materialModelList);

        //}


        //[HttpGet]
        //public ActionResult MaterialSetup()
        //{
        //    if (Session["LogedAdminUserID"] == null)
        //    {
        //        return RedirectToAction("Login", "Admin");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}


        //[HttpPost]
        //public ActionResult MaterialSetup(MaterialModel model)
        //{
        //    System.Random random = new System.Random();
        //    Material material = db.Materials.Where(a => a.MaterialId.Equals(model.MaterialId)).FirstOrDefault();
        //    if (material == null)
        //    {
        //        Material newMaterialadd = new Material();
        //        newMaterialadd.MaterialNo = "MatNo_" + random.Next();
        //        newMaterialadd.Name = model.Name;
        //        newMaterialadd.Quantity = model.Quantity;
        //        newMaterialadd.Price = model.Price;
        //        newMaterialadd.CreateDate = DateTime.Now;
        //        db.Materials.Add(newMaterialadd);
        //        db.SaveChanges();
        //        ModelState.Clear();
        //        model = null;
        //        this.AddNotification("Thats great! Successfully Saved.", NotificationType.SUCCESS);
        //    }
        //    else
        //    {
        //        material.Name = model.Name;
        //        material.Quantity = model.Quantity;
        //        material.Price = model.Price;
        //        db.SaveChanges();
        //        model = null;
        //        this.AddNotification("Thats great! Successfully Edited.", NotificationType.SUCCESS);
        //    }
        //    return RedirectToAction("MaterialList");
        //}


        //[HttpGet]
        //public ActionResult MaterialEditView(int MaterialId)
        //{
        //    MaterialModel model = new MaterialModel();
        //    Material newFitCat = db.Materials.Where(a => a.MaterialId.Equals(MaterialId)).FirstOrDefault();
        //    if (newFitCat != null)
        //    {
        //        model.MaterialId = newFitCat.MaterialId;
        //        model.MaterialNo = newFitCat.MaterialNo;
        //        model.Name = newFitCat.Name;
        //        model.Quantity = newFitCat.Quantity;
        //        model.Price = decimal.Truncate(newFitCat.Price.Value);
        //    }
        //    return View("MaterialSetup", model);
        //}


        //public ActionResult ViewMaterial(int MaterialId)
        //{
        //    List<Material> listitem = db.Materials.Where(x => x.MaterialId == MaterialId).ToList();
        //    ViewBag.ViewMaterialDataList = listitem;
        //    return PartialView("_ViewMaterial");

        //}

        //[HttpPost]
        //public ActionResult DeleteMaterial(int MaterialId)
        //{
        //    Material newFitCat = db.Materials.Where(a => a.MaterialId.Equals(MaterialId)).FirstOrDefault();
        //    if (newFitCat != null)
        //    {
        //        db.Entry(newFitCat).State = EntityState.Deleted;
        //        db.SaveChanges();
        //        ModelState.Clear();
        //        //this.AddNotification("Fitness Category Delete.", NotificationType.SUCCESS);
        //        return Json(new { success = true, message = "Fitness Category Delete" }, JsonRequestBehavior.AllowGet);
        //        //return RedirectToAction("MaterialList");
        //    }
        //    else
        //    {
        //        //this.AddNotification("Fitness Category Not Deleted.", NotificationType.ERROR);
        //        return Json(new { error = true, message = "Unsuccessfull" }, JsonRequestBehavior.AllowGet);
        //        //return RedirectToAction("MaterialList");
        //    }
        //}

        #endregion

        #region material in purchaser


        [HttpGet]
        public ActionResult MaterialInPurchaserList()
        {
            checkUserAdmin();
            if (Session["LogedAdminUserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            var materialInPurchaserList = db.MaterialInPurchasers.ToList();

            List<MaterialInPurchaserModel> materialInPurchaserModelList = new List<MaterialInPurchaserModel>();
            if (materialInPurchaserList != null)
            {
                foreach (var item in materialInPurchaserList)
                {
                    materialInPurchaserModelList.Add(new MaterialInPurchaserModel
                    {
                        MatInPurchaserId = item.MatInPurchaserId,
                        Name = item.Name,
                        OpeningBalance = item.OpeningBalance.Value,
                        CreateDate = item.CreateDate.Value,
                        IsActive = item.IsActive.Value                        
                    });
                }
            }


            return View(materialInPurchaserModelList);

        }


        [HttpGet]
        public ActionResult MaterialInPurchaserSetup()
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
        public ActionResult MaterialInPurchaserSetup(MaterialInPurchaserModel model)
        {
            MaterialInPurchaser materialInPurchaser = db.MaterialInPurchasers.Where(a => a.MatInPurchaserId.Equals(model.MatInPurchaserId)).FirstOrDefault();
            if (materialInPurchaser == null)
            {
                MaterialInPurchaser newMaterialInPurchaseradd = new MaterialInPurchaser();
                newMaterialInPurchaseradd.Name = model.Name;
                newMaterialInPurchaseradd.OpeningBalance = model.OpeningBalance;
                newMaterialInPurchaseradd.CreateDate = DateTime.Now;
                //newMaterialInPurchaseradd.IsActive = model.IsActive;
                newMaterialInPurchaseradd.IsActive = true;
                db.MaterialInPurchasers.Add(newMaterialInPurchaseradd);
                db.SaveChanges();
                ModelState.Clear();
                model = null;
                this.AddNotification("Thats great! Successfully Saved.", NotificationType.SUCCESS);
            }
            else
            {
                materialInPurchaser.Name = model.Name;
                materialInPurchaser.OpeningBalance = model.OpeningBalance;
                //materialInPurchaser.IsActive = model.IsActive;
                materialInPurchaser.IsActive = true;
                db.SaveChanges();
                model = null;
                this.AddNotification("Thats great! Successfully Edited.", NotificationType.SUCCESS);
            }
            return RedirectToAction("MaterialInPurchaserList");
        }


        [HttpGet]
        public ActionResult MaterialInPurchaserEditView(int MatInPurchaserId)
        {
            MaterialInPurchaserModel model = new MaterialInPurchaserModel();
            MaterialInPurchaser newFitCat = db.MaterialInPurchasers.Where(a => a.MatInPurchaserId.Equals(MatInPurchaserId)).FirstOrDefault();
            if (newFitCat != null)
            {
                model.Name = newFitCat.Name;
                model.OpeningBalance = newFitCat.OpeningBalance.Value;
                model.IsActive = newFitCat.IsActive.Value;
            }
            return View("MaterialInPurchaserSetup", model);
        }


        public ActionResult ViewMaterialInPurchaser(int MatInPurchaserId)
        {
            List<MaterialInPurchaser> listitem = db.MaterialInPurchasers.Where(x => x.MatInPurchaserId == MatInPurchaserId).ToList();
            ViewBag.ViewMaterialInPurchaserDataList = listitem;
            return PartialView("_ViewMaterialInPurchaser");

        }

        [HttpPost]
        public ActionResult DeleteMaterialInPurchaser(int MatInPurchaserId)
        {
            MaterialInPurchaser newFitCat = db.MaterialInPurchasers.Where(a => a.MatInPurchaserId.Equals(MatInPurchaserId)).FirstOrDefault();
            if (newFitCat != null)
            {
                db.Entry(newFitCat).State = EntityState.Deleted;
                db.SaveChanges();
                ModelState.Clear();
                return Json(new { success = true, message = "Purchaser Delete" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { error = true, message = "Unsuccessfull" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion


        #region material out item


        [HttpGet]
        public ActionResult MaterialOutItemList()
        {
            checkUserAdmin();
            if (Session["LogedAdminUserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            var materialOutItemList = db.MaterialOutItems.ToList();

            List<MaterialOutItemModel> materialOutItemnModelList = new List<MaterialOutItemModel>();
            if (materialOutItemList != null)
            {
                foreach (var item in materialOutItemList)
                {
                    materialOutItemnModelList.Add(new MaterialOutItemModel
                    {
                        MaterialOutItemId = item.MaterialOutItemId,
                        Name = item.Name,
                        CreateDate = item.CreateDate.Value,
                        IsActive = item.IsActive.Value
                    });
                }
            }


            return View(materialOutItemnModelList);

        }


        [HttpGet]
        public ActionResult MaterialOutItemSetup()
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
        public ActionResult MaterialOutItemSetup(MaterialOutItemModel model)
        {
            MaterialOutItem materialOutItem = db.MaterialOutItems.Where(a => a.MaterialOutItemId.Equals(model.MaterialOutItemId)).FirstOrDefault();
            if (materialOutItem == null)
            {
                MaterialOutItem newMaterialOutItemadd = new MaterialOutItem();
                newMaterialOutItemadd.Name = model.Name;
                newMaterialOutItemadd.CreateDate = DateTime.Now;
                //newMaterialOutItemadd.IsActive = model.IsActive;
                newMaterialOutItemadd.IsActive = true;
                db.MaterialOutItems.Add(newMaterialOutItemadd);
                db.SaveChanges();
                ModelState.Clear();
                model = null;
                this.AddNotification("Thats great! Successfully Saved.", NotificationType.SUCCESS);
            }
            else
            {
                materialOutItem.Name = model.Name;
                //materialOutItem.IsActive = model.IsActive;
                materialOutItem.IsActive = true;
                db.SaveChanges();
                model = null;
                this.AddNotification("Thats great! Successfully Edited.", NotificationType.SUCCESS);
            }
            return RedirectToAction("MaterialOutItemList");
        }


        [HttpGet]
        public ActionResult MaterialOutItemEditView(int MaterialOutItemId)
        {
            MaterialOutItemModel model = new MaterialOutItemModel();
            MaterialOutItem newFitCat = db.MaterialOutItems.Where(a => a.MaterialOutItemId.Equals(MaterialOutItemId)).FirstOrDefault();
            if (newFitCat != null)
            {
                model.Name = newFitCat.Name;
                model.IsActive = newFitCat.IsActive.Value;
            }
            return View("MaterialOutItemSetup", model);
        }


        public ActionResult ViewMaterialOutItem(int MaterialOutItemId)
        {
            List<MaterialOutItem> listitem = db.MaterialOutItems.Where(x => x.MaterialOutItemId == MaterialOutItemId).ToList();
            ViewBag.ViewMaterialOutItemDataList = listitem;
            return PartialView("_ViewMaterialOutItem");

        }

        [HttpPost]
        public ActionResult DeleteMaterialOutItem(int MaterialOutItemId)
        {
            MaterialOutItem newFitCat = db.MaterialOutItems.Where(a => a.MaterialOutItemId.Equals(MaterialOutItemId)).FirstOrDefault();
            if (newFitCat != null)
            {
                db.Entry(newFitCat).State = EntityState.Deleted;
                db.SaveChanges();
                ModelState.Clear();
                return Json(new { success = true, message = "Item Delete" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { error = true, message = "Unsuccessfull" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region material out party


        [HttpGet]
        public ActionResult MaterialOutPartyList()
        {
            checkUserAdmin();
            if (Session["LogedAdminUserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            var materialOutPartiesList = db.MaterialOutParties.ToList();

            List<MaterialOutPartyModel> materialOutPartyModelList = new List<MaterialOutPartyModel>();
            if (materialOutPartiesList != null)
            {
                foreach (var item in materialOutPartiesList)
                {
                    materialOutPartyModelList.Add(new MaterialOutPartyModel
                    {
                        MatOutPartyId = item.MatOutPartyId,
                        Name = item.Name,
                        OpeningBalance = item.OpeningBalance.Value,
                        CreateDate = item.CreateDate.Value,
                        IsActive = item.IsActive.Value
                    });
                }
            }


            return View(materialOutPartyModelList);

        }


        [HttpGet]
        public ActionResult MaterialOutPartySetup()
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
        public ActionResult MaterialOutPartySetup(MaterialOutPartyModel model)
        {
            MaterialOutParty materialOutParty = db.MaterialOutParties.Where(a => a.MatOutPartyId.Equals(model.MatOutPartyId)).FirstOrDefault();
            if (materialOutParty == null)
            {
                MaterialOutParty newMaterialOutPartyadd = new MaterialOutParty();
                newMaterialOutPartyadd.Name = model.Name;
                newMaterialOutPartyadd.OpeningBalance = model.OpeningBalance;
                newMaterialOutPartyadd.CreateDate = DateTime.Now;
                //newMaterialOutPartyadd.IsActive = model.IsActive;
                newMaterialOutPartyadd.IsActive = true;
                db.MaterialOutParties.Add(newMaterialOutPartyadd);
                db.SaveChanges();
                ModelState.Clear();
                model = null;
                this.AddNotification("Thats great! Successfully Saved.", NotificationType.SUCCESS);
            }
            else
            {
                materialOutParty.Name = model.Name;
                materialOutParty.OpeningBalance = model.OpeningBalance;
                //materialOutParty.IsActive = model.IsActive;
                materialOutParty.IsActive = true;
                db.SaveChanges();
                model = null;
                this.AddNotification("Thats great! Successfully Edited.", NotificationType.SUCCESS);
            }
            return RedirectToAction("MaterialOutPartyList");
        }


        [HttpGet]
        public ActionResult MaterialOutPartyEditView(int MatOutPartyId)
        {
            MaterialOutPartyModel model = new MaterialOutPartyModel();
            MaterialOutParty newFitCat = db.MaterialOutParties.Where(a => a.MatOutPartyId.Equals(MatOutPartyId)).FirstOrDefault();
            if (newFitCat != null)
            {
                model.Name = newFitCat.Name;
                model.OpeningBalance = newFitCat.OpeningBalance.Value;
                model.IsActive = newFitCat.IsActive.Value;
            }
            return View("MaterialOutPartySetup", model);
        }


        public ActionResult ViewMaterialOutParty(int MatOutPartyId)
        {
            List<MaterialOutParty> listitem = db.MaterialOutParties.Where(x => x.MatOutPartyId == MatOutPartyId).ToList();
            ViewBag.ViewMaterialOutPartyDataList = listitem;
            return PartialView("_ViewMaterialOutParty");

        }

        [HttpPost]
        public ActionResult DeleteMaterialOutParty(int MatOutPartyId)
        {
            MaterialOutParty newFitCat = db.MaterialOutParties.Where(a => a.MatOutPartyId.Equals(MatOutPartyId)).FirstOrDefault();
            if (newFitCat != null)
            {
                db.Entry(newFitCat).State = EntityState.Deleted;
                db.SaveChanges();
                ModelState.Clear();
                return Json(new { success = true, message = "Deleted" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { error = true, message = "Unsuccessfull" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion



        #region material in data


        [HttpGet]
        public ActionResult MaterialInDataList()
        {
            checkUserAdmin();
            if (Session["LogedAdminUserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            var materialInDataList = db.MaterialIns.ToList();

            List<MaterialInModel> materialInDataModelList = new List<MaterialInModel>();
            if (materialInDataList != null)
            {
                foreach (var item in materialInDataList)
                {
                    materialInDataModelList.Add(new MaterialInModel
                    {
                        MaterialInId = item.MaterialInId,
                        MaterialInNo = item.MaterialInNo,
                        MatInPurchaserId = item.MatInPurchaserId,
                        PurchaseItem = item.PurchaseItem,
                        Quantity = item.Quantity,
                        Rate = item.Rate,
                        IsDebit = item.IsDebit.Value,
                        IsCredit = item.IsCredit.Value,
                        Quality = item.Quality,
                        Size = item.Size,
                        Cartridge = item.Cartridge,
                        CreateDate = item.CreateDate.Value,
                        IsActive = item.IsActive.Value
                    });
                }
            }


            return View(materialInDataModelList);

        }


        [HttpGet]
        public ActionResult MaterialInDataSetup()
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
        public ActionResult MaterialInDataSetup(MaterialInModel model)
        {
            System.Random random = new System.Random();
            MaterialIn materialInData = db.MaterialIns.Where(a => a.MaterialInId.Equals(model.MaterialInId)).FirstOrDefault();
            if (materialInData == null)
            {
                MaterialIn newMaterialInDataadd = new MaterialIn();
                newMaterialInDataadd.MaterialInNo = "MatNo_" + random.Next();
                newMaterialInDataadd.MatInPurchaserId = model.MatInPurchaserId;
                newMaterialInDataadd.PurchaseItem = model.PurchaseItem;
                newMaterialInDataadd.Quantity = model.Quantity;
                newMaterialInDataadd.Rate = model.Rate;
                newMaterialInDataadd.IsDebit = true;
                newMaterialInDataadd.IsCredit = false;
                newMaterialInDataadd.Quality = model.Quality;
                newMaterialInDataadd.Size = model.Size;
                newMaterialInDataadd.Cartridge = model.Cartridge;
                newMaterialInDataadd.CreateDate = DateTime.Now;
                newMaterialInDataadd.IsActive = true;
                db.MaterialIns.Add(newMaterialInDataadd);
                db.SaveChanges();
                ModelState.Clear();
                model = null;
                this.AddNotification("Thats great! Successfully Saved.", NotificationType.SUCCESS);
            }
            else
            {
                materialInData.MatInPurchaserId = model.MatInPurchaserId;
                materialInData.PurchaseItem = model.PurchaseItem;
                materialInData.Quantity = model.Quantity;
                materialInData.Rate = model.Rate;
                materialInData.Quality = model.Quality;
                materialInData.Size = model.Size;
                materialInData.Cartridge = model.Cartridge;
                db.SaveChanges();
                model = null;
                this.AddNotification("Thats great! Successfully Edited.", NotificationType.SUCCESS);
            }
            return RedirectToAction("MaterialInDataList");
        }


        [HttpGet]
        public ActionResult MaterialInDataEditView(int MaterialInId)
        {
            GetMaterialInPurchaserList();
            MaterialInModel model = new MaterialInModel();
            MaterialIn newFitCat = db.MaterialIns.Where(a => a.MaterialInId.Equals(MaterialInId)).FirstOrDefault();
            if (newFitCat != null)
            {
                model.MatInPurchaserId = newFitCat.MatInPurchaserId;
                model.PurchaseItem = newFitCat.PurchaseItem;
                model.Quantity = newFitCat.Quantity;
                model.Rate = newFitCat.Rate;
                model.Quality = newFitCat.Quality;
                model.Size = newFitCat.Size;
                model.Cartridge = newFitCat.Cartridge;
            }
            return View("MaterialInDataSetup", model);
        }


        public ActionResult ViewMaterialInData(int MaterialInId)
        {
            List<MaterialIn> listitem = db.MaterialIns.Where(x => x.MaterialInId == MaterialInId).ToList();
            List<MaterialInModel> list = new List<MaterialInModel>();
            foreach (var item in listitem)
            {
                var purchaserName = db.MaterialInPurchasers.Where(x => x.MatInPurchaserId.Equals(item.MatInPurchaserId.Value)).FirstOrDefault();
                
                list.Add(new MaterialInModel()
                {
                    MatInPurchaserName = purchaserName.Name,
                    PurchaseItem = item.PurchaseItem,
                    Quantity = item.Quantity,
                    Rate = item.Rate,
                    Quality = item.Quality,
                    Size = item.Size,
                    Cartridge = item.Cartridge
                });
            }
            ViewBag.ViewMaterialInDataList = list;
            return PartialView("_ViewMaterialInData");

        }

        [HttpPost]
        public ActionResult DeleteMaterialInData(int MaterialInId)
        {
            MaterialIn newFitCat = db.MaterialIns.Where(a => a.MaterialInId.Equals(MaterialInId)).FirstOrDefault();
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

        #region material in purchaser legder


        [HttpGet]
        public ActionResult MaterialInPurchaserLedgerList()
        {
            checkUserAdmin();
            if (Session["LogedAdminUserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            GetMaterialInPurchaserList();
            return View();

        }

        
        public ActionResult GetMatInPurchaserLegder(int MatInPurchaserId)
        {
            
            var materialInDataList = db.MaterialIns.Where(x => x.MaterialInId.Equals(MatInPurchaserId)).ToList();

            List<MaterialInModel> materialInDataModelList = new List<MaterialInModel>();
            if (materialInDataList != null)
            {
                foreach (var item in materialInDataList)
                {
                    materialInDataModelList.Add(new MaterialInModel
                    {
                        MaterialInId = item.MaterialInId,
                        MaterialInNo = item.MaterialInNo,
                        MatInPurchaserId = item.MatInPurchaserId,
                        PurchaseItem = item.PurchaseItem,
                        Quantity = item.Quantity,
                        Rate = item.Rate,
                        IsDebit = item.IsDebit.Value,
                        IsCredit = item.IsCredit.Value,
                        Quality = item.Quality,
                        Size = item.Size,
                        Cartridge = item.Cartridge,
                        CreateDate = item.CreateDate.Value,
                        IsActive = item.IsActive.Value
                    });
                }
            }


            return View(materialInDataModelList);

        }

        #endregion



        #region material out data


        [HttpGet]
        public ActionResult MaterialOutDataList()
        {
            checkUserAdmin();
            if (Session["LogedAdminUserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            var materialOutDataList = db.MaterialOuts.ToList();

            List<MaterialOutModel> materialOutDataModelList = new List<MaterialOutModel>();
            if (materialOutDataList != null)
            {
                foreach (var item in materialOutDataList)
                {
                    materialOutDataModelList.Add(new MaterialOutModel
                    {
                        MaterialOutId = item.MaterialOutId,
                        MaterialOutNo = item.MaterialOutNo,
                        MatOutPartyId = item.MatOutPartyId,
                        MaterialOutItemId = item.MaterialOutItemId,
                        Quantity = item.Quantity,
                        Rate = item.Rate,
                        Description = item.Description,
                        DCNumber = item.DCNumber,
                        IsDebit = item.IsDebit.Value,
                        IsCredit = item.IsCredit.Value,
                        CreateDate = item.CreateDate.Value,
                        IsActive = item.IsActive.Value
                    });
                }
            }


            return View(materialOutDataModelList);

        }


        [HttpGet]
        public ActionResult MaterialOutDataSetup()
        {
            if (Session["LogedAdminUserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                GetMaterialOutPartyList();
                GetMaterialOutItemList();
                return View();
            }
        }


        [HttpPost]
        public ActionResult MaterialOutDataSetup(MaterialOutModel model)
        {
            System.Random random = new System.Random();
            MaterialOut materialOutData = db.MaterialOuts.Where(a => a.MaterialOutId.Equals(model.MaterialOutId)).FirstOrDefault();
            if (materialOutData == null)
            {
                MaterialOut newMaterialOutDataadd = new MaterialOut();
                newMaterialOutDataadd.MaterialOutNo = "MatNo_" + random.Next();
                newMaterialOutDataadd.MatOutPartyId = model.MatOutPartyId;
                newMaterialOutDataadd.MaterialOutItemId = model.MaterialOutItemId;
                newMaterialOutDataadd.Quantity = model.Quantity;
                newMaterialOutDataadd.Rate = model.Rate;
                newMaterialOutDataadd.Description = model.Description;
                newMaterialOutDataadd.DCNumber = model.DCNumber;
                newMaterialOutDataadd.IsDebit = false;
                newMaterialOutDataadd.IsCredit = true;
                newMaterialOutDataadd.CreateDate = DateTime.Now;
                newMaterialOutDataadd.IsActive = true;
                db.MaterialOuts.Add(newMaterialOutDataadd);
                db.SaveChanges();
                ModelState.Clear();
                model = null;
                this.AddNotification("Thats great! Successfully Saved.", NotificationType.SUCCESS);
            }
            else
            {
                materialOutData.MatOutPartyId = model.MatOutPartyId;
                materialOutData.MaterialOutItemId = model.MaterialOutItemId;
                materialOutData.Quantity = model.Quantity;
                materialOutData.Rate = model.Rate;
                materialOutData.Description = model.Description;
                materialOutData.DCNumber = model.DCNumber;
                db.SaveChanges();
                model = null;
                this.AddNotification("Thats great! Successfully Edited.", NotificationType.SUCCESS);
            }
            return RedirectToAction("MaterialOutDataList");
        }


        [HttpGet]
        public ActionResult MaterialOutDataEditView(int MaterialOutId)
        {
            GetMaterialOutPartyList();
            GetMaterialOutItemList();
            MaterialOutModel model = new MaterialOutModel();
            MaterialOut newFitCat = db.MaterialOuts.Where(a => a.MaterialOutId.Equals(MaterialOutId)).FirstOrDefault();
            if (newFitCat != null)
            {
                model.MatOutPartyId = newFitCat.MatOutPartyId;
                model.MaterialOutItemId = newFitCat.MaterialOutItemId;
                model.Quantity = newFitCat.Quantity;
                model.Rate = newFitCat.Rate;
                model.Description = newFitCat.Description;
                model.DCNumber = newFitCat.DCNumber;
            }
            return View("MaterialOutDataSetup", model);
        }


        public ActionResult ViewMaterialOutData(int MaterialOutId)
        {
            List<MaterialOut> listitem = db.MaterialOuts.Where(x => x.MaterialOutId == MaterialOutId).ToList();
            List<MaterialOutModel> list = new List<MaterialOutModel>();
            foreach (var item in listitem)
            {
                var partyName = db.MaterialOutParties.Where(x => x.MatOutPartyId.Equals(item.MatOutPartyId.Value)).FirstOrDefault();
                var outItem = db.MaterialOutItems.Where(x => x.MaterialOutItemId.Equals(item.MaterialOutItemId.Value)).FirstOrDefault();

                list.Add(new MaterialOutModel()
                {
                    MatOutPartyName = partyName.Name,
                    MaterialOutItemName = outItem.Name,
                    Quantity = item.Quantity,
                    Rate = item.Rate,
                    Description = item.Description,
                    DCNumber = item.DCNumber
                });
            }
            
            ViewBag.ViewMaterialOutDataList = list;
            return PartialView("_ViewMaterialOutData");

        }

        [HttpPost]
        public ActionResult DeleteMaterialOutData(int MaterialOutId)
        {
            MaterialOut newFitCat = db.MaterialOuts.Where(a => a.MaterialOutId.Equals(MaterialOutId)).FirstOrDefault();
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