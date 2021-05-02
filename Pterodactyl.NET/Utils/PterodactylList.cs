using System.Collections.Generic;

namespace Pterodactyl.NET.Endpoints
{
    public class PterodactylList<T> : List<T> 
    {

        public PterodactylList(BaseResponse<T> response) : base(response.Data)
        { }

        public PterodactylList(IEnumerable<T> enumerable) : base(enumerable)
        { }
    }
}
