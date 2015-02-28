using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using GreatSavings.Models;
using GreatSavings.ViewModels;
using System.Data.Entity.Validation;
using GreatSavings.Helper;


namespace GreatSavings.Controllers
{
    public class Account1Controller : Controller
    {
        #region -- PUBLIC PROPERTIES --
        public UserManager<ApplicationUser, string> UserManager { get; private set; } 
        #endregion

        #region -- PRIVATE PROPERTIES --
        private GreatSavingsEntities db = new GreatSavingsEntities();

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        } 
        #endregion

        #region -- CONSTRUCTOR --
        //public Account1Controller()
        //    : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        //{
        //}

        public Account1Controller(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        } 
        #endregion

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        public ActionResult MerchantLogin(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MerchantLogin(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(model.UserName, model.Password); 
                
                if (user != null)
                {
                    if (user.ConfirmedEmail == true)
                    {
                        await SignInAsync(user, false);
                        Session["UserId"] = user.Id;
                        return RedirectToAction("Subscribe", "ProductSubmission");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Confirm Email Address.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return PartialView();
        }

        //
        // GET: /ProductSubmission/Advertisement/
        public ActionResult LoadRegisterModel()
        {
            RegisterViewModel registerModel = new RegisterViewModel();
            ///todo
            ///check this function
            registerModel.FirstName = "Testing";
            return Json(registerModel, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = model.Email };
                user.Email = model.Email;
                user.ConfirmedEmail = false;
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage(
                    //    new System.Net.Mail.MailAddress("sender@mydomain.com", "Web Registration"),
                    //    new System.Net.Mail.MailAddress(user.Email));
                    //m.Subject = "Email confirmation";
                    //m.Body = string.Format("Dear {0}<BR})Thank you for your registration, please click on the below link to complete your registration: <a href=\"{1}\" title=\"User Email Confirm\">{1}</a>", user.UserName, Url.Action("ConfirmEmail", "Account", new { Token = user.Id, Email = user.Email }, Request.Url.Scheme));
                    //m.IsBodyHtml = true;
                    //System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.mydomain.com");
                    //smtp.Credentials = new System.Net.NetworkCredential("sender@mydomain.com", "password");
                    //smtp.EnableSsl = true;
                    //smtp.Send(m);

                    return RedirectToAction("CreateProfile", "Account", new { accountId = user.Id, fName = model.FirstName, lName = model.LastName });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult CreateProfile(string accountId, string fName, string lName)
        {
           // ViewBag.AccountId = accountId;
            //ViewBag.FirstName = fName;
            //ViewBag.LastName = lName;

            BusinessOperation bizOperations = new BusinessOperation();
            MerchantViewModel merchantModel = new MerchantViewModel();

            //merchantModel.Countries = new SelectList(db.Countries, "CountryName", "CountryName");
            //merchantModel.States = new SelectList(db.States, "StateName", "StateName");
            //merchantModel.BusinessIndustries = new SelectList(db.BusinessIndustries, "BusIndustryId", "BusIndustry");   // get the period for business operation
            merchantModel.OperatingHours = new SelectList(bizOperations.Hours);     // get the hours for business operation
            merchantModel.OperatingMinutes = new SelectList(bizOperations.Minutes); // get the minutes for business operation
            merchantModel.OperatingPeriod = new SelectList(bizOperations.Period);   // get the period for business operation          
            merchantModel.Merchant.FirstName = fName;
            merchantModel.Merchant.LastName = lName;
            merchantModel.Merchant.UserId = accountId;

            return View(merchantModel);
        }

        //
        // POST: /MerchantModel/Create

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProfile(MerchantViewModel merchantModel)
        {
            try
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                if (ModelState.IsValid)
                {
                    HttpPostedFileBase file = Request.Files["ImageData"];

                    merchantModel.Merchant.CompanyImg = DataManager.ConvertImageToBytes(file);
                    merchantModel.Merchant.MerchantId = merchantModel.GetNewMerchantId();
                    merchantModel.Merchant.State = merchantModel.SelectedState;
                    merchantModel.Merchant.Country = merchantModel.SelectedCountry;
                    merchantModel.Merchant.BusIndustryId = merchantModel.SelectedIndustry;
                    merchantModel.Merchant.OperateFrom = merchantModel.StartTime; // string.Format("{0}:{1} {2}", merchantModel.SelectedStartHour, merchantModel.SelectedStartMins, merchantModel.SelectedStartPeriod);
                    merchantModel.Merchant.OperateTo = merchantModel.EndTime; // string.Format("{0}:{1} {2}", merchantModel.SelectedEndHour, merchantModel.SelectedEndMins, merchantModel.SelectedEndPeriod);

                    db.Merchants.Add(merchantModel.Merchant);
                    db.SaveChanges();

                    return RedirectToAction("Index", "ProductSubmission", new { merchantName = merchantModel.Merchant.FirstName });
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

        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string Token, string Email)
        {
            ApplicationUser user = this.UserManager.FindById(Token);
            if (user != null)
            {
                if (user.Email == Email)
                {
                    user.ConfirmedEmail = true;
                    await UserManager.UpdateAsync(user);
                    await SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home", new { ConfirmedEmail = user.Email });
                }
                else
                {
                    return RedirectToAction("Confirm", "Account", new { Email = user.Email });
                }
            }
            else
            {
                return RedirectToAction("Confirm", "Account", new { Email = "" });
            }

        }


        #region -- PRIVATE METHODS --
        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }
        #endregion
    }
}