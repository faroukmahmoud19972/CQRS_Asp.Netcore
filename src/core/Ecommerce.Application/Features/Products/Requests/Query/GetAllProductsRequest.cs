using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.DTOs.EntitiesDTO.Product;

namespace Ecommerce.Application.Features.Products.Requests.Query
{
    public class GetAllProductsRequest : IRequest<List<ProductDTO>>
    {
    }
}
