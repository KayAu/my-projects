using GreatSavings.Helper;
using GreatSavings.Models;
using GreatSavings.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
//using System.Web.Http;
using System.Web.Mvc;

namespace GreatSavings.Controllers
{
    public class ProductSubmissionController : Controller
    {
        private GreatSavingsEntities db = new GreatSavingsEntities();
        //
        // GET: /ProductSubmission/
        public ActionResult Index()
        {
            var products = db.Products.Where(p => p.Payable == true);
            return View(products.ToList());
        }

        public ActionResult ProductList()
        {
            var products = db.Products.Where(p => p.Payable == true);

            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            string jsonString = JsonConvert.SerializeObject(products, Formatting.None, settings);

            return View((object)jsonString);
        }

        [HttpPost]
        public ActionResult ProductList(FormCollection form)
        {
            try
            {
                // TODO: Add insert logic here
                Session["SelectedProducts"] = form["selectedProducts"];
                return RedirectToAction("Subscribe");
                //return RedirectToAction("Login", "Account");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ProductSubmission/Deals/
        public ActionResult Deals()
        {
            return View();
        }

        //
        // GET: /ProductSubmission/Directory/
        public ActionResult Directory()
        {
            return View();
        }

        //
        // GET: /ProductSubmission/Directory/
        public ActionResult LoadDirectoryModel()
        {
            BusinessOperation bizOperations = new BusinessOperation();
            DirectoryViewModel merchantModel = new DirectoryViewModel();

            merchantModel.BusinessIndustries = db.BusinessIndustries.ToList().Select(b => new KeyValuePair<int, string>(b.BusIndustryId, b.BusIndustry)).ToList();
            merchantModel.Countries = db.Countries.ToList();
            merchantModel.States = db.States.ToList();
            merchantModel.OperatingHours = new SelectList(bizOperations.Hours);     // get the hours for business operation
            merchantModel.OperatingMinutes = new SelectList(bizOperations.Minutes); // get the minutes for business operation
            merchantModel.OperatingPeriod = new SelectList(bizOperations.Period);   // get the period for business operation          
            merchantModel.Merchant.CompanyName = "Testing";
            return Json(merchantModel, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /ProductSubmission/Directory/
        public ActionResult LoadDealModel()
        {
            Deal dealModel = new Deal();
         
            dealModel.Title = "Testing";
            // return PartialView(merchantModel);
            return Json(dealModel, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /ProductSubmission/OpeningModel/
        public ActionResult LoadNewOpeningModel()
        {
            NewOpening newOpeningModel = new NewOpening();

            newOpeningModel.Description = "Testing";
            // return PartialView(merchantModel);
            return Json(newOpeningModel, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /ProductSubmission/Recommendation/
        public ActionResult LoadRecommendationModel()
        {
            Recommendation recommendationModel = new Recommendation();

            recommendationModel.Description = "Testing";
            // return PartialView(merchantModel);
            return Json(recommendationModel, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /ProductSubmission/Advertisement/
        public ActionResult LoadAdvertisementModel()
        {
            Advertisement advertisementModel = new Advertisement();

            advertisementModel.ExpiryDate = DateTime.Now;
            // return PartialView(merchantModel);
            return Json(advertisementModel, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /ProductSubmission/Create
        public ActionResult Subscribe()
        {
            if (Session["SelectedProducts"] != null)
            {
                // Step 1: get the services selected from session 
                string jsonString = Session["SelectedProducts"].ToString();

                // Step 2: load the partial view 
                return View((object)jsonString);
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /ProductSubmission/Create
        public ActionResult Promotion()
        {
           
                return View();
            
        }

        //
        // GET: /ProductSubmission/Create
        public ActionResult GetForm(int productId)
        {
            switch  (productId)
            {
                case 0:
                    return PartialView("~/Views/Account/Register.cshtml");
                case 1: // Adevertisement

                case 2:   // Deals
                    // load the partial view 
                    return PartialView("~/Views/ProductSubmission/Deals.cshtml");
                case 3:   // Directory Listing
                    // load the partial view 

                   //return RedirectToAction("Directory");
                   return PartialView("~/Views/ProductSubmission/Directory.cshtml");
                case 4: // New Opening
                   // load the partial view 
                   return PartialView("~/Views/ProductSubmission/NewOpening.cshtml");
                case 5: // Recommendation
                   // load the partial view 
                   return PartialView("~/Views/ProductSubmission/Recommendation.cshtml");
                default:
                    return View();
            }
        }


    }
}
