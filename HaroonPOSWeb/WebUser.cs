//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HaroonPOSWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class WebUser
    {
        public int UserId { get; set; }
        public string UserGuidId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Nullable<int> Country { get; set; }
        public Nullable<int> City { get; set; }
        public Nullable<int> State { get; set; }
        public Nullable<int> Zipcode { get; set; }
        public string UserEmail { get; set; }
        public Nullable<int> Gender { get; set; }
        public Nullable<bool> IsUserActive { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public Nullable<bool> IsBlocked { get; set; }
        public string ProfileImage { get; set; }
        public string CoverImage { get; set; }
        public string DeviceId { get; set; }
        public string HeadLine { get; set; }
    }
}
