using RestSharp;

namespace Pterodactyl.NET.Endpoints
{
    public abstract class BaseEndpoint
    {

        internal readonly IRestClient _client;

        internal BaseEndpoint(IRestClient client)
        {
            this._client = client;
        }
    }
}
