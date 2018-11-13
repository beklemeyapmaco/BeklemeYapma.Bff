using Newtonsoft.Json;

namespace BeklemeYapma.Bff.Core.Models.Requests
{
    public class RestaurantGetRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}