Feature: NewContract
	As organizer 
	I want to apply for a musical artist contract


@mytag
Scenario: If the data of the contract is valid
	Given that the organizer want to send a contract to the musician
	When the organizer request to 'api/organizers/13/musicians/12/contracts' to contract for an avaible time, date and location with the following data '{	"Name" : "Contrato",	"PaymentAmount" : 5000,	"Address" : "Mi casa",	"Reference" : "Al lado del vecino",	"StartDate" : "2020-05-09T20:00:00",	"EndDate" : "2020-05-10T05:00:00"	}'
	Then the response status code for this new contract request is '200'
