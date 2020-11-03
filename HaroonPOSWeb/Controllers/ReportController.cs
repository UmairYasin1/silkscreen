﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace HaroonPOSWeb.Controllers
{
    public class ReportController : BaseController
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult PartyPurchaseLedger()
        {
            GetMaterialInPurchaserList();
            GetMonthList();
            GetYearList();
            return View();
        }


        

        #region download new sales data pdf


        //public FileResult CreatePdfPartyPurchaseLedger(string MatInPurchaserId, string MonthId, string YearId)
        public FileResult CreatePdfPartyPurchaseLedger(string stringValues)
        {

            string[] values = stringValues.Split('?');
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = values[i].Trim();
            }

            var MatInPurchaserId = values[0];
            var MonthId = values[1].Replace("MonthId=", "");
            var YearId = values[2].Replace("YearId=", "");

            int MatInPurchaserIdVal = Convert.ToInt32(MatInPurchaserId);
            int MonthIdVal = Convert.ToInt32(MonthId);
            int YearIdVal = Convert.ToInt32(YearId);

            MemoryStream workStream = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            DateTime dTime = DateTime.Now;
            //file name to be created   
            string strPDFFileName = string.Format("PartyPurchaseLedger.pdf");
            Document doc = new Document();
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table with 5 columns  
            PdfPTable tableLayout = new PdfPTable(7);
            //doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table  

            string strAttachment = Server.MapPath("~/" + strPDFFileName);


            PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            doc.Open();

            //Add Content to PDF   
            doc.Add(Add_Content_To_PDF_NewSales(tableLayout, MatInPurchaserIdVal, MonthIdVal, YearIdVal));

            // Closing the document  
            doc.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            return File(workStream, "application/pdf", strPDFFileName);

        }

        protected PdfPTable Add_Content_To_PDF_NewSales(PdfPTable tableLayout, int MatInPurchaserId, int MonthId, int YearId)
        {

            float[] headers = { 25, 50, 50, 25, 25, 25, 50 }; //Header Widths  
            tableLayout.SetWidths(headers); //Set the pdf headers  
            tableLayout.WidthPercentage = 100; //Set the PDF File witdh percentage  
            tableLayout.HeaderRows = 1;
            //Add Title to the PDF file at the top  

            //List<Customer> employees = db.Customers.Take(5).ToList();
            //var todaySales = db.MaterialIns.Where(x => x.MatInPurchaserId.Value.Equals(MatInPurchaserId)).ToList();
            var purchaser = db.MaterialInPurchasers.Where(x => x.MatInPurchaserId.Equals(MatInPurchaserId)).FirstOrDefault();
            var month = db.Months.Where(x => x.MonthId.Equals(MonthId)).FirstOrDefault();
            var year = db.Years.Where(x => x.YearId.Equals(YearId)).FirstOrDefault();
            int monthVal = MonthId;
            int yearVal = Convert.ToInt32(year.YearName);
            var purchaseItemList = db.MaterialIns.Where(x => x.MatInPurchaserId.Value.Equals(MatInPurchaserId)
                                    && x.CreateDate.Value.Month.Equals(monthVal) 
                                    && x.CreateDate.Value.Year.Equals(yearVal)).ToList();

            tableLayout.AddCell(new PdfPCell(new Phrase("Party purchase ledger of " + purchaser.Name + " according to " + month.MonthName + "-" + year.YearName,
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
            {
                Colspan = 12,
                Border = 0,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_CENTER
            });


            ////Add header  
            AddCellToHeader_NewSales(tableLayout, "Cartridge");
            AddCellToHeader_NewSales(tableLayout, "Purchase Item");
            AddCellToHeader_NewSales(tableLayout, "Quality");
            AddCellToHeader_NewSales(tableLayout, "Quantity");
            AddCellToHeader_NewSales(tableLayout, "Size");
            AddCellToHeader_NewSales(tableLayout, "Rate");
            AddCellToHeader_NewSales(tableLayout, "Sub Amount");

            ////Add body  

            int grandTotal = 0;
            var last = purchaseItemList.Last();
            foreach (var tS in purchaseItemList)
            {
                var cartVal = tS.Cartridge;
                var quantityVal = tS.Quantity;
                var sizeVal = tS.Size;
                var rateVal = tS.Rate;
                var subAmount1 = quantityVal * sizeVal * rateVal;
                int subAmount2 = Convert.ToInt32(cartVal + subAmount1);
                grandTotal += subAmount2;

                AddCellToBody_NewSales(tableLayout, tS.Cartridge.Value.ToString("."));
                AddCellToBody_NewSales(tableLayout, tS.PurchaseItem);
                AddCellToBody_NewSales(tableLayout, tS.Quality);
                AddCellToBody_NewSales(tableLayout, tS.Quantity.Value.ToString());
                AddCellToBody_NewSales(tableLayout, tS.Size.Value.ToString());
                AddCellToBody_NewSales(tableLayout, tS.Rate.Value.ToString("."));
                AddCellToBody_NewSales(tableLayout, subAmount2.ToString("."));

                if (tS.Equals(last))
                {
                    AddCellToBody_NewSales(tableLayout, "");
                    AddCellToBody_NewSales(tableLayout, "");
                    AddCellToBody_NewSales(tableLayout, "");
                    AddCellToBody_NewSales(tableLayout, "");
                    AddCellToBody_NewSales(tableLayout, "");
                    AddCellToBody_NewSales(tableLayout, "");
                    AddCellToBody_NewSales(tableLayout, "Grand Total : " + grandTotal.ToString("."));
                }

            }


            return tableLayout;
        }
        // Method to add single cell to the Header  
        private static void AddCellToHeader_NewSales(PdfPTable tableLayout, string cellText)
        {

            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.YELLOW)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(128, 0, 0)
            });
        }

        // Method to add single cell to the body  
        private static void AddCellToBody_NewSales(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)
            });
        }

        #endregion
    }
}