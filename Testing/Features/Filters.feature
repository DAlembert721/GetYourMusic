Feature: Filters
	As an organizer 
	I want to search a musician using many filters
	in order to find the musician I need 

@mytag
Scenario: Using instrument filter I found many musicians who play this instrument
	Given I am an organizer
	When I select a filter and make a request to 'api/instruments/id/musicians'
	Then the result list should be a status code of '200'

Scenario: Using instrument filter I didn't find any musicians who play this instrument
	Given I am an organizer
	When I select a filter and make a request to 'api/instruments/id/musicians'
	Then the result list should be a status code of '400'

Scenario: Using genre filter I found many musicians who play this genre
	Given I am an organizer
	When I select a filter and make a request to 'api/genres/id/musicians'
	Then the result list should be a status code of '200'

Scenario: Using genre filter I didn't find any musicians who play this genre
	Given I am an organizer
	When I select a filter and make a request to 'api/genres/id/musicians'
	Then the result list should be a status code of '400'

Scenario: Using district filter I found many musicians who live on this district
	Given I am an organizer
	When I select a filter and make a request to 'api/districts/id/musicians'
	Then the result list should be a status code of '200'

Scenario: Using district filter I didn't find any musicians who live on this district
	Given I am an organizer
	When I select a filter and make a request to 'api/districts/id/musicians'
	Then the result list should be a status code of '400'