using MQTTnet.Server;

namespace Web.Communication.Protocols.Simple.MQTT.Interfaces.Interceptors
{
    internal interface IPublisherInterceptor
    {
        Task InterceptAsync(InterceptingPublishEventArgs arg);
    }
}
