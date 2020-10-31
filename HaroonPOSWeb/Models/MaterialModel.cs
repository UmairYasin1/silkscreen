using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaroonPOSWeb.Models
{
    public class MaterialModel
    {
        public int MaterialId { get; set; }

        public string MaterialNo { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Nullable<int> Quantity { get; set; }

        [Required]
        public Nullable<decimal> Price { get; set; }

        public System.DateTime CreateDate { get; set; }
    }
}