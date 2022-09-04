using AutoMapper;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController<CategoryController>
    {
        public CategoryController(IMapper mapper, ICategoryService categoryService) : base(mapper, categoryService)
        {
        }

        //Get api/product/GetProductWithCategory metot ismi vermeden de yapabiliriz.
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProduct(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryByIdWithProduct(categoryId));
        }
    }
}
