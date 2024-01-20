Feature: Genre Resource

@GetGenreAll
Scenario: Get Genre All
	Given I am a client
	When I make GET Request '/genres'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"Action"},{"id":2,"name":"Horror"}]'

@GetGenreById
Scenario: Get Genre By Id
	Given I am a client
	When I make GET Request '<Endpoint>'
	Then response code must be '<StatusCode>'
	And response data must look like '<Response>'
Examples: 
| Endpoint  | StatusCode | Response                         |
| /genres/1 | 200        | {"id":1,"name":"Action"}         |
| /genres/0 | 400        | Invalid Id                       |
| /genres/4 | 404        | Genre 4 is Null (Parameter 'Id') |


@PostGenre
Scenario: Post Genre 
	Given I am a client
	When I am making a post request to '<Endpoint>' with the following Data '<Input Data>'
	Then response code must be '<StatusCode>'
	And response data must look like '<Response>'
Examples: 
| Endpoint | Input Data        | StatusCode | Response                        |
| /genres  | {"name":"Action"} | 201        | 3                               |
| /genres  | {"name":""}       | 400        | Invalid arguments in Genre Name |


@PutGenre
Scenario: Put Genre
	Given I am a client
	When I make PUT Request '<Endpoint>' with the following Data with the following Data '<Input Data>'
	Then response code must be '<StatusCode>'
	And response data must look like '<Response>'
Examples: 
| Endpoint  | Input Data        | StatusCode | Response                         |
| /genres/1 | {"name":"Action"} | 200        |                                  |
| /genres/0 | {"name":"Action"} | 400        | Invalid Id                       |
| /genres/1 | {"name":""}       | 400        | Invalid arguments in Genre Name  |
| /genres/4 | {"name":"Action"} | 404        | Genre 4 is Null (Parameter 'Id') |


@DeleteGenre
Scenario: Delete Genre 
	Given I am a client
	When I make Delete Request '<Endpoint>'
	Then response code must be '<StatusCode>'
	And response data must look like '<Response>'
Examples: 
| Endpoint  | StatusCode | Response                         |
| /genres/1 | 200        |                                  |
| /genres/0 | 400        | Invalid Id                       |
| /genres/4 | 404        | Genre 4 is Null (Parameter 'Id') |


