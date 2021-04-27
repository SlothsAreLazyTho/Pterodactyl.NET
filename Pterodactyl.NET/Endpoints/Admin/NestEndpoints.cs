using Pterodactyl.NET.Objects.Admin;

using RestSharp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pterodactyl.NET.Endpoints.Admin
{
    public class NestEndpoints : BaseEndpoint
    {
        internal NestEndpoints(IRestClient client) : base(client)
        { }


        public async Task<IEnumerable<Nest>> GetNestsAsync(CancellationToken token = default)
        {
            var request = new RestRequest("/api/application/nests");
            var response = await HandleRequest<List<Nest>>(request, token);

            return response.Data;
        }

        public async Task<IEnumerable<Nest>> FindNestsAsync(Func<Nest, bool> func, CancellationToken token = default)
        {
            var users = await GetNestsAsync(token);
            return users.Where(func);
        }

        public async Task<Nest> FindNestAsync(Func<Nest, bool> func, CancellationToken token = default)
        {
            var users = await GetNestsAsync(token);
            return users.Where(func).FirstOrDefault();
        }

        public async Task<Nest> GetNestByIdAsync(int id, CancellationToken token = default)
            => await FindNestAsync(x => x.Id == id, token);

        public async Task<IEnumerable<Egg>> GetEggsByNestAsync(Nest nest, CancellationToken token = default)
            => await GetEggsByNestIdAsync(nest.Id, token);

        public async Task<IEnumerable<Egg>> GetEggsByNestIdAsync(int id, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/nests/{id}/eggs");
            var response = await HandleRequest<List<Egg>>(request, token).ConfigureAwait(false);

            return response.Data;
        }

        public async Task<Egg> GetEggByIdAsync(Nest nest, int eggId, CancellationToken token = default)
            => await GetEggByIdAsync(nest.Id, eggId, token);

        public async Task<Egg> GetEggByIdAsync(int nestId, int eggId, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/nests/{nestId}/eggs/{eggId}");
            var response = await HandleRequest<Egg>(request, token).ConfigureAwait(false);

            return response.Data;
        }

    }
}
