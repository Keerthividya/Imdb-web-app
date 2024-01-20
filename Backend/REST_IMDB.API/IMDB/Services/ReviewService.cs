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
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMovieRepository _movieRepository;

        public ReviewService(IReviewRepository reviewRepository, IMovieRepository movieRepository)
        {
            _reviewRepository = reviewRepository;
            _movieRepository = movieRepository;
        }

        public IList<ReviewResponse> Get(int movieId)
        {
            if (movieId <= 0)
            {
                throw new ArgumentException("Invalid MovieId");
            }
            var reviews = _reviewRepository.Get().Where(x => x.MovieId == movieId);
            if (!reviews.Any())
            {
                throw new ArgumentNullException("Reviews", $"Reviews for MovieId {movieId} is Null");
            }
            var reviewResponse = reviews.Select(x => new ReviewResponse()
            {
                Id = x.Id,
                Message = x.Message,
                MovieId = x.MovieId,
            }).ToList();
            return reviewResponse;
        }

        public ReviewResponse Get(int movieId, int id)
        {
            if (movieId <= 0)
            {
                throw new ArgumentException("Invalid MovieId");
            }
            else if (id <= 0)
            {
                throw new ArgumentException("Invalid ReviewId");
            }
            Review review = _reviewRepository.Get().FirstOrDefault(x => x.MovieId == movieId && x.Id == id);
            if (review == null)
            {
                throw new ArgumentNullException("Id", $"Review {id} for MovieId {movieId} is Null");
            }
            var reviewResponse = new ReviewResponse()
            {
                Id = review.Id,
                Message = review.Message,
                MovieId = review.MovieId,
            };

            return reviewResponse;
        }

        public int Create(int movieId, ReviewRequest reviewRequest)
        {
            if (movieId <= 0)
            {
                throw new ArgumentException("Invalid MovieId");
            }
            else if (string.IsNullOrEmpty(reviewRequest.Message))
            {
                throw new ArgumentException("Invalid arguments in Review Message");
            }
            else if (reviewRequest.MovieId<=0)
            {
                throw new ArgumentException("Invalid MovieId");
            }
            else if (_movieRepository.Get().FirstOrDefault(x => x.Id == movieId) == null)
            {
                throw new ArgumentNullException("MovieId", $"MovieId {movieId} is Null");
            }
            Review review = new Review()
            {
                Id = reviewRequest.Id,
                Message = reviewRequest.Message,
                MovieId = reviewRequest.MovieId,
            };
            var id = _reviewRepository.Create(review);
            return id;
        }

        public void Update(int movieId, int id, ReviewRequest reviewRequest)
        {
            if (movieId <= 0)
            {
                throw new ArgumentException("Invalid MovieId");
            }
            else if (id <= 0)
            {
                throw new ArgumentException("Invalid ReviewId");
            }
            else if (string.IsNullOrEmpty(reviewRequest.Message))
            {
                throw new ArgumentException("Invalid arguments in Review Message");
            }
            else if (reviewRequest.MovieId <= 0)
            {
                throw new ArgumentException("Invalid MovieId");
            }
            else if (_reviewRepository.Get().FirstOrDefault(x => x.MovieId == movieId && x.Id == id) == null)
            {
                throw new ArgumentNullException("Id", $"Review {id} for MovieId {movieId} is Null");
            }
            Review review = new Review()
            {
                Id = reviewRequest.Id,
                Message = reviewRequest.Message,
                MovieId = reviewRequest.MovieId,
            };
            _reviewRepository.Update(id, review);
        }

        public void Delete(int movieId, int id)
        {
            if (movieId <= 0)
            {
                throw new ArgumentException("Invalid MovieId");
            }
            else if (id <= 0)
            {
                throw new ArgumentException("Invalid ReviewId");
            }
            Review review = _reviewRepository.Get().FirstOrDefault(x => x.MovieId == movieId && x.Id == id);
            if (review == null)
            {
                throw new ArgumentNullException("Id", $"Review {id} for MovieId {movieId} is Null");
            }
            _reviewRepository.Delete(id);
        }
    }
}
