using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pterodactyl.NET.Objects;

namespace Pterodactyl.NET.Exceptions
{
    class PterodactylException : Exception
    {

        public PterodactylException(string message) : base(message)
        { }

        public PterodactylException(PterodactylError error) : base($"{(error.Status != 0 ? $"[{error.Status}]" : "")} {error.Detail}")
        { }

    }
}
