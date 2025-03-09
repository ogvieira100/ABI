using DeveloperEvaluation.MessageBus.Interface;
using DeveloperEvaluation.MessageBus.Models;
using DeveloperEvaluation.MessageBus.Models.Integration;
using MediatR;

namespace DeveloperEvaluation.ProductsApi.Application.CreateProducts
{
    public class CreateProductsEventHandler : INotificationHandler<InsertProductsIntegrationEvent>
    {
        readonly IMessageBusRabbitMq _messageBusRabbitMq;
        public CreateProductsEventHandler(IMessageBusRabbitMq messageBusRabbitMq)
        {
            _messageBusRabbitMq = messageBusRabbitMq;
        }

        public async Task Handle(InsertProductsIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                _messageBusRabbitMq.Publish(notification,
                new PropsMessageQueeDto
                {
                    Queue = "QueeProductsInsert"
                });
            });

        }
    }
}
