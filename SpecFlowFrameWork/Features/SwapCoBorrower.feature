@BeforeFeatureDontLaunch @AfterStep @Origination
Feature: SwapCoBorrower


Scenario Outline: To verify that swap co-borrower button present
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
Then Check that the Borrower has a CoBorrower, Create it if not
When Click on the Swap to Borrower button
And  Click on Confirm button
Then Validate success-notification displaying
Then Validate Co-Borrower swapped to Borrower successfully


Examples:
| User_Email           |
| slaadmin@yopmail.com | 
