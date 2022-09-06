using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Menus.Dto;
using VFT.CMS.Entities;

namespace VFT.CMS.Application.PostsNews.Dto
{
    public class PostsMapProfile : Profile
    {
        public PostsMapProfile()
        {
            CreateMap<Posts, PostsDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Title : String.Empty));

            CreateMap<Posts, PostsEditDto>();
            CreateMap<PostsCreateDto, Posts>();
            CreateMap<PostsEditDto, Posts>();

            CreateMap<Meta, MetaDto>();
        }
    }
}
