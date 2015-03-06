using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GreatSavings.ViewModels
{
    public class DirectoryViewModel
    {
        public Directory Merchant { get; set; }
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

        public DirectoryViewModel()
        {
            this.Merchant = new Directory();
        }

        public int GetNewMerchantId()
        {
            int newId = 100001;
          
            if (db.MerchantAccounts.Count() > 0)
            {
                var result = db.MerchantAccounts.Where(m => m.MerchantId > 0).Max(m => m.MerchantId);
                newId = result+=1;
            }
  
            return newId;
        }
         
    }

}