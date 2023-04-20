using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Web.Communication.Protocols.Function.Serverless.SignalR.Startup))]

namespace Web.Communication.Protocols.Function.Serverless.SignalR
{
    internal class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddCors();

            builder.Services.RegisterPackages();
        }
    }
}
