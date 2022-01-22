using System;
using System.ComponentModel.DataAnnotations;
using InqudePOC.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;


namespace InqudePOC.Model
{
    [Table("users")]
    public class User : BaseEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("user_name")]
        public string UserName { get; set; }

        [Column("user_role")]
        public string UserRole { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("refresh_token")]
        public string RefreshToken { get; set; }

        [Column("refresh_token_expiry_time")]
        public DateTime RefreshTokenExpiryTime { get; set; }
        [Column("gender")]
        public string Gender { get; set; }

        [Column("enabled")]
        public Boolean Enabled { get; set; }

        


    }
}
