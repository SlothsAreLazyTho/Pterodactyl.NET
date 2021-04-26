using System.Collections.Generic;

namespace Pterodactyl.NET.Endpoints.Client
{
    class BaseListResponse<T>
    {

        public IEnumerable<T> Data { get; set; }

    }
}
