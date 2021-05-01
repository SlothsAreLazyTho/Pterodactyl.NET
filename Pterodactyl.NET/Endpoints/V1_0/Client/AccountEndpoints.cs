using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Pterodactyl.NET.Objects.V1_0.Client;

using RestSharp;

namespace Pterodactyl.NET.Endpoints.V1_0.Client
{
    public class AccountEndpoints : BaseEndpoint
    {

        internal AccountEndpoints(IRestClient client) : base(client)
        { }


        public async Task<Account> GetAccountAsync(CancellationToken token = default)
        {
            var request = new RestRequest("/api/client/account");

            var response = await HandleRequest<Account>(request, token);

            return response;
        }

        public async Task<Account2FA> Get2FAAsync(CancellationToken token = default)
        {
            var request = new RestRequest("/api/client/account/two-factor");

            var response = await HandleRequest<Account>(request, token);

            return response;
        }



    }
}
