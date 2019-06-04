
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
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(cust => cust.Id, opt => opt.Ignore());
            Mapper.CreateMap<MembershipTypes, MembershipTypeDto>();

            Mapper.CreateMap<Movie, MoviesDtos>();
            Mapper.CreateMap<MoviesDtos, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }


    }
}