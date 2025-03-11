using DeveloperEvaluation.MessageBus.Interface;
using DeveloperEvaluation.MessageBus.Models.Integration;
using DeveloperEvaluation.MessageBus.Models;
using MediatR;

namespace DeveloperEvaluation.ProductsApi.Application.DeleteProducts
{
    public class DeleteProductsEventHandler : INotificationHandler<DeleteProductsIntegrationEvent>
    {
        readonly IMessageBusRabbitMq _messageBusRabbitMq;

        public DeleteProductsEventHandler(IMessageBusRabbitMq messageBusRabbitMq)
        {
            _messageBusRabbitMq = messageBusRabbitMq;
        }

        public async Task Handle(DeleteProductsIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                _messageBusRabbitMq.Publish(notification,
                new PropsMessageQueeDto
                {
                    Queue = "QueeProductsDeleted"
                });
            });

        }
    }
}
