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

        public PterodactylError[] Errors { get; }

        public PterodactylException(PterodactylError[] errors) : base(errors.First().Detail)
        {
            this.Errors = errors;
        }

    }
}
