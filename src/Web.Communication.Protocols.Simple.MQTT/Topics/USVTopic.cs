using Web.Communication.Protocols.Simple.MQTT.Interfaces.Topics;

namespace Web.Communication.Protocols.Simple.MQTT.Topics
{
    internal class USVTopic : IUSVTopic
    {
        public Task ConsumeAsync(string payload)
        {
            Console.WriteLine($"USVTopic -> payload");

            return Task.CompletedTask;
        }
    }
}
