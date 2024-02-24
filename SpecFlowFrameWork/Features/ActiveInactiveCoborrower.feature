@BeforeFeatureDontLaunch @AfterStep @Origination
Feature: ActiveInactive_Coborrower

A short summary of the feature

Scenario Outline: To verify that the  co-borrower can be activate_deactivate properly
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
Then Check that the Borrower has a CoBorrower then Click on it Borrower details

When Click on Active_Inactive Toggle button
And  Click on Confirm button
Given Navigate to Co-Borrower section of application's when no Co-Borrower name
Then Validate that Co-Borrower deactivated successfully

Then Validate that the deactivated Co-Borrower has not swapping facility


When Click on Active_Inactive Toggle button
And  Click on Confirm button
Given Navigate to Co-Borrower section of application's when no Co-Borrower name
Then Validate that Co-Borrower activated successfully

When Click on Active_Inactive Toggle button 
And  Click on the Cancel button
Then Validate that status of Co-Borrower could not affected by canceling the process


Examples:
| User_Email           | Message      |
| slaadmin@yopmail.com | Successfully |

