using DeveloperEvaluation.Core.Data;
using DeveloperEvaluation.Core.Validation;
using DeveloperEvaluation.MessageBus.Interface;
using DeveloperEvaluation.MessageBus.Models;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperEvaluation.Core.Utils
{
    public static class DependencyResolver
    {

        public static void RegisterDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped(typeof(IRepositoryConsult<>), typeof(RepositoryConsult<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            builder.Services.AddSingleton<IMessageBusRabbitMq, MessageBusRabbitMq>();

        }
    }
}
