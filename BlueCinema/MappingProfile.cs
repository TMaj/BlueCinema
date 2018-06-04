using AutoMapper;
using BlueCinema.Helpers;
using BlueCinema.Models;
using BlueCinema.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueCinema
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Booking, BookingDto>().ForMember(dest => dest.BookedPlaces, opts => opts.MapFrom(src => ConversionHelper.ParseDelimitedStringToInts(':', src.Places)))
                                            .ForMember(dest => dest.BookingTime, opts => opts.MapFrom(src => src.BookingTime.ToString()));
                                            
            CreateMap<BookingDto, Booking> ().ForMember(dest => dest.Places, opts => opts.MapFrom(src => ConversionHelper.ParseIntsToDelimitedString(':', src.BookedPlaces)))
                                             .ForMember(dest => dest.Seance, opts => opts.MapFrom(src => new Seance() { Id = src.SeanceId }))
                                             .ForMember(dest => dest.BookingTime, opts => opts.MapFrom(src => DateTime.Parse(src.BookingTime)));
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<Film, FilmDto>().ReverseMap();
            CreateMap<Seance, SeanceDto>().ForMember(dest => dest.Time, opts => opts.MapFrom(src => src.Time.ToString()));
            CreateMap<SeanceDto, Seance>().ForMember(dest => dest.Time, opts => opts.MapFrom(src => DateTime.Parse(src.Time)));
        }
    }
}
