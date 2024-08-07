//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Directory
    {
        public Directory()
        {
            this.Advertisements = new HashSet<Advertisement>();
            this.Deals = new HashSet<Deal>();
            this.NewOpenings = new HashSet<NewOpening>();
            this.Recommendations = new HashSet<Recommendation>();
        }
    
        public string DirId { get; set; }
        public string CompanyName { get; set; }
        public string StreetName { get; set; }
        public int Postcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string OperateFrom { get; set; }
        public string OperateTo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public int BusIndustryId { get; set; }
        public Nullable<bool> IsActivated { get; set; }
        public byte[] CompanyImg { get; set; }
        public Nullable<int> TransId { get; set; }
        public Nullable<int> MerchantId { get; set; }
    
        public virtual ICollection<Advertisement> Advertisements { get; set; }
        public virtual BusinessIndustry BusinessIndustry { get; set; }
        public virtual ICollection<Deal> Deals { get; set; }
        public virtual MerchantAccount MerchantAccount { get; set; }
        public virtual Transaction Transaction { get; set; }
        public virtual ICollection<NewOpening> NewOpenings { get; set; }
        public virtual ICollection<Recommendation> Recommendations { get; set; }
    }
}
