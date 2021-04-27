using System;
using System.Diagnostics;

using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.Admin
{

    [DebuggerDisplay("{" + nameof(Name) + "}")]
    public class Node
    {

        public int Id { get; set; }

        public bool Public { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonProperty("location_id")]
        public int LocationId { get; set; }

        public string Fqdn { get; set; }

        public string Scheme { get; set; }

        [JsonProperty("behind_proxy")]
        public bool IsBehindProxy { get; set; }

        [JsonProperty("mainstance_mode")]
        public bool IsMainstanceMode { get; set; }

        public long Memory { get; set; }

        [JsonProperty("memory_overallocate")]
        public long MemoryOverallocate { get; set; }

        public long Disk { get; set; }

        [JsonProperty("disk_overallocate")]
        public long DiskOverallocate { get; set; }

        [JsonProperty("upload_size")]
        public long UploadSize { get; set; }

        [JsonProperty("daemon_listen")]
        public int DaemonPort { get; set; }

        [JsonProperty("daemon_sftp")]
        public int SftpPort { get; set; }
    
        [JsonProperty("daemon_base")]
        public string DaemonBase { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
