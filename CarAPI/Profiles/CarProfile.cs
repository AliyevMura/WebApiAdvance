using AutoMapper;
using CarAPI.Entities;
using CarAPI.Entities.Dtos.Car;
using CarAPI.Entities.Dtos.Color;

namespace CarAPI.Profiles
{
    public class CarProfile: Profile
    {


        public CarProfile()
        {
            CreateMap<Car, GetCarDto>();
            CreateMap<CreateCarDto, Car>();
            CreateMap<UpdateCarDto, Car>();
        }
    }
}
