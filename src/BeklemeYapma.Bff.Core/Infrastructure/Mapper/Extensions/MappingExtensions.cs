using System;

namespace BeklemeYapma.Bff.Core.Infrastructure.Mapper.Extensions
{
    public static class MappingExtensions
    {
        public static TDestination Map<TDestination>(this object source)
        {
            return AutoMapperConfiguration.Mapper.Map<TDestination>(source);
        }
    }
}