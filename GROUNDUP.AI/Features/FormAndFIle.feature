Feature: Formsandfile

A short summary of the feature

@tag1
Scenario: Full Form submission
	Given The User is at the Registration Form page
	When The user add first name
	And The user add Last name
	And The user add email
	And The user choose Gender 
	And The user add phnumber
	And The user add Date of Birth
	And The user choose subjects
	And The user choose hobbies
	And The user upload file 
	And The user add current address
	#And The user choose state 
	#And The user choose city
	And The user clicks Submit
	Then The form is submitted
	And The user Confirm the information shown in table
	And The User close the browser

@driver
Scenario: Invalid Email format
	Given The User is at the Registration Form page
	When The user add first name
	And The user add Last name
	And The user add phnumber
	And The user choose Gender
	And The user add invalid emails
	| Emails       |
	| phone        |
	| phone@       |
	| phone@gmail  |
	| phone@gmail. |
	| @gmail.com   |
	And The user clicks Submit
	Then The form is not submitted
	When The user add email
	Then The form is submitted
		And The User close the browser


@driver
Scenario: Invalid Phnumber format
	Given The User is at the Registration Form page
	When The user add first name
	And The user add Last name
	And The user add email
	And The user choose Gender
	And The user add invalid ph number
	And The user clicks Submit
	Then The form is not submitted
	When The user add phnumber
	And The user clicks Submit
	Then The form is submitted
	And The User close the browser


@driver
Scenario: Submitting without the First Name
	Given The User is at the Registration Form page
	When The user add Last name
	And The user add email
	And The user choose Gender
	When The user add phnumber
	And The user clicks Submit
	Then The form is not submitted
	When The user add first name
	And The user clicks Submit
	Then The form is submitted
	And The User close the browser

@driver
Scenario: Submitting without the Last Name
	Given The User is at the Registration Form page
	When The user add first name
	And The user add email
	And The user choose Gender
	When The user add phnumber
	And The user clicks Submit
	Then The form is not submitted
	When The user add Last name
	And The user clicks Submit
	Then The form is submitted
	And The User close the browser
