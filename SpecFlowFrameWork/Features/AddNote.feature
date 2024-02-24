@BeforeFeatureDontLaunch @AfterStep @Origination
Feature: AddNote

A short summary of the feature

Scenario Outline: To verify that the Noe can be added using Add Note button successfully
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID

And Navigate to the Notes section
When Click on Add Note button
When Select the value by check "noteAction", <NumberOfOptionSelect>
Then Click on Select "noteAction"
When Select the value by check "noteResult", <NumberOfOptionSelect>
Then Click on Select "noteResult"
When Provide description to popup
When Click on Add button
Then Validate success-notification Successfully <Message>
Then Validate that the Add button navigates to Create Task pop-up
When Provide Input value to the Create task pop-up
Then Click on the Create button
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible
Then Validate that the Added Note displaying properly
When Click on Reply to Note button
When Provide Description to the Add Reply Note Pop-up
Then Validate that Reply note added successfully
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible
Given Navigate to Task Queue page
Then Validate that the Created Task during Add Note is reflecting properly in Queue list page

Examples: 
| User_Email           | Message      | NumberOfOptionSelect |
| slaadmin@yopmail.com | Successfully | 3                    |
| slaadmin@yopmail.com | Successfully | 2                    |
| slaadmin@yopmail.com | Successfully | 1                    |

#| slamember@yopmail.com | Successfully| 3                   |
