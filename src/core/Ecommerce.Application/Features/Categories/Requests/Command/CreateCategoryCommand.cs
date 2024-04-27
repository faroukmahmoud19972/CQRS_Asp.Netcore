using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.DTOs.EntitiesDTO.Category;
using Ecommerce.Application.Responses;

namespace Ecommerce.Application.Features.Categories.Requests.Command
{
    public class CreateCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CategoryDTO CategoryDTO { get; set; }
    }
}
