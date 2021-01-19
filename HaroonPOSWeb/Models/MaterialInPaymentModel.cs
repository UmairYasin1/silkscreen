using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaroonPOSWeb.Models
{
    public class MaterialInPaymentModel
    {
        public int MaterialInPayId { get; set; }

        [Required]
        public Nullable<int> MatInPurchaserId { get; set; }

        public string MatInPurchaserName { get; set; }

        [Required]
        public Nullable<decimal> Payment { get; set; }

        public Nullable<bool> Debit { get; set; }

        public Nullable<bool> Credit { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string LongDescription { get; set; }

        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}