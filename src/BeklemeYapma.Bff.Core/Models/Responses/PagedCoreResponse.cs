using Newtonsoft.Json;

namespace BeklemeYapma.Bff.Core.Models.Responses
{
    public class PagedCoreResponse<TItems>
    {
        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("page_size")]
        public long PageSize { get; set; }

        [JsonProperty("total")]
        public long? Total { get; set; }

        [JsonProperty("items")]
        public TItems Items { get; set; }

        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("prev")]
        public string Prev { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }
    }
}