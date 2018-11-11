﻿namespace BeklemeYapma.Bff.Core.Models.Responses
{
    public class PagedAPIResponse<TItems>
    {
        public int Index { get; set; }
        public long PageSize { get; set; }
        public long? Total { get; set; }
        public TItems Items { get; set; }
        public string First { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }
        public string Last { get; set; }
    }
}