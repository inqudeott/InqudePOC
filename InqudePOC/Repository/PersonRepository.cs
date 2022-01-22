using InqudePOC.Model;
using InqudePOC.Model.Context;
using InqudePOC.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InqudePOC.Repository
{
    public class PersonRepository : GenericRepository<User>, IPersonRepository
    {
        public PersonRepository(MySQLContext context) : base (context) { }

        public User Disable(long id)
        {
            if (!_context.Users.Any(person => person.Id.Equals(id)))
            {
                return null;
            }
            var user = _context.Users.SingleOrDefault(person => person.Id.Equals(id));

            if (user != null)
            {
                user.Enabled = false;

                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                } 
                catch (Exception)
                {
                    throw;
                }
            }

            return user;

        }

        public List<User> FindByName(string userName, string fullName)
        {
            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(fullName))
            {
                return _context.Users.Where(
                    person => person.UserName.Contains(userName)
                    && person.FullName.Contains(fullName)).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(userName) && string.IsNullOrWhiteSpace(fullName))
            {
                return _context.Users.Where(
                    person => person.UserName.Contains(userName)).ToList();
            }
            else if (string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(fullName))
            {
                return _context.Users.Where(
                    person =>  person.FullName.Contains(fullName)).ToList();
            }
            else
            {
                return _context.Users.ToList();
            }
        }
    

    //   public List<User> FindByUserName(string userName)
    //     {
    //         if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(fullName))
    //         {
    //             return _context.Users.Where(
    //                 person => person.UserName.Contains(userName)
    //                 && person.FullName.Contains(fullName)).ToList();
    //         }
    //         else if (!string.IsNullOrWhiteSpace(userName) && string.IsNullOrWhiteSpace(fullName))
    //         {
    //             return _context.Users.Where(
    //                 person => person.UserName.Contains(userName)).ToList();
    //         }
    //         else if (string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(fullName))
    //         {
    //             return _context.Users.Where(
    //                 person =>  person.FullName.Contains(fullName)).ToList();
    //         }
    //         else
    //         {
    //             return _context.Users.ToList();
    //         }
    //     }
    }

}
