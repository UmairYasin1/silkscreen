﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HaroonPOSWebEntities : DbContext
    {
        public HaroonPOSWebEntities()
            : base("name=HaroonPOSWebEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AdminUser> AdminUsers { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialIn> MaterialIns { get; set; }
        public virtual DbSet<MaterialInPurchaser> MaterialInPurchasers { get; set; }
        public virtual DbSet<MaterialOut> MaterialOuts { get; set; }
        public virtual DbSet<MaterialOutItem> MaterialOutItems { get; set; }
        public virtual DbSet<MaterialOutParty> MaterialOutParties { get; set; }
        public virtual DbSet<Month> Months { get; set; }
        public virtual DbSet<StockData> StockDatas { get; set; }
        public virtual DbSet<UserRight> UserRights { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<WebUser> WebUsers { get; set; }
        public virtual DbSet<Year> Years { get; set; }
        public virtual DbSet<MaterialInPayment> MaterialInPayments { get; set; }
        public virtual DbSet<MaterialOutPayment> MaterialOutPayments { get; set; }
    }
}
