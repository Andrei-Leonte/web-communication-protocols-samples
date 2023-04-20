using Microsoft.Extensions.DependencyInjection;
using MQTTnet.Server;
using Web.Communication.Protocols.Simple.MQTT.Interceptos;

namespace Web.Communication.Protocols.Simple.MQTT.Startups
{
    public static class InterceptorStartup
    {
        public static void AddInterceptor(this MqttServer mqttServer)
        {
            var publisherInterceptor = new PublisherInterceptor();
            var validatingConnectionInterceptor = new ValidatingConnectionInterceptor();
            var clientAcknowledgedPublishPacketInterceptor = new ClientAcknowledgedPublishPacketInterceptor();

            mqttServer.InterceptingPublishAsync += publisherInterceptor.InterceptAsync;
            mqttServer.ValidatingConnectionAsync += validatingConnectionInterceptor.InterceptAsync;
            mqttServer.ClientAcknowledgedPublishPacketAsync += clientAcknowledgedPublishPacketInterceptor.InterceptAsync;
        }
    }
}
