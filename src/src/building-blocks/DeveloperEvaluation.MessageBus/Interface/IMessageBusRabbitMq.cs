using DeveloperEvaluation.MessageBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperEvaluation.MessageBus.Interface
{
    public interface IMessageBusRabbitMq
    {
        #region " Mensagens Assincronas "

        void Publish<T>(T message, PropsMessageQueeDto propsMessageQueeDto
                       ) where T : IntegrationEvent;

        void Subscribe<T>(PropsMessageQueeDto propsMessageQueeDto, Action<T> onMessage) where T : IntegrationEvent;

        void SubscribeAsync<T>(PropsMessageQueeDto propsMessageQueeDto, Func<T, Task> onMessage) where T : IntegrationEvent;


        #endregion

        #region " RPC "

        /*usado como publicação envia o request e aguarda o response*/
        TResp RpcSendRequestReceiveResponse<TReq, TResp>(TReq req, PropsMessageQueeDto propsMessageQueeDto) where TReq : IntegrationEvent where TResp : ResponseMessage;

        /*usado como subscription recebe o request processa e envia o response*/
        void RpcSendResponseReceiveRequestAsync<TReq, TResp>(PropsMessageQueeDto propsMessageQueeDto, Func<TReq, Task<TResp>> onMessage) where TReq : IntegrationEvent where TResp : ResponseMessage;


        #endregion
    }
}
