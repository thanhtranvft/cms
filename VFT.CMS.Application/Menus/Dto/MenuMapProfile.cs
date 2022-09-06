using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Entities;

namespace VFT.CMS.Application.Menus.Dto
{
    public class MenuMapProfile : Profile
    {
        public MenuMapProfile()
        {
            CreateMap<Menu, MenuDto>();
            CreateMap<Menu, MenuEditDto>();
            CreateMap<MenuCreateDto, Menu>();
            CreateMap<MenuEditDto, Menu>();
        }
    }
}
