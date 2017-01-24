Feature: CalculatorAdd
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@adding
Scenario Outline: Adding
	Given I have entered <first> into the calculator	
	When I press add
	Given I have entered <second> into the calculator	
	When I press equals
	Then the result should be <result> on the screen

	Examples:
		| first | second | result |
		|  12   |  5     |  17    |
		|  20   |  -5    |  15    |
		|  1.1  |  2.2   |  3.3   |