using System.Collections.Generic;

namespace Pterodactyl.NET.Objects
{
    public class BaseAttributes<T>
    {

        public string Object { get; set; }
        public T Attributes { get; set; }

    }
}
