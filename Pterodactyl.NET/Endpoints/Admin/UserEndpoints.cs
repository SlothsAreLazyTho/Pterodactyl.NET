using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Pterodactyl.NET.Endpoints.Client;
using Pterodactyl.NET.Objects.Admin;

using RestSharp;
using Pterodactyl.NET.Objects.Admin.UserAttributes;
using Pterodactyl.NET.Objects;

namespace Pterodactyl.NET.Endpoints.Admin
{
    public class UserEndpoints : BaseEndpoint
    {

        internal UserEndpoints(IRestClient client) : base(client)
        { }

        public async Task<PterodactylList<User>> GetUsersAsync(CancellationToken token = default)
        {
            var request = new RestRequest("/api/application/users");

            var response = await HandleArrayRequest<BaseAttributes<User>>(request, token);

            var list = response.Select(rsp => rsp.Attributes);

            return new PterodactylList<User>(list);
        }

        public async Task<IEnumerable<User>> GetUsersAsync(Func<User, bool> func, CancellationToken token = default)
        {
            var users = await GetUsersAsync(token);
            return users.Where(func);
        }

        public async Task<User> FindUserByIdAsync(int id, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/users/{id}");

            var response = await HandleRequest<User>(request, token);

            return response;
        }

        public async Task<User> FindUserByExternalIdAsync(string externalId, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/users/external/{externalId}", Method.GET);
            
            var response = await HandleRequest<User>(request, token);

            return response;
        }

        public async Task<User> FindUserByFirstnameAsync(string firstName, CancellationToken token = default)
        {
            var users = await GetUsersAsync(token);
            return users.Where(c => c.FirstName == firstName).FirstOrDefault();
        }

        public async Task<User> FindUserByLastnameAsync(string lastName, CancellationToken token = default)
        {
            var users = await GetUsersAsync(token);
            return users.Where(c => c.LastName == lastName).FirstOrDefault();
        }

        public async Task<User> FindUserByUsernameAsync(string username, CancellationToken token = default)
        {
            var users = await GetUsersAsync(token);
            return users.Where(c => c.Username == username).FirstOrDefault();
        }

        public async Task<User> FindUserByUUIDAsync(string uuid, CancellationToken token = default)
        {
            var users = await GetUsersAsync(token);
            return users.Where(c => c.Uuid == uuid).FirstOrDefault();
        }

        public async Task<User> CreateUserAsync(Action<UserOptions> options, CancellationToken token = default)
        {
            var user = new UserOptions();
            options.Invoke(user);
            var request = new RestRequest($"/api/application/users", Method.POST)
                .AddJsonBody(user);

            var response = await HandleRequest<User>(request, token);

            return response;
        }

        public async Task<User> CreateUserAsync(UserOptions options, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/users", Method.POST)
                .AddJsonBody(options);

            var response = await HandleRequest<User>(request, token);

            return response;
        }

        public async Task<User> EditUserAsync(int id, Action<UserOptions> options, CancellationToken token = default)
        {
            var userOptions = new UserOptions();
            options.Invoke(userOptions);

            var request = new RestRequest($"/api/application/users/{id}", Method.PATCH)
                .AddJsonBody(userOptions);

            var response = await HandleRequest<User>(request, token);

            return response;
        }

        public async Task<User> EditUserAsync(User user, Action<UserOptions> options, CancellationToken token = default)
        {
            return await EditUserAsync(user.Id, options, token);
        }

        public async Task<User> EditUserAsync(int id, UserOptions options, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/users/{id}", Method.PATCH)
                .AddJsonBody(options);

            var response = await HandleRequest<User>(request, token);

            return response;
        }

        public async Task<User> EditUserAsync(User user, UserOptions options, CancellationToken token = default)
        {
            return await EditUserAsync(user.Id, options, token);
        }

        public async Task<bool> DeleteUserAsync(int id, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/users/{id}", Method.DELETE);

            var response = await HandleRequest(request, token);

            return response.IsSuccessful;
        }

        public async Task<bool> DeleteUserAsync(User user, CancellationToken token = default)
        {
            return await DeleteUserAsync(user.Id, token);
        }
    }
}
