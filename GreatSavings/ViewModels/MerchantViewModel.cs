using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GreatSavings.ViewModels
{
    public class MerchantViewModel
    {
       // public Merchant Merchant { get; set; }
        //public SelectList States { get; set; }
        //public SelectList Countries { get; set; }
        public List<State> States { get; set; }
        public List<Country> Countries { get; set; }
        public List<KeyValuePair<int, string>> BusinessIndustries { get; set; }
        public SelectList OperatingHours{ get; set; }
        public SelectList OperatingMinutes{ get; set; }
        public SelectList OperatingPeriod{ get; set; }
        //public SelectList BusinessIndustries { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        [Required(ErrorMessage = "Please select a state")]
        public string SelectedState { get; set; }
        public string SelectedCountry { get; set; }
        public string SelectedStartHour { get; set; }
        public string SelectedStartMins { get; set; }
        public string SelectedStartPeriod { get; set; }
        public string SelectedEndHour { get; set; }
        public string SelectedEndMins { get; set; }
        public string SelectedEndPeriod { get; set; }
        public int SelectedIndustry{ get; set; }
        private GreatSavingsEntities db = new GreatSavingsEntities();

        public MerchantViewModel()
        {
           // this.Merchant = new Merchant();
           // this.SelectedCountry = new SelectListItem();
            
        }

        public int GetNewMerchantId()
        {
            int newId = 100001;

            //if (db.Merchants.Count() > 0)
            //{
            //    var result = db.Merchants.Where(m => m.MerchantId > 0).Max(m => m.MerchantId);
            //    newId = result+=1;
            //}
  
            return newId;
        }
         
    }

    //public class LoginViewModel
    //{
    //    [Required]
    //    [Display(Name = "User name")]
    //    public string UserName { get; set; }

    //    [Required]
    //    [DataType(DataType.Password)]
    //    [Display(Name = "Password")]
    //    public string Password { get; set; }


    //}
}