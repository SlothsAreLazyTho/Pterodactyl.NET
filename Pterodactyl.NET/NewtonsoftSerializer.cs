using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using RestSharp;
using RestSharp.Serialization;

#pragma warning disable 618
namespace Pterodactyl.NET
{
    internal class NewtonsoftSerializer : IRestSerializer
    {

        private static readonly JsonSerializerSettings SerializerSettings = new()
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, false),
            }
        };

        public string ContentType { get; set; } = "application/json";
        public DataFormat DataFormat { get; } = DataFormat.Json;
        public string[] SupportedContentTypes { get; } =
        {
            "application/json",
            "application/json; charset=utf"
        };

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, SerializerSettings);
        }

        public string Serialize(Parameter parameter)
        {
            return JsonConvert.SerializeObject(parameter.Value, SerializerSettings);
        }

        public T Deserialize<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

    }
}
#pragma warning restore 618