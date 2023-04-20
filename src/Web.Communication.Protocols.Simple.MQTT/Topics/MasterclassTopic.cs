using Web.Communication.Protocols.Simple.MQTT.Interfaces.Topics;

namespace Web.Communication.Protocols.Simple.MQTT.Services
{
    internal class MasterclassTopic : IMasterclassTopic
    {
        public Task ConsumeAsync(string payload)
        {
            Console.WriteLine($"MasterclassTopic -> {payload}");

            return Task.CompletedTask;
        }
    }
}
