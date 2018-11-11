namespace BeklemeYapma.Bff.Core.Models.Requests
{
    public class RestaurantGetAllRequest : PagedBaseAPIRequest
    {
        public string CompanyId { get; set; }
    }
}