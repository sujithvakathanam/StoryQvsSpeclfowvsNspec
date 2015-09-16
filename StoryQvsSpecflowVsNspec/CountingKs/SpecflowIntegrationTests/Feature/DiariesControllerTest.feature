@TestSupport.Rest
@TestSupport.Rest.Given

Feature: Diaries

#Diaries Controller
Scenario: GET Response Status-200 OK for DiaryEntriesController
Given the request has the following header values
| header | value            |
| Accept | application/json |	
When the request is sent as a GET to #DiariesUri#
Then the server returns response code 200	


##This can be also represented as 
#Scenario: GET Response 
#Given the Diaries are set up
#When I send a request to retrieveData from DiaryURI
#Then I should get success response

