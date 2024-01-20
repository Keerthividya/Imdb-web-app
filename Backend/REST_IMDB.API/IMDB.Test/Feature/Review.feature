Feature: Review Resource

@GetReviewAll
Scenario: Get Review All
	Given I am a client
	When I make GET Request '/movies/1/reviews'
	Then response code must be '200'
	And response data must look like '[{"id":1,"message":"Message 1","movieId":1}]'

@GetReviewById
Scenario: Get Review By Id
	Given I am a client
	When I make GET Request '<Endpoint>'
	Then response code must be '<StatusCode>'
	And response data must look like '<Response>'
Examples: 
| Endpoint            | StatusCode | Response                                        |
| /movies/1/reviews/1 | 200        | {"id":1,"message":"Message 1","movieId":1}      |
| /movies/0/reviews/1 | 400        | Invalid MovieId                                 |
| /movies/1/reviews/0 | 400        | Invalid ReviewId                                |
| /movies/1/reviews/4 | 404        | Review 4 for MovieId 1 is Null (Parameter 'Id') |



@PostReview
Scenario: Post Review 
	Given I am a client
	When I am making a post request to '<Endpoint>' with the following Data '<Input Data>'
	Then response code must be '<StatusCode>'
	And response data must look like '<Response>'
Examples: 
| Endpoint          | Input Data                          | StatusCode | Response                                |
| /movies/1/reviews | {"message":"Message 1","movieId":1} | 201        | 3                                       |
| /movies/1/reviews | {"message":"","movieId":1}          | 400        | Invalid arguments in Review Message     |
| /movies/1/reviews | {"message":"Message 1","movieId":0} | 400        | Invalid MovieId                         |
| /movies/4/reviews | {"message":"Message 1","movieId":1} | 404        | MovieId 4 is Null (Parameter 'MovieId') |


@PutReview
Scenario: Put Review 
	Given I am a client
	When I make PUT Request '<Endpoint>' with the following Data with the following Data '<Input Data>'
	Then response code must be '<StatusCode>'
Examples: 
| Endpoint            | Input Data                          | StatusCode | Response                                        |
| /movies/1/reviews/1 | {"message":"Message 1","movieId":1} | 200        |                                                 |
| /movies/0/reviews/1 | {"message":"Message 1","movieId":1} | 400        | Invalid MovieId                                 |
| /movies/1/reviews/0 | {"message":"Message 1","movieId":1} | 400        | Invalid ReviewId                                |
| /movies/1/reviews/1 | {"message":"","movieId":1}          | 400        | Invalid arguments in Review Message             |
| /movies/1/reviews/1 | {"message":"Message 1","movieId":0} | 400        | Invalid MovieId                                 |
| /movies/1/reviews/4 | {"message":"Message 1","movieId":1} | 404        | Review 4 for MovieId 1 is Null (Parameter 'Id') |



@DeleteReview
Scenario: Delete Review 
	Given I am a client
	When I make Delete Request '<Endpoint>'
	Then response code must be '<StatusCode>'
	And response data must look like '<Response>'

Examples: 
| Endpoint            | StatusCode | Response                                        |
| /movies/1/reviews/1 | 200        |                                                 |
| /movies/0/reviews/1 | 400        | Invalid MovieId                                 |
| /movies/1/reviews/0 | 400        | Invalid ReviewId                                |
| /movies/1/reviews/4 | 404        | Review 4 for MovieId 1 is Null (Parameter 'Id') |


