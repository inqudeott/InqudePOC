using InqudePOC.Data.Converter.Contract;
using InqudePOC.Data.VO;
using InqudePOC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InqudePOC.Data.Converter.Implementations
{
    public class UserConverter : IParser<UserVO, User>, IParser<User, UserVO>
    {
        public User Parse(UserVO origin)
        {
            if (origin == null)
                return null;
            return new User
            {
                Id = origin.Id,
                UserName = origin.UserName,
                FullName = origin.FullName,
                UserRole = origin.UserRole,
                Password = origin.Password,
                Gender = origin.Gender,
                Enabled = origin.Enabled
            };
        }

        public UserVO Parse(User origin)
        {
            if (origin == null)
                return null;
            return new UserVO
            {
                               Id = origin.Id,
                UserName = origin.UserName,
                FullName = origin.FullName,
                UserRole = origin.UserRole,
                Password = origin.Password,
                Gender = origin.Gender,
                Enabled = origin.Enabled
            };
        }

        public List<User> Parse(List<UserVO> origin)
        {
            if (origin == null)
                return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<UserVO> Parse(List<User> origin)
        {
            if(origin == null)
                return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
