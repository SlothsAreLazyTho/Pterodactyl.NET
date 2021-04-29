using RestSharp;


namespace Pterodactyl.NET.Endpoints.V0_7.Admin
{
    public class AdminEndpoint
    {

        public NestEndpoints Nests { get; }

        public UserEndpoints Users { get; }

        public LocationEndpoints Locations { get; }

        public NodeEndpoints Nodes { get; }

        public ServerEndpoints Servers { get; }

        public DatabaseEndpoints Database { get; }

        public AdminEndpoint(IRestClient client)
        {
            Nests = new NestEndpoints(client);
            Users = new UserEndpoints(client);
            Locations = new LocationEndpoints(client);
            Nodes = new NodeEndpoints(client);
            Servers = new ServerEndpoints(client);
            Database = new DatabaseEndpoints(client);
        }

    }
}
