using Ecommerce.Application.Presistance.Email;
using Ecommerce.infrastructure.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.infrastructure.Shared
{
    public static class InfrastructureServiceRegistration
    {
        public static void configureInfrastructureService(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<EmailSender>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailSender, EmailSender>();
        }


    }
}
