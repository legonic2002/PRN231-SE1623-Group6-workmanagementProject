using AutoMapper;
using DataAccess.Entities;
using Entities.EntitiesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            #region Account

            CreateMap<Account, AccountDtoDisplay>().ReverseMap();

            CreateMap<Account, AccountDtoCreate>().ReverseMap();

            CreateMap<Account, AccountDtoChangeable>().ReverseMap();

            CreateMap<Account, AccountDtoApplied>().ReverseMap();

            #endregion Account

            CreateMap<AppliedAndCared, AppliedAndCaredDto>().ReverseMap();

            CreateMap<AppliedUser, AppliedUserDto>().ReverseMap();

            CreateMap<Company, CompanyDto>().ReverseMap();

            CreateMap<Cvfile, CvfileDto>().ReverseMap();

            CreateMap<Post, PostDto>().ReverseMap();
        }
    }
}
