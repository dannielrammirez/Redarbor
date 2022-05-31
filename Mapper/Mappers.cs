using AutoMapper;
using APIRedarbor.Models;
using APIRedarbor.Models.Dtos;

namespace APIRedarbor.Mapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
