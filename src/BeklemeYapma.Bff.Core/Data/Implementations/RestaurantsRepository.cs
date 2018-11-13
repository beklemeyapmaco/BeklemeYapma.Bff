using System.Collections.Generic;
using System.Threading.Tasks;
using BeklemeYapma.Bff.Core.Models.Requests;
using BeklemeYapma.Bff.Core.Models.Domain;
using BeklemeYapma.Bff.Core.Models.Responses;
using RestSharp;

namespace BeklemeYapma.Bff.Core.Data.Implementations
{
    public class RestaurantsRepository : IRestaurantsRepository
    {
        public readonly string DataApiRoute = "restaurants";

        public async Task<BaseResponse<List<Restaurant>>> GetAllAsync(RestaurantGetAllRequest request)
        {
            BaseResponse<List<Restaurant>> restaurantGetResponses = new BaseResponse<List<Restaurant>>();

            var restClient = new RestClient(Configurations.DataApiBaseUrl);
            var restRequest = new RestRequest(DataApiRoute, Method.GET);
            restRequest.AddParameter("company_id", request.CompanyId);
            restRequest.AddParameter("offset", request.Offset);
            restRequest.AddParameter("limit", request.Limit);

            var restResponse = restClient.Execute<PagedAPIResponse<List<Restaurant>>>(restRequest);

            restaurantGetResponses.Data = restResponse.Data.Items;

            return await Task.FromResult(restaurantGetResponses);
        }

        public async Task<Restaurant> GetAsync(RestaurantGetRequest request)
        {
            Restaurant restaurant = new Restaurant()
            {
                CompanyId = "1",
                Name = "Test"
            };

            return await Task.FromResult(restaurant);
        }
    }
}