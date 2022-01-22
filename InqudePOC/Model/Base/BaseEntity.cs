using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace InqudePOC.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
