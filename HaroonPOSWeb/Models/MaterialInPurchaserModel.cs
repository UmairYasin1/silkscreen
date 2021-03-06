﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaroonPOSWeb.Models
{
    public class MaterialInPurchaserModel
    {
        public int MatInPurchaserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Nullable<decimal> OpeningBalance { get; set; }

        [Required(ErrorMessage ="Please select date")]
        public Nullable<System.DateTime> OB_Date { get; set; }

        public Nullable<System.DateTime> CreateDate { get; set; }

        public bool IsActive { get; set; }

    }
}