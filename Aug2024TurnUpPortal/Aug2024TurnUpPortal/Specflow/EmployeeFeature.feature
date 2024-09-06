Feature: Feature1

As a TurnUp portal admin user
I would like to create, edit and delete employee records
So that I can manage employees records successfully

Background: 
	Given I logged into TurnUp portal successfully
	When I navigate to Employee page

@patch_regression
Scenario: Employee record creation flow
	And I create a new Employe record
	Then I should be able to create the record successfully

Scenario: Employee record update flow

	And I update a new Employee page
	Then I should be able to update the record successfully

Scenario: Employee record deletion
	And I delete a new Employee record
	Then I should be able to delete the record successfully
