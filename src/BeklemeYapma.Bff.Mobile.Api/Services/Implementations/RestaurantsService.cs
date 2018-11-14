using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeklemeYapma.Bff.Core.Data;
using BeklemeYapma.Bff.Core.Infrastructure.Mapper.Extensions;
using BeklemeYapma.Bff.Mobile.Api.Models.Requests;
using BeklemeYapma.Bff.Mobile.Api.Models.Responses;
using Microsoft.Extensions.Logging;

namespace BeklemeYapma.Bff.Mobile.Api.Services.Implementations
{
    public class RestaurantsService : IRestaurantsService
    {
        private readonly ILogger<RestaurantsService> _logger;
        private readonly IRestaurantsRepository _restaurantsRepository;

        public RestaurantsService(ILogger<RestaurantsService> logger, IRestaurantsRepository restaurantsRepository)
        {
            _logger = logger;
            _restaurantsRepository = restaurantsRepository;
        }

        public async Task<BaseResponse<RestaurantGetResponse>> GetAsync(RestaurantGetRequest request)
        {
            BaseResponse<RestaurantGetResponse> response = new BaseResponse<RestaurantGetResponse>();
            var dataRequest = request.Map<BeklemeYapma.Bff.Core.Models.Requests.RestaurantGetRequest>();

            try
            {
                if (!string.IsNullOrEmpty(request.Id))
                {
                    var dataResponse = await _restaurantsRepository.GetAsync(dataRequest);
                    response.Data = dataResponse.Data.Map<RestaurantGetResponse>();
                }
                else
                {
                    response.Errors.Add("Id is can not be empty.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                response.Errors.Add("An error occurred while processing your request.");
            }

            return response;
        }

        public async Task<BaseResponse<List<RestaurantGetResponse>>> GetAllAsync(RestaurantGetAllRequest request)
        {
            BaseResponse<List<RestaurantGetResponse>> response = new BaseResponse<List<RestaurantGetResponse>>();
            var dataRequest = request.Map<BeklemeYapma.Bff.Core.Models.Requests.RestaurantGetAllRequest>();

            try
            {
                if (request.Limit == 0)
                {
                    request.Limit = 50;
                }

                var dataResponse = await _restaurantsRepository.GetAllAsync(dataRequest);
                List<RestaurantGetResponse> restaurants = dataResponse.Items.Map<List<RestaurantGetResponse>>();

                if (restaurants != null && restaurants.Any())
                {
                    response.Data = new List<RestaurantGetResponse>();
                    response.Data.AddRange(restaurants);
                    response.Total = response.Data.Count();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                response.Errors.Add("An error occurred while processing your request.");
            }

            return response;
        }
    }
}