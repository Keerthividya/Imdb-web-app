using Dapper;
using IMDB.Models.DB;
using IMDB.Repository.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace IMDB.Repository
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        private readonly ConnectionString _connectionString;
        public MovieRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDBDB)
        {
            _connectionString = connectionString.Value;
        }

        public IEnumerable<Movie> Get()
        {
            const string query = @"
SELECT [Id]
	,[Name]
	,[YearOfRelease]
	,[Plot]
    ,[Language]
	,[Producer]
    ,[Poster] AS [CoverImage]
FROM foundation.Movies(NOLOCK)

";

            return Get(query);
        }

        public Movie Get(int id)
        {
            const string query = @"
SELECT [Id]
	,[Name]
	,[YearOfRelease]
	,[Plot]
    ,[Language]
	,[Producer]
    ,[Poster] AS [CoverImage]
FROM foundation.Movies(NOLOCK)
WHERE Id = @Id";

            return Get(query, new { Id = id });

        }

        public int Create(Movie movie,List<int>actors,List<int>genre)
        {
            var ActorIds = string.Join(",", actors);
            var GenreIds = string.Join(",", genre);


            var parameters = new DynamicParameters();
            parameters.Add("@Name", movie.Name);
            parameters.Add("@YearOfRelease", movie.YearOfRelease);
            parameters.Add("@Plot", movie.Plot);
            parameters.Add("@Language", movie.Language);
            parameters.Add("@Producer", movie.Producer);
            parameters.Add("@CoverImage", movie.CoverImage);
            parameters.Add("@ActorIds", ActorIds);
            parameters.Add("@GenreIds", GenreIds);
            parameters.Add("@MovieId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using var connection = new SqlConnection(_connectionString.IMDBDB);
            connection.Execute("usp_AddMovie", parameters, commandType: CommandType.StoredProcedure);
            int id = parameters.Get<int>("@MovieId");
            return id;
           
        }

        public void Update(int id,Movie movie, List<int> actors, List<int> genre)
        {
            var ActorIds = string.Join(",", actors);
            var GenreIds = string.Join(",", genre);

            var parameters = new DynamicParameters();
            parameters.Add("@Name", movie.Name);
            parameters.Add("@YearOfRelease", movie.YearOfRelease);
            parameters.Add("@Plot", movie.Plot);
            parameters.Add("@Language", movie.Language);
            parameters.Add("@Producer", movie.Producer);
            parameters.Add("@CoverImage", movie.CoverImage);
            parameters.Add("@ActorIds", ActorIds);
            parameters.Add("@GenreIds", GenreIds);
            parameters.Add("@MovieId", id);
            StoredProcedure("usp_UpdateMovie", parameters);

        }

        public void Delete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            StoredProcedure("usp_DeleteMovie", parameters);

        }

    }
}
