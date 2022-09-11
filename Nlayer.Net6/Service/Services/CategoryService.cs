using AutoMapper;
using Core.DTOs;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
   
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        } 

        public async Task<CustomResponseDto<CategoryByIdWithProducts>> GetSingleCategoryByIdWithProduct(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdWithProducts(categoryId);
            var categoryDto = _mapper.Map<CategoryByIdWithProducts>(category);
            return CustomResponseDto<CategoryByIdWithProducts>.Success(200, categoryDto);
        }
    }
}
