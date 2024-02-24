@BeforeFeatureDontLaunch @AfterStep @Origination
Feature: Participant

Scenario Outline: To verify that Participant can be added using add Participant button successfully
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Participant page
When Click on Add participant button
When Provide Participant name to popup
When Provide Email to the popup
When Provide Password to the popup <password>
Then Click on Add button
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible
Then Validate that the participant name displaying properly on participant page
Then Validate that the participant email displaying properly on participant page



Examples: 
| User_Email           | password       | Message      |
| slaadmin@yopmail.com | Yrefy@123      | successfully |

Scenario Outline: To verify that Participant can be deleted using delete button successfully
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Participant page
When Click on delete button
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible
Then Validate that the Participant has been deleted successfully

Examples: 
| User_Email           | Message     |
| slaadmin@yopmail.com |Successfully |
