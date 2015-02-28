using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GreatSavings.Controllers
{
    public class NewOpeningController : ApiController
    {
        #region -- PRIVATE PROPERTIES --
        private GreatSavingsEntities db = new GreatSavingsEntities();
        #endregion

        // GET api/<controller>
        public IEnumerable<NewOpening> Get()
        {
            return db.NewOpenings;
        }

        // GET api/<controller>/5
        public NewOpening Get(int id)
        {
            var newOpening = db.NewOpenings.Where(t => t.TransId == id).FirstOrDefault();
            if (newOpening == null)
            {
                newOpening = new NewOpening();
            }

            return newOpening ;
        }

        // POST api/<controller>
        public HttpResponseMessage Post(NewOpening item)
        {
            try
            {
                db.NewOpenings.Add(item);
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

        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage AddNewOpenings(int transactionId, IEnumerable<NewOpening> newOpenings)
        {
            try
            {
                foreach (NewOpening item in newOpenings)
                {
                    item.TransId = transactionId;  // Convert.ToInt32(transactionId);
                    db.NewOpenings.Add(item);
                    db.SaveChanges();
                }

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
        public HttpResponseMessage Put(int id, NewOpening updatedItem)
        { 
            try
            {
                var newOpening = db.NewOpenings.Where(t => t.TransId == id).FirstOrDefault();
                if (newOpening == null)
                {
                    newOpening = updatedItem;
                    db.SaveChanges();
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotImplemented, ex.Message);
                return response;
            }
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                NewOpening newOpening = new NewOpening { NewOpenId = id };
                db.NewOpenings.Attach(newOpening);

                db.NewOpenings.Remove(newOpening);
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
    }
}