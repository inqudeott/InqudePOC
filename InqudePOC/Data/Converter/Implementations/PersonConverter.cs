using InqudePOC.Data.Converter.Contract;
using InqudePOC.Data.VO;
using InqudePOC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InqudePOC.Data.Converter.Implementations
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO origin)
        {
            if (origin == null)
                return null;
            return new Person
            {
                Id = origin.Id,
               
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender,
                Enabled = origin.Enabled
            };
        }

        public PersonVO Parse(Person origin)
        {
            if (origin == null)
                return null;
            return new PersonVO
            {
                Id = origin.Id,
                
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender,
                Enabled = origin.Enabled
            };
        }

        public List<Person> Parse(List<PersonVO> origin)
        {
            if (origin == null)
                return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PersonVO> Parse(List<Person> origin)
        {
            if(origin == null)
                return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
