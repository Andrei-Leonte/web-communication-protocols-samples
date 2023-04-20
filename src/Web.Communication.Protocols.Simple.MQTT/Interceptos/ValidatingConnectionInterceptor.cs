using MQTTnet.Server;
using Web.Communication.Protocols.Simple.MQTT.Interfaces.Interceptors;

namespace Web.Communication.Protocols.Simple.MQTT.Interceptos
{
    internal class ValidatingConnectionInterceptor : IValidatingConnectionInterceptor
    {
        public async Task InterceptAsync(ValidatingConnectionEventArgs arg)
        {

        }
    }
}
