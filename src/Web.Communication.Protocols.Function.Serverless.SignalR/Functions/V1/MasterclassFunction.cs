using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using System.Threading.Tasks;
using Web.Communication.Protocols.Function.Serverless.SignalR.Consts;

namespace Web.Communication.Protocols.Function.Serverless.SignalR.Functions.V1
{
    public class MasterclassFunction : ServerlessHub
    {
        [FunctionName(nameof(MasterclassTrigger))]
        public async Task MasterclassTrigger(
           [SignalRTrigger(HubConst.Name, HubConst.MessagesCategory, "MasterclassTrigger")]
            InvocationContext invocationContext)
        {
            try
            {
                var userId = invocationContext.Arguments[0].ToString();

                await Clients
                    .User(userId)
                    .SendAsync("MasterclassTrigger", $"Hi from {invocationContext.UserId}");


                await Clients
                    .User(invocationContext.UserId)
                    .SendAsync("MasterclassTriggerSuccess", "Message sent!");
            }
            catch
            {
                await Clients
                    .User(invocationContext.UserId)
                    .SendAsync("MasterclassTriggerError", "Argument is invalid");
            }
        }
    }
}