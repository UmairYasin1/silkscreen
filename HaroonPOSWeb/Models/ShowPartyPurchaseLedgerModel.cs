using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaroonPOSWeb.Models
{
    public class ShowPartyPurchaseLedgerModel
    {
        public string PartyName { get; set; }
        public string Month { get; set; }
        public int ?Year { get; set; }


        public List<MaterialInModel> MaterialInModelList { get; set; }
    }

}