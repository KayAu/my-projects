using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GreatSavings.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GreatSavings.Controllers
{
    public class ProductController : Controller
    {
        private GreatSavingsEntities db = new GreatSavingsEntities();

        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Deals(int id)
        {
            Deal dealObj = db.Deals.Where(d => d.Id == id).FirstOrDefault();
            
            return View(dealObj);
        }

        public ActionResult DisplayProducts(int productType, int categoryId)
        {
            if (productType == 2)
            {
                // begin to search by product type and  category id
                var results = db.SearchProducts(productType, categoryId, null, null, null).ToList();

                // show the results
                if (results != null || results.Count() > 0)
                {
                    string jsonString = JsonConvert.SerializeObject(results, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
                    return View("~/Views/Product/AllDeals.cshtml", (object)jsonString);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult DisplayProducts(FormCollection form)
        {
            try
            {
                int? start_range = form["start_range"] == null ? (int?)null : Convert.ToInt32(form["start_range"]);
                int? end_range = form["end_range"] == null ? (int?)null : Convert.ToInt32(form["end_range"]);
                int? category = form["category"] == string.Empty ? (int?)null : Convert.ToInt32(form["category"]);
                string location = form["location"] == string.Empty ? null : form["location"].ToString();
                int productType;

                if (form["product-type"] != null && form["product-type"].ToString() != string.Empty)
                {
                    // try parse the product type to integer
                    if (int.TryParse(form["product-type"].ToString(), out productType))
                    {
                        // begin to search when the product type is an integer
                        var results = db.SearchProducts(productType, category, location, start_range, end_range).ToList();

                        // show the results
                        if (results != null || results.Count() > 0)
                        { 
                            if (productType == 2)
                            {
                                string jsonString = JsonConvert.SerializeObject(results, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

                                return View("~/Views/Product/AllDeals.cshtml", (object)jsonString);
                            }
                        }
                    }
                } 
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return View();
        }
    }
}
