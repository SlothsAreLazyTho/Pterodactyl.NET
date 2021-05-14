using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

using RestSharp;

namespace Pterodactyl.NET.Objects.V1_0.Client
{

    [DebuggerDisplay("{" + nameof(Username) + "}")]
    public partial class Account
    {
        private readonly IRestClient _client;

        public Account()
        {
            _client = Pterodactyl.Instance.HttpClient;
        }


        public int Id { get; set; }

        [JsonProperty("admin")]
        public bool IsAdmin { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        public string Language { get; set; }


        public async Task<bool> UpdateEmailAsync(string email, string password, CancellationToken token = default)
        {
            var payload = new
            {
                Email = email,
                Password = password
            };

            var request = new RestRequest("/api/client/account/email", Method.PUT)
                .AddJsonBody(payload);

            var response = await _client.ExecuteAsync(request, token);

            return response.IsSuccessful;
        }

        public async Task<bool> UpdatePasswordAsync(string currentPassword, string newPassword, CancellationToken token = default)
        {
            var payload = new
            {
                current_password = currentPassword,
                password = newPassword,
                password_confirmation = newPassword
            };

            var request = new RestRequest("/api/client/account/password", Method.PUT)
                .AddJsonBody(payload);

            var response = await _client.ExecuteAsync(request, token);

            return response.IsSuccessful;
        }

    }

    public partial class Account2FA
    {

        [JsonProperty("image_url_data")]
        public string ImageUrlData { get; set; }
    }

    public partial class Account2FATokens
    {

        public string[] Tokens { get; set; }

    }
}
