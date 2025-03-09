using DeveloperEvaluation.MessageBus.Interface;
using DeveloperEvaluation.MessageBus.Models.Integration;
using DeveloperEvaluation.MessageBus.Models;
using MediatR;

namespace DeveloperEvaluation.ProductsApi.Application.UpdateProducts
{
    public class UpdateProductsEventHandler : INotificationHandler<UpdateProductsIntegrationEvent>
    {
        readonly IMessageBusRabbitMq _messageBusRabbitMq;
        public UpdateProductsEventHandler(IMessageBusRabbitMq messageBusRabbitMq)
        {
            _messageBusRabbitMq = messageBusRabbitMq;
        }

        public async Task Handle(UpdateProductsIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                _messageBusRabbitMq.Publish(notification,
                new PropsMessageQueeDto
                {
                    Queue = "QueeProductsUpdate"
                });
            });

        }
    }
}
