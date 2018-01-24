using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class CustomerRentalDTO
    {
        public List<int> NaatId { get; set; }
        public int CustomerId { get; set; }
    }
}