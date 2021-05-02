using RestSharp;

namespace Pterodactyl.NET.Endpoints.V0_7
{
    public class PterodactylV0_7
    {

        public ClientEndpoint Client;

        public AdminEndpoint Admin;

        internal PterodactylV0_7(RestClient client)
        {
            Client = new ClientEndpoint(client);
            Admin = new AdminEndpoint(client);
        }

    }
}
