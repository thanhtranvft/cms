using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VFT.CMS.Application.Menus.Dto;
using VFT.CMS.Application.Common.Dto;
using VFT.CMS.Entities;
using VFT.CMS.EntityFrameworkCore;
using VFT.CMS.Application.Services;
using Microsoft.AspNetCore.Http;

namespace VFT.CMS.Application.Menus
{
    public class MenuService : BaseService, IMenuService
    {
        private readonly IRepository<Menu> _repo;
        private readonly CMSDbContext _context;
        private readonly IMapper _mapper;
        public MenuService(IRepository<Menu> repo, CMSDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) :base(httpContextAccessor)
        {
            _repo = repo;
            _context = context;
            _mapper = mapper;
        }

        public async Task<MenuEditDto> GetAsync(int id)
        {
            try
            {
                var data = await _repo.GetAsync(id);

                return _mapper.Map<MenuEditDto>(data);
            }
            catch (Exception ex)
            {
                return new MenuEditDto();
            }
        }

        public async Task<bool> CreateAsync(MenuCreateDto input)
        {
            try
            {
                var data = _mapper.Map<Menu>(input);
                FillAuthInfo(data);

                await _repo.AddAsyn(data);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(MenuEditDto input)
        {
            try
            {
                var data = _mapper.Map<Menu>(input);
                FillAuthInfo(data);

                await _repo.UpdateAsyn(data, input.Id);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<PagedResponseDto<List<MenuDto>>> GetAllPaging(MenuPagedRequestDto input)
        {
            try
            {
                var query = _context.Set<Menu>()
                    .Where(x => string.IsNullOrEmpty(input.Keyword) || x.Title.Contains(input.Keyword));

                var list = await query.Skip(input.SkipCount)
                .Take(input.PageSize)
                .ToListAsync();

                var totalCount = await query.CountAsync();
                var data = _mapper.Map<List<MenuDto>>(list);
                var result = new PagedResponseDto<List<MenuDto>>(data, input.PageNumber, input.PageSize, totalCount, input.Keyword);
                
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

