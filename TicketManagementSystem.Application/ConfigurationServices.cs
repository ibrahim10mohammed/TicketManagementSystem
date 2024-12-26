using FluentValidation;
using Hangfire;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TicketInventoryManagement.Application.Common.Exceptions;
using TicketManagementSystem.Application.Common.Behaviours;
using TicketManagementSystem.Application.Common.Exceptions.FluentValidation;

namespace TicketManagementSystem.Application
{
    public static class ConfigurationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            // Register AutoMapper for the application layer
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Register MediatR handlers from the application assembly
            services.AddMediatR(ctg =>
            {
                ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            // Register FluentValidation validators from the application assembly
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Add MediatR pipeline behaviors
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>)); // Add validation behavior

            return services;
        }
    }
}