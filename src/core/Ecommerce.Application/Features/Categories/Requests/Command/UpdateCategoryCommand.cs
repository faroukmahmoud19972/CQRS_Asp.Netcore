using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Categories.Requests.Command
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public CategoryDTO CategoryDTO { get; set; }
    }
}
