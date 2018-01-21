using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RandomNaatsViewModel
    {
        public Naat Naat { get; set; }
        public List<Customer> Customers { get; set; }
    }
}