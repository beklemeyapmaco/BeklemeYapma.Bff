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

            if (!response.HasError && response.Data != null)
            {
                return Ok(response.Data);
            }
            else if (!response.HasError && response.Data == null)
            {
                return NotFound("No product found for requested filter.");
            }
            else
            {
                return BadRequest(response.Errors);
            }
        }

        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(BaseResponse<List<RestaurantGetResponse>>))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(BaseResponse<List<RestaurantGetResponse>>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(BaseResponse<List<RestaurantGetResponse>>))]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]RestaurantGetAllRequest request)
        {
            BaseResponse<List<RestaurantGetResponse>> restaurants = await _restaurantsService.GetAllAsync(request);

            if (!restaurants.HasError && restaurants.Data != null && restaurants.Data.Any())
            {
                PagedAPIResponse<List<RestaurantGetResponse>> response = new PagedAPIResponse<List<RestaurantGetResponse>>();
                response.Items = new List<RestaurantGetResponse>();
                response.Items.AddRange(restaurants.Data);

                PreprearePagination(request.Offset, request.Limit, restaurants.Total, "values", response);
                return Ok(response);
            }
            else if (!restaurants.HasError && restaurants.Data == null)
            {
                return NotFound("No value found for requested filter.");
            }
            else
            {
                return BadRequest(restaurants.Errors);
            }
        }
    }
}