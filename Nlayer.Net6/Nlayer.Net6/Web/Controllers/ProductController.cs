using AutoMapper;
using Core;
using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var CustomResponse = await _productService.GetProductWithCategory();

            return View(CustomResponse.Data);
        }


        public async Task<IActionResult> Save()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoryDto = _mapper.Map<List<CategoryDto>>(categories.ToList());

            ViewBag.categories = new SelectList(categoryDto, "Id", "Name");

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Save(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddAsync(_mapper.Map<Product>(productDto));

                return RedirectToAction(nameof(Index));
            }

            var categories = await _categoryService.GetAllAsync();
            var categoryDto = _mapper.Map<List<CategoryDto>>(categories.ToList());

            ViewBag.categories = new SelectList(categoryDto, "Id", "Name");
            return View();
        }
    }
}
