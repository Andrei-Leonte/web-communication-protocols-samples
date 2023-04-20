using MQTTnet.Server;
using Web.Communication.Protocols.Simple.MQTT.Interfaces.Interceptors;

namespace Web.Communication.Protocols.Simple.MQTT.Interceptos
{
    internal class ClientAcknowledgedPublishPacketInterceptor : IClientAcknowledgedPublishPacketInterceptor
    {
        public async Task InterceptAsync(ClientAcknowledgedPublishPacketEventArgs arg)
        {

        }
    }
}
