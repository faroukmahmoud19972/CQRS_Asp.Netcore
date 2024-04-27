﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.DTOs.EntitiesDTO.Category;

namespace Ecommerce.Application.Features.Categories.Requests.Query
{
    public class GetCategoryDetailsRequest : IRequest<CategoryDTO>
    {
        public int  id{ get; set; }
    }
}
