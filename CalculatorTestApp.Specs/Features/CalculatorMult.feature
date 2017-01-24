Feature: CalculatorMult
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the multiply of two numbers

@mytag
Scenario: Multiply two numbers
	Given I have entered 5 into the calculator	
	When I press mult
	Given I have entered 7 into the calculator	
	When I press equals
	Then the result should be 35 on the screen
