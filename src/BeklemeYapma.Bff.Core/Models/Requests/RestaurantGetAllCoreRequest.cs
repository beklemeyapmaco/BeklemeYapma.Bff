using Newtonsoft.Json;

namespace BeklemeYapma.Bff.Core.Models.Requests
{
    public class RestaurantGetAllCoreRequest : PagedBaseCoreRequest
    {
        [JsonProperty("company_id")]
        public string CompanyId { get; set; }
    }
}