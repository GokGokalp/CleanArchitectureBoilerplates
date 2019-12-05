using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Minimal.Core.Dtos;
using Minimal.Core.Dtos.Requests;
using Minimal.Core.Interfaces;
using Minimal.Core.Models;

namespace Minimal.Core.Services.MovieUseCases
{
    public class GetBestMoviesForKidsHandler : IRequestHandler<GetBestMoviesForKidsRequest, BaseResponseDto<List<MovieDto>>>
    {
        private readonly IRepository<Movie> _repository;
        private readonly ILogger<GetBestMoviesForKidsHandler> _logger;

        public GetBestMoviesForKidsHandler(IRepository<Movie> repository, ILogger<GetBestMoviesForKidsHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<BaseResponseDto<List<MovieDto>>> Handle(GetBestMoviesForKidsRequest request, CancellationToken cancellationToken)
        {
            BaseResponseDto<List<MovieDto>> response = new BaseResponseDto<List<MovieDto>>();

            try
            {
                List<MovieDto> movies = (await _repository.GetWhereAsync(m => m.AgeGroup <= 16)).Select(m => new MovieDto
                {
                    Name = m.Name,
                    Rating = m.Rating,
                    AgeGroup = m.AgeGroup
                }).ToList();

                response.Data = movies;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Errors.Add("An error occurred while getting movies.");
            }

            return response;
        }
    }
}