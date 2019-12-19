using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerData.Models
{
    public class ResponseModel
    {
        public string Data { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }

}