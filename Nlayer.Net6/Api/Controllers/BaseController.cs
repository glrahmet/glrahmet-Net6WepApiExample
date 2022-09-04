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
        public readonly IService<Product> _productService;

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
            return new ObjectResult(null)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}

