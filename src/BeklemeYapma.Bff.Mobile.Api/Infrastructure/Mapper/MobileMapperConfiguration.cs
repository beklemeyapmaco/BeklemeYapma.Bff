using AutoMapper;
using BeklemeYapma.Bff.Mobile.Api.Models.Requests;
using BeklemeYapma.Bff.Mobile.Api.Models.Responses;

namespace BeklemeYapma.Bff.Mobile.Api.Infrastructure.Mapper
{
    public class MobileMapperConfiguration : Profile
    {
        public MobileMapperConfiguration()
        {
            CreateMap<RestaurantGetRequest, BeklemeYapma.Bff.Core.Models.Requests.RestaurantGetRequest>();
            CreateMap<RestaurantGetAllRequest, BeklemeYapma.Bff.Core.Models.Requests.RestaurantGetAllRequest>();
            CreateMap<RestaurantGetResponse, BeklemeYapma.Bff.Core.Models.Domain.Restaurant>();
        }
    }
}