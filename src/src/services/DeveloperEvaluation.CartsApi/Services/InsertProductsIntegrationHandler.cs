
using AutoMapper;
using DeveloperEvaluation.CartsApi.Application.CreateProducts;
using DeveloperEvaluation.MessageBus.Interface;
using DeveloperEvaluation.MessageBus.Models;
using DeveloperEvaluation.MessageBus.Models.Integration;
using MediatR;

namespace DeveloperEvaluation.CartsApi.Services
{
    public class InsertProductsIntegrationHandler : BackgroundService
    {
        readonly IServiceProvider _serviceProvider;
        readonly IMessageBusRabbitMq _messageBusRabbitMq;

        public InsertProductsIntegrationHandler(IServiceProvider serviceProvider,
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
            _messageBusRabbitMq.SubscribeAsync<InsertProductsIntegrationEvent>(
                new PropsMessageQueeDto { Queue = "QueeProductsInsert" },
                     InsertProductsAsync
                );
        }

        async Task InsertProductsAsync(InsertProductsIntegrationEvent request)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var mediatorService = scope.ServiceProvider.GetRequiredService<IMediator>();
                    var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
                    var command = mapper.Map<CreateProductsCommand>(request);
                    var responseCommand =  await mediatorService.Send(command);
                }
            }
            catch (Exception ex) { }
        }
    }
}
