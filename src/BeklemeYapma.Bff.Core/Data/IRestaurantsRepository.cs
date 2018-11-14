using System.Collections.Generic;
using System.Threading.Tasks;
using BeklemeYapma.Bff.Core.Models.Requests;
using BeklemeYapma.Bff.Core.Models.Domain;
using BeklemeYapma.Bff.Core.Models.Responses;

namespace BeklemeYapma.Bff.Core.Data
{
    public interface IRestaurantsRepository
    {
        Task<BaseResponse<Restaurant>> GetAsync(RestaurantGetRequest request);
        Task<PagedAPIResponse<List<Restaurant>>> GetAllAsync(RestaurantGetAllRequest request);
    }
}