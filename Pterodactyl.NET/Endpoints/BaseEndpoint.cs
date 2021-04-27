using Newtonsoft.Json;

using Pterodactyl.NET.Exceptions;

using RestSharp;

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

        public async Task<BaseResponse<T>> HandleRequest<T>(IRestRequest request, CancellationToken token = default)
        {
            var response = await HandleRequestRaw<T>(request, token);
            return response.Data;
        }

        public async Task<IRestResponse<BaseResponse<T>>> HandleRequestRaw<T>(IRestRequest request, CancellationToken token = default)
        {
            var response = await _client.ExecuteAsync<BaseResponse<T>>(request, token).ConfigureAwait(false);

            if (response.IsSuccessful)
            {
                var body = JsonConvert.DeserializeObject<BaseError>(response.Content);
                throw new PterodactylException(body?.errors);
            }

            return response;
        }

        public async Task<IRestResponse> HandleRequest(IRestRequest request, CancellationToken token = default)
        {
            var response = await _client.ExecuteAsync(request, token).ConfigureAwait(false);

            if (response.IsSuccessful)
            {
                var body = JsonConvert.DeserializeObject<BaseError>(response.Content);
                throw new PterodactylException(body?.errors);
            }

            return response;
        }

    }
}
