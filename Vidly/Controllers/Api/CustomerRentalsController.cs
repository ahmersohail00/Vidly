using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomerRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomerRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult NewRentals(CustomerRentalDTO CRDTO)
        {
            var customer = _context.Customers.Single(c => c.Id == CRDTO.CustomerId);
            var naats = _context.Naats.Where(n => CRDTO.NaatId.Contains(n.Id)).ToList();

            foreach (var naat in naats)
            {
                if (naat.NumberAvailable == 0)
                    return BadRequest("Naat is not available");
                naat.NumberAvailable--;

                var rental = new Rental
                {
                    DateRented = DateTime.Now.Date,
                    Customer = customer,
                    Naat = naat
                };
                _context.Rental.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
