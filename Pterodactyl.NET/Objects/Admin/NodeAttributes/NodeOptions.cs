using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.Admin.NodeAttributes
{
    public class NodeOptions
    {

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonProperty("location_id")]
        public int LocationId { get; set; }

        [JsonProperty("public")]
        public bool IsPublic { get; set; }

        public string Fqdn { get; set; }

        public string Scheme { get; set; }

        [JsonProperty("behind_proxy")]
        public bool IsBehindProxy { get; set; }

        public long Memory { get; set; }

        [JsonProperty("memory_overallocate")]
        public long MemoryOverallocate { get; set; }

        public long Disk { get; set; }

        [JsonProperty("disk_overallocate")]
        public long DiskOverallocate { get; set; }

        [JsonProperty("daemon_base")]
        public string DaemonBase { get; set; }

        [JsonProperty("daemon_listen")]
        public string DaemonListen { get; set; }

        [JsonProperty("daemon_sftp")]
        public string DaemonSftp { get; set; }

        [JsonProperty("mainstance_mode")]
        public bool IsMainstanceMode { get; set; }

        [JsonProperty("upload_size")]
        public long UploadSize { get; set; }

    }
}
