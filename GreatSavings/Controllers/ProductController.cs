using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GreatSavings.Helper;

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


        public ActionResult DisplayProducts(int productId, int categoryId )
        {
            IQueryable<Deal> lstDeals = db.Deals.Where(d => d.Directory.BusIndustryId == categoryId);

           return View(lstDeals);

        }
    }
}
