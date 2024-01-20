Feature: Producer Resource

@GetProducerAll
Scenario: Get Producer All
	Given I am a client
	When I make GET Request '/producers'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"Producer 1","bio":"--","dob":"1990-05-01T00:00:00","gender":"Male","image":""},{"id":2,"name":"Producer 2","bio":"--","dob":"1980-03-01T00:00:00","gender":"Female","image":""}]'

@GetProducerById
Scenario: Get Actor By Id
	Given I am a client
	When I make GET Request '<Endpoint>'
	Then response code must be '<StatusCode>'
	And response data must look like '<Response>'
Examples: 
| Endpoint     | StatusCode | Response                                                                                       |
| /producers/1 | 200        | {"id":1,"name":"Producer 1","bio":"--","dob":"1990-05-01T00:00:00","gender":"Male","image":""} |
| /producers/0 | 400        | Invalid Id                                                                                     |
| /producers/4 | 404        | Producer 4 is Null (Parameter 'Id')                                                            |


@PostProducer
Scenario: Post Producer 
	Given I am a client
	When I am making a post request to '<Endpoint>' with the following Data '<Input Data>'
	Then response code must be '<StatusCode>'
	And response data must look like '<Response>'
Examples: 
| Endpoint   | Input Data                                                                   | StatusCode | Response                             |
| /producers | {"name":"Producer 1","bio":"--","dob":"1990-05-01T00:00:00","gender":"Male"} | 201        | 3                                    |
| /producers | {"name":"","bio":"--","dob":"1990-05-01T00:00:00","gender":"Male"}           | 400        | Invalid arguments in Producer Name   |
| /producers | {"name":"Producer 1","bio":"","dob":"1990-05-01T00:00:00","gender":"Male"}   | 400        | Invalid arguments in Producer Bio    |
| /producers | {"name":"Producer 1","bio":"--","dob":"2025-04-01T00:00:00","gender":"Male"} | 400        | Invalid arguments in Producer DOB    |
| /producers | {"name":"Producer 1","bio":"--","dob":"1990-05-01T00:00:00","gender":""}     | 400        | Invalid arguments in Producer Gender |


@PutProducer
Scenario: Put Producer 
	Given I am a client
	When I make PUT Request '<Endpoint>' with the following Data with the following Data '<Input Data>'
	Then response code must be '<StatusCode>'
Examples: 
| Endpoint     | Input Data                                                                          | StatusCode | Response                             |
| /producers/1 | {"name":"Producer update 1","bio":"--","dob":"1990-05-01T00:00:00","gender":"Male"} | 200        |                                      |
| /producers/0 | {"name":"Producer update 1","bio":"--","dob":"1990-05-01T00:00:00","gender":"Male"} | 400        | Invalid Id                           |
| /producers/1 | {"name":"","bio":"--","dob":"1990-05-01T00:00:00","gender":"Male"}                  | 400        | Invalid arguments in Producer Name   |
| /producers/1 | {"name":"Producer update 1","bio":"","dob":"1990-05-01T00:00:00","gender":"Male"}   | 400        | Invalid arguments in Producer Bio    |
| /producers/1 | {"name":"Producer update 1","bio":"--","dob":"2025-04-01T00:00:00","gender":"Male"} | 400        | Invalid arguments in Producer DOB    |
| /producers/1 | {"name":"Producer update 1","bio":"--","dob":"1990-05-01T00:00:00","gender":""}     | 400        | Invalid arguments in Producer Gender |
| /producers/4 | {"name":"Producer update 1","bio":"--","dob":"1990-05-01T00:00:00","gender":"Male"} | 404        | Producer 4 is Null (Parameter 'Id')  |


@DeleteActor
Scenario: Delete Producer 
	Given I am a client
	When I make Delete Request '<Endpoint>'
	Then response code must be '<StatusCode>'
	And response data must look like '<Response>'

Examples: 
| Endpoint     | StatusCode | Response                            |
| /producers/1 | 200        |                                     |
| /producers/0 | 400        | Invalid Id                          |
| /producers/4 | 404        | Producer 4 is Null (Parameter 'Id') |