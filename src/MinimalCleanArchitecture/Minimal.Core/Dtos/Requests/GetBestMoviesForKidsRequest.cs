using MediatR;

namespace Minimal.Core.Dtos.Requests
{
    public class GetBestMoviesForKidsRequest : IRequest<BaseResponseDto<MovieDto>>
    {
        
    }
}