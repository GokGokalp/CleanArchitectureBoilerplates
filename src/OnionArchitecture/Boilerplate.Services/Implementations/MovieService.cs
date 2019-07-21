using System;
using System.Threading.Tasks;
using Boilerplate.Domain.Dtos;
using Boilerplate.Domain.Entities;
using Boilerplate.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Boilerplate.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly ILogger<MovieService> _logger;
        private readonly IRepository<Movie> _movieRepository;

        public MovieService(ILogger<MovieService> logger, IRepository<Movie> movieRepository)
        {
            _logger = logger;
            _movieRepository = movieRepository;
        }

        public async Task<BaseResponseDto<MovieDto>> GetAsync(Guid id)
        {
            BaseResponseDto<MovieDto> getMovieResponse = new BaseResponseDto<MovieDto>();

            try
            {
                Movie movie = await _movieRepository.GetAsync(id);

                if (movie != null)
                {
                    getMovieResponse.Data = new MovieDto
                    {
                        Name = movie.Name,
                        Rating = movie.Rating
                    };
                }
                else
                {
                    getMovieResponse.Errors.Add("Movie not found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                getMovieResponse.Errors.Add(ex.Message);
            }

            return getMovieResponse;
        }
    }
}