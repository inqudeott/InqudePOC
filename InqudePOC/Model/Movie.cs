using InqudePOC.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InqudePOC.Model
{
    [Table("movie")]
    public class Movie : BaseEntity
    {

        [Column("author")]
        public string Author { get; set; }

        [Column("launch_date")]
        public DateTime Launch_Date { get; set; }
        [Column("release_date")]
        public DateTime ReleaseDate { get; set; }

        [Column("rating")]
        public double Rating { get; set; }

        [Column("title")]
        public string Title { get; set; }
        [Column("running_time")]
        public string Running_time { get; set; }
        [Column("comparision")]
        public string Comparision { get; set; }
        [Column("keywords")]
        public string Keywords { get; set; }

        [Column("source")]
        public string Source { get; set; }
        [Column("genre")]
        public string Genre { get; set; }
        [Column("production")]
        public string Production { get; set; }

        [Column("production_type")]
        public string Production_type { get; set; }
        [Column("production_countries")]
        public string Production_countries { get; set; }
        [Column("language")]
        public string Language { get; set; }

        [Column("cast")]
        public string Cast { get; set; }
        [Column("synopsis")]
        public string Synopsis { get; set; }
        [Column("reviwes")]
        public string Revievs { get; set; }
    }
}
