@BeforeFeatureDontLaunch @AfterStep @Origination
Feature: BorrowerDocuments

A short summary of the feature

Scenario Outline:01 To verify that document field can be added using add document button 
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
When Expand Document section
Then Check Borrower documents sub tab
Given Navigate to Borrower Document
When Select document and add Document
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible
Then Validate that the required document field getting added successfully

Examples:
| User_Email           |Message      |
| slaadmin@yopmail.com |Successfully | 

Scenario Outline:02 To verify that document uploaded using upload button successfully
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
When Expand Document section
Given Navigate to Borrower Document
When Click on upload document
When Upload document using HandleOpenDialog <FileName>
Then Validate success-notification Successfully <Message>
Then Validate that document uploaded properly



Examples:
| User_Email           | Message      | FileName      |
| slaadmin@yopmail.com | Successfully | uploadDoc.png |



Scenario Outline: 03 To verify that view document and download document button working properly
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
When Expand Document section
Given Navigate to Borrower Document
When Click on View document button
Then Validate that the document viewed successfully
#Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible
When Click on Download document button
When Click on Confirm button
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible



Examples:
| User_Email           | Message      | FileName      |
| slaadmin@yopmail.com | Successfully | uploadDoc.png |
