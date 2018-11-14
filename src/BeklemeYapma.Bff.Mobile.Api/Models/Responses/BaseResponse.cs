using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace BeklemeYapma.Bff.Mobile.Api.Models.Responses
{
    public class BaseResponse<TData>
    {
        public BaseResponse()
        {
            Errors = new List<string>();
        }

        [JsonProperty("has_error")]
        public bool HasError => Errors.Any();

        [JsonProperty("errors")]
        public List<string> Errors { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("data")]
        public TData Data { get; set; }
    }
}