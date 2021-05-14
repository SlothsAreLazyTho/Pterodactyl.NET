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

        private static int CheckRateLimit(IRestResponse response)
        {
            var headers = response.Headers;
            var rateLimitHeader = 
                headers.FirstOrDefault((x) => x.Name != null && x.Name.Equals("x-ratelimit-limit"));
            var remainingHeader =
                headers.FirstOrDefault((h) => h.Name != null && h.Name.Equals("x-ratelimit-remaining"));
            if (rateLimitHeader == null || remainingHeader == null)
            {
                return 0;
            }

            return int.Parse(remainingHeader.Value?.ToString() ?? "0");
        }

        protected async Task<IRestResponse<T>> HandleRequestRawAsync<T>(IRestRequest request, CancellationToken token = default)
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

        protected async Task<IRestResponse> HandleRequestRawAsync(IRestRequest request, CancellationToken token = default)
        {
            var result = await HandleRequestRawAsync<object>(request, token)
                .ConfigureAwait(false);

            return result;
        }

        protected async Task<T> HandleRequest<T>(IRestRequest request, CancellationToken token = default)
        {
            var response = await HandleRequestRawAsync<BaseAttributes<T>>(request, token);

            return response.Data.Attributes;
        }

        protected async Task<PterodactylList<T>> HandleArrayRequest<T>(IRestRequest request, CancellationToken token = default)
        {
            var response = await HandleRequestRawAsync<BaseResponse<T>>(request, token);

            return new PterodactylList<T>(response.Data);
        }

    }
}
