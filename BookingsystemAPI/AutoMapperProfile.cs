using AutoMapper;
using BookingsystemAPI.DTOs;
using BookingsystemModels;

namespace BookingsystemAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
