using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BeklemeYapma.Bff.Mobile.Api.Models.Requests
{
    public class RestaurantGetRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}