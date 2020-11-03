using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaroonPOSWeb.Models
{
    public class PartyPurchaseLedgerModel
    {
        [Required(ErrorMessage = "Party Name")]
        public Nullable<int> MatInPurchaserId { get; set; }

        public Nullable<System.DateTime> CreateDate { get; set; }

        [Required(ErrorMessage ="Select Month")]
        public Nullable<int> MonthId { get; set; }

        [Required(ErrorMessage = "Select Year")]
        public Nullable<int> YearId { get; set; }
    }
}