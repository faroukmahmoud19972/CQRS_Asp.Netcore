using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Presistance.Repositories
{
    public class ProductRepository : GenericRepositories<Product>, IProductRepository
    {
        private readonly ApplicationDBContext _context;

        public ProductRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<Product>> GetAllGetAllAsyncWithInclude()
         =>   _context.Products.AsNoTracking().Include(x=>x.Categories).ToListAsync();
    }
}
