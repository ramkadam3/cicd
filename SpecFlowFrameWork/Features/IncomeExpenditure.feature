@BeforeFeatureDontLaunch @AfterStep @Origination
Feature: IncomeExpenditure

A short summary of the feature
Scenario Outline: To verify that the income can be add using Add income button with  <IncomeType>, <Frequency>
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
#When Order the loans in "descending" 
Given Click on ApplicationID
And Expand Finance details section
And Click on the Income and Expenditure details section
And Click on Add income button
And Select Borrower-CoBorrower
When Select Income Type <IncomeType>
And Select payment frequency <Frequency>
And Enter Amount and Note <amount>
Then Click on Add button
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible
Then Validate that income type displaying properly on Income page <IncomeType>
Then Validate that Income Frequency displaying properly on Income page <Frequency>
Then Validate that Income Amount displaying properly on Income page <amount>
Then Validate that Notes displaying properly on Income page 

Examples:
| User_Email           | IncomeType            | Frequency  | amount | Message      |
| slaadmin@yopmail.com | Paycheck              |Monthly     | 1254.21| Successfully |
| slaadmin@yopmail.com | Shares/Stocks/Bonds   |Weekly      | 1254.21| Successfully |
| slaadmin@yopmail.com | Alimony               |Bi-Weekly   | 1254.21| Successfully |
| slaadmin@yopmail.com | Government Support    |Semi-Monthly| 1254.21| Successfully |
| slaadmin@yopmail.com | Other                 |Quarterly   | 1254.21| Successfully |
| slaadmin@yopmail.com | Child Support         |Annually    | 1254.21| Successfully |

Scenario Outline: To verify that the Delete income button working properly
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
And Expand Finance details section
And Click on the Income and Expenditure details section
When Click on delete income button
Then Validate success-notification displaying
Given Wait until success notification invisible
Then Validate that the income has been deleted successfully

Examples: 
| User_Email           | 
| slaadmin@yopmail.com |
