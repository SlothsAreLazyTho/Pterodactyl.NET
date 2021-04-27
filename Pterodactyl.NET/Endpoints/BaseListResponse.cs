using System.Collections.Generic;

namespace Pterodactyl.NET.Endpoints.Client
{
    class BaseListResponse<T>
    {

        public string Object { get; set; }

        public IEnumerable<T> Data { get; set; }

    }
}
