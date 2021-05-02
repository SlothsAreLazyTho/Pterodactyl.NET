using System.Collections.Generic;

namespace Pterodactyl.NET.Endpoints
{
    public class BaseResponse<T>
    {

        public IEnumerable<T> Data { get; set; }

    }
}
