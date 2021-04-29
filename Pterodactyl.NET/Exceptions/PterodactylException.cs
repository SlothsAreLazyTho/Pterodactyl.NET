using System;
using System.Linq;

using Pterodactyl.NET.Objects;

namespace Pterodactyl.NET.Exceptions
{
    class PterodactylException : Exception
    {

        public PterodactylError[] Errors { get; }

        public PterodactylException(PterodactylError[] errors) : base(errors.First().Detail)
        {
            Errors = errors;
        }

    }
}
