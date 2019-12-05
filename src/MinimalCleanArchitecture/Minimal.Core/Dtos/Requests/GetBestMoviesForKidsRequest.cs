using System.Collections.Generic;
using MediatR;

namespace Minimal.Core.Dtos.Requests
{
    public class GetBestMoviesForKidsRequest : IRequest<BaseResponseDto<List<MovieDto>>>
    {
        
    }
}