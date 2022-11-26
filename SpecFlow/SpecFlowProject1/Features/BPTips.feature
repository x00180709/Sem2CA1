Feature: Present information to the user on how to take an accurate reading

This feature gives the user the ability to expand a collapsible panel to view information on taking a blood pressue reading

@tag1
Scenario: Expand the panel
	Given the user is on the Blood Pressure Calculator home page
	When the user clicks on the collapsible panel
	Then additional text is displayed to the user

@tag2
Scenario: Close the panel
	Given the user is on the Blood Pressure Calculator home page
	And the panel has been expanded
	When the user clicks on the collapsible panel
	Then the panel will closes