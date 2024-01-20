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
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;

        }

        public IList<GenreResponse> Get()
        {
            var genres = _genreRepository.Get();
            if (!genres.Any())
            {
                throw new ArgumentNullException("Genres", "Genres cannot be Null");
            }
            var genreResponse = genres.Select(x => new GenreResponse()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
            return genreResponse;
        }

        public GenreResponse Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid Id");
            }
            Genre genre = _genreRepository.Get().FirstOrDefault(a => a.Id == id);
            if (genre == null)
            {
                throw new ArgumentNullException("Id", $"Genre {id} is Null");
            }
            var genreResponse = new GenreResponse()
            {
                Id = genre.Id,
                Name = genre.Name,
            };

            return genreResponse;
        }
        public int Create(GenreRequest genreRequest)
        {
            if (string.IsNullOrEmpty(genreRequest.Name))
            {
                throw new ArgumentException("Invalid arguments in Genre Name");
            }
            Genre genre = new Genre()
            {
                Id = genreRequest.Id,
                Name = genreRequest.Name,

            };
            try
            {
                var id = _genreRepository.Create(genre);
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(int id, GenreRequest genreRequest)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid Id");
            }
            else if (string.IsNullOrEmpty(genreRequest.Name))
            {
                throw new ArgumentException("Invalid arguments in Genre Name");
            }
            else if (_genreRepository.Get().FirstOrDefault(a => a.Id == id) == null)
            {
                throw new ArgumentNullException("Id", $"Genre {id} is Null");
            }
            Genre genre = new Genre()
            {
                Id = genreRequest.Id,
                Name = genreRequest.Name,
            };
            try
            {
                _genreRepository.Update(id, genre);
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
            Genre genre = _genreRepository.Get().FirstOrDefault(a => a.Id == id);
            if (genre == null)
            {
                throw new ArgumentNullException("Id", $"Genre {id} is Null");
            }
            _genreRepository.Delete(id);
        }
    }
}
