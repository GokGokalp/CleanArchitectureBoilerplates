using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Minimal.Core.Dtos;
using Minimal.Core.Dtos.Requests;

namespace Minimal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateMovieAsync([FromBody]CreateMovieRequest createMovieRequest)
        {
            BaseResponseDto<bool> createResponse = await _mediator.Send(createMovieRequest);

            if(createResponse.Data)
            {
                return Created("...", null);
            }
            else
            {
                return BadRequest(createResponse.Errors);
            }
        }
    }
}