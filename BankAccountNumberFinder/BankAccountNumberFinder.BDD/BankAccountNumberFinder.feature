Feature: BankAccountNumberFinder
	In order to gain time
	As a bank
	I want to scan letters & faxes to get bank account numbers


Scenario Outline: When I read a digit I want to get its value
	When I read a digit
	Then I want to find its value
	Examples:
	| line			| value |
	|  _ \|_  _\| | 5     |
	