Feature: Signup

A short summary of the feature

@ignore
Scenario: New User Registeration
	Given The user go to the registeration page
	When The user Add in the First Name
	And The User Fill in the Lat Name
	And The User Fill in the User Name
	And The User Fill in the Valid Password
	And The User click on the captcha
	And The User Click on the Register button
	Then The User is registered
	And The User is guided back to the Registeration Page
	And The User close the browser

@driver
Scenario: User Register without clicking on the captcha 
Given The user go to the registeration page
	When The user Add in the First Name
	And The User Fill in the Lat Name
	And The User Fill in the User Name
	And The User Fill in the Valid Password
	And The User Click on the Register button
	Then The User is shown the Error Message to verify captcha
	And The User close the browser

@driver
Scenario: Valid username and password login
Given The User Go to the login page
When  The User Fill in the Valid User Name to Login
And The User Fill in the Valid Password to Login
And The User click on the login
Then The User confirm hes guided to profile page
And The User close the browser

@driver
Scenario: Invalid username and valid password Login
Given The User Go to the login page
When  The User Fill in the InValid Username to Login
And The User Fill in the Valid Password to Login
And The User click on the login
Then The User confirm the error message shows up
And The User close the browser

@driver
Scenario: Valid username and Invalid password Login
Given The User Go to the login page
When  The User Fill in the Valid User Name to Login
And The User Fill in the InValid Password to Login
And The User click on the login
Then The User confirm the error message shows up
And The User close the browser

@driver
Scenario: InValid username and Invalid password Login
Given The User Go to the login page
When  The User Fill in the InValid Username to Login
And The User Fill in the InValid Password to Login
And The User click on the login
Then The User confirm the error message shows up
And The User close the browser

@driver
Scenario: Navigation Between Register and login page
Given The User Go to the login page
When  The User Click on the New User Button
Then The user go to the registeration page
When The user click on the Back to login button
Then The User Go to the login page
And The User close the browser

@driver
Scenario: Logout 
Given The user is login and at the Profile page
When The user click on the logout button 
Then The user confirm the logout
And The User close the browser
