using AutoMapper;
using BusinessLayer.Model.Models;
using System.Reflection;
using WebApi.Models;

namespace WebApi
{
    public class AppServicesProfile : Profile
    {
        public AppServicesProfile()
        {
            CreateMapper();
        }

        private void CreateMapper()
        {
            CreateMap<BaseInfo, BaseDto>();
            CreateMap<CompanyInfo, CompanyDto>();

            CreateMap<EmployeeDto, EmployInfo>().ForMember(dest => dest.Occupation, opt => opt.MapFrom(src => src.OccupationName))
                                    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber))
                                    .ForMember(dest => dest.LastModified, opt => opt.MapFrom(src => src.LastModifiedDateTime));

            CreateMap<ArSubledgerInfo, ArSubledgerDto>();
        }
    }
}