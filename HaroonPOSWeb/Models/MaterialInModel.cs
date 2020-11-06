using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaroonPOSWeb.Models
{
    public class MaterialInModel
    {
        public int MaterialInId { get; set; }

        public string MaterialInNo { get; set; }

        [Required(ErrorMessage ="Select purchaser")]
        public Nullable<int> MatInPurchaserId { get; set; }

        public string MatInPurchaserName { get; set; }

        [Required(ErrorMessage = "Fill item")]
        public string PurchaseItem { get; set; }

        [Required]
        public Nullable<int> Quantity { get; set; }

        [Required]
        public Nullable<decimal> Rate { get; set; }

        public Nullable<bool> IsDebit { get; set; }
        public Nullable<bool> IsCredit { get; set; }

        [Required]
        public string Quality { get; set; }

        [Required]
        public Nullable<int> Size { get; set; }

        [Required]
        public Nullable<decimal> Cartridge { get; set; }

        public Nullable<System.DateTime> CreateDate { get; set; }

        public Nullable<bool> IsActive { get; set; }
    }
}