@BeforeFeatureDontLaunch @AfterStep @Origination
Feature: Debt_Details

A short summary of the feature

Scenario Outline: To verify that the Add debt button working properly
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
Given Expand Finance details section
Given Navigate to the Loan details section
When  Click on add Debts button
When Provide required details to the Add debts pop-up and save it <DebtsType>
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible
Then Validate that the debt details displaying properly <DebtsType>, <cardName>



Examples:
| User_Email           | DebtsType | cardName | Message      | 
| slaadmin@yopmail.com | Rent      | Debt     | Successfully |
| slaadmin@yopmail.com | Mortgage  | Debt     | Successfully |
#| slamember@yopmail.com|Rent      | Debt     | Successfully |
