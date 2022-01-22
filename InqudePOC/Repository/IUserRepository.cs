﻿using InqudePOC.Data.VO;
using InqudePOC.Model;

namespace InqudePOC.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials (UserVO user);
        User ValidateCredentials (string username);

        bool RevokeToken(string username);

        User RefreshUserInfo(User user);

        

    }
}
