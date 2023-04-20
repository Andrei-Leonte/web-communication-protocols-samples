namespace Web.Communication.Protocols.Simple.MQTT.Interfaces.Topics
{
    internal interface IUSVTopic
    {
        Task ConsumeAsync(string payload);
    }
}
