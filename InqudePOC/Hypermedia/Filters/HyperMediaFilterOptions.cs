using InqudePOC.Hypermedia.Abstract;
using System.Collections.Generic;

namespace InqudePOC.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
