using Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validations
{
    public class ProductDtValidator : AbstractValidator<ProductDto>
    {
        //hata durumlarının ne olması gereklilikler kısmını güncellleme 
        public ProductDtValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("{PropertyName} gereklidir.").NotEmpty().WithMessage("{PropertyName} boş olamaz.");

            RuleFor(p => p.Price).InclusiveBetween(1,int.MaxValue).WithMessage("{PropertyName} 0 dan büyük bir değer olmalıdır.");
        }
    }
}
