using Newtonsoft.Json;

namespace BeklemeYapma.Bff.Core.Models.Domain
{
    public class Restaurant
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("company_id")]
        public string CompanyId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}