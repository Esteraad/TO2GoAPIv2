using AutoMapper;
using TO2GoAPIv2.Data;
using TO2GoAPIv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TO2GoAPIv2.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer() {
            //CreateMap<Country, CountryDTO>().ReverseMap();
            //CreateMap<Country, CreateCountryDTO>().ReverseMap();
            //CreateMap<Hotel, HotelDTO>().ReverseMap();
            //CreateMap<Hotel, CreateHotelDTO>().ReverseMap();
            CreateMap<ApiUser, UserDTO>().ReverseMap();

        }
    }
}
