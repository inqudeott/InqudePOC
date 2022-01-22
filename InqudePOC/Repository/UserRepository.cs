using InqudePOC.Data.VO;
using InqudePOC.Model;
using InqudePOC.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace InqudePOC.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context)
        {
            _context = context;
        }
        public MySqlConnection Connection { get; }
        public User ValidateCredentials(UserVO user)
        {
        //    MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=Inqude@123;database=InqudePOC");
           
        //    MySqlConnection Connection  = new MySqlConnection(conn.ConnectionString);
        //    Connection.Open();

        //     MySqlCommand command = Connection.CreateCommand();
        //     command.CommandText = "INSERT INTO users (user_name, password, full_name) " +
        //         "VALUES('"+ user.UserName+"', '"+
        //         "Password" +"', '"+ 
        //         "fullName" + 
        //          "')";
        //     Console.WriteLine("-------------------",command.CommandText);
        //     MySqlDataReader reader = command.ExecuteReader();
            //return user;
            //var pass = ComuterHash(user.Password, new SHA256CryptoServiceProvider());
            return _context.Users.FirstOrDefault(u => (u.UserName == user.UserName)&&(u.Password == user.Password));
            //return true;
        }

        public User ValidateCredentials(string userName)
        {
            return _context.Users.SingleOrDefault(u => (u.UserName == userName));
        }

        public bool RevokeToken(string userName)
        {
           var user = _context.Users.SingleOrDefault(u => (u.UserName == userName));
           
           if (user is null)
                return false;
           user.RefreshToken = null;
           _context.SaveChanges();
           return true;
        }

        public string ComuterHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        public User RefreshUserInfo(User user)
        {
            if (!_context.Users.Any(u => u.Id.Equals(user.Id)))
            {
                return null;
            }

            var result = _context.Users.SingleOrDefault(u => u.Id.Equals(user.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return result;
        }

        
    }
}
