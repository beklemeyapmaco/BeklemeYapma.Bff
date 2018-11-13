using Newtonsoft.Json;

namespace BeklemeYapma.Bff.Core.Models.Requests
{
    public class PagedBaseAPIRequest
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("company_id")]
        public int Limit { get; set; }
    }
}