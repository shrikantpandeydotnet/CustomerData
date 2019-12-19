using CustomerData.Data;
using CustomerData.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CustomerData.Controllers
{   
    [RoutePrefix("api/values")] // Using Routing Annotation
    public class ValuesController : ApiController
    {
        // GET api/values
        public ResponseModel Get()
        {
            try
            {
                using (UKABEntities objContext = new UKABEntities())
                {
                    ResponseModel objResponse = new ResponseModel();

                    List<Customer> customers = objContext.Customers.AsEnumerable<Customer>().ToList<Customer>();

                    objResponse.Data = JsonConvert.SerializeObject(customers);
                    objResponse.Status = true;
                    objResponse.Message = "Data Received Succesfully";

                    return objResponse;
                }
            }
            catch (Exception ex)
            {

                throw ex; // Currently I am throwing the error. In real scenario we can log it which helps in debugging the issue.
            }
        }

        // POST api/values
        [HttpPost, HttpOptions]
        [Route("PostCustomer")]
        public ResponseModel Post([FromBody]Customer value)
        {
            try
            {
                using (UKABEntities objContext = new UKABEntities())
                {
                    ResponseModel objResponse = new ResponseModel();

                    if (value != null)
                    {
                        objContext.Customers.Add(value);
                        objContext.SaveChanges();
                    }

                    objResponse.Data = JsonConvert.SerializeObject(value);
                    objResponse.Status = true;
                    objResponse.Message = "Data Posted Succesfully";

                    return objResponse;
                }
            }
            catch (Exception ex)
            { 
                throw ex; // Currently I am throwing the error. In real scenario we can log it which helps in debugging the issue.
            }
        }
    }
}
