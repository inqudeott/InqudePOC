using InqudePOC.Data.Converter.Implementations;
using InqudePOC.Data.VO;
using InqudePOC.Model;
using InqudePOC.Repository;
using InqudePOC.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InqudePOC.Business.Implementations
{
    public class MovieBusinessImplementation : IMovieBusiness
    {
        private IRepository<Movie> _repository;
        private readonly MovieConverter _converter;

        public MovieBusinessImplementation(IRepository<Movie> repository)
        {
            _repository = repository;
            _converter = new MovieConverter();
        }

        public List<MovieVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public MovieVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public MovieVO Create(MovieVO movie)
        {
            try{
            var movieEntity = _converter.Parse(movie);
            movieEntity  = _repository.Create(movieEntity);
            return _converter.Parse(movieEntity);
            }catch(Exception e){
                Console.WriteLine("Exception ---"+e.StackTrace);
                return movie;
            }
        }
        public MovieVO Update(MovieVO movie)
        {
            var movieEntity = _converter.Parse(movie);
            movieEntity = _repository.Update(movieEntity);
            return _converter.Parse(movieEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

       
    }
}
