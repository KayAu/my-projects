using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GreatSavings.Controllers
{
    public class TransactionController : ApiController
    {
        #region -- PRIVATE PROPERTIES --
        private GreatSavingsEntities db = new GreatSavingsEntities();

        #endregion

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {

            return db.Transactions;
        }

        // GET api/<controller>/5
        [HttpGet]
        public Transaction Get(int id)
        {
            var transaction = db.Transactions.Where(t=> t.TransId == id).FirstOrDefault();
            if (transaction == null)
            {
                transaction = new Transaction();
                //transaction.MerchantId = id;
            }

            return transaction;
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Transaction transObj)
        {
            try
            {
               
                transObj.CreatedOn = DateTime.Now;
                transObj = db.Transactions.Add(transObj);
                db.SaveChanges();

                //return transObj.TransId;
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transObj);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotImplemented, ex.Message);
                return response;

              //  return null;
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Transaction updatedItem)
        {
            try
            {
                var transaction = db.Transactions.Where(t => t.TransId == id).FirstOrDefault();
                if (transaction == null)
                {
                    transaction = updatedItem;
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
                Transaction transaction = new Transaction { TransId = id };
                db.Transactions.Attach(transaction);

                db.Transactions.Remove(transaction);
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