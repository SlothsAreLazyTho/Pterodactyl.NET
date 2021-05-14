using Newtonsoft.Json;

using Pterodactyl.NET.Exceptions;
using Pterodactyl.NET.Objects;

using RestSharp;

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Pterodactyl.NET.Endpoints
{
    public abstract class BaseEndpoint
    {

        private readonly IRestClient _client;

        internal BaseEndpoint(IRestClient client)
        {
            _client = client;
        }

        private int CheckRateLimit(IRestResponse response)
        {

            var headers = response.Headers;

            var rateLimit = headers.Where((h) => h.Name.Equals("x-ratelimit-limit"));

            if (!rateLimit.Any()) return 0;

            var remainingHeader = headers.Where((h) => h.Name.Equals("x-ratelimit-remaining"));

            if (!remainingHeader.Any()) return 0;

            return int.Parse(remainingHeader.ToList()[0].Value.ToString()); /* Not proud of this tbh */
        }

        protected async Task<IRestResponse<T>> HandleRequestRawAsync<T>(IRestRequest request, CancellationToken token = default)
        {

            var response = await _client.ExecuteAsync<T>(request, token)
                .ConfigureAwait(false);

            var rateLimited = CheckRateLimit(response);

            if(rateLimited != 0)
            {
                throw new PterodactylException($"You are being ratelimited, Wait another {rateLimited} seconds.");
            }

            if (!response.IsSuccessful)
            {
                var body = JsonConvert.DeserializeObject<BaseError>(response.Content);
                throw new PterodactylException(body?.Errors);
            }

            return response;
        }

        protected async Task<IRestResponse> HandleRequestRawAsync(IRestRequest request, CancellationToken token = default)
        {

            var response = await _client.ExecuteAsync(request, token)
                .ConfigureAwait(false);

            var rateLimited = CheckRateLimit(response);

            if (rateLimited != 0)
            {
                throw new PterodactylException($"You are being ratelimited, Wait another {rateLimited} seconds.");
            }

            if (!response.IsSuccessful)
            {
                var body = JsonConvert.DeserializeObject<BaseError>(response.Content);
                throw new PterodactylException(body?.Errors);
            }

            return response;
        }

        protected async Task<T> HandleRequest<T>(IRestRequest request, CancellationToken token = default)
        {
            var rsp = await HandleRequestRawAsync<BaseAttributes<T>>(request, token);
            return rsp.Data.Attributes;
        }

        protected async Task<PterodactylList<T>> HandleArrayRequest<T>(IRestRequest request, CancellationToken token = default)
        {
            var response = await HandleRequestRawAsync<BaseResponse<T>>(request, token);

            return new PterodactylList<T>(response.Data);
        }

    }
}
