using MQTTnet.Server;

namespace Web.Communication.Protocols.Simple.MQTT.Interfaces.Interceptors
{
    internal interface IClientAcknowledgedPublishPacketInterceptor
    {
        Task InterceptAsync(ClientAcknowledgedPublishPacketEventArgs arg);
    }
}