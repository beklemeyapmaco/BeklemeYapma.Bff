using BeklemeYapma.Bff.Mobile.Api.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BeklemeYapma.Bff.Mobile.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        public void PreprearePagination<T>(int offset, int limit, long total, string resource, PagedAPIResponse<List<T>> response)
        {
            response.Total = total;
            response.PageSize = limit;
            response.Next = $"api/{resource}?offset={offset + limit + 1}&limit={limit}";

            int tmpOffset = (offset - limit) - 1;
            if (tmpOffset >= 0)
            {
                response.Prev = $"api/{resource}?offset={tmpOffset}&limit={limit}";
            }

            if(total > 0)
            {
                response.Last = $"api/{resource}?offset={total - limit}&limit={limit}";
            }

            response.First = $"api/{resource}?offset=0&limit={limit}";
        }
    }
}