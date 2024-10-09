using AutoMapper;
using ClubFitnessDomain;
using ClubFitnessDomain.Dtos;
using AccountProductSubCategory = ClubFitnessDomain.AccountProductSubCategory;

namespace ClubFitnessSolution.MappingProfiles
{
    public class AdministratorProfile : Profile
    {
        public AdministratorProfile()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<AccountProductCategoryDto, AccountProductCategory>().ReverseMap();
            CreateMap<AccountProductSubCategory, AccountProductSubCategoryDto>().ReverseMap();
            //CreateMap<AccountProductCategory, AccountProductCategoryDto>();
        }
    }
}
