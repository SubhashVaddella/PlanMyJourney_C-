Feature: Plan a Journey

Scenarios to test plan a journey

Background: 
Given I navigate to Transport for London website

Scenario: 1.0_Valid Journey
	Given I select valid From "Stratford" and To "Euston" Locations
	When I click on Plan my journey Button
	Then "Journey results" page should be returned
	And Journey results show details for "Stratford" and "Euston"
	And Journey is planned based on "Leaving"

Scenario: 2.0_Invalid Journey
	Given I select valid From "12345" and To "67890" Locations
	When I click on Plan my journey Button
	Then "Journey results" page should be returned
	And Error should be displayed - "Journey planner could not find any results to your search. Please try again"

Scenario Outline: 3.0_Blank To and From Locations
	Given I select valid From "<From>" and To "<To>" Locations
	When I click on Plan my journey Button
	Then Error is displayed stating missing required "<fields>" - "<Error>"
	Examples: 
	| From | To | fields | Error |
	| Stratford |        | To | The To field is required.   |
	|           | Euston | From   | The From field is required. |


Scenario: 4.0_Change time functionality
 Given change time functionality is selected
 Then Arrival Time option should be available
 And I select valid From "Stratford" and To "Euston" Locations
 When I click on Plan my journey Button
 Then "Journey results" page should be returned
 And Journey is planned based on "Arriving"


 Scenario: 5.0_Edit Journey
	Given I select valid From "Stratford" and To "Euston" Locations
	And I click on Plan my journey Button
	Then "Journey results" page should be returned
	When I select Edit Journey button
	And I Update From "Whitechapel" location
	When I click on update journey Button
	Then Journey results show details for "Whitechapel" and "Euston"


 Scenario: 6.0_Recent Journeys
    Given I select valid From "Stratford" and To "Euston" Locations
	When I click on Plan my journey Button
	Then "Journey results" page should be returned
	When I navigate back to Plan my Journey
	And I click on Recents tab on Plan my journey page
	Then Recently serched journey should be available

