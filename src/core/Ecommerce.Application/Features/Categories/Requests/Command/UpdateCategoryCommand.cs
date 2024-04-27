using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.DTOs.EntitiesDTO.Category;
using Ecommerce.Application.DTOs.EntitiesDTO.Product;

namespace Ecommerce.Application.Features.Categories.Requests.Command
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public CategoryDTO CategoryDTO { get; set; }
    }
}
