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
    
    public partial class Transaction
    {
        public Transaction()
        {
            this.Advertisements = new HashSet<Advertisement>();
            this.Directories = new HashSet<Directory>();
            this.NewOpenings = new HashSet<NewOpening>();
            this.Recommendations = new HashSet<Recommendation>();
            this.Deals = new HashSet<Deal>();
        }
    
        public int TransId { get; set; }
        public string TransCode { get; set; }
        public int MerchantId { get; set; }
        public decimal TotalPymt { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public bool PymtReceived { get; set; }
    
        public virtual ICollection<Advertisement> Advertisements { get; set; }
        public virtual ICollection<Directory> Directories { get; set; }
        public virtual ICollection<NewOpening> NewOpenings { get; set; }
        public virtual ICollection<Recommendation> Recommendations { get; set; }
        public virtual ICollection<Deal> Deals { get; set; }
        public virtual Merchant Merchant { get; set; }
        public virtual Transaction Transactions1 { get; set; }
        public virtual Transaction Transaction1 { get; set; }
    }
}
