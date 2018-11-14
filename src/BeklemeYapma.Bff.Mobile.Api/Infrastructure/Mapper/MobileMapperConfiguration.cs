using AutoMapper;
using BeklemeYapma.Bff.Core.Models.Domain;
using BeklemeYapma.Bff.Core.Models.Requests;
using BeklemeYapma.Bff.Mobile.Api.Models.Requests;
using BeklemeYapma.Bff.Mobile.Api.Models.Responses;

namespace BeklemeYapma.Bff.Mobile.Api.Infrastructure.Mapper
{
    public class MobileMapperConfiguration : Profile
    {
        public MobileMapperConfiguration()
        {
            CreateMap<RestaurantGetRequest, RestaurantGetCoreRequest>();
            CreateMap<RestaurantGetAllRequest, RestaurantGetAllCoreRequest>();
            CreateMap<RestaurantGetResponse, Restaurant>();
        }
    }
}