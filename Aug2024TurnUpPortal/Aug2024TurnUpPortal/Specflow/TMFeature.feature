Feature: TMFeature

As a TurnUp portal admin user
I would like to create, edit and delete time and material records
So that I can manage employees time and materials successfully

Background: 
	Given I logged into TurnUp portal successfully
	When I navigate to Time and Material page

@regression
Scenario Outline: create time record with valid data
	When I create a time record '<TypeCode>', '<Code>', '<Description>' and '<Price>'
	Then the record should have the created '<TypeCode>', '<Code>', '<Description>' and '<Price>'

	Examples:
	| TypeCode | Code        | Description        | Price |
	| T        | Code KLD 01 | Description KLD 01 | 100   |
	| M        | Code KLD 02 | Description KLD 02 | 200   |
	| T        | Code KLD 03 | Description KLD 03 | 300   |

Scenario Outline: edit existing time record with valid data
	When I update the '<TypeCode>', '<Code>', '<Description>' and '<Price>' on an existing Time record
	Then the record should have the updated '<TypeCode>', '<Code>', '<Description>' and '<Price>'

Examples:
	| TypeCode | Code        | Description        | Price |
	| T        | Code KLD 01 | Description KLD 01 | 100   |
	| M        | Code KLD 02 | Description KLD 02 | 200   |
	| T        | Code KLD 03 | Description KLD 03 | 300   |

Scenario Outline: delete existing time record
	When I delete an existing record
	Then the record should not be similat to '<StoredCode>'

Examples:
	| StoredCode  |
	| Code KLD 01 |
	



	