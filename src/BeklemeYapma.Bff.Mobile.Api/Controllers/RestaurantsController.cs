using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BeklemeYapma.Bff.Mobile.Api.Models.Requests;
using BeklemeYapma.Bff.Mobile.Api.Models.Responses;
using BeklemeYapma.Bff.Mobile.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BeklemeYapma.Bff.Mobile.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/restaurants")]
    public class RestaurantsController : BaseController
    {
        private readonly ILogger<RestaurantsController> _logger;
        private readonly IRestaurantsService _restaurantsService;

        public RestaurantsController(ILogger<RestaurantsController> logger, IRestaurantsService restaurantsService)
        {
            _logger = logger;
            _restaurantsService = restaurantsService;
        }

        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(BaseResponse<RestaurantGetResponse>))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(BaseResponse<RestaurantGetResponse>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(BaseResponse<RestaurantGetResponse>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            RestaurantGetRequest restaurantGetRequest = new RestaurantGetRequest()
            {
                Id = id
            };

            BaseResponse<RestaurantGetResponse> response = await _restaurantsService.GetAsync(restaurantGetRequest);

            return ActionResponse(response);
        }

        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(BaseResponse<List<RestaurantGetResponse>>))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(BaseResponse<List<RestaurantGetResponse>>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(BaseResponse<List<RestaurantGetResponse>>))]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]RestaurantGetAllRequest request)
        {
            BaseResponse<List<RestaurantGetResponse>> response = await _restaurantsService.GetAllAsync(request);

            return ActionResponse(response);
        }
    }
}