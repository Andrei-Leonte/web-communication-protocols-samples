using MQTTnet;
using MQTTnet.Server;

namespace Web.Communication.Protocols.Simple.MQTT.Startups
{
    internal class MQTTSBrokerServer
    {
        public MQTTSBrokerServer()
        {
        }

        public  async Task RunMinimalServer()
        {
            var mqttFactory = new MqttFactory(new ConsoleLogger());
            var certificate = Certificate.CreateSelfSignedCertificate("1.3.6.1.5.5.7.3.1");

            var mqttServerOptions = new MqttServerOptionsBuilder()
                 .WithDefaultEndpoint()
                 .WithEncryptionCertificate(certificate)
                 .WithEncryptedEndpoint()
                 .Build();

            using var mqttServer = mqttFactory.CreateMqttServer(mqttServerOptions);
            
            mqttServer.AddInterceptor();

            await mqttServer.StartAsync();

            Console.WriteLine("Running!");
            Console.ReadLine();
        }
    }
}
