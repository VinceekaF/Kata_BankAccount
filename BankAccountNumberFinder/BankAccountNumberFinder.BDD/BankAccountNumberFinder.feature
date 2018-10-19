Feature: BankAccountNumberFinder
	In order to gain time
	As a bank
	I want to scan letters & faxes to get bank account numbers


Scenario Outline: When I read a file I want to get the account numbers
	When I read a text <file>
	Then I want to get a list with the correct count of account <numbers>
	Examples:
	| file          | numbers |
	| Example55.txt | 5       |
	| Example66.txt | 5       |

Scenario Outline: When I target a specific account in my list, I want to see a readable number
	When I read a text <file>
	And I target an account by its <index>
	Then I want to get a normalized <account>
	Examples:
	| file          | index | account		|
	| Example55.txt | 1     | 729466750 AMB |
	| Example55.txt | 4     | 55?7?312? ILL |
	| Example66.txt | 0     | 123456789     |
		