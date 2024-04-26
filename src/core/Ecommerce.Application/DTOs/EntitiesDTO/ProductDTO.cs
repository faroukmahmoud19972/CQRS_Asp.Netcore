using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.EntitiesDTO
{
    public class ProductDTO : BaseDTO<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
