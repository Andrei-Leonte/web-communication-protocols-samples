using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Communication.Protocols.Function.Serverless.SignalR.Interfaces.Connections
{
    public interface INegotiateService
    {
        Task<SignalRConnectionInfo> NegotiateAsync(HttpRequest req, CancellationToken cancellationToken);
    }
}
