using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaroonPOSWeb.Models
{
    public class MaterialOutModel
    {
        public int MaterialOutId { get; set; }

        public string MaterialOutNo { get; set; }

        [Required(ErrorMessage = "Select party")]
        public Nullable<int> MatOutPartyId { get; set; }

        public string MatOutPartyName { get; set; }

        [Required(ErrorMessage = "Select item")]
        public Nullable<int> MaterialOutItemId { get; set; }

        public string MaterialOutItemName { get; set; }

        [Required]
        public Nullable<int> Quantity { get; set; }

        [Required]
        public Nullable<decimal> Rate { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Nullable<int> DCNumber { get; set; }

        public Nullable<bool> IsDebit { get; set; }

        public Nullable<bool> IsCredit { get; set; }

        public Nullable<System.DateTime> CreateDate { get; set; }

        public Nullable<bool> IsActive { get; set; }
    }
}