using AutoMapper;
using CarAPI.Entities;
using CarAPI.Entities.Dtos.Brand;
using CarAPI.Entities.Dtos.Car;

namespace CarAPI.Profiles
{
    public class BrandProfile:Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, GetBrandDto>();
            CreateMap<CreateBrandDto, Brand>();
            CreateMap<UpdateBrandDto, Brand>();
        }
      
    }
}
