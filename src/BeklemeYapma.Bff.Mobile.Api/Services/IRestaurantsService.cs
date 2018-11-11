using BeklemeYapma.Bff.Mobile.Api.Models.Requests;
using BeklemeYapma.Bff.Mobile.Api.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeklemeYapma.Bff.Mobile.Api.Services
{
    public interface IRestaurantsService
    {
        Task<BaseResponse<List<RestaurantGetResponse>>> GetAllAsync(RestaurantGetAllRequest request);
        Task<BaseResponse<RestaurantGetResponse>> GetAsync(RestaurantGetRequest request);
    }
}