using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Minimal.Core.Dtos;
using Minimal.Core.Dtos.Requests;
using Minimal.Core.Events;
using Minimal.Core.Interfaces;
using Minimal.Core.Models;

namespace Minimal.Core.Services.MovieUseCases
{
    public class CreateMovieHandler : IRequestHandler<CreateMovieRequest, BaseResponseDto<bool>>
    {
        private readonly IRepository<Movie> _repository;
        private readonly ILogger<CreateMovieHandler> _logger;
        private readonly IMediator _mediator;

        public CreateMovieHandler(IRepository<Movie> repository, ILogger<CreateMovieHandler> logger, IMediator mediator)
        {
            _repository = repository;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<BaseResponseDto<bool>> Handle(CreateMovieRequest request, CancellationToken cancellationToken)
        {
            BaseResponseDto<bool> response = new BaseResponseDto<bool>();

            try
            {
                var movie = new Movie
                {
                    Name = request.Name,
                    Rating = request.Rating,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now
                };

                await _repository.CreateAsync(movie);

                response.Data = true;

                await _mediator.Publish(new NewMovieCreatedEvent(movieName: movie.Name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Errors.Add("An error occurred while creating the movie.");
            }

            return response;
        }
    }
}