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

        public ServerEndpoints Servers { get; }

        public UserEndpoints Users { get; }



        public AdminEndpoint(IRestClient client)
        {
            Servers = new ServerEndpoints(client);
            Users = new UserEndpoints(client);
        }


    }
}
