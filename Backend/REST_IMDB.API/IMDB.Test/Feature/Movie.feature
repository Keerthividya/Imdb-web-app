Feature: Movie Resource

@GetMovieAll
Scenario: Get Movie All
	Given I am a client
	When I make GET Request '/movies'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"Movie 1","yearOfRelease":2020,"plot":"About the movie","language":"Tamil","actors":[{"id":1,"name":"Actor 1","bio":"--","dob":"1990-04-01T00:00:00","gender":"Male","image":""},{"id":2,"name":"Actor ","bio":"--","dob":"1997-04-02T00:00:00","gender":"Female","image":""}],"genre":[{"id":1,"name":"Action"},{"id":2,"name":"Horror"}],"producer":"Producer 1","coverImage":"Image"},{"id":2,"name":"Movie 2","yearOfRelease":2021,"plot":"About the movie","language":"Tamil","actors":[{"id":1,"name":"Actor 1","bio":"--","dob":"1990-04-01T00:00:00","gender":"Male","image":""},{"id":2,"name":"Actor ","bio":"--","dob":"1997-04-02T00:00:00","gender":"Female","image":""}],"genre":[{"id":1,"name":"Action"},{"id":2,"name":"Horror"}],"producer":"Producer 2","coverImage":"Image"}]'

@GetMovieById
Scenario: Get Movie By Id
	Given I am a client
	When I make GET Request '<Endpoint>'
	Then response code must be '<StatusCode>'
	And response data must look like '<Response>'
Examples: 
| Endpoint  | StatusCode | Response                                                                                                                                                                                                                                                                                                                                                       |
| /movies/1 | 200        | {"id":1,"name":"Movie 1","yearOfRelease":2020,"plot":"About the movie","language":"Tamil","actors":[{"id":1,"name":"Actor 1","bio":"--","dob":"1990-04-01T00:00:00","gender":"Male","image":""},{"id":2,"name":"Actor ","bio":"--","dob":"1997-04-02T00:00:00","gender":"Female","image":""}],"genre":[{"id":1,"name":"Action"},{"id":2,"name":"Horror"}],"producer":"Producer 1","coverImage":"Image"} |
| /movies/0 | 400        | Invalid Id                                                                                                                                                                                                                                                                                                                                                     |
| /movies/4 | 404        | Movie 4 is Null (Parameter 'Id')                                                                                                                                                                                                                                                                                                                               |

@PostMovie
Scenario: Post Movie 
	Given I am a client
	When I am making a post request to '<Endpoint>' with the following Data '<Input Data>'
	Then response code must be '<StatusCode>'
	And response data must look like '<Response>'
Examples: 
| Endpoint | Input Data                                                                                                                               | StatusCode | Response                                                                                                                                                        |
| /movies  | {"name":"Movie 1","yearOfRelease":2020,"plot":"About the movie","actors":[1,2],"genre":[1],"producer":"Producer 1","coverImage":"Image"} | 201        | {"id":0,"name":"Movie 1","yearOfRelease":2020,"plot":"About the movie","language":null,"actors":[1,2],"genre":[1],"producer":"Producer 1","coverImage":"Image"} |
| /movies  | {"name":"","yearOfRelease":2020,"plot":"About the movie","actors":[1,2],"genre":[1],"producer":"Producer 1","coverImage":"Image"}        | 400        | Invalid arguments in Movie Name                                                                                                                                 |
| /movies  | {"name":"Movie 1","yearOfRelease":0,"plot":"About the movie","actors":[1,2],"genre":[1],"producer":"Producer 1","coverImage":"Image"}    | 400        | Invalid arguments in Movie Year Of Release                                                                                                                      |
| /movies  | {"name":"Movie 1","yearOfRelease":2020,"plot":"","actors":[1,2],"genre":[1],"producer":"Producer 1","coverImage":"Image"}                | 400        | Invalid arguments in Movie Plot                                                                                                                                 |
| /movies  | {"name":"Movie 1","yearOfRelease":2020,"plot":"About the movie","actors":[],"genre":[1],"producer":"Producer 1","coverImage":"Image"}    | 400        | Invalid arguments in Movie Actors                                                                                                                               |
| /movies  | {"name":"Movie 1","yearOfRelease":2020,"plot":"About the movie","actors":[1,2],"genre":[],"producer":"Producer 1","coverImage":"Image"}  | 400        | Invalid arguments in Movie Genres                                                                                                                               |
| /movies  | {"name":"Movie 1","yearOfRelease":2020,"plot":"About the movie","actors":[1,2],"genre":[1],"producer":"","coverImage":"Image"}           | 400        | Invalid arguments in Movie Producer                                                                                                                             |
| /movies  | {"name":"Movie 1","yearOfRelease":2020,"plot":"About the movie","actors":[1,2],"genre":[1],"producer":"Producer 1","coverImage":""}      | 400        | Invalid arguments in Movie CoverImage                                                                                                                           |


@PutMovie
Scenario: Put Movie 
	Given I am a client
	When I make PUT Request '<Endpoint>' with the following Data with the following Data '<Input Data>'
	Then response code must be '<StatusCode>'
	And response data must look like '<Response>'
Examples: 
| Endpoint  | Input Data                                                                                                                                      | StatusCode | Response                                   |
| /movies/1 | {"name":"Movie update 1","yearOfRelease":2020,"plot":"About the movie","actors":[1,2],"genre":[1],"producer":"Producer 1","coverImage":"Image"} | 200        |                                            |
| /movies/0 | {"name":"Movie update 1","yearOfRelease":2020,"plot":"About the movie","actors":[1,2],"genre":[1],"producer":"Producer 1","coverImage":"Image"} | 400        | Invalid Id                                 |
| /movies/1 | {"name":"","yearOfRelease":2020,"plot":"About the movie","actors":[1,2],"genre":[1],"producer":"Producer 1","coverImage":"Image"}               | 400        | Invalid arguments in Movie Name            |
| /movies/1 | {"name":"Movie update 1","yearOfRelease":0,"plot":"About the movie","actors":[1,2],"genre":[1],"producer":"Producer 1","coverImage":"Image"}    | 400        | Invalid arguments in Movie Year Of Release |
| /movies/1 | {"name":"Movie update 1","yearOfRelease":2020,"plot":"","actors":[1,2],"genre":[1],"producer":"Producer 1","coverImage":"Image"}                | 400        | Invalid arguments in Movie Plot            |
| /movies/1 | {"name":"Movie update 1","yearOfRelease":2020,"plot":"About the movie","actors":[],"genre":[1],"producer":"Producer 1","coverImage":"Image"}    | 400        | Invalid arguments in Movie Actors          |
| /movies/1 | {"name":"Movie update 1","yearOfRelease":2020,"plot":"About the movie","actors":[1,2],"genre":[],"producer":"Producer 1","coverImage":"Image"}  | 400        | Invalid arguments in Movie Genres          |
| /movies/1 | {"name":"Movie update 1","yearOfRelease":2020,"plot":"About the movie","actors":[1,2],"genre":[1],"producer":"","coverImage":"Image"}           | 400        | Invalid arguments in Movie Producer        |
| /movies/1 | {"name":"Movie update 1","yearOfRelease":2020,"plot":"About the movie","actors":[1,2],"genre":[1],"producer":"Producer 1","coverImage":""}      | 400        | Invalid arguments in Movie CoverImage      |
| /movies/4 | {"name":"Movie update 1","yearOfRelease":2020,"plot":"About the movie","actors":[1,2],"genre":[1],"producer":"Producer 1","coverImage":"Image"} | 404        | Movie 4 is Null (Parameter 'Id')           | 


@DeleteMovie
Scenario: Delete Movie 
	Given I am a client
	When I make Delete Request '<Endpoint>'
	Then response code must be '<StatusCode>'
	And response data must look like '<Response>'
Examples: 
| Endpoint  | StatusCode | Response                         |
| /movies/1 | 200        |                                  |
| /movies/0 | 400        | Invalid Id                       |
| /movies/4 | 404        | Movie 4 is Null (Parameter 'Id') |

