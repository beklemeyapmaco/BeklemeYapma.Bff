using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BeklemeYapma.Bff.Mobile.Api.Models.Requests
{
    public class PagedBaseAPIRequest
    {
        [JsonProperty("offset")]
        [FromQuery(Name = "offset")]
        public int Offset { get; set; }

        [JsonProperty("limit")]
        [FromQuery(Name = "limit")]
        public int Limit { get; set; }
    }
}