using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaroonPOSWeb.Models
{
    public class StockDataModel
    {

        public int StockDataId { get; set; }

        [Required(ErrorMessage = "Please fill item")]
        public string ItemName { get; set; }

        //[Required(ErrorMessage = "Please select date")]
        //public Nullable<System.DateTime> Date { get; set; }

        [Required(ErrorMessage = "Please select date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Date { get; set; }

        [Required(ErrorMessage = "Please fill quantity")]
        public Nullable<int> Quantity { get; set; }

        [Required(ErrorMessage = "Please fill rate")]
        public Nullable<decimal> Rate { get; set; }

        public Nullable<System.DateTime> CreateDate { get; set; }

        public Nullable<bool> IsActive { get; set; }
    }
}