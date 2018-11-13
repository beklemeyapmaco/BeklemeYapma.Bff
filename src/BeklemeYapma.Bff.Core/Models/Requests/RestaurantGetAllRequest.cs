using Newtonsoft.Json;

namespace BeklemeYapma.Bff.Core.Models.Requests
{
    public class RestaurantGetAllRequest : PagedBaseAPIRequest
    {
        [JsonProperty("company_id")]
        public string CompanyId { get; set; }
    }
}