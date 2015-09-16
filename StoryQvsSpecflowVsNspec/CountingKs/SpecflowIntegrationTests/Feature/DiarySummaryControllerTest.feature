@TestSupport.Rest
@TestSupport.Rest.Given

Feature: DiarySummary	

#DiarySummary Controller
Scenario: GET Response body -json file validation for DiarySummaryController
Given the request has the following header values
| header | value            |
| Accept | application/json |	
When the request is sent as a GET to #DiariesSummaryUri#
Then the server returns response code 200
And the response has the following body
"""
{"diaryDate":"2015-05-07T00:00:00","totalCalories":44143.0}
"""


##This can be also represented as 
#Scenario: GET Response 
#Given the DiarySummary is set up
#When I send a request to retrieveData from DiarySummaryURI
#Then I should get success response