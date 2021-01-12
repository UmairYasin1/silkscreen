using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaroonPOSWeb.Models
{
    public class MaterialOutPartyModel
    {
        public int MatOutPartyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Nullable<decimal> OpeningBalance { get; set; }

        public Nullable<System.DateTime> CreateDate { get; set; }

        public bool IsActive { get; set; }
    }
}