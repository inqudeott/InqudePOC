using System;
namespace InqudePOC.Data.VO
{
    public class UserVO
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get;  set; }
        public string UserRole { get;  set; }

        public string FullName { get;  set; }

        public string Gender {get;set;}
        public Boolean Enabled {get;set;}
       
    }
}
