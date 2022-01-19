using AutoMapper;
using CRM.Models.Entities;
using CRM.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, UserVM>();
        }
    }
}
