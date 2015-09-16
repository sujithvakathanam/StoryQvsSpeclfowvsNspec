@TestSupport.Rest
@TestSupport.Rest.Given

Feature: DiariyEntries


#DiaryEntries Controller
Scenario: GET Response body -json file validation for DiaryEntriesController
Given the request has the following header values
| header | value            |
| Accept | application/json |
When the request is sent as a GET to #DiaryEntriesUri#/1
Then the server returns response code 200
And the response has the following body
"""
{"url":"http://localhost:8901/api/user/diaries/2015-05-07/entries/1","foodDescription":"Turkey, All Classes, Meat&Skn&Giblets&Neck, Raw","measureDescription":"1 Turkey","measureUrl":"http://localhost:8901/api/nutrition/foods/912/measures/1595","quantity":1.5}
"""


Scenario: POST ResponseCodes- 201 Created for DiaryEntriesController
Given the request has the content type application/json and the following body
"""
{
"quantity":105,"measureUrl":"http://localhost:8901/api/nutrition/foods/7224/measures/11433"
}
"""
When the request is sent as a POST to #DiaryEntriesUri#
Then the server returns response code 201


@myTag
Scenario: POST ResponseCode 400-Bad Request-  Duplicateerror message 
Given the request has the content type application/json and the following body
"""
{"quantity":105,"measureUrl":"http://localhost:8901/api/nutrition/foods/4280/measures/6924"
}
"""
When the request is sent as a POST to #DiaryEntriesUri#
Then the server returns response code 400
And the response has the following body
"""
{"message":"Duplicate Measure not allowed."}
"""
