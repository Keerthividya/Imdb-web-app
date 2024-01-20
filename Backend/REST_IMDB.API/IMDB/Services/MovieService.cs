using System;
using System.Collections.Generic;
using System.Linq;
using IMDB.Models.DB;
using IMDB.Models.Request;
using IMDB.Models.Response;
using IMDB.Repository.Interfaces;
using IMDB.Services.Interfaces;

namespace IMDB.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IGenreRepository _genreRepository;

        public MovieService(IMovieRepository movieRepository, IActorRepository actorRepository, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            _genreRepository = genreRepository;
        }

        public IList<MovieResponse> Get()
        {

            var movies = _movieRepository.Get();
            if (!movies.Any())
            {
                throw new ArgumentNullException("Movies", "Movies cannot be Null");
            }
            var movieResponse = movies.Select(x => new MovieResponse()
            {
                Id = x.Id,
                Name = x.Name,
                YearOfRelease = x.YearOfRelease,
                Plot = x.Plot,
                Language= x.Language,
                Producer = x.Producer,
                Actors = _actorRepository.GetByMovieId(x.Id).Select(x => new ActorResponse()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Bio = x.Bio,
                    DOB = x.DOB,
                    Gender = x.Gender,
                    Image= x.Image,
                }).ToList(),
                Genre = _genreRepository.GetByMovieId(x.Id).Select(x => new GenreResponse()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),
                CoverImage = x.CoverImage,
            }).ToList();
            return movieResponse;

        }

        public MovieResponse Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid Id");
            }
            var movie = _movieRepository.Get().FirstOrDefault(a => a.Id == id);
            if (movie == null)
            {
                throw new ArgumentNullException("Id", $"Movie {id} is Null");
            }
            var movieResponse = new MovieResponse()
            {
                Id = movie.Id,
                Name = movie.Name,
                YearOfRelease = movie.YearOfRelease,
                Plot = movie.Plot,
                Language= movie.Language,
                Producer = movie.Producer,
                Actors = _actorRepository.GetByMovieId(id).Select(x => new ActorResponse()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Bio = x.Bio,
                    DOB = x.DOB,
                    Gender = x.Gender,
                    Image= x.Image,
                }).ToList(),
                Genre = _genreRepository.GetByMovieId(id).Select(x => new GenreResponse()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),
                CoverImage = movie.CoverImage,
            };
            return movieResponse;
        }
        public int Create(MovieRequest movieRequest)
        {
            if (string.IsNullOrEmpty(movieRequest.Name))
            {
                throw new ArgumentException("Invalid arguments in Movie Name");
            }
            else if (movieRequest.YearOfRelease <= 0)
            {
                throw new ArgumentException("Invalid arguments in Movie Year Of Release");
            }
            else if (string.IsNullOrEmpty(movieRequest.Plot))
            {
                throw new ArgumentException("Invalid arguments in Movie Plot");
            }
            else if (!movieRequest.Actors.Any())
            {
                throw new ArgumentException("Invalid arguments in Movie Actors");
            }
            else if (!movieRequest.Genre.Any())
            {
                throw new ArgumentException("Invalid arguments in Movie Genres");
            }
            else if (string.IsNullOrEmpty(movieRequest.Producer))
            {
                throw new ArgumentException("Invalid arguments in Movie Producer");
            }
            else if (string.IsNullOrEmpty(movieRequest.CoverImage))
            {
                throw new ArgumentException("Invalid arguments in Movie CoverImage");
            }
            var movie = new Movie()
            {
                Id = movieRequest.Id,
                Name = movieRequest.Name,
                YearOfRelease = movieRequest.YearOfRelease,
                Plot = movieRequest.Plot,
                Language= movieRequest.Language,
                Producer = movieRequest.Producer,
                CoverImage = movieRequest.CoverImage
            };

            try
            {
                var id = _movieRepository.Create(movie, movieRequest.Actors, movieRequest.Genre);
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(int id, MovieRequest movieRequest)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid Id");
            }
            if (string.IsNullOrEmpty(movieRequest.Name))
            {
                throw new ArgumentException("Invalid arguments in Movie Name");
            }
            else if (movieRequest.YearOfRelease <= 0)
            {
                throw new ArgumentException("Invalid arguments in Movie Year Of Release");
            }
            else if (string.IsNullOrEmpty(movieRequest.Plot))
            {
                throw new ArgumentException("Invalid arguments in Movie Plot");
            }
            else if (!movieRequest.Actors.Any())
            {
                throw new ArgumentException("Invalid arguments in Movie Actors");
            }
            else if (!movieRequest.Genre.Any())
            {
                throw new ArgumentException("Invalid arguments in Movie Genres");
            }
            else if (string.IsNullOrEmpty(movieRequest.Producer))
            {
                throw new ArgumentException("Invalid arguments in Movie Producer");
            }
            else if (string.IsNullOrEmpty(movieRequest.CoverImage))
            {
                throw new ArgumentException("Invalid arguments in Movie CoverImage");
            }
            else if (_movieRepository.Get().FirstOrDefault(a => a.Id == id) == null)
            {
                throw new ArgumentNullException("Id", $"Movie {id} is Null");
            }
            var movie = new Movie()
            {
                Id = movieRequest.Id,
                Name = movieRequest.Name,
                YearOfRelease = movieRequest.YearOfRelease,
                Plot = movieRequest.Plot,
                Language= movieRequest.Language,
                Producer = movieRequest.Producer,
                CoverImage = movieRequest.CoverImage
            };

            try
            {
                _movieRepository.Update(id, movie, movieRequest.Actors, movieRequest.Genre);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid Id");
            }
            var movie = _movieRepository.Get().FirstOrDefault(a => a.Id == id);
            if (movie == null)
            {
                throw new ArgumentNullException("Id", $"Movie {id} is Null");
            }
            _movieRepository.Delete(id);
        }
    }
}
