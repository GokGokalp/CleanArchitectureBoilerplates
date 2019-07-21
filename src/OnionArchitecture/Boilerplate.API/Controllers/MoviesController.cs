using System;
using System.Threading.Tasks;
using Boilerplate.Domain.Dtos;
using Boilerplate.Services;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get([FromRoute]string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            Guid _id = Guid.Parse(id);

            BaseResponseDto<MovieDto> movie = await _movieService.GetAsync(_id);

            if (!movie.HasError || movie.Data != null)
            {
                return Ok(movie.Data);
            }
            else if (!movie.HasError || movie.Data == null)
            {
                return NotFound();
            }
            else
            {
                return BadRequest(movie.Errors);
            }
        }
    }
}