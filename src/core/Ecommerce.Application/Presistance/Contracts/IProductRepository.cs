﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Presistance.Contracts
{
    public interface IProductRepository : IGenricRepository<Product>
    {
        Task<List<Product>> GetAllGetAllAsyncWithInclude();
    }
}
