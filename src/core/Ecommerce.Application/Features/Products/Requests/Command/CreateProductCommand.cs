using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.DTOs.EntitiesDTO.Product;
using Ecommerce.Application.Responses;

namespace Ecommerce.Application.Features.Products.Requests.Command
{
    public class CreateProductCommand : IRequest<BaseCommandResponse>
    {
        public ProductDTO ProductDTO { get; set; }
    }
}
