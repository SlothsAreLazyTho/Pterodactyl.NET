using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pterodactyl.NET.Objects;

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
