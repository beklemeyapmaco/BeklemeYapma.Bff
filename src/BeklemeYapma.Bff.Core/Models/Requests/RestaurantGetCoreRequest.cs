using Newtonsoft.Json;

namespace BeklemeYapma.Bff.Core.Models.Requests
{
    public class RestaurantGetCoreRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}