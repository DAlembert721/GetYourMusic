Feature: MusicianRegistration
	In order to register
	As a musician
	I want to create an account with the required data to access the experience that it offers me

@mytag
Scenario: The data entered is valid
	Given I have entered my data correctly
	When I make a post request to 'api/users' with the following data '{ "Email": "lucian@gmail.com",	"Password": "password"	}'
	And also I make a post request to 'api/users/12/accounts' with the following data '{ "FirstName": "Luciano", "LastName": "Alva", "BirthDate": "1978-06-03", "AccountType": "Musician", "DistrictId": 1 }'
	Then the response should be a status code of '200'

Scenario: The data entered is not valid
	Given I have entered my data correctly
	When I make a post request to 'api/users' with the following data '{ "Email": "lucian@gmail.com",	"Password": "password"	}'
	And also I make a post request to 'api/users/12/accounts' with the following data '{ "FirstName": "Luciano", "LastName": "Alva", "BirthDate": "1978-06-03", "AccountType": "Musician", "DistrictId": 1 }'
	Then the response should be a status code of '200'