using InqudePOC.Hypermedia;
using InqudePOC.Hypermedia.Abstract;
using System;
using System.Collections.Generic;

namespace InqudePOC.Data.VO
{
    public class MovieVO : ISupportsHyperMedia
    {

        public long Id { get; set; }
        public string Author { get; set; }
        public DateTime Launch_Date { get; set; }
        public DateTime ReleaseDate { get; set; }

        public double Rating { get; set; }


        public string Title { get; set; }
        public string Running_time { get; set; }

        public string Comparision { get; set; }

        public string Keywords { get; set; }


        public string Source { get; set; }
        public string Genre { get; set; }

        public string Production { get; set; }

        public string Production_type { get; set; }

        public string Production_countries { get; set; }

        public string Language { get; set; }

        public string Cast { get; set; }

        public string Synopsis { get; set; }

        public string Revievs { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    }
}