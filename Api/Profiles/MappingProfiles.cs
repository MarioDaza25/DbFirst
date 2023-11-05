using Api.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Driver,DriverDto>().ReverseMap();
        CreateMap<Driver,GetDriverDto>().ReverseMap();

        CreateMap<Team,TeamDto>().ReverseMap();
        CreateMap<Team,GetTeamDto>().ReverseMap();
    }
}