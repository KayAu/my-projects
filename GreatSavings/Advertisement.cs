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
    
    public partial class Advertisement
    {
        public int AdId { get; set; }
        public int TransId { get; set; }
        public System.DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
        public byte[] Image { get; set; }
        public int AdTypeId { get; set; }
        public string DirId { get; set; }
    
        public virtual AdvertisementType AdvertisementType { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
