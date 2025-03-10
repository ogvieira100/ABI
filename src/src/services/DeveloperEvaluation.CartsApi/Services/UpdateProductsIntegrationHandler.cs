using AutoMapper;
using DeveloperEvaluation.CartsApi.Application.UpdateProducts;
using DeveloperEvaluation.MessageBus.Interface;
using DeveloperEvaluation.MessageBus.Models;
using DeveloperEvaluation.MessageBus.Models.Integration;
using MediatR;

namespace DeveloperEvaluation.CartsApi.Services
{
    public class UpdateProductsIntegrationHandler : BackgroundService
    {
        readonly IServiceProvider _serviceProvider;
        readonly IMessageBusRabbitMq _messageBusRabbitMq;

        public UpdateProductsIntegrationHandler(IServiceProvider serviceProvider,
               IMessageBusRabbitMq messageBusRabbitMq)
        {
            _serviceProvider = serviceProvider;
            _messageBusRabbitMq = messageBusRabbitMq;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }

        void OnConnect(object s, EventArgs e)
        {
            SetResponder();
        }

        void SetResponder()
        {
            _messageBusRabbitMq.SubscribeAsync<UpdateProductsIntegrationEvent>(
                new PropsMessageQueeDto { Queue = "QueeProductsUpdate" },
                     UpdateProductsIntegrationAsync
                );
        }

        async Task UpdateProductsIntegrationAsync(UpdateProductsIntegrationEvent request)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var imediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                    var imapper = scope.ServiceProvider.GetRequiredService<IMapper>();
                    var updateProductCommand =  imapper.Map<UpdateProductsCommand>(request);
                    var ret =  await imediator.Send(updateProductCommand);
                   
                }
            }
            catch (Exception ex) { }
        }
    }
}
