using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web.Communication.Protocols.Function.Serverless.SignalR.Interfaces.Connections;

namespace Web.Communication.Protocols.Function.Serverless.SignalR.Connections
{
    public class ConnectionHandshake: INegotiateService, IBroadcastService, IDisposable
    {
        public IHubClients Clients { get; private set; }
        public IGroupManager Groups { get; private set; }

        private readonly ServiceHubContext serviceHubContext;

        public ConnectionHandshake(
            string azureSignalRServiceConnectionString,
            string signalRHubName)
        {
            using (var serviceManager = new ServiceManagerBuilder()
                .WithOptions(options =>
                {
                    options.ConnectionString = azureSignalRServiceConnectionString;
                })
                .BuildServiceManager())
            {
                serviceHubContext = serviceManager
                    .CreateHubContextAsync(signalRHubName, default)
                .GetAwaiter()
                    .GetResult();
            }

            Clients = serviceHubContext.Clients;
            Groups = serviceHubContext.Groups;
        }

        public async Task<SignalRConnectionInfo> NegotiateAsync(
            HttpRequest req, CancellationToken cancellationToken)
        {
            string bearerToken = req.Headers.FirstOrDefault(header => header.Key == "Authorization").Value.ToString().Replace("Bearer ", "");
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(bearerToken);

            var negotiationResponse = await serviceHubContext.NegotiateAsync(new NegotiationOptions
            {
                UserId = jwtToken.Subject,
            });

            return new SignalRConnectionInfo
            {
                Url = negotiationResponse.Url,
                AccessToken = negotiationResponse.AccessToken,
            };
        }

        public void Dispose() => serviceHubContext.Dispose();
    }
}
