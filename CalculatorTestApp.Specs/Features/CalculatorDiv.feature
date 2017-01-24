Feature: CalculatorDiv
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the div of two numbers

@mytag
Scenario: Divide two numbers
	Given I have entered 50 into the calculator	
	When I press div
	Given I have entered 5 into the calculator	
	When I press equals
	Then the result should be 10 on the screen

Scenario: Divide two numbers error
	Given I have entered 50 into the calculator	
	When I press div
	Given I have entered 0 into the calculator	
	When I press equals
	Then I expect error: Cannot divide by zero