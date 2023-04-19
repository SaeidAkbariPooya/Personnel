using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MiniPerson.Application.Features.Persons.Handlers.Commands.PersonCreateHandlers;
using System.Reflection;

namespace MiniPerson.Application
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            //var assembly = typeof(PersonDeleteCommandValidator).Assembly;

            //services.AddAutoMapper(typeof(AutoMapperConfig));
            //services.AddValidatorsFromAssembly(assembly);

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddValidatorsFromAssemblyContaining<PersonCreateCommandValidator>();
            //services.AddValidatorsFromAssemblyContaining<PersonDeleteCommandValidator>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
        }
    }
}
