using AutoMapper;
using ClubFitnessDomain;
using ClubFitnessDomain.Dtos;

namespace ClubFitnessSolution.MappingProfiles
{
    public class AdministratorProfile : Profile
    {
        public AdministratorProfile()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<AccountProductCategoryDto, AccountProductCategory>();
            CreateMap<AccountProductCategory, AccountProductCategoryDto>();
        }
    }
}
