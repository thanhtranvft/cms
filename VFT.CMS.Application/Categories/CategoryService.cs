using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VFT.CMS.Application.Categories.Dto;
using VFT.CMS.Application.Common.Dto;
using VFT.CMS.Application.Services;
using VFT.CMS.Entities;
using VFT.CMS.EntityFrameworkCore;
using VFT.Shared;

namespace VFT.CMS.Application.Categories
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IRepository<Category> _repo;
        private readonly CMSDbContext _context;
        private readonly IMapper _mapper;
        public CategoryService(IRepository<Category> repo, CMSDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _repo = repo;
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryEditDto> GetAsync(int id)
        {
            try
            {
                var data = await _repo.GetAsync(id);

                return _mapper.Map<CategoryEditDto>(data);
            }
            catch (Exception ex)
            {
                return new CategoryEditDto();
            }
        }

        public async Task<bool> CreateAsync(CategoryCreateDto input)
        {
            try
            {
                var data = _mapper.Map<Category>(input);
                FillAuthInfo(data);

                await _repo.AddAsyn(data);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(CategoryEditDto input)
        {
            try
            {
                var data = _mapper.Map<Category>(input);
                FillAuthInfo(data);

                await _repo.UpdateAsyn(data, input.Id);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<PagedResponseDto<List<CategoryDto>>> GetAllPaging(CategoryPagedRequestDto input)
        {
            try
            {
                var query = _context.Set<Category>()
                    .Include(x=>x.Parent)
                    .Where(x => string.IsNullOrEmpty(input.Keyword) || x.Title.Contains(input.Keyword));

                var list = await query.Skip(input.SkipCount)
                .Take(input.PageSize)
                .ToListAsync();

                var totalCount = await query.CountAsync();
                var data = _mapper.Map<List<CategoryDto>>(list);
                var result = new PagedResponseDto<List<CategoryDto>>(data, input.PageNumber, input.PageSize, totalCount, input.Keyword);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<SelectListItem>> GetCategoryItems(int? id)
        {
            try
            {
                var result = _context.Set<Category>()
                   .Where(x => x.Status == StatusActivity.Active);

                return id != null
                    ? await result.Where(x => x.Id != id.GetValueOrDefault() && x.ParentCategory != id.GetValueOrDefault()).Select(x => new SelectListItem()
                    {
                        Value = x.Id.ToString(),
                        Text = x.Title,
                    }).ToListAsync()
                    : await result.Select(x => new SelectListItem()
                    {
                        Value = x.Id.ToString(),
                        Text = x.Title,
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

