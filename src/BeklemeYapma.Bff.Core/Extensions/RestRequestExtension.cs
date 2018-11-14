namespace BeklemeYapma.Bff.Core.Extensions
{
    public static class RestRequestExtension
    {
        public static string AddRouteId(this string routeString, string id)
        {
            return string.Format("{0}/{1}", routeString, id);
        }
    }
}