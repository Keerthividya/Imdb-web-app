using System.Collections.Generic;
using Microsoft.Extensions.Options;
using IMDB.Models.DB;
using IMDB.Repository.Interfaces;
using IMDB;
using IMDB.Repository;


namespace IMDB.Repository
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        private readonly ConnectionString _connectionString;
        public ReviewRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDBDB)
        {
            _connectionString = connectionString.Value;
        }

        public IEnumerable<Review> Get()
        {
            const string query = @"
SELECT [Id]
	,[Message]
	,[MovieId]
FROM foundation.Reviews(NOLOCK)";

            return Get(query);
        }

        public Review Get(int id)
        {
            const string query = @"
SELECT [Id]
	,[Message]
	,[MovieId]
FROM foundation.Reviews(NOLOCK)
WHERE Id = @Id";

            return Get(query, new { Id = id });

        }

        public int Create(Review review)
        {
            string query = @"
INSERT INTO foundation.Reviews (
	Message
	,MovieId
	)
VALUES (
	@Message
	,@MovieId
	)
SELECT SCOPE_IDENTITY()";
            return Create(query, new
            {
                review.Message,
                review.MovieId                
            });

        }

        public void Update(int id, Review review)
        {
            string query = @"
UPDATE foundation.Reviews
SET Message = @Message
	,MovieId = @MovieId
WHERE Id = @Id";

            Update(query, new
            {
                review.Message,
                review.MovieId,
                id = id
            });

        }

        public void Delete(int id)
        {
            string query = @"
DELETE
FROM foundation.Reviews
WHERE Id = @Id";

            Delete(query, new { id = id });
        }

    }
}
