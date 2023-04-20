using MQTTnet.Server;
using System.Text;
using Web.Communication.Protocols.Simple.MQTT.Interfaces.Interceptors;
using Web.Communication.Protocols.Simple.MQTT.Services;
using Web.Communication.Protocols.Simple.MQTT.Topics;

namespace Web.Communication.Protocols.Simple.MQTT.Interceptos
{
    internal class PublisherInterceptor : IPublisherInterceptor
    {
        public async Task InterceptAsync(InterceptingPublishEventArgs arg)
        {
            var assistTopic = new AssistTopic();
            var masterclassTopic = new MasterclassTopic();
            var usvTopic = new USVTopic();
            
            string payload = Encoding.UTF8.GetString(arg.ApplicationMessage.Payload);

            var _ = arg.ApplicationMessage.Topic switch
            {
                "masterclasstopic" => masterclassTopic.ConsumeAsync(payload),
                "assisttopic" => assistTopic.ConsumeAsync(payload),
                "usvtopic" => usvTopic.ConsumeAsync(payload),
                _ => throw new ArgumentException($"Invalid topic: {arg.ApplicationMessage.Topic}")
            };

            await _;
        }
    }
}
