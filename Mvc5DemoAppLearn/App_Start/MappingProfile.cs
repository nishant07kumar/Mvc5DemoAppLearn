
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Mvc5DemoAppLearn.Models;
using Mvc5DemoAppLearn.Dtos;

namespace Mvc5DemoAppLearn.App_Start
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>().ForMember(cust => cust.Id, opt => opt.Ignore());
            Mapper.CreateMap<CustomerDto, Customer>();

            Mapper.CreateMap<Movie, MoviesDtos>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<MoviesDtos, Movie>();
        }


    }
}