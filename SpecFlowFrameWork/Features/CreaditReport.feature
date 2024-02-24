@BeforeFeatureDontLaunch @AfterStep @Origination
Feature: CreaditReport

A short summary of the feature

Scenario Outline: 01_To verify that the Credit report can be added using Add Credit Report button successfully
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID

When Navigate to the Credit Report section
Then Validate that the Add credit report button is displaying on credit report section

When Click on the Add Credit Report button
When Select among Drop-down "Select Borrower", 0
When Select among Drop-down "Pull Type", 0
When Click on Fetch button
Then Validate that the Add Credit report pop-up shows selected borrower name properly
Then Validate that the fetch button is getting enabled by checked the check-box
When Click on Fetch button
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible


Examples: 
| User_Email           | Message      |
| slaadmin@yopmail.com | Successfully |


Scenario Outline: 02_To verify that the Credit report action item working successfully
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID

When Navigate to the Credit Report section
When Click on The Credit Report Action Button
Then Validate that the Credit Report displaying label properly

Examples: 
| User_Email           | Message      |
| slaadmin@yopmail.com | Successfully |
