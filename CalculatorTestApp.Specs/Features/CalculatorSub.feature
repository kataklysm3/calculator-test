Feature: CalculatorSub
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sub of two numbers

@mytag
Scenario: Subtract two numbers
	Given I have entered 50 into the calculator
	When I press sub
	Given I have entered 70 into the calculator
	When I press equals
	Then the result should be -20 on the screen
