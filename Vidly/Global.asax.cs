using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vidly.App_Start;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<Customer, CustomerDTO>();

                c.CreateMap<CustomerDTO, Customer>();
                c.CreateMap<MembershipType, MembershipTypeDTO>();
                c.CreateMap<MembershipTypeDTO, MembershipType>();
                c.CreateMap<Naat, NaatDTO>();
                c.CreateMap<NaatDTO, Naat>();
                c.CreateMap<Genre, GenreDTO>();
                c.CreateMap<GenreDTO, Genre>();
            }
             );
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
