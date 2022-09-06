using VFT.CMS.Application.Menus.Dto;
using VFT.CMS.Application.Common.Dto;

namespace VFT.CMS.Application.Menus
{
    public interface IMenuService
    {
        Task<bool> CreateAsync(MenuCreateDto categoryCreateDto);
        Task<bool> UpdateAsync(MenuEditDto input);
        Task<MenuEditDto> GetAsync(int id);
        Task<PagedResponseDto<List<MenuDto>>> GetAllPaging(MenuPagedRequestDto input);
    }
}
