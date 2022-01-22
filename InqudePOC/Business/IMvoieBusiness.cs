using System;
using System.Collections.Generic;
using InqudePOC.Data.VO;
using InqudePOC.Model;

namespace InqudePOC.Business
{
    public interface IMovieBusiness
    {
        List<MovieVO> FindAll();

        MovieVO FindById(long id);

        MovieVO Create(MovieVO book);

        MovieVO Update(MovieVO book);

        void Delete(long id);

        
    }
}
