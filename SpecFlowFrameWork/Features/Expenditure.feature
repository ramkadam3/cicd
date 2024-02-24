@BeforeFeatureDontLaunch @AfterStep @Origination
Feature: Expenditure

A short summary of the feature

Scenario Outline: To verify that Expenditure can be added using add Expenditure button successfully
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
And Expand Finance details section
And Click on the Income and Expenditure details section
And Click on Add Expenditure button
When Select Expenditure type <ExpenditureType>
And Select Expenditure frequency <Frequency>
And Enter Payment date 
And Enter Amount and Note <amount>

Then Click on Add button
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible
Then Validate that Expenditure type displaying properly on Income page <ExpenditureType>
Then Validate that Expenditure Frequency displaying properly on Income page <Frequency>
Then Validate that Expenditure Amount displaying properly on Income page <amount>
Then Validate that Notes displaying properly on Expenditure page


Examples: 
| User_Email           | ExpenditureType       | Frequency  | amount | Message      |
| slaadmin@yopmail.com | Utilities             |Monthly     | 1254.21| Successfully |
| slaadmin@yopmail.com |Phone                  |Weekly      | 1254.21| Successfully |
| slaadmin@yopmail.com |Child care             |Bi-Weekly   | 1254.21| Successfully |
| slaadmin@yopmail.com | Cable                 |Semi Monthly| 1254.21| Successfully |
| slaadmin@yopmail.com | Subscriptions         |Monthly     | 1254.21| Successfully |
| slaadmin@yopmail.com | Child care            |Weekly      | 1254.21| Successfully |


Scenario Outline: To verify that the Delete income button working properly
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
And Expand Finance details section
And Click on the Income and Expenditure details section
When Click on delete Expenditure button
Then Validate success-notification displaying
Given Wait until success notification invisible
Then Validate that the Expenditure has been deleted successfully

Examples: 
| User_Email           | 
| slaadmin@yopmail.com |
