using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GreatSavings.Controllers
{
    public class RecommendationController : ApiController
    {
        #region -- PRIVATE PROPERTIES --
        private GreatSavingsEntities db = new GreatSavingsEntities();
        #endregion

        // GET api/<controller>
        public IEnumerable<Recommendation> Get()
        {
            return db.Recommendations;
        }

        // GET api/<controller>/5
        public Recommendation Get(int id)
        {
            var recommendation = db.Recommendations.Where(t => t.TransId == id).FirstOrDefault();
            if (recommendation == null)
            {
                recommendation = new Recommendation();
            }

            return recommendation;
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Recommendation item)
        {
            try
            {
                
                db.Recommendations.Add(item);
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

        public HttpResponseMessage AddRecommendations(int transactionId, IEnumerable<Recommendation> recommendationsList)
        {
            try
            {
                foreach (Recommendation item in recommendationsList)
                {
                    item.TransId = transactionId;
                    db.Recommendations.Add(item);
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
        public HttpResponseMessage Put(int id, Recommendation updatedItem)
        {
            try
            {
                var recommendation = db.Recommendations.Where(t => t.TransId == id).FirstOrDefault();
                if (recommendation == null)
                {
                    recommendation = updatedItem;
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
                Recommendation recommendation = new Recommendation { RecomId = id };
                db.Recommendations.Attach(recommendation);

                db.Recommendations.Remove(recommendation);
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