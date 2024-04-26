namespace Ecommerce.Application.Shared
{
    public static class ApplicationServiceRegistration
    {
        public static void ConfigureApplicatonService(this IServiceCollection service)
        {
            //Configure AutoMapper && mediator
            service.AddAutoMapper(typeof(CategoryMappingProfile));
            service.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            //services.AddAutoMapper(typeof(ProductMappingProfile));

        }

    }
}


