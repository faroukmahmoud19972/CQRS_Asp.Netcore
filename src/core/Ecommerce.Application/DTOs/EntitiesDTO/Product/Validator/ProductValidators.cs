using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.EntitiesDTO.Product.Validator
{
    public class ProductValidators : AbstractValidator<ProductDTO>
    {

        public ProductValidators(IProductRepository repository)
        {
            RuleFor(x => x.Name)
              .NotNull()
              .NotEmpty().WithMessage("{PropertyName} Is Required !")
              .MinimumLength(3).WithMessage("{PropertyName} limit with {ComparionValue} characters!")
              .MaximumLength(50).WithMessage("{PropertyName} limit with {ComparionValue} characters!");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("{PropertyName} greater than  {ComparionValue} !");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("{PropertyName} greater than  {ComparionValue} !")
                .MustAsync(async (id, token) =>
                {
                    var categoryIdExist =await repository.Exist(id);
                    return !categoryIdExist;
                }).WithMessage("{PropertyName} Doesnt Exist !");
        }
    }
}
