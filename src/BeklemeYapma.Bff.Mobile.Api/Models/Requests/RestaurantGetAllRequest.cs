namespace BeklemeYapma.Bff.Mobile.Api.Models.Requests
{
    public class RestaurantGetAllRequest : PagedBaseAPIRequest
    {
        public string CompanyId { get; set; }
    }
}