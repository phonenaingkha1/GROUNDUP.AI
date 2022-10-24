Feature: Books Finding and Collection

A short summary of the feature


@driver
Scenario: Adding multilple books to Collection and deleting
Given The user is login and at the book store url
	When The user clicks on book A 
	Then The user is taken to the book detail
	And The user confirm the book tittle 
	When The user add the book to the book collection
	Then The user sees the successful alert
	And The user click on Ok 
	When The user click goes back to book store
	When The user click on the book B
	Then The user is taken to the book detail
	When The user add the book to the book collection
	Then The user sees the successful alert
	And The user click on Ok
	When The user click goes back to book store
	Then The user gets the book store 
	When The user goes to profile 
	Then The user sees the book A in the collection
	When The user clicks on the delete button
	Then The user sees the confirm alert
	When The user clicks ok 
	Then The user sees the book delete alert 
	And The user click on Ok
	When The user clicks on the delete button
	Then The user sees the confirm alert
	When The user clicks ok 
	Then The user sees the book delete alert 
	And The user click on Ok
	And The user cannot see the book A anymore
	And The User close the browser


@driver
Scenario: Adding same books twice to Collection and deleting
	Given The user is login and at the book store url
	When The user clicks on book A 
	Then The user is taken to the book detail
	And The user confirm the book tittle 
	When The user add the book to the book collection
	Then The user sees the successful alert
	And The user click on Ok 
	When The user add the book to the book collection
	Then The user sees the Error alert 
	And The user click on Ok
	When The user click goes back to book store
	Then The user gets the book store 
	When The user goes to profile 
	Then The user sees the book A in the collection
	When The user clicks on the delete button
	Then The user sees the confirm alert
	When The user clicks ok 
	Then The user sees the book delete alert 
	And The user click on Ok
	And The user cannot see the book A anymore
	And The User close the browser

@driver
Scenario: Delete All Books from profile
Given The user is login and at the book store url
	When The user clicks on book A 
	Then The user is taken to the book detail
	And The user confirm the book tittle 
	When The user add the book to the book collection
	Then The user sees the successful alert
	And The user click on Ok 
	When The user click goes back to book store
	When The user click on the book B
	Then The user is taken to the book detail
	When The user add the book to the book collection
	Then The user sees the successful alert
	And The user click on Ok
	When The user click goes back to book store
	Then The user gets the book store 
	When The user goes to profile 
	Then The user sees the book A in the collection
	When THe user clicks on the delete all books button
	And The user clicks ok
	Then The user sees the all books delete alert
	Then The user click on Ok
	And The User close the browser
