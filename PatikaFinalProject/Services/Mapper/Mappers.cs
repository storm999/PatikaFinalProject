using AutoMapper;
using PatikaFinalProject.DataAccess;

namespace PatikaFinalProject.Services.Mapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerCreateDTO>().ReverseMap();
        }
    }
}
