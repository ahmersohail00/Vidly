﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;

namespace Vidly.Controllers.Api
{
    public class CustomerRentalController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetRentalData(CustomerRentalDTO CRDTO)
        {
            
            return Ok();
        }
    }
}
