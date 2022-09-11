using AutoMapper;
using Core;
using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public abstract class BaseController<T> : ControllerBase where T : BaseController<T>
    {
        public readonly IMapper _mapper;
        public readonly IProductService _productService;
        public readonly ICategoryService _categoryService;

        public BaseController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public BaseController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {

            if (response.StatusCode == 204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };

            }
            //insert ederken id görmesi için
            else if (response.StatusCode == 201)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode,
                    Value = response.Data
                };
            }
            else if (response.StatusCode == 200)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode,
                    Value = response.Data
                };
            }
            return new ObjectResult(null)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}

