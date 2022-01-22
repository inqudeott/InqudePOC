using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InqudePOC.Business;
using InqudePOC.Data.VO;
using InqudePOC.Hypermedia.Filters;
using InqudePOC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InqudePOC.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    // [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class MoviesController : Controller
    {
       private readonly ILogger<MoviesController> _logger;
       private readonly IMovieBusiness movieBusiness;

        public MoviesController(ILogger<MoviesController> logger, IMovieBusiness movieBusiness)
        {
            _logger = logger;
            this.movieBusiness = movieBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<MovieVO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(movieBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(MovieVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get (long id)
        {
            var movie = movieBusiness.FindById(id);
            if (movie == null)
            {
                return NotFound();
            }
                return Ok(movie);
        }

        [HttpPost]
        //[Authorize("Bearer")]
        [ProducesResponseType((200), Type = typeof(MovieVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]MovieVO movie)
        {
            if (movie == null)
                return NotFound();
            return Ok (movieBusiness.Create(movie));
        }

        [HttpPut]
        [Authorize("Bearer")]
        [ProducesResponseType((200), Type = typeof(MovieVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put ([FromBody] MovieVO movie)
        {
            if (movie == null)
                return NotFound();
            return Ok(movieBusiness.Update(movie));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete (long id)
        {
            var movie = movieBusiness.FindById(id);
            if (movie == null)
            {
                return NotFound();
            }

            movieBusiness.Delete(id);
            return NoContent();
        }
    }
}
