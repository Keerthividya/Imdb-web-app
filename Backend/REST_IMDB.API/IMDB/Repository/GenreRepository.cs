using Dapper;
using IMDB.Models.DB;
using IMDB.Repository.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace IMDB.Repository
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        private readonly ConnectionString _connectionString;
        public GenreRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDBDB)
        {
            _connectionString = connectionString.Value;
        }

        public IEnumerable<Genre> Get()
        {
            const string query = @"
SELECT [Id]
	,[Name]
FROM foundation.Genres(NOLOCK)";

            return Get(query);
        }

        public Genre Get(int id)
        {
            const string query = @"
SELECT [Id]
	,[Name]
FROM foundation.Genres(NOLOCK)
WHERE Id = @Id";

            return Get(query, new { Id = id });

        }

        public int Create(Genre genre)
        {
            string query = @"
INSERT INTO foundation.Genres (
	NAME
	)
VALUES (
	@Name
	)
SELECT SCOPE_IDENTITY()";
            return Create(query, new
            {
                genre.Name,
                
            });

        }

        public void Update(int id, Genre genre)
        {
            string query = @"
UPDATE foundation.Genres
SET Name = @Name    
WHERE Id = @Id";

            Update(query, new
            {
                genre.Name,
                id = id
            });

        }
        public void Delete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            StoredProcedure("usp_DeleteGenre", parameters);

        }

        public IEnumerable<Genre> GetByMovieId(int movieId)
        {
            const string query = @"
SELECT G.*
FROM foundation.Genres G
INNER JOIN foundation.Genres_Movies MG
	ON G.Id = MG.GenreId
WHERE MG.MovieId = @MovieId
";


            using var connection = new SqlConnection(_connectionString.IMDBDB);
            var genres = connection.Query<Genre>(query, new
            { MovieId = movieId });
            return genres;
        }

    }
}
