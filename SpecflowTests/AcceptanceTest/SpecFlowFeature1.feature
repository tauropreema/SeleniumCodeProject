Feature: SpecFlowFeature1
	In order to update my profile 
	As a skill trader
	I want to add the languages,Skills,Education and Certifications that I know

@mytag
Scenario: Check if user could able to add a language 
	Given I clicked on the Language tab under Profile page
	When I add a new language
	Then that language should be displayed on my listings

Scenario: Check if user could able to edit a language
	Given I clicked on the Language tab under Profile page
	When I edit a existing language
	Then that language edited should be displayed on my listings

Scenario: Check if user could able to delete a language
	Given I clicked on the Language tab under Profile page
	When I delete a existing language
	Then that language should not be displayed on my listings
	
Scenario:Check if user could able to add a skill
	Given I clicked on the Skills tab under Profile page
	When I add a new skill
	Then that skill should be displayed on my listings

Scenario:Check if user could able to edit a skill
	Given I clicked on the Skills tab under Profile page
	When I edit an existing skill
	Then that skill edited should be displayed on my listings

Scenario: Check if user could able to delete a skill
	Given I clicked on the Skills tab under Profile page
	When I delete a existing skill
	Then that skill should not be displayed on my listings

Scenario:Check if user could able to add a education
	Given I clicked on the Education tab under Profile page
	When I add a new education
	Then that education should be displayed on my listings

Scenario:Check if user could able to edit a education
	Given I clicked on the Education tab under Profile page
	When I edit an existing education
	Then that education edited should be displayed on my listings

Scenario: Check if user could able to delete a education
	Given I clicked on the Education tab under Profile page
	When I delete a existing education
	Then that education should not be displayed on my listings

Scenario:Check if user could able to add a certifications
	Given I clicked on the Certifications tab under Profile page
	When I add a new certifications
	Then that certifications should be displayed on my listings

Scenario:Check if user could able to edit a certifications
	Given I clicked on the Certifications tab under Profile page
	When I edit an existing certifications
	Then that certifications edited should be displayed on my listings

Scenario: Check if user could able to delete a certifications
	Given I clicked on the Certifications tab under Profile page
	When I delete a existing certifications
	Then that certifications should not be displayed on my listings



