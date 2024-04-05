using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using PermitPequests.Application.Features.Permissions.Services;
using PermitPequests.Application.Features.PermissionType.Services;
using PermitPequests.Application.Interfaces.Services;
using System.Reflection;

namespace PermitPequests.Application
{
    public static class IoC
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();
            services.AddTransient<IPermissionsService, PermissionsService>();
            services.AddTransient<IPermissionTypeService, PermissionTypeService>();

            return services;
        }
    }
}
