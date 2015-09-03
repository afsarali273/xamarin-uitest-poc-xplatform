Feature: Example
	
@mytag
Scenario: Viewing a location
	Given I am on the locations page
	When I select location 'Xamarin Denmark APS'
	Then I should see information
