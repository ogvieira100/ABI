
using DeveloperEvaluation.MessageBus.Interface;
using DeveloperEvaluation.MessageBus.Models;
using DeveloperEvaluation.MessageBus.Models.Integration;
using MediatR;

namespace DeveloperEvaluation.CartsApi.Services
{
    public class DeleteProductsIntegrationHandler : BackgroundService
    {
        readonly IServiceProvider _serviceProvider;
        readonly IMessageBusRabbitMq _messageBusRabbitMq;

        public DeleteProductsIntegrationHandler(IServiceProvider serviceProvider,
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
            _messageBusRabbitMq.SubscribeAsync<DeleteProductsIntegrationEvent>(
                new PropsMessageQueeDto { Queue = "QueeProductsDeleted" },
                    DeleteProductsIntegrationAsync
                );
        }

        async Task DeleteProductsIntegrationAsync(DeleteProductsIntegrationEvent request)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var iMediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                    //var ret = await serviceArchive.SendCommand<DeleteCustomerCommand, object>(
                    //new DeleteCustomerCommand
                    //{
                    //    Id = request.Id,
                    //    UserDeleteId = request.UserDeleteId,
                    //});
                }
            }
            catch (Exception ex) { }
        }
    }
}
