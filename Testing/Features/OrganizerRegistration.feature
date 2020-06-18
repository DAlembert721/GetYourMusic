Feature: OrganizerRegistration
	In order to register
	As a organizer
	I want to create an account with the required data to access the experience that it offers me

@mytag
Scenario: The data entered is valid
	Given I'm a organizer and I have entered my data correctly
	When I make a post request to 'api/users' with the following data required '{ "Email": "juanito@gmail.com",	"Password": "password2"	}'
	And make a post request to 'api/users/13/accounts' with the following data '{ "FirstName": "Juano", "LastName": "Aliz", "BirthDate": "1978-06-03", "AccountType": "Organizer", "DistrictId": 1 }'
	Then the response for this request should be a status code of '200'
	
