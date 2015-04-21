using GreatSavings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Validation;
using GreatSavings.ViewModels;
using GreatSavings.Helper;

using Microsoft.Owin.Host.SystemWeb;
using System.Data.Entity.Core.Objects;





namespace GreatSavings.Controllers
{
    public class AccountController : ApiController
    {

        #region -- PUBLIC PROPERTIES --
        public UserManager<ApplicationUser, string> UserManager { get; private set; }
      
        #endregion

        #region -- PRIVATE PROPERTIES --
        private GreatSavingsEntities db = new GreatSavingsEntities();

        //private IAuthenticationManager AuthenticationManager
        //{
        //    get
        //    {
        //        ApiController.
        //        var context = Request.Properties["MS_HttpContext"] as System.Web.HttpContext;
               
        //        return HttpContext.GetOwinContext().Authentication;
        //    }
        //} 
        #endregion


        #region -- CONSTRUCTOR --
        public AccountController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        } 
        #endregion

        //// GET api/<controller> 
        //[HttpGet]
        //public IEnumerable<Product> GetProducts()
        //{
        //    var products = db.Products.Where(p => p.Payable == true);
        //    return products.AsEnumerable();
        //}

        // GET api/values/5
        [HttpGet]
        public RegisterViewModel GetRegisterModel()
        {
            RegisterViewModel registerModel = new RegisterViewModel();
            ///todo
            ///check this function
           // registerModel.FirstName = "Testing";
            return registerModel;
        }


        //// GET api/values/5
        //public RegisterViewModel Get(int id)
        //{
        //    RegisterViewModel registerModel = new RegisterViewModel();
 
        //    registerModel.FirstName = "Testing";
        //    return registerModel;
        //}

        // GET api/<controller>/GenerateId/PG
        [System.Web.Http.HttpGet, System.Web.Http.ActionName("CheckEmailAlreadyExist")]
        public HttpResponseMessage CheckEmailAlreadyExist(string email)
        {
            try
            {
                var retValue =  db.CheckEmailAlreadyExist(email);
                int status = retValue.SingleOrDefault().Value;

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, Convert.ToBoolean(status));
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotImplemented, ex.Message);
                return response;
            }
        }

        // POST api/values
        [AllowAnonymous]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        [System.Web.Http.HttpPost, System.Web.Http.ActionName("Register")]
        public async Task<string> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = register.Email };
                user.Email = register.Email;
                user.ConfirmedEmail = false;
                
                var result = await UserManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    var newMerchantId = db.CreateMerchantAccount(user.Id).FirstOrDefault();
                    
                    return newMerchantId != null ? newMerchantId.ToString() : string.Empty;
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
               // return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            } 
        }

     
        [AllowAnonymous]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        [System.Web.Http.HttpPost, System.Web.Http.ActionName("MerchantLogin")]
        public async Task<int> MerchantLogin(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(login.UserName, login.Password);

                if (user != null)
                {
                    //todo: temporary comment this line
                    //if (user.ConfirmedEmail == true)
                    //{
                        var merchant = db.MerchantAccounts.Where(m => m.UserId == user.Id).FirstOrDefault();

                        if (merchant != null)
                            return merchant.MerchantId;
                    //}
                }
            }
            return 0;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        #region -- PRIVATE METHODS --
        //private async Task SignInAsync(ApplicationUser user)
        //{
        //    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
        //    var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        //    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, identity);
        //}
        #endregion
    }
}