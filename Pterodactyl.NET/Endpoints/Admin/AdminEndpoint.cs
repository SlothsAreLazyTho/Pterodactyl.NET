using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;


namespace Pterodactyl.NET.Endpoints.Admin
{
    public class AdminEndpoint
    {

        public NestEndpoints Nests { get; }

        public UserEndpoints Users { get; }

        public LocationEndpoints Locations { get; }



        public AdminEndpoint(IRestClient client)
        {
            Nests = new NestEndpoints(client);
            Users = new UserEndpoints(client);
            Locations = new LocationEndpoints(client);
        }


    }
}
