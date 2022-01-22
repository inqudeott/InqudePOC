using InqudePOC.Data.Converter.Contract;
using InqudePOC.Data.VO;
using InqudePOC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InqudePOC.Data.Converter.Implementations
{
    public class MovieConverter : IParser<MovieVO, Movie>, IParser<Movie, MovieVO>
    {
        public Movie Parse(MovieVO origin)
        {
           if (origin == null)
                return null;

           return new Movie
           {
               Id = origin.Id,
               Title = origin.Title,
               Launch_Date = origin.Launch_Date,
               Rating = origin.Rating,
               Comparision = origin.Comparision,
               Keywords = origin.Keywords,
               Running_time = origin.Running_time,
               Source =  origin.Source,
               Production= origin.Production,
               Production_type = origin.Production_type
        
           };
        }



// namespace InqudePOC.Model
// {
//     [Table("movie")]
//     public class Movie : BaseEntity
//     {
//         public string keywords { get; set; }

//         [Column("source")]
//         public string source { get; set; }
//         [Column("genre")]
//         public string genre { get; set; }
//         [Column("production")]
//         public string production { get; set; }

//         [Column("production_type")]
//         public string production_type { get; set; }
//         [Column("production_countried")]
//         public string production_countries { get; set; }
//         [Column("language")]
//         public string language { get; set; }

//         [Column("cast")]
//         public string cast { get; set; }
//         [Column("synopsys")]
//         public string synopsis { get; set; }
//         [Column("reviwes")]
//         public string revies { get; set; }
//     }
// }


        public MovieVO Parse(Movie origin)
        {
            if (origin == null)
                return null;

            return new MovieVO
            {
                Id = origin.Id,
               Title = origin.Title,
               Launch_Date = origin.Launch_Date,
               Rating = origin.Rating,
               Comparision = origin.Comparision,
               Keywords = origin.Keywords,
               Running_time = origin.Running_time,
               Source =  origin.Source,
               Production= origin.Production,
               Production_type = origin.Production_type
            };
        }

        public List<MovieVO> Parse(List<Movie> origin)
        {
            if (origin == null)
                return null;

            return origin.Select(item=> Parse(item)).ToList();
        }

        public List<Movie> Parse(List<MovieVO> origin)
        {
            if (origin == null)
                return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
