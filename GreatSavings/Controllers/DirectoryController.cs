using GreatSavings.Helper;
using GreatSavings.Models;
using GreatSavings.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Linq;

namespace GreatSavings.Controllers
{
    public class DirectoryController : ApiController
    {
        #region -- PRIVATE PROPERTIES --
        private GreatSavingsEntities db = new GreatSavingsEntities();
        #endregion

        // GET api/<controller>
        public IEnumerable<Directory> Get()
        {
            return db.Directories;
        }

        // GET api/<controller>
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetByMerchant(int id)
        {
            try
            {
                var results = db.Directories.Where(d => d.Transaction.MerchantId == id)
                                             .Select(m => new { DirId = m.DirId, CompanyName = m.CompanyName });

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, results);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotImplemented, ex.Message);
                return response;
            }
           
        }


        // GET api/<controller>/5
        public DirectoryViewModel Get(int id)
        {
            BusinessOperation bizOperations = new BusinessOperation();
            DirectoryViewModel directoryModel = new DirectoryViewModel();
            var directory = db.Directories.Where(t => t.TransId == id).FirstOrDefault();

            directoryModel.BusinessIndustries = db.BusinessIndustries.ToList().Select(b => new KeyValuePair<int, string>(b.BusIndustryId, b.BusIndustry)).ToList();
            directoryModel.Countries = db.Countries.ToList();
            directoryModel.States = db.States.ToList();
            directoryModel.OperatingHours = new SelectList(bizOperations.Hours);     // get the hours for business operation
            directoryModel.OperatingMinutes = new SelectList(bizOperations.Minutes); // get the minutes for business operation
            directoryModel.OperatingPeriod = new SelectList(bizOperations.Period);   // get the period for business operation

            if (directory == null)
            {
                directory = new Directory();
                directoryModel.Merchant.CompanyName = "Testing";
            }
            else
            {
                directoryModel.Merchant = directory;
            }
            return directoryModel;
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Directory item)
        {
            try
            {
                db.Directories.Add(item);
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

        public HttpResponseMessage AddDirectories(int transactionId, IEnumerable<DirectoryViewModel> directoryList)
        {
            try
            {
                foreach (DirectoryViewModel item in directoryList)
                {
                    Directory newDirectory = item.Merchant;

                    newDirectory.TransId = transactionId;
                    db.Directories.Add(newDirectory);
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

        // GET api/<controller>/GenerateId/PG
        [System.Web.Http.HttpGet, System.Web.Http.ActionName("GenerateId")]
        public HttpResponseMessage GenerateId(string id)
        {
            try
            {
                int randNum = DataManager.GetRandonNum();

                string newMerhantID = string.Concat(id, randNum);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, newMerhantID);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotImplemented, ex.Message);
                return response;
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Directory updatedItem)
        {
            try
            {
                var directory = db.Directories.Where(t => t.TransId == id).FirstOrDefault();
                if (directory == null)
                {
                    directory = updatedItem;
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
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                Directory directory = new Directory { DirId = id };
                db.Directories.Attach(directory);

                db.Directories.Remove(directory);
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