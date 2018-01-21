using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class NaatsController : Controller
    {
        private IEnumerable<Naat> GetNaats()
        {
            return new List<Naat>()
            {
                new Naat { Id = 1, Name = "Nabi" },
                new Naat { Id = 2, Name = "Rasool" }
            };
        }
        // GET: Naats
        public ActionResult Random()
        {
            var naat = new Naat { Name="Nabi"};

            var customers = new List<Customer>
            {
                new Customer{Name="Ahmer"},
                new Customer{Name="Arsalan"}
            };

            var naatsViewModel = new RandomNaatsViewModel()
            {
                Naat = naat,
                Customers=customers
            };

            return View(naatsViewModel);
        }

        public ActionResult Index()
        {
            var naats = GetNaats();
            return View(naats);
        }

        public ActionResult Details(int Id)
        {
            Naat naat= GetNaats().SingleOrDefault(a => a.Id == Id);
            if (naat is null)
                return HttpNotFound();
            return View(naat);
        }

        [Route("naats/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"{year}/{month}");
        }
    }
}