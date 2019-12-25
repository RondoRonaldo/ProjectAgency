using System;
using System.Collections.Generic;
using System.Linq;
using API_Contracts.Models.CommentModels;
using API_Contracts.Models.DistrictModels;
using API_Contracts.Models.RequestModels;
using API_Contracts.Models.UserModels;
using AutoMapper;
using DAL.Entities;

namespace BLL.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RequestEntity, RequestDetailsModel>()
                .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District.Name))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comment))
                .ForMember(dest => dest.UserInfo, opt => opt.MapFrom(src => src.UserProfile));
            CreateMap<RegisterModel, UserProfileEntity>();
            CreateMap<UserInfoModel, UserProfileEntity>();
            CreateMap<RequestModel, RequestEntity>()
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(opt => opt.District, opt => opt.Ignore());
            CreateMap<RequestEntity, RequestDashboardModel>()
                .ForMember(dest => dest.UserInfo, opt => opt.MapFrom(src => src.UserProfile))
                .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District.Name));
            CreateMap<RequestDashboardModel, RequestEntity>();
            CreateMap<UserProfileEntity, UserInfoModel>();
            CreateMap<RequestUpdateModel, RequestEntity>()
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => DateTime.Now));
      
            CreateMap<CommentModel, CommentEntity>();
            CreateMap<CommentEntity, CommentDashboardModel>()
                .ForMember(dest => dest.UserInfo, opt => opt.MapFrom(x => x.UserProfile));
            CreateMap<UserProfileEntity, ProfileModel>();
            CreateMap<DistrictEntity, DistrictDashboardModel>().ReverseMap();
        }
    }
}