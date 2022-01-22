using InqudePOC.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InqudePOC.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidadeCredentials (UserVO user);

        TokenVO ValidadeCredentials(TokenVO token);

        bool RevokeToken(string userName);
    }
}
