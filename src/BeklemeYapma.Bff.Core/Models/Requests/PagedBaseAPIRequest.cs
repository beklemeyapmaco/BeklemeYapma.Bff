namespace BeklemeYapma.Bff.Core.Models.Requests
{
    public class PagedBaseAPIRequest
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}