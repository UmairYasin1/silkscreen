using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaroonPOSWeb.Models
{
    public class MaterialOutPartyModel
    {
        public int MatOutPartyId { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public bool IsActive { get; set; }
    }
}