using System.Collections.Generic;
using Microsoft.Extensions.Options;
using IMDB.Models.DB;
using IMDB.Repository.Interfaces;
using IMDB;
using IMDB.Repository;


namespace IMDB.Repository
{
    public class ProducerRepository : BaseRepository<Producer>, IProducerRepository
    {
        private readonly ConnectionString _connectionString;
        public ProducerRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDBDB)
        {
            _connectionString = connectionString.Value;
        }

        public IEnumerable<Producer> Get()
        {
            const string query = @"
SELECT [Id]
	,[Name]
	,[Bio]
	,[DOB]
	,[Sex] AS [Gender]
    ,[Image]
FROM foundation.Producers (NOLOCK)";

            return Get(query);
        }

        public Producer Get(int id)
        {
            const string query = @"
SELECT [Id]
	,[Name]
	,[Bio]
	,[DOB]
	,[Sex] AS [Gender]
    ,[Image]
FROM foundation.Producers(NOLOCK)
WHERE Id = @Id";

            return Get(query, new { Id = id });

        }

        public int Create(Producer producer)
        {
            string query = @"
INSERT INTO foundation.Producers (
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
                producer.Name,
                producer.Bio,
                producer.DOB,
                producer.Gender,
                producer.Image
            });

        }

        public void Update(int id, Producer producer)
        {
            string query = @"
UPDATE foundation.Producers
SET Name = @Name
	,Bio = @Bio
	,DOB = @DOB
	,Sex = @Gender
    ,Image=@Image
WHERE Id = @Id";

            Update(query, new
            {
                producer.Name,
                producer.Bio,
                producer.DOB,
                producer.Gender,
                producer.Image,
                id = id
            });

        }

        public void Delete(int id)
        {
            string query = @"
DELETE
FROM foundation.Producers
WHERE Id = @Id";

            Delete(query, new { id = id });
        }

    }
}
