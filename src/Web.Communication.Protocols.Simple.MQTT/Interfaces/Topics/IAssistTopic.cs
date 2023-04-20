namespace Web.Communication.Protocols.Simple.MQTT.Interfaces.Topics
{
    public interface IAssistTopic
    {
        Task ConsumeAsync(string payload);
    }
}
