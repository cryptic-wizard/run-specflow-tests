Feature: Calculator
Simple calculator for adding **2** numbers

[Calculator.feature](https://github.com/cryptic-wizard/run-specflow-tests/blob/main/RunSpecflowTests/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario Outline: Add two numbers
	Given the first number is <first>
	And the second number is <second>
	When the two numbers are added
	Then the result should be <result>

	Examples:
	| first | second | result |
	| 50    | 70     | 120    |
	| -5    | 7      | 2      |
	| 5     | -7     | -2     |
	| -5    | -7     | -12    |

Scenario Outline: Subtract two numbers
	Given the first number is <first>
	And the second number is <second>
	When the two numbers are subtracted
	Then the result should be <result>

	Examples:
	| first | second | result |
	| 50    | 70     | -20    |
	| -5    | 7      | -12    |
	| 5     | -7     | 12     |
	| -5    | -7     |   2    |