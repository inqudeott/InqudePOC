using InqudePOC.Data.Converter.Implementations;
using InqudePOC.Data.VO;
using InqudePOC.Hypermedia.Utils;
using InqudePOC.Model;
using InqudePOC.Model.Context;
using InqudePOC.Repository;
using InqudePOC.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace InqudePOC.Business.Implementations
{
    public class PersonBusinessImplementations : IPersonBusiness
    {

        private readonly IPersonRepository _repository;
        private readonly UserConverter _converter;


        public PersonBusinessImplementations(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new UserConverter();
        }

        public List<UserVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        // public PagedSearchVO<UserVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        // {
        //     var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
        //     var size = (pageSize < 1) ? 10 : pageSize;
        //     var offset = page > 0 ? (page - 1) * size : 0;

        //     string query = @"select * from user p where 1 = 1 ";

        //     if (!string.IsNullOrWhiteSpace(name)) { 
            
        //         query = query + $"and p.first_name like '%{name}%' ";
        //     }
        //     query += $"order by p.first_name {sort} limit {size} offset {offset}";

        //     string countQuery = @"select count(*) from user p where 1 = 1 ";

        //     if (!string.IsNullOrWhiteSpace(name))
        //     {

        //         countQuery = countQuery + $"and p.first_Name like '%{name}%' ";
        //     }

        //     var users = _repository.FindWithPagedSearch(query);
        //     int totalResults = _repository.GetCount(countQuery);

        //     return new PagedSearchVO<UserVO> { 
        //         CurrentPage = page,
        //         List = _converter.Parse(users),
        //         PageSize = size,
        //         SortDirections = sort,
        //         TotalResults = totalResults

        //     };
        // }


        public UserVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<UserVO> FindByName(string firstName, string lastName)
        {
            return _converter.Parse(_repository.FindByName(firstName, lastName));
        }

        public string Create(UserVO user)
        {
            try{
            var userEntity = _converter.Parse(user);

            var res = _repository.FindByName(userEntity.UserName, "");
            Console.WriteLine("Insert resule is "+res);
            if(res.Count()>0){
                return "User Already Exist";
            }
            userEntity = _repository.Create(userEntity);
            
            return "User Successfuly Registered";
            }catch(Exception e){
                Console.WriteLine("Excpetion thrown "+e.StackTrace);
                return "Server Error";
            }
        }


        public UserVO Update(UserVO user)
        {
            var userEntity = _converter.Parse(user);
            userEntity = _repository.Update(userEntity);
            return _converter.Parse(userEntity);
        }

        public UserVO Disable(long id)
        {
            var userEntity = _repository.Disable(id);
            return _converter.Parse(userEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
       
}
