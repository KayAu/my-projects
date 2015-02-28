using GreatSavings.Models;
using GreatSavings.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreatSavings.Controllers
{
    public class MerchantController : Controller
    {
        private GreatSavingsEntities db = new GreatSavingsEntities();

        //
        // GET: /Merchant/

        public ActionResult Index()
        {
            var merchants = db.Merchants.Include(m => m.BusinessIndustry);
            return View(merchants.ToList());
        }

        //
        // GET: /Merchant/Details/5

        public ActionResult Details(string id = null)
        {
            Merchant merchant = db.Merchants.Find(id);
            if (merchant == null)
            {
                return HttpNotFound();
            }
            return View(merchant);
        }

        ////
        //// GET: /Merchant/Create

        //public ActionResult Create()
        //{
        //    BusinessOperation bizOperations = new BusinessOperation();
        //    MerchantViewModel merchantModel = new MerchantViewModel();
            
        //    //merchantModel.Countries = new SelectList(db.Countries, "CountryCode", "CountryName");
        //    //merchantModel.States = new SelectList(db.States, "StateId", "StateName");
        //    merchantModel.OperatingHours = new SelectList(bizOperations.Hours);     // get the hours for business operation
        //    merchantModel.OperatingMinutes = new SelectList(bizOperations.Minutes); // get the minutes for business operation
        //    merchantModel.OperatingPeriod = new SelectList(bizOperations.Period);   // get the period for business operation

        //    ViewBag.BusIndustryId = new SelectList(db.BusinessIndustries, "BusIndustryId", "BusIndustry");
        //    return View(merchantModel);
        //}

        ////
        //// POST: /Merchant/Create

        //[HttpPost]
        //public ActionResult Create(Merchant merchant)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Merchants.Add(merchant);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        ViewBag.BusIndustryId = new SelectList(db.BusinessIndustries, "BusIndustryId", "BusIndustry", merchant.BusIndustryId);
        //        return View(merchant);
        //    }
        //    catch (DbEntityValidationException e)
        //    {
        //        foreach (var eve in e.EntityValidationErrors)
        //        {
        //            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
        //                eve.Entry.Entity.GetType().Name, eve.Entry.State);
        //            foreach (var ve in eve.ValidationErrors)
        //            {
        //                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
        //                    ve.PropertyName, ve.ErrorMessage);
        //            }
        //        }
        //        throw;
        //    }
        //}

        //
        // GET: /Merchant/Edit/5

        public ActionResult Edit(string id = null)
        {
            Merchant merchant = db.Merchants.Find(id);
            if (merchant == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusIndustryId = new SelectList(db.BusinessIndustries, "BusIndustryId", "BusIndustry", merchant.BusIndustryId);
            return View(merchant);
        }

        //
        // POST: /Merchant/Edit/5

        [HttpPost]
        public ActionResult Edit(Merchant merchant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(merchant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusIndustryId = new SelectList(db.BusinessIndustries, "BusIndustryId", "BusIndustry", merchant.BusIndustryId);
            return View(merchant);
        }

        //
        // GET: /Merchant/Delete/5

        public ActionResult Delete(string id = null)
        {
            Merchant merchant = db.Merchants.Find(id);
            if (merchant == null)
            {
                return HttpNotFound();
            }
            return View(merchant);
        }

        //
        // POST: /Merchant/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            Merchant merchant = db.Merchants.Find(id);
            db.Merchants.Remove(merchant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        public ActionResult Create()
        {
            BusinessOperation bizOperations = new BusinessOperation();
            MerchantViewModel merchantModel = new MerchantViewModel();

            //merchantModel.Countries = new SelectList(db.Countries, "CountryName", "CountryName");
            //merchantModel.States = new SelectList(db.States, "StateName", "StateName");
            //merchantModel.BusinessIndustries = new SelectList(db.BusinessIndustries, "BusIndustryId", "BusIndustry");   // get the period for business operation

            //merchantModel.BusinessIndustries = db.BusinessIndustries.ToList();
            merchantModel.Countries = db.Countries.ToList();
            merchantModel.States = db.States.ToList();
            merchantModel.OperatingHours = new SelectList(bizOperations.Hours);     // get the hours for business operation
            merchantModel.OperatingMinutes = new SelectList(bizOperations.Minutes); // get the minutes for business operation
            merchantModel.OperatingPeriod = new SelectList(bizOperations.Period);   // get the period for business operation          

            return View(merchantModel);
        }

        //
        // POST: /MerchantModel/Create

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MerchantViewModel merchantModel)
        {
            try
            {
                var test = ViewBag.FirstName;
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                if (ModelState.IsValid)
                {
                    HttpPostedFileBase file = Request.Files["ImageData"];

                    merchantModel.Merchant.CompanyImg = ConvertToBytes(file);
                    merchantModel.Merchant.MerchantId = merchantModel.GetNewMerchantId();
                    merchantModel.Merchant.State = merchantModel.SelectedState;
                    merchantModel.Merchant.Country = merchantModel.SelectedCountry;
                    merchantModel.Merchant.BusIndustryId = merchantModel.SelectedIndustry;
                    merchantModel.Merchant.OperateFrom = merchantModel.StartTime; // string.Format("{0}:{1} {2}", merchantModel.SelectedStartHour, merchantModel.SelectedStartMins, merchantModel.SelectedStartPeriod);
                    merchantModel.Merchant.OperateTo = merchantModel.EndTime; // string.Format("{0}:{1} {2}", merchantModel.SelectedEndHour, merchantModel.SelectedEndMins, merchantModel.SelectedEndPeriod);

                    db.Merchants.Add(merchantModel.Merchant);
                    db.SaveChanges();

                    //var user = new ApplicationUser() { UserName = merchantModel.Merchant.Email };
                    //user.Email = merchantModel.Merchant.Email;
                    //user.ConfirmedEmail = false;
                    //var result = await UserManager.CreateAsync(user, merchantModel.Merchant.Password);
                    //if (result.Succeeded)
                    //{
                    //    string senderEmail = "kau@sjm.com";
                    //    System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage(
                    //        new System.Net.Mail.MailAddress(senderEmail, "Web Registration"),
                    //        new System.Net.Mail.MailAddress(merchantModel.Merchant.Email));
                    //    m.Subject = "Email confirmation";
                    //    m.Body = string.Format("Dear {0}<BR/>Thank you for your registration, please click on the below link to complete your registration: <a href=\"{1}\" title=\"User Email Confirm\">{1}</a>", user.UserName, Url.Action("ConfirmEmail", "Account", new { Token = user.Id, Email = user.Email }, Request.Url.Scheme));
                    //    m.IsBodyHtml = true;
                    //    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("usspclient.sjm.com");
                    //    smtp.Credentials = new System.Net.NetworkCredential(senderEmail, "password");
                    //    //smtp.EnableSsl = true;
                    //    //smtp.Send(m);

                    //}

                    return RedirectToAction("Confirmation", "MerchantModel", new { merchantName = merchantModel.Merchant.FirstName });
                }

                //merchantModel.BusinessIndustries = new SelectList(db.BusinessIndustries, "BusIndustryId", "BusIndustry", merchantModel.SelectedIndustry);
                //merchantModel.Countries = new SelectList(db.Countries, "CountryName", "CountryName", merchantModel.SelectedState);
                //merchantModel.States = new SelectList(db.States, "StateName", "StateName", merchantModel.SelectedState);
                return View(merchantModel);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        [AllowAnonymous]
        public ActionResult Confirmation(string merchantName)
        {
            ViewBag.MerchantName = merchantName;

            return View();
        }

    }
}