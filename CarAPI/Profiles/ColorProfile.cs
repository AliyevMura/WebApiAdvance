using AutoMapper;
using CarAPI.Entities;
using CarAPI.Entities.Dtos.Color;

namespace CarAPI.Profiles
{
    public class ColorProfile: Profile
    {
        public ColorProfile()
        {
            CreateMap<Color, GetColorDto>();
            CreateMap<CreateColorDto, Color>();
            CreateMap<UpdateColorDto, Color>();
        }
    }
}
