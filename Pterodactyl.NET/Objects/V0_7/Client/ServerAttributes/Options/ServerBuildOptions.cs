using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

using Pterodactyl.NET.Objects.Components;

namespace Pterodactyl.NET.Objects.V0_7.Client.ServerAttributes.Options
{
    public class ServerBuildOptions
    {

        public int Allocation { get; set; }

        [JsonProperty("oom_disabled")]
        public bool OomDisabled { get; set; }

        public Limits Limits { get; set; }

        [JsonProperty("add_allocations")]
        public int[] AddAllocations { get; set; }

        [JsonProperty("remove_allocations")]
        public int[] RemoveAllocations { get; set; }

        [JsonProperty("feature_limits")]
        public ServerFeatureLimits Featurelimits { get; set; }

    }
}
