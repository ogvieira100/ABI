
//using DeveloperEvaluation.MessageBus.Interface;

//namespace DeveloperEvaluation.CartsApi.Services
//{
//    public class DeleteProductsIntegrationHandler : BackgroundService
//    {
//        readonly IServiceProvider _serviceProvider;
//        readonly IMessageBusRabbitMq _messageBusRabbitMq;

//        public DeleteProductsIntegrationHandler(IServiceProvider serviceProvider,
//               IMessageBusRabbitMq messageBusRabbitMq)
//        {
//            _serviceProvider = serviceProvider;
//            _messageBusRabbitMq = messageBusRabbitMq;
//        }
//        protected override Task ExecuteAsync(CancellationToken stoppingToken)
//        {
//            SetResponder();
//            return Task.CompletedTask;
//        }

//        void OnConnect(object s, EventArgs e)
//        {
//            SetResponder();
//        }

//        void SetResponder()
//        {
//            _messageBusRabbitMq.SubscribeAsync<UserDeletedIntegrationEvent>(
//                new BuildingBlocksMessageBus.Models.PropsMessageQueeDto { Queue = "QueeUserDeleted" },
//               DeleteCustomerUserAsync
//                );
//        }

//        async Task DeleteCustomerUserAsync(UserDeletedIntegrationEvent request)
//        {
//            try
//            {
//                using (var scope = _serviceProvider.CreateScope())
//                {
//                    var serviceArchive = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
//                    var ret = await serviceArchive.SendCommand<DeleteCustomerCommand, object>(
//                    new DeleteCustomerCommand
//                    {
//                        Id = request.Id,
//                        UserDeleteId = request.UserDeleteId,
//                    });
//                }
//            }
//            catch (Exception ex) { }
//        }
//    }
//}
