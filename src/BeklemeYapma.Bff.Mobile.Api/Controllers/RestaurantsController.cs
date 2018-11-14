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

        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(RestaurantGetResponse))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "No restaurant found for requested filter.")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Request not accepted.")]
        [SwaggerResponse((int)HttpStatusCode.Forbidden, Description = "Access not allowed.")]
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

        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(PagedAPIResponse<List<RestaurantGetResponse>>))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "No restaurant found for requested filter.")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Request not accepted.")]
        [SwaggerResponse((int)HttpStatusCode.Forbidden, Description = "Access not allowed.")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]RestaurantGetAllRequest request)
        {
            BaseResponse<List<RestaurantGetResponse>> restaurants = await _restaurantsService.GetAllAsync(request);

            if (!restaurants.HasError && restaurants.Data != null && restaurants.Data.Any())
            {
                PagedAPIResponse<List<RestaurantGetResponse>> response = new PagedAPIResponse<List<RestaurantGetResponse>>();
                response.Items = new List<RestaurantGetResponse>();
                response.Items.AddRange(restaurants.Data);

                PreprearePagination(request.Offset, request.Limit, restaurants.Total, "restaurants", response);
                return Ok(response);
            }
            else if (!restaurants.HasError && restaurants.Data == null)
            {
                return NotFound("No restaurant found for requested filter.");
            }
            else
            {
                return BadRequest(restaurants.Errors);
            }
        }

        // POST api/restaurants
        [HttpPost]
        public void Post([FromBody]string restaurant)
        {
        }

        // PUT api/restaurants/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string restaurant)
        {
        }

        // DELETE api/restaurants/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}