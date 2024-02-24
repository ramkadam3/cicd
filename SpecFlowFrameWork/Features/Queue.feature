@BeforeFeatureDontLaunch @AfterStep @Origination
Feature: Queue

A short summary of the feature

Scenario Outline: To verify that the task can be added using add task button successfully
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Task Queue page
When Click on Add Task button
When Select Application id on Popup
When Provide Due date to popup
When Provide input to Assign task field
When Provide input to Assign priority <Priority>
When Provide description to popup
Then Click on the Create button
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible
Then Validate that Task reflects data properly in Queue list page

Examples: 
| User_Email           | Priority | Message      |
| slaadmin@yopmail.com | Medium   | Successfully |




Scenario Outline: To verify that assign task button working properly
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Task Queue page
When Click on Assign Task button
When Select Assign task to on Select member pop-up
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible
#Then Validate that the Assigned Task updated properly

Examples: 
| User_Email           | Priority | Message      |
| slaadmin@yopmail.com | Medium   | Successfully |




Scenario Outline: To verify that Edit task button working properly
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Task Queue page
When Click on Edit Task button
When Edit Task details
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible
Then Validate that the Task updated successfully

Examples: 
| User_Email           | Priority | Message      |
| slaadmin@yopmail.com | Medium   | Successfully |





Scenario Outline: To verify that Change status action working properly
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Task Queue page
When Click on Change status action and Change the status <Status>
#Then Validate success-notification displaying
Given Wait until success notification invisible
Then Validate that the status changed successfully <Status>

Examples: 
| User_Email           | Status      | Message      |
| slaadmin@yopmail.com | In Progress | Successfully |
