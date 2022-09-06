using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VFT.CMS.Application.Categories;
using VFT.CMS.Application.Categories.Dto;

namespace VFT.CMS.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoryController : BaseController
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = await _categoryService.GetAllPaging(new CategoryPagedRequestDto());

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
        public async Task<IActionResult> Create(CategoryCreateDto createVm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Thông tin không hợp lệ");
                return View(createVm);
            }
            var isSucceeded = await _categoryService.CreateAsync(createVm);

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

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _categoryService.GetAsync(id);

            if (result != null)
            {
                ViewBag.Categories = await _categoryService.GetCategoryItems(id);

                return View(result);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryEditDto editModal)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Thông tin không hợp lệ");
                return View(editModal);
            }
            var isSucceeded = await _categoryService.UpdateAsync(editModal);

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
    }
}
