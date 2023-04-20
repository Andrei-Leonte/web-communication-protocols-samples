using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using System.Threading.Tasks;
using Web.Communication.Protocols.Function.Serverless.SignalR.Consts;

namespace Web.Communication.Protocols.Function.Serverless.SignalR.Functions.V1
{
    public class USVFunction : ServerlessHub
    {
        [FunctionName(nameof(USVTrigger))]
        public async Task USVTrigger(
           [SignalRTrigger(HubConst.Name, HubConst.MessagesCategory, "USVTrigger")]
            InvocationContext invocationContext)
        {
            await Clients.All.SendAsync("MasterclassTriggerFeedback", "Hi all from usv");
        }
    }
}
