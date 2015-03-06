using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace GreatSavings.Controllers
{
    public class PromotionController : ApiController
    {
        #region -- PRIVATE PROPERTIES --
        private GreatSavingsEntities db = new GreatSavingsEntities();

        #endregion

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public Promotion Get(int id)
        {
            var promo = db.Promotions.Where(t => t.PromotionId == id).FirstOrDefault();
            if (promo == null)
            {
                promo = new Promotion();
            }

            return promo;
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Promotion value)
        {
            try
            {

                db.Promotions.Add(value);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotImplemented, ex.Message);
                return response;
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}