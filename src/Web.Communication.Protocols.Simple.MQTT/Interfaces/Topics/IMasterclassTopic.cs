namespace Web.Communication.Protocols.Simple.MQTT.Interfaces.Topics
{
    internal interface IMasterclassTopic
    {
        Task ConsumeAsync(string payload);
    }
}
