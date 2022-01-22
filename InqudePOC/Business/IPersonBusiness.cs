using InqudePOC.Data.VO;
using InqudePOC.Hypermedia.Utils;
using System.Collections.Generic;

namespace InqudePOC.Business
{
    public interface IPersonBusiness
    {
        string Create (UserVO user);
        UserVO FindByID (long id);

        List<UserVO> FindByName(string firstName, string lastName);
        List<UserVO> FindAll();

        //PagedSearchVO<UserVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);

        UserVO Update (UserVO user);
        UserVO Disable(long id);
        void Delete (long id);
    }
}
