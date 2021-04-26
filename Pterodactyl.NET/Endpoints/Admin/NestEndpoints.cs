using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Pterodactyl.NET.Endpoints.Client;
using Pterodactyl.NET.Objects.Admin;

using RestSharp;

namespace Pterodactyl.NET.Endpoints.Admin
{
    public class NestEndpoints : BaseEndpoint
    {
        internal NestEndpoints(IRestClient client) : base(client)
        { }


        public async Task<IEnumerable<Nest>> GetNestsAsync(CancellationToken token = default)
        {
            var request = new RestRequest("/api/application/nests", Method.GET);
            var response = await _client.ExecuteAsync<BaseListResponse<BaseResponse<Nest>>>(request, token).ConfigureAwait(false);
            return response.Data.Data.Select(c => c.Attributes);
        }

        public async Task<IEnumerable<Nest>> GetNestsAsync(Func<Nest, bool> func, CancellationToken token = default)
        {
            var users = await GetNestsAsync(token);
            return users.Where(func);
        }

        public async Task<Nest> GetNestByIdAsync(int id, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/nests/{id}", Method.GET);
            var response = await _client.ExecuteAsync<BaseResponse<Nest>>(request, token).ConfigureAwait(false);
            return response.Data.Attributes;
        }

        public async Task<IEnumerable<Egg>> GetEggsByNestIdAsync(int id, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/nests/{id}/eggs", Method.GET);
            var response = await _client.ExecuteAsync<BaseListResponse<BaseResponse<Egg>>>(request, token).ConfigureAwait(false);
            return response.Data.Data.Select(c => c.Attributes);
        }

        public async Task<IEnumerable<Egg>> GetEggsByNestAsync(Nest nest, CancellationToken token = default) => await GetEggsByNestIdAsync(nest.Id);

        public async Task<Egg> GetEggByIdAsync(int nestId, int eggId, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/nests/{nestId}/eggs/{eggId}", Method.GET);
            var response = await _client.ExecuteAsync<BaseResponse<Egg>>(request, token).ConfigureAwait(false);
            return response.Data.Attributes;
        }

        public async Task<Egg> GetEggByIdAsync(Nest nest, int eggId, CancellationToken token = default) => await GetEggByIdAsync(nest.Id, eggId, token);



    }
}
