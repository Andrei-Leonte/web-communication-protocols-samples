using Web.Communication.Protocols.Simple.MQTT.Interfaces.Topics;

namespace Web.Communication.Protocols.Simple.MQTT.Topics
{
    internal class AssistTopic : IAssistTopic
    {
        public Task ConsumeAsync(string payload)
        {
            Console.WriteLine($"AssistTopic -> {payload}");

            return Task.CompletedTask;
        }
    }
}
