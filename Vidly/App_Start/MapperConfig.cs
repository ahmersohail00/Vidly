using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<Customer, CustomerDTO>();

                c.CreateMap<CustomerDTO, Customer>();
            }
             );
        }
    }
}