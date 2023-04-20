using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;

namespace Web.Communication.Protocols.Function.Serverless.SignalR.Functions.V1
{
    public static class NegociateFunction
    {
        [FunctionName("negotiate")]
        public static SignalRConnectionInfo Negotiate(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req,
            [SignalRConnectionInfo(HubName = "HubValue")] SignalRConnectionInfo connectionInfo)
        {
            return connectionInfo;
        }
    }
}