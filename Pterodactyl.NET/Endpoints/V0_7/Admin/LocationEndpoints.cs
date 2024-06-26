﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Pterodactyl.NET.Objects;
using Pterodactyl.NET.Objects.V0_7.Admin;
using Pterodactyl.NET.Objects.V0_7.Admin.LocationAttributes;

using RestSharp;

namespace Pterodactyl.NET.Endpoints.V0_7.Admin
{
    public class LocationEndpoints : BaseEndpoint
    {

        internal LocationEndpoints(IRestClient client) : base(client)
        { }

        public async Task<PterodactylList<Location>> GetLocationsAsync(CancellationToken token = default) ///api/application/locations
        {
            var request = new RestRequest("/api/application/locations");

            var response = await HandleArrayRequest<BaseAttributes<Location>>(request, token);

            var list = response.Select(rsp => rsp.Attributes);

            return new PterodactylList<Location>(list);
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync(Func<Location, bool> func, CancellationToken token = default)
        {
            var locations = await GetLocationsAsync(token);
            return locations.Where(func);
        }

        public async Task<Location> GetLocationByShortCodeAsync(string code, CancellationToken token = default)
        {
            var locations = await GetLocationsAsync(token);
            return locations.FirstOrDefault(l => l.ShortCode == code);
        }

        public async Task<Location> GetLocationByDescriptionAsync(string description, CancellationToken token = default)
        {
            var locations = await GetLocationsAsync(token);
            return locations.FirstOrDefault(l => l.Description == description);
        }

        public async Task<Location> GetLocationByIdAsync(string id, CancellationToken token = default) ///api/application/locations
        {
            var request = new RestRequest($"/api/application/locations/{id}");
            var response = await HandleRequest<Location>(request, token); 

            return response;
        }

        public async Task<Location> CreateLocationAsync(Action<LocationOptions> options, CancellationToken token = default)
        {
            var location = new LocationOptions();
            options.Invoke(location);
            var request = new RestRequest($"/api/application/users", Method.Post)
                .AddJsonBody(location);

            var response = await HandleRequest<Location>(request, token);

            return response;
        }

        public async Task<Location> CreateLocationAsync(LocationOptions options, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/users", Method.Post)
                .AddJsonBody(options);

            var response = await HandleRequest<Location>(request, token);

            return response;
        }

        public async Task<Location> EditLocationAsync(int id, Action<LocationOptions> options, CancellationToken token = default)
        {
            var locationOptions = new LocationOptions();
            options.Invoke(locationOptions);

            var request = new RestRequest($"/api/application/users/{id}", Method.Patch)
                .AddJsonBody(locationOptions);

            var response = await HandleRequest<Location>(request, token);

            return response;
        }

        public async Task<Location> EditLocationAsync(Location location, Action<LocationOptions> options, CancellationToken token = default)
        {
            return await EditLocationAsync(location.Id, options, token);
        }

        public async Task<Location> EditLocationAsync(int id, LocationOptions options, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/users/{id}", Method.Patch)
                .AddJsonBody(options);

            var response = await HandleRequest<Location>(request, token);

            return response;
        }

        public async Task<Location> EditLocationAsync(Location location, LocationOptions options, CancellationToken token = default)
        {
            return await EditLocationAsync(location.Id, options, token);
        }

        public async Task<bool> DeleteLocationAsync(int id, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/locations/{id}", Method.Delete);

            var response = await HandleRequestRawAsync(request, token);
            
            return response.IsSuccessful;
        }

        public async Task<bool> DeleteLocationAsync(Location location, CancellationToken token = default)
        {
            return await DeleteLocationAsync(location.Id, token);
        }

    }
}
