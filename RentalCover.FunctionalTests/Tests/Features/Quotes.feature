Feature: Quotes
	Get Quotes from Rental Cover


Scenario Outline: Get Instant Quote
	Given I browse to the Rental Cover Homepage '<Homepage>'
	When I select the country where I am renting the vehicle '<CountryRenting>'
	And I select the to and from dates '<FromDate>' '<ToDate>'
	And  I select my country of residence '<CountryLiving>'
	And  I select the vehicle I want to rent '<VehicleType>'
	And  I click the Get Instant Quote button
	Then I am taken to the Policy Information & Payment page

	Examples: 
	| Homepage                     | CountryRenting | FromDate     | ToDate       | CountryLiving | VehicleType |
	| https://www.rentalcover.com/ | United States  | 25 June 2023 | 27 July 2023 | United States | Car         |
