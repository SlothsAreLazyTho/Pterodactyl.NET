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

        /*protected async Task<BaseResponse<T>> HandleRequest<T>(IRestRequest request, CancellationToken token = default)
        {
            var response = await HandleRequestRaw<T>(request, token);
            return response.Data;
        }*/

        protected async Task<IRestResponse<BaseResponse<T>>> HandleRequestRaw<T>(IRestRequest request, CancellationToken token = default)
        {
            var response = await _client.ExecuteAsync<BaseResponse<T>>(request, token).ConfigureAwait(false);

            Console.WriteLine($"[{response.StatusCode}] {response.ResponseUri}");
            if (!response.IsSuccessful)
            {
                var body = JsonConvert.DeserializeObject<BaseError>(response.Content);
                throw new PterodactylException(body?.Errors);
            }

            return response;
        }

        protected async Task<IRestResponse> HandleRequest(IRestRequest request, CancellationToken token = default)
        {
            var response = await _client.ExecuteAsync(request, token)
                .ConfigureAwait(false);

            if (!response.IsSuccessful)
            {
                var body = JsonConvert.DeserializeObject<BaseError>(response.Content);
                throw new PterodactylException(body?.Errors);
            }

            return response;
        }
        protected async Task<T> HandleRequest<T>(IRestRequest request, CancellationToken token = default)
        {
            var response = await _client.ExecuteAsync<BaseAttributes<T>>(request, token)
                .ConfigureAwait(false);

            if (!response.IsSuccessful)
            {
                var body = JsonConvert.DeserializeObject<BaseError>(response.Content);
                throw new PterodactylException(body?.Errors);
            }

            return response.Data.Attributes;
        }

        protected async Task<PterodactylList<T>> HandleArrayRequest<T>(IRestRequest request, CancellationToken token = default)
        {
            var response = await _client.ExecuteAsync<BaseResponse<T>>(request, token)
                .ConfigureAwait(false);

            if (!response.IsSuccessful)
            {
                var body = JsonConvert.DeserializeObject<BaseError>(response.Content);
                throw new PterodactylException(body?.Errors);
            }

            return new PterodactylList<T>(response.Data);
        }


    }
}
