using Newtonsoft.Json;

using Pterodactyl.NET.Exceptions;

using RestSharp;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pterodactyl.NET.Endpoints
{
    public abstract class BaseEndpoint
    {

        private readonly IRestClient _client;

        internal BaseEndpoint(IRestClient client)
        {
            _client = client;
        }

        private static int CheckRateLimit(RestResponse response)
        {
            var headers = response.Headers;
            if (headers != null)
            {
                var rateLimitHeader = headers.FirstOrDefault((x) => x.Name is "x-ratelimit-limit");
                var remainingHeader = headers.FirstOrDefault((h) => h.Name is "x-ratelimit-remaining");
                if (rateLimitHeader == null || remainingHeader == null)
                {
                    return 0;
                }

                return int.Parse(remainingHeader.Value?.ToString() ?? "0");
            }

            return (0);
        }

        protected async Task<RestResponse<T>> HandleRequestRawAsync<T>(RestRequest request, CancellationToken token = default)
        {
            var response = await _client.ExecuteAsync<T>(request, token)
                .ConfigureAwait(false);

            var rateLimited = CheckRateLimit(response);
            if(rateLimited != 0)
            {
                throw new PterodactylException($"You are being rate limited, Wait another {rateLimited} seconds.");
            }

            if (!response.IsSuccessful)
            {
                var body = JsonConvert.DeserializeObject<BaseError>(response.Content);
                throw new PterodactylException(body?.Errors);
            }

            return response;
        }

        protected async Task<RestResponse> HandleRequestRawAsync(RestRequest request, CancellationToken token = default)
        {
            var result = await HandleRequestRawAsync<object>(request, token)
                .ConfigureAwait(false);

            return result;
        }

        protected async Task<T> HandleRequest<T>(RestRequest request, CancellationToken token = default)
        {
            var response = await HandleRequestRawAsync<BaseAttributes<T>>(request, token);

            return response.Data.Attributes;
        }

        protected async Task<PterodactylList<T>> HandleArrayRequest<T>(RestRequest request, CancellationToken token = default)
        {
            var response = await HandleRequestRawAsync<BaseResponse<T>>(request, token);

            return new PterodactylList<T>(response.Data);
        }

    }
}
