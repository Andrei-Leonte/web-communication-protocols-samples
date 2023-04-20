using Microsoft.Extensions.DependencyInjection;
using Web.Communication.Protocols.Simple.MQTT.Interceptos;
using Web.Communication.Protocols.Simple.MQTT.Interfaces.Interceptors;
using Web.Communication.Protocols.Simple.MQTT.Interfaces.Topics;
using Web.Communication.Protocols.Simple.MQTT.Services;
using Web.Communication.Protocols.Simple.MQTT.Topics;

namespace Web.Communication.Protocols.Simple.MQTT
{
    internal static class IoCPackage
    {
        public static ServiceProvider Register()
        {
            return new ServiceCollection()
                 .AddTransient<IPublisherInterceptor, PublisherInterceptor>()
                 .AddTransient<IValidatingConnectionInterceptor, ValidatingConnectionInterceptor>()
                 .AddTransient<IClientAcknowledgedPublishPacketInterceptor, ClientAcknowledgedPublishPacketInterceptor>()
                 .AddTransient<IMasterclassTopic, MasterclassTopic>()
                 .AddTransient<IAssistTopic, AssistTopic>()
                 .AddTransient<IUSVTopic, USVTopic>()
                 .BuildServiceProvider();
        }
    }
}
