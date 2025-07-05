using AuthAPI.DTOs;
using AutoMapper;
using Microsoft.Identity.Client;
using AuthAPI.Models;

namespace AuthAPI.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<RegisterDTO, Accounts>();
            CreateMap<LoginDTO, Accounts>();
            CreateMap<Accounts, RegisterDTO>();
            CreateMap<Accounts, LoginDTO>();
        }
    }

}
