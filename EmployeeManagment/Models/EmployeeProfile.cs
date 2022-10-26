﻿using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;

namespace EmployeeManagment.Models
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EditEmployeeModel>()
                .ForMember(dest =>dest.ConfirmEmail, opt=>opt.MapFrom(src=>src.Email));
            CreateMap<EditEmployeeModel, Employee>();
        }
    }
}
