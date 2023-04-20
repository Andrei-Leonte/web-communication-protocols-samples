using MQTTnet.Server;

namespace Web.Communication.Protocols.Simple.MQTT.Interfaces.Interceptors
{
    internal interface IValidatingConnectionInterceptor
    {
        Task InterceptAsync(ValidatingConnectionEventArgs arg);
    }
}