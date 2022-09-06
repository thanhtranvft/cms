using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VFT.CMS.Application.PostsNews.Dto;
using VFT.CMS.Application.Common.Dto;
using VFT.CMS.Entities;
using VFT.CMS.EntityFrameworkCore;
using VFT.CMS.Application.Services;
using Microsoft.AspNetCore.Http;
using VFT.CMS.Application.Menus.Dto;

namespace VFT.CMS.Application.PostsNews
{
    public class PostsService : BaseService, IPostsService
    {
        private readonly IRepository<Posts> _repo;
        private readonly CMSDbContext _context;
        private readonly IMapper _mapper;
        public PostsService(IRepository<Posts> repo, CMSDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _repo = repo;
            _context = context;
            _mapper = mapper;
        }

        public async Task<PostsEditDto> GetAsync(int id)
        {
            try
            {
                var data = await _repo.GetAsync(id);

                return _mapper.Map<PostsEditDto>(data);
            }
            catch (Exception ex)
            {
                return new PostsEditDto();
            }
        }

        public async Task<bool> CreateAsync(PostsCreateDto input)
        {
            try
            {
                var data = _mapper.Map<Posts>(input);
                FillAuthInfo(data);

                await _repo.AddAsyn(data);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(PostsEditDto input)
        {
            try
            {
                var data = _mapper.Map<Posts>(input);
                FillAuthInfo(data);

                //create a Photo list to store the upload files.
                //List<Photo> photolist = new List<Photo>();
                //if (input.Files.Count > 0)
                //{
                //    foreach (var formFile in input.Files)
                //    {
                //        if (formFile.Length > 0)
                //        {
                //            using (var memoryStream = new MemoryStream())
                //            {
                //                await formFile.CopyToAsync(memoryStream);
                //                // Upload the file if less than 2 MB
                //                if (memoryStream.Length < 2097152)
                //                {
                //                    //based on the upload file to create Photo instance.
                //                    //You can also check the database, whether the image exists in the database.
                //                    var newphoto = new Photo()
                //                    {
                //                        Bytes = memoryStream.ToArray(),
                //                        Description = formFile.FileName,
                //                        FileExtension = Path.GetExtension(formFile.FileName),
                //                        Size = formFile.Length,
                //                    };
                //                    //add the photo instance to the list.
                //                    photolist.Add(newphoto);
                //                }
                //                else
                //                {
                //                    throw new Exception("The file is too large.");
                //                }
                //            }
                //        }
                //    }
                //}
                //data.Photos = photolist;

                await _repo.UpdateAsyn(data, input.Id);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var data = await _repo.GetAsync(id);
                await _repo.DeleteAsyn(data);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<PagedResponseDto<List<PostsDto>>> GetAllPaging(PostsPagedRequestDto input)
        {
            try
            {
                var query = _context.Set<Posts>()
                    .Include(x => x.Category)
                    .Where(x => string.IsNullOrEmpty(input.Keyword) || x.Title.Contains(input.Keyword));

                var list = await query.Skip(input.SkipCount)
                .Take(input.PageSize)
                .ToListAsync();

                var totalCount = await query.CountAsync();
                var data = _mapper.Map<List<PostsDto>>(list);
                var result = new PagedResponseDto<List<PostsDto>>(data, input.PageNumber, input.PageSize, totalCount, input.Keyword);
                
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

