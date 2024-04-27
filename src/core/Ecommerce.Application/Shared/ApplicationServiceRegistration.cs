namespace Ecommerce.Application.Shared
{
    public static class ApplicationServiceRegistration
    {
        public static void ConfigureApplicatonService(this IServiceCollection service)
        {
            //Configure AutoMapper && mediator && Fluent Validation : 

            service.AddAutoMapper(typeof(CategoryMappingProfile));
            service.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            service.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        }

    }
}


