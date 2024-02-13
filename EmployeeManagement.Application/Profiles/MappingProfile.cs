using AutoMapper;
using EmployeeManagement.Application.DTOs.Employee;
using EmployeeManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // for detail
            CreateMap<Employee, EmployeeDto>().ReverseMap();

            // for list
            CreateMap<Employee, EmployeeListDto>().ReverseMap();

            // for create
            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();

            // for update
            CreateMap<Employee, UpdateEmployeeDto>().ReverseMap();
        }
    }
}
