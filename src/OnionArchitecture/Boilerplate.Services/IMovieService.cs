using System;
using System.Threading.Tasks;
using Boilerplate.Domain.Dtos;

namespace Boilerplate.Services
{
    public interface IMovieService
    {
        Task<BaseResponseDto<MovieDto>> GetAsync(Guid id);
    }
}