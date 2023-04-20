namespace Web.Communication.Protocols.Simple.MQTT.Interfaces.Topics
{
    internal interface ITopic
    {
        Task ConsumeAsync(string payload);
    }
}
