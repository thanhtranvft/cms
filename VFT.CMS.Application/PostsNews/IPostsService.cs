using VFT.CMS.Application.PostsNews.Dto;
using VFT.CMS.Application.Common.Dto;
using VFT.CMS.Application.Menus.Dto;

namespace VFT.CMS.Application.PostsNews
{
    public interface IPostsService
    {
        Task<bool> CreateAsync(PostsCreateDto categoryCreateDto);
        Task<bool> UpdateAsync(PostsEditDto input);
        Task<PostsEditDto> GetAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<PagedResponseDto<List<PostsDto>>> GetAllPaging(PostsPagedRequestDto input);
    }
}
