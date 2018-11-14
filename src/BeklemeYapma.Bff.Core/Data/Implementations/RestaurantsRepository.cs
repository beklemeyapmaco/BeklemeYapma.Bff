using System.Collections.Generic;
using System.Threading.Tasks;
using BeklemeYapma.Bff.Core.Models.Requests;
using BeklemeYapma.Bff.Core.Models.Domain;
using BeklemeYapma.Bff.Core.Models.Responses;
using RestSharp;
using BeklemeYapma.Bff.Core.Extensions;

namespace BeklemeYapma.Bff.Core.Data.Implementations
{
    public class RestaurantsRepository : IRestaurantsRepository
    {
        public readonly string DataApiRoute = "restaurants";

        public async Task<PagedCoreResponse<List<Restaurant>>> GetAllAsync(RestaurantGetAllCoreRequest request)
        {
            var restClient = new RestClient(Configurations.DataApiBaseUrl);
            var restRequest = new RestRequest(DataApiRoute, Method.GET);
            restRequest.AddParameter("company_id", request.CompanyId);
            restRequest.AddParameter("offset", request.Offset);
            restRequest.AddParameter("limit", request.Limit);

            var restResponse = restClient.Execute<PagedCoreResponse<List<Restaurant>>>(restRequest);

            return await Task.FromResult(restResponse.Data);
        }

        public async Task<BaseCoreResponse<Restaurant>> GetAsync(RestaurantGetCoreRequest request)
        {
            var restClient = new RestClient(Configurations.DataApiBaseUrl);
            var restRequest = new RestRequest(DataApiRoute.AddRouteId(request.Id), Method.GET);

            var restResponse = restClient.Execute<BaseCoreResponse<Restaurant>>(restRequest);

            return await Task.FromResult(restResponse.Data);
        }
    }
}