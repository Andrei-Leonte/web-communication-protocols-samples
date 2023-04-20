using Microsoft.AspNetCore.SignalR;

namespace Web.Communication.Protocols.Function.Serverless.SignalR.Interfaces.Connections
{
    public interface IBroadcastService
    {
        IHubClients Clients { get; }
        IGroupManager Groups { get; }
    }
}
