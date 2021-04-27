using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Pterodactyl.NET.Objects.Admin;
using Pterodactyl.NET.Objects.Admin.LocationAttributes;

using RestSharp;

namespace Pterodactyl.NET.Endpoints.Admin
{
    public class LocationEndpoints : BaseEndpoint
    {

        internal LocationEndpoints(IRestClient client) : base(client)
        { }

        public async Task<IEnumerable<Location>> GetAllAsync(CancellationToken token = default) ///api/application/locations
        {
            var request = new RestRequest("/api/application/locations");
            
            var response = await HandleRequest<IEnumerable<Location>>(request, token);

            return response.Data;
        }

        public async Task<IEnumerable<Location>> GetAllAsync(Func<Location, bool> func, CancellationToken token = default)
        {
            var locations = await GetAllAsync();
            return locations.Where(func);
        }

        public async Task<Location> GetLocationByShortCodeAsync(string code, CancellationToken token = default)
        {
            var locations = await GetAllAsync();
            return locations.Where(l => l.ShortCode == code).FirstOrDefault();
        }

        public async Task<Location> GetLocationByDescriptionAsync(string description, CancellationToken token = default)
        {
            var locations = await GetAllAsync();
            return locations.Where(l => l.Description == description).FirstOrDefault();
        }

        public async Task<Location> GetLocationByIdAsync(string id, CancellationToken token = default) ///api/application/locations
        {
            var request = new RestRequest($"/api/application/locations/{id}");
            var response = await HandleRequest<Location>(request, token); 

            return response.Data;
        }

        public async Task<Location> CreateLocationAsync(Action<LocationOptions> options, CancellationToken token = default)
        {
            var location = new LocationOptions();
            options.Invoke(location);
            var request = new RestRequest($"/api/application/users", Method.POST)
                .AddJsonBody(location);

            var response = await HandleRequest<Location>(request, token);

            return response.Data;
        }

        public async Task<Location> CreateLocationAsync(LocationOptions options, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/users", Method.POST)
                .AddJsonBody(options);

            var response = await HandleRequest<Location>(request, token);

            return response.Data;
        }

        public async Task<Location> EditLocationAsync(int id, Action<LocationOptions> options, CancellationToken token = default)
        {
            var locationOptions = new LocationOptions();
            options.Invoke(locationOptions);

            var request = new RestRequest($"/api/application/users/{id}", Method.PATCH)
                .AddJsonBody(locationOptions);

            var response = await HandleRequest<Location>(request, token);

            return response.Data;
        }

        public async Task<Location> EditLocationAsync(Location location, Action<LocationOptions> options, CancellationToken token = default)
        {
            return await EditLocationAsync(location.Id, options, token);
        }

        public async Task<Location> EditLocationAsync(int id, LocationOptions options, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/users/{id}", Method.PATCH)
                .AddJsonBody(options);

            var response = await HandleRequest<Location>(request, token);

            return response.Data;
        }

        public async Task<Location> EditLocationAsync(Location location, LocationOptions options, CancellationToken token = default)
        {
            return await EditLocationAsync(location.Id, options, token);
        }

        public async Task<bool> DeleteLocationAsync(int id, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/locations/{id}", Method.DELETE);

            var response = await HandleRequest(request, token);
            
            return response.IsSuccessful;
        }

        public async Task<bool> DeleteLocationAsync(Location location, CancellationToken token = default)
        {
            return await DeleteLocationAsync(location.Id, token);
        }

    }
}
