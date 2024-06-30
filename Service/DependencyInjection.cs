using Microsoft.Extensions.DependencyInjection;
using Service.Service.Interface;
using Service.Service;
using Service.Helpers;
using FluentValidation.AspNetCore;

namespace Service
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
            });

            //services.AddScoped<IValidator<CountryCreateDto>, CountryCreateDtoValidator>();

            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IStudentService, StudentService>();

            return services;


        }
    }
}
