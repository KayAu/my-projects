﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace GreatSavings.Controllers
{
    public class DealsController : ApiController
    {
        #region -- PRIVATE PROPERTIES --
        private GreatSavingsEntities db = new GreatSavingsEntities();

        #endregion


        // GET api/<controller>
        public IEnumerable<Deal> Get()
        {
            return db.Deals;
        }


        // GET api/<controller>/5
        public Deal Get(int id)
        {
            var deal = db.Deals.Where(t => t.TransId == id).FirstOrDefault();
            if (deal == null)
            {
                deal = new Deal();
            }

            return deal;
        }

        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage Load(int totalReturn, int skipRecord)
        {
            try
            {
               // var test = db.Deals.Include(i=>i.Transaction).ToList();
              
                var deals = db.Deals.ToList()
                            .Where(t => t.Transaction.PymtReceived == true && (t.ExpiryDate - DateTime.Now.Date).Days >= 0).AsEnumerable()
                            .Select(d => new { Image = System.Convert.ToBase64String(d.Image),
                                                Id = d.Id,
                                                CompanyName = d.Directory.CompanyName,
                                                Title = d.Title,
                                                ExpiryDate = d.ExpiryDate.ToString("dd MMM yyyy")
                            }).Skip(skipRecord).Take(totalReturn).OrderByDescending(d => d.ExpiryDate);

                
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, deals);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotImplemented, ex.Message);
                return response;
            }
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Deal deals)
        {
            try 
            {
                db.Deals.Add(deals);
                db.SaveChanges();
                //foreach (Deal item in deals)
                //{
                //   // item.TransId = Convert.ToInt32(transactionId);
                //    db.Deals.Add(item);
                //    db.SaveChanges();
                //}
               
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
        public HttpResponseMessage AddDeals(int transactionId, IEnumerable<Deal> deals)
        {
            try
            {
                foreach (Deal item in deals)
                {
                    item.TransId = transactionId;  // Convert.ToInt32(transactionId);
                    item.ExpiryDate = new DateTime(1900, 01, 01, 00, 00, 00);
                    db.Deals.Add(item);
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
        public HttpResponseMessage Put(int id, Deal updatedItem)
        {
            try
            {
                var deal = db.Deals.Where(t => t.TransId == id).FirstOrDefault();
                if (deal == null)
                {
                    deal = updatedItem;
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
                Deal deal = new Deal {  Id = id };
                db.Deals.Attach(deal);

                db.Deals.Remove(deal);
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