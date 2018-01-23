using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _contex;
        public CustomersController()
        {
            _contex = new ApplicationDbContext();
        }

        CustomersViewModel customersVM = new CustomersViewModel();
        // GET: Customers
        public ActionResult Index()
        {
            //var customers = _contex.Customers.Include(c => c.MembershipType).ToList();
            return View();
        }

        public ActionResult New()
        {

            var membershipType = _contex.MembershipTypes;
            var NewCustomerVM = new CustomerFormViewModel { MembershipTypes = membershipType };
            return View("CustomerForm",NewCustomerVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var membershipType = _contex.MembershipTypes;
                var NewCustomerVM = new CustomerFormViewModel { Customer=customer,MembershipTypes = membershipType };
                return View("CustomerForm", NewCustomerVM);
            }
            if (customer.Id==0)
                _contex.Customers.Add(customer);
            else
            {
                var customerInDB = _contex.Customers.Single(c => c.Id == customer.Id);
                customerInDB.Name = customer.Name;
                customerInDB.BirthDate = customer.BirthDate;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _contex.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int Id)
        {
            var customer = _contex.Customers.SingleOrDefault(c => c.Id == Id);
            var memberships = _contex.MembershipTypes.ToList();

            var CustomerFormVM = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = memberships
            };
            return View("CustomerForm",CustomerFormVM);
        }


        public ActionResult Details(int Id)
        {
            var customer = _contex.Customers.Include(c => c.MembershipType).SingleOrDefault(a => a.Id == Id);
            if (customer is null)
                return HttpNotFound();
            return View(customer);
        }
    }
}