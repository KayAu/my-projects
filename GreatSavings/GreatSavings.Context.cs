﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GreatSavings
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    
    public partial class GreatSavingsEntities : DbContext
    {
        public GreatSavingsEntities()
            : base("name=GreatSavingsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<BusinessIndustry> BusinessIndustries { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PromotionsType> PromotionsTypes { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdvertisementType> AdvertisementTypes { get; set; }
        public DbSet<Directory> Directories { get; set; }
        public DbSet<NewOpening> NewOpenings { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<MerchantAccount> MerchantAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
    
        public virtual ObjectResult<Nullable<int>> CreateMerchantAccount(string prUserID)
        {
            var prUserIDParameter = prUserID != null ?
                new ObjectParameter("prUserID", prUserID) :
                new ObjectParameter("prUserID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CreateMerchantAccount", prUserIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> CheckEmailAlreadyExist(string prEmail)
        {
            var prEmailParameter = prEmail != null ?
                new ObjectParameter("prEmail", prEmail) :
                new ObjectParameter("prEmail", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CheckEmailAlreadyExist", prEmailParameter);
        }
    }
}
