using Microsoft.AspNetCore.Mvc.Rendering;
using VFT.CMS.Application.Categories.Dto;
using VFT.CMS.Application.Common.Dto;

namespace VFT.CMS.Application.Categories
{
    public interface ICategoryService
    {
        Task<bool> CreateAsync(CategoryCreateDto categoryCreateDto);
        Task<bool> UpdateAsync(CategoryEditDto input);
        Task<CategoryEditDto> GetAsync(int id);
        Task<PagedResponseDto<List<CategoryDto>>> GetAllPaging(CategoryPagedRequestDto input);
        Task<List<SelectListItem>> GetCategoryItems(int? id = null);
    }
}
