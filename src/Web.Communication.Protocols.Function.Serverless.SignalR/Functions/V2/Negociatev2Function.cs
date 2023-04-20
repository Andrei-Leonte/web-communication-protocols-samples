using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using System.Threading.Tasks;
using Web.Communication.Protocols.Function.Serverless.SignalR.Interfaces.Connections;

namespace Web.Communication.Protocols.Function.Serverless.SignalR.Functions.V2
{
    public class Negociatev2Function
    {
        private readonly INegotiateService negotiateService;

        public Negociatev2Function(
            INegotiateService negotiateService)
        {
            this.negotiateService = negotiateService;
        }

        [FunctionName("negotiatev2")]
        public async Task<SignalRConnectionInfo> Negotiate(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
        {
            return await negotiateService.NegotiateAsync(req, default);
        }
    }
}