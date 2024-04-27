using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.EntitiesDTO.Category.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryDTO>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} Is Required !")
                .MinimumLength(3).WithMessage("{PropertyName} limit with 3 characters!")
                .MaximumLength(50).WithMessage("{PropertyName} limit with 50 characters!");

        }
    }
}
