using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using System.Threading.Tasks;
using Web.Communication.Protocols.Function.Serverless.SignalR.Consts;

namespace Web.Communication.Protocols.Function.Serverless.SignalR.Functions.V1
{
    public class AssistFunction : ServerlessHub
    {
        [FunctionName(nameof(AssistTrigger))]
        public async Task AssistTrigger(
           [SignalRTrigger(HubConst.Name, HubConst.MessagesCategory, "AssistTrigger")]
            InvocationContext invocationContext)
        {
            await Clients
                .User("1234567890")
                .SendAsync("AssistTrigger Harcoded", "Hi from assist");

            await Clients
                .User(invocationContext.UserId)
                .SendAsync("AssistTrigger Not Harcoded", "Hi from assist");
        }
    }
}
