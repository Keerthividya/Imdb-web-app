using Dapper;
using IMDB.Models.DB;
using IMDB.Repository.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace IMDB.Repository
{
    public class ActorRepository : BaseRepository<Actor>, IActorRepository
    {
        private readonly ConnectionString _connectionString;
        public ActorRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDBDB)
        {
            _connectionString = connectionString.Value;
        }

        public IEnumerable<Actor> Get()
        {
          

                const string query = @"
SELECT [Id]
	,[Name]
	,[Bio]
	,[DOB]
	,[Sex] AS [Gender]
    ,[Image]
FROM [foundation].[Actors](NOLOCK)";

                return Get(query);
            }
        
    public Actor Get(int id)
        {
            const string query = @"
SELECT [Id]
	,[Name]
	,[Bio]
	,[DOB]
	,[Sex] AS [Gender]
    ,[Image]
FROM [foundation].[Actors](NOLOCK)
WHERE Id = @Id";

            return Get(query, new { Id = id });

        }

        public int Create(Actor actor) 
        {
            string query = @"
INSERT INTO foundation.Actors (
	NAME
	,Bio
	,DOB
	,Sex
    ,Image
	)
VALUES (
	@Name
	,@Bio
	,@DOB
	,@Gender
    ,@Image
	)
SELECT SCOPE_IDENTITY()";
            return Create(query, new
            {
                actor.Name,
                actor.Bio,
                actor.DOB,
                actor.Gender,
                actor.Image
            });

        }

        public void Update(int id, Actor actor)
        {
            string query = @"
UPDATE foundation.Actors
SET Name = @Name
	,Bio = @Bio
	,DOB = @DOB
	,Sex = @Gender
    ,Image=@Image
WHERE Id = @Id";

            Update(query, new
            {
                actor.Name,
                actor.Bio,
                actor.DOB,
                actor.Gender,
                actor.Image,
                id = id
            });
        }

        public void Delete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            StoredProcedure("usp_DeleteActor", parameters);

        }

        public IEnumerable<Actor> GetByMovieId(int movieId)
        {
            const string query = @"
SELECT A.*
FROM foundation.Actors A
INNER JOIN foundation.Actors_Movies MA
	ON A.Id = MA.ActorId
WHERE MA.MovieId = @MovieId
";


            using var connection = new SqlConnection(_connectionString.IMDBDB);
            var actors = connection.Query<Actor>(query, new
            { MovieId = movieId });
            return actors;
        }
    }

}
