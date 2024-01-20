Feature: Actor Resource

@GetActorAll
Scenario: Get Actor All
	Given I am a client
	When I make GET Request '/actors'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"Actor 1","bio":"--","dob":"1990-04-01T00:00:00","gender":"Male","image":""},{"id":2,"name":"Actor ","bio":"--","dob":"1997-04-02T00:00:00","gender":"Female","image":""}]'

@GetActorById
Scenario: Get Actor By Id
	Given I am a client
	When I make GET Request '<Endpoint>'
	Then response code must be '<StatusCode>'
	And response data must look like '<Response>'
Examples: 
| Endpoint  | StatusCode | Response                                                                                    |
| /actors/1 | 200        | {"id":1,"name":"Actor 1","bio":"--","dob":"1990-04-01T00:00:00","gender":"Male","image":""} |
| /actors/0 | 400        | Invalid Id                                                                                  |
| /actors/4 | 404        | Actor 4 is Null (Parameter 'Id')                                                            |


@PostActor
Scenario: Post Actor 
	Given I am a client
	When I am making a post request to '<Endpoint>' with the following Data '<Input Data>'
	Then response code must be '<StatusCode>'
	And response data must look like '<Response>'
Examples: 
| Endpoint | Input Data                                                                | StatusCode | Response                          |
| /actors  | {"name":"Actor 1","bio":"--","dob":"1990-04-01T00:00:00","gender":"Male"} | 201        | 3                                 |
| /actors  | {"name":"","bio":"--","dob":"1990-04-01T00:00:00","gender":"Male"}        | 400        | Invalid arguments in Actor Name   |
| /actors  | {"name":"Actor 1","bio":"","dob":"1990-04-01T00:00:00","gender":"Male"}   | 400        | Invalid arguments in Actor Bio    |
| /actors  | {"name":"Actor 1","bio":"--","dob":"2025-04-01T00:00:00","gender":"Male"} | 400        | Invalid arguments in Actor DOB    |
| /actors  | {"name":"Actor 1","bio":"--","dob":"1990-04-01T00:00:00","gender":""}     | 400        | Invalid arguments in Actor Gender |


@PutActor
Scenario: Put Actor 
	Given I am a client
	When I make PUT Request '<Endpoint>' with the following Data with the following Data '<Input Data>'
	Then response code must be '<StatusCode>'
	And response data must look like '<Response>'
Examples: 
| Endpoint  | Input Data                                                                       | StatusCode | Response                          |
| /actors/1 | {"name":"Actor update 1","bio":"--","dob":"1990-04-01T00:00:00","gender":"Male"} | 200        |                                   |
| /actors/0 | {"name":"Actor update 1","bio":"--","dob":"1990-04-01T00:00:00","gender":"Male"} | 400        | Invalid Id                        |
| /actors/1 | {"name":"","bio":"--","dob":"1990-04-01T00:00:00","gender":"Male"}               | 400        | Invalid arguments in Actor Name   |
| /actors/1 | {"name":"Actor 1","bio":"","dob":"1990-04-01T00:00:00","gender":"Male"}          | 400        | Invalid arguments in Actor Bio    |
| /actors/1 | {"name":"Actor 1","bio":"--","dob":"2025-04-01T00:00:00","gender":"Male"}        | 400        | Invalid arguments in Actor DOB    |
| /actors/1 | {"name":"Actor 1","bio":"--","dob":"1990-04-01T00:00:00","gender":""}            | 400        | Invalid arguments in Actor Gender |
| /actors/4 | {"name":"Actor 1","bio":"--","dob":"1990-04-01T00:00:00","gender":"Male"}        | 404        | Actor 4 is Null (Parameter 'Id')  |


@DeleteActor
Scenario: Delete Actor 
	Given I am a client
	When I make Delete Request '<Endpoint>'
	Then response code must be '<StatusCode>'
	And response data must look like '<Response>'

Examples: 
| Endpoint  | StatusCode | Response                         |
| /actors/1 | 200        |                                  |
| /actors/0 | 400        | Invalid Id                       |
| /actors/4 | 404        | Actor 4 is Null (Parameter 'Id') |


