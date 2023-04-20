using Web.Communication.Protocols.Simple.MQTT.Startups;

var MQTTSBrokerServer = new MQTTSBrokerServer();
await MQTTSBrokerServer.RunMinimalServer();

Console.WriteLine("Hello, World!");
