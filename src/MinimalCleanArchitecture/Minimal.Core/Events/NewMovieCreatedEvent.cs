using MediatR;

namespace Minimal.Core.Events
{
    public class NewMovieCreatedEvent : INotification
    {
        private readonly string _movieName;

        public NewMovieCreatedEvent(string movieName)
        {
            _movieName = movieName;
        }
    }
}