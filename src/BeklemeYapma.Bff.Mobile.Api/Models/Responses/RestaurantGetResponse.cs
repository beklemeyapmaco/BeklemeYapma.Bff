using Newtonsoft.Json;

namespace BeklemeYapma.Bff.Mobile.Api.Models.Responses
{
    public class RestaurantGetResponse
    {
        [JsonProperty("company_id")]
        public string CompanyId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}