    using Ecommerce.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.EntitiesDTO.Category
{
    public class CategoryDTO : BaseDTO<int>
    {

        public string Name { get; set; }

    }
}
