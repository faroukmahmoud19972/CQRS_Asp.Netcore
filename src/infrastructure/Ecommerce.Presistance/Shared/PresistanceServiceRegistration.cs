using Ecommerce.Presistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Presistance.Shared
{
    public static class PresistanceServiceRegistration
    {
        public static void ConfigurePresistanceService(this IServiceCollection services,IConfiguration configuration)
        {
            // Configure AddDbContext
            services.AddDbContext<ApplicationDBContext>(
                op=>
                    op.UseSqlServer(configuration.GetConnectionString("defualtConnection")));

            //Configure services : 
            services.AddScoped(typeof(IGenricRepository<>), typeof(GenericRepositories<>));
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
        }
    }
}
