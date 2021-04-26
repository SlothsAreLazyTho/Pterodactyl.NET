using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;


namespace Pterodactyl.NET.Endpoints.Admin
{
    public class AdminEndpoints
    {

        public ServerEndpoints Servers { get; }



        public AdminEndpoints(IRestClient client)
        {
            Servers = new ServerEndpoints(client);
        }


    }
}
