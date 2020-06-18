Feature: Musician
	As a musician I'd like to meet other artists
	to improve as a musician myself

@mytag
Scenario: Musician was found
	Given I am a musician
	When I make a get request to 'api/musicians/' with the user id of '12'
	Then the result should be a status code of '200'

Scenario: Musician wasn't found
	Given I am a musician
	When I make a get request to 'api/musicians/' with the user id of '50'
	Then the musician finded do not exist and the result should be a status code of '400' 