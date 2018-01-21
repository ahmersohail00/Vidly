using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
            new Customer{Id = 1, Name = "Ahmer" },
            new Customer{Id = 2, Name = "Arsalan" },
            new Customer{Id = 3, Name = "Azeezullah" }
            };
        }
        CustomersViewModel customersVM = new CustomersViewModel();
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        public ActionResult Details(int Id)
        {
            var customer = GetCustomers().SingleOrDefault(a => a.Id == Id);
            if (customer is null)
                return HttpNotFound();
            return View(customer);
        }
    }
}