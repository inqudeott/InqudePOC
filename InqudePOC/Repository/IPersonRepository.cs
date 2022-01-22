using InqudePOC.Model;
using InqudePOC.Repository.Generic;
using System.Collections.Generic;

namespace InqudePOC.Repository
{
    public interface IPersonRepository : IRepository<User>
    {
        User Disable (long id);
       // string Cretae(User user);
        List<User> FindByName(string firstName, string lastName);

       // List<User> FindByUserNmae(string userName);

    }
}
