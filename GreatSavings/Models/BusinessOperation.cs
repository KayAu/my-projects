using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreatSavings.Models
{
    public class BusinessOperation
    {
        public List<int> Hours { get; set; }
        public List<int> Minutes { get; set; }
        public List<string> Period { get; set; }

        public BusinessOperation()
        {
            // load the operations hours
            this.LoadHours();

            // load minutes associated to the operating hours
            this.LoadMinutes();

            // load the am/pm 
            this.Period = new List<string>();
            this.Period.AddRange(new string[] { "AM", "PM" });
        }

        private void LoadHours()
        {
            this.Hours = new List<int>();

            for (int hour = 1; hour <= 12; hour++)
            {
                this.Hours.Add(hour);
            }
        }

        private void LoadMinutes()
        {
            this.Minutes = new List<int>();

            for (int min = 5; min <= 55; min += 5)
            {
                this.Minutes.Add(min);
            }
        }
    }
}