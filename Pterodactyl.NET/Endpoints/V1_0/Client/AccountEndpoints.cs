using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Pterodactyl.NET.Objects.V1_0.Client;
using Pterodactyl.NET.Objects.V1_0.Client.Options;

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

            var response = await HandleRequest<Account2FA>(request, token);

            return response;
        }

        public async Task<Account2FATokens> Enable2FAAsync(string totp, CancellationToken token = default)
        {
            var payload = new
            {
                code = totp
            };

            var request = new RestRequest("/api/client/account/two-factor", Method.Post)
                .AddJsonBody(payload);

            var response = await HandleRequest<BaseAttributes<Account2FATokens>>(request, token);

            return response.Attributes;
        }

        public async Task<bool> Disable2FAAsync(string password, CancellationToken token = default)
        {
            var payload = new
            {
                Password = password
            };

            var request = new RestRequest("/api/client/account/two-factor", Method.Delete)
                .AddJsonBody(payload);

            var response = await HandleRequestRawAsync(request, token);

            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        public async Task<bool> UpdateEmailAsync(string email, string password, CancellationToken token = default)
        {
            var payload = new
            {
                Email = email,
                Password = password
            };

            var request = new RestRequest("/api/client/account/email", Method.Put)
                .AddJsonBody(payload);

            var response = await HandleRequestRawAsync(request, token);

            return response.IsSuccessful;
        }

        public async Task<bool> UpdatePasswordAsync(string currentPassword, string newPassword, CancellationToken token = default)
        {
            var payload = new
            {
                current_password = currentPassword,
                password = newPassword,
                password_confirmation = newPassword
            };

            var request = new RestRequest("/api/client/account/password", Method.Put)
                .AddJsonBody(payload);

            var response = await HandleRequestRawAsync(request, token);

            return response.IsSuccessful;
        }

        public async Task<PterodactylList<ApiKey>> GetApiKeysAsync(CancellationToken token = default)
        {
            var request = new RestRequest("/api/client/account/api-keys");

            var response = await HandleArrayRequest<BaseAttributes<ApiKey>>(request, token);

            var list = response.Select(rsp => rsp.Attributes);

            return new PterodactylList<ApiKey>(list);
        }

        public async Task<ApiKey> CreateApiKeyAsync(Action<ApiKeyOptions> options, CancellationToken token = default)
        {
            var keyOption = new ApiKeyOptions();
            options.Invoke(keyOption);

            var request = new RestRequest($"/api/client/account/api-keys", Method.Post)
                .AddJsonBody(keyOption);

            var response = await HandleRequest<ApiKey>(request, token);

            return response;
        }

        public async Task<ApiKey> CreateApiKeyAsync(ApiKeyOptions options, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/client/account/api-keys", Method.Post)
                .AddJsonBody(options);

            var response = await HandleRequest<ApiKey>(request, token);

            return response;
        }

        public async Task<bool> DeleteApiKeyAsync(string identifier, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/client/account/api-keys/{identifier}", Method.Delete);

            var response = await HandleRequestRawAsync(request, token);

            return response.IsSuccessful;
        }

        public async Task<bool> DeleteApiKeyAsync(ApiKey key, CancellationToken token = default)
        {
            return await DeleteApiKeyAsync(key.Identifier, token);
        }

    }
}
