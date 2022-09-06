using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VFT.CMS.Application.Menus;
using VFT.CMS.Application.Menus.Dto;
using VFT.Shared;
using VFT.CMS.Web.Areas.Admin.Common.Extensions;

namespace VFT.CMS.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class MenuController : BaseController
    {
        IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var data = await _menuService.GetAllPaging(new MenuPagedRequestDto());

                return View(data);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MenuCreateDto createVm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Thông tin không hợp lệ");
                return View(createVm);
            }
            var isSucceeded = await _menuService.CreateAsync(createVm);

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
            var result = await _menuService.GetAsync(id);

            if (result != null)
            {
                return View(result);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MenuEditDto editModal)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Thông tin không hợp lệ");
                return View(editModal);
            }
            var isSucceeded = await _menuService.UpdateAsync(editModal);

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
