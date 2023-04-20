using Microsoft.Extensions.DependencyInjection;
using System;
using Web.Communication.Protocols.Function.Serverless.SignalR.Connections;
using Web.Communication.Protocols.Function.Serverless.SignalR.Consts;
using Web.Communication.Protocols.Function.Serverless.SignalR.Interfaces.Connections;

namespace Web.Communication.Protocols.Function.Serverless.SignalR
{
    internal static class IoCPackage
    {
        public static void RegisterPackages(this IServiceCollection serviceCollection)
        {
            var azureSignalRConnectionString = Environment.GetEnvironmentVariable("AzureSignalRConnectionString");
        }
    }
}
