using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VFT.CMS.Application.Categories;
using VFT.CMS.Application.PostsNews;
using VFT.CMS.Application.PostsNews.Dto;
using VFT.CMS.EntityFrameworkCore;

namespace VFT.CMS.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class PostsController : BaseController
    {
        IPostsService _postsService;
        ICategoryService _categoryService;
        public PostsController(IPostsService postsService, ICategoryService categoryService)
        {
            _postsService = postsService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var data = await _postsService.GetAllPaging(new PostsPagedRequestDto());

                return View(data);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetCategoryItems();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostsCreateDto createVm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("Error", "Thông tin không hợp lệ");
                    return View(createVm);
                }
                var isSucceeded = await _postsService.CreateAsync(createVm);

                if (isSucceeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Error_Save", "Có lỗi xảy ra");
                    return View(createVm);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", "Lỗi hệ thống");
                return View(createVm);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var result = await _postsService.GetAsync(id);

                if (result != null)
                {
                    ViewBag.Categories = await _categoryService.GetCategoryItems();

                    return View(result);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", "Lỗi hệ thống");
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PostsEditDto editModal)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("Error", "Thông tin không hợp lệ");
                    return View(editModal);
                }
                var isSucceeded = await _postsService.UpdateAsync(editModal);

                if (isSucceeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Error_Save", "Có lỗi xảy ra");
                    return View(editModal);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", "Lỗi hệ thống");
                return View(editModal);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _postsService.DeleteAsync(id);
                if (!result)
                {
                    ModelState.AddModelError("Error_Save", "Có lỗi xảy ra");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", "Lỗi hệ thống");
            }

            return RedirectToAction("Index");
        }
    }
}
