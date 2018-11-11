using System.Collections.Generic;
using System.Threading.Tasks;
using BeklemeYapma.Bff.Core.Models.Requests;
using BeklemeYapma.Bff.Core.Models.Domain;
using BeklemeYapma.Bff.Core.Models.Responses;

namespace BeklemeYapma.Bff.Core.Data.Implementations
{
    public class RestaurantsRepository : IRestaurantsRepository
    {
        public async Task<BaseResponse<List<Restaurant>>> GetAllAsync(RestaurantGetAllRequest request)
        {
            BaseResponse<List<Restaurant>> restaurantGetResponses = new BaseResponse<List<Restaurant>>();



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