using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VFT.CMS.Application.Categories;
using VFT.CMS.Web.Models;

namespace VFT.CMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            //await _categoryService.CreateAsync(new Application.Categories.Dto.CategoryCreateDto() { Title = "Nha dat", Status = "Hoat dong"});

            //var test = await _categoryService.GetAllPaging(new Application.Categories.Dto.CategoryPagedRequestDto());

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}