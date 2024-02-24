@BeforeFeatureDontLaunch @AfterStep @M2I
Feature: AddInvestor

A short summary of the feature


Scenario Outline: To Verify That the Investor can be added using Add Investor button

Given Login to Profile <User_Email>
Given Navigate to Investor Page
When Click on Add Investor button
And Select Investor Type on Select Investor type pop-up <InvestorType>
When Click on Next button
Then Validate that the Investor Type displaying at Headline of Add Investor form <InvestorType>
When Provide details to Investor details section of Add investor form <IsMultiAccount>
Then Validate that the Role is at the Investor Admin position


Given Expand The Details Card Contact Details
When Provide details to the Contact Details section of Add Investor form No
Given Expand The Details Card Address
When Provide details to the Home Address section of Add Investor form
When Provide details to the Mailing Address section of Add Investor form No
When Provide details to the Business Address section of Add Investor form
Given Close The Details Card Address
Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section of Add Investor form <AccountType>, <AccountNumber>
When Click on Save(Green) button
Then Validate success-notification Successfully Successfully
Then Validate that The Investor details of Investor displaying properly on View Investor page <InvestorType>, <IsMultiAccount>
Then Validate that the Contact Details of Investor displaying properly on View Investor page
Then Validate that the Address Details of Investor displaying properly on View Investor page
Then Validate that the Account Details of Investor displaying properly on View Investor page <AccountType>, <AdminName>, <AccountNumber>

Examples:
| User_Email      | InvestorType | IsMultiAccount | AccountNumber | AccountType | AdminName         |
| CompanyManager  | Individual   | No             | 1             | Check       | Jhon Doe          |
| Finder          | Individual   | No             | 1             | ACH         | Automation finder |
| SalesRep        | Individual   | No             | 1             | Wire        | jack sulivan      |
#| MRIAUser        | Individual   | No             | 1             | Wire        | jack sulivan      |





Scenario Outline: To Verify That the Investor can be added properly when user belongs to multiple account with existing Email

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Investor Page

Given Search the Investor on the Investor page <SearchInvestor>
When Get the email of the Investor from investor page
When Click on Add Investor button
And Select Investor Type on Select Investor type pop-up <InvestorType>
When Click on Next button
Then Validate that the Investor Type displaying at Headline of Add Investor form <InvestorType>
When Check the CheckBox Check this checkbox if user belongs to multiple accounts.
When Provide details to Investor details section of Add investor form <IsMultiAccount>
Then Validate that the Role is at the Investor Admin position

Given Expand The Details Card Contact Details
When Provide details to the Contact Details section of Add Investor form <isInvited>
Given Expand The Details Card Address
When Provide details to the Home Address section of Add Investor form
When Check the CheckBox Same as Home Address
When Provide details to the Mailing Address section of Add Investor form Yes
When Provide details to the Business Address section of Add Investor form
Given Close The Details Card Address
Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section of Add Investor form <AccountType>, <AccountNumber>
When Click on Save(Green) button
Then Validate success-notification Successfully Successfully
Then Validate that The Investor details of Investor displaying properly on View Investor page <InvestorType>, <IsMultiAccount>
Then Validate that the Contact Details of Investor displaying properly on View Investor page
Then Validate that the Address Details of Investor displaying properly on View Investor page
Then Validate that the Account Details of Investor displaying properly on View Investor page <AccountType>, <AdminName>, <AccountNumber>

Examples: 
| User_Email                   | InvestorType | IsMultiAccount | AccountNumber | AccountType | AdminName | isInvited | SearchInvestor   |
| atestmanager3105@yopmail.com | Individual   | Yes            | 1             | Check       | Jhon Doe  | No        | Joint&Individual |




Scenario Outline: To verify that the Individual investor can be added by invitation successfully
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Investor Page
When Click on the Invite Investor button
When Select offering on Invite Investor
When Provide Email to invite pop-up <isExisting>
When Click on Send button
Then Validate success-notification Successfully Successfully
Given Navigate to the Email
Then Validate that CreateMyAccount button navigates to the Add investor page <InvestorType>
Given Click on Investor Type Card on Add Investor page <InvestorType>

Then Validate that the Investor Type displaying at Headline of Add Investor form <InvestorType>
When Provide details to Investor details section of Add investor form <IsMultiAccount>
Given Expand The Details Card Contact Details
When Provide details to the Contact Details section of Add Investor form <isInvited>
Then Validate that the Personal email filed populate invited email by default
Given Expand The Details Card Address
When Provide details to the Home Address section of Add Investor form
When Provide details to the Mailing Address section of Add Investor form No
When Provide details to the Business Address section of Add Investor form
Given Close The Details Card Address
Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section of Add Investor form <AccountType>, <AccountNumber>

When Click on Add button
When Click on Continue button
When Provide Email and Password then login

Then Validate that The Investor details of Investor displaying properly on View Investor page <InvestorType>, <IsMultiAccount>
Then Validate that the Contact Details of Investor displaying properly on View Investor page when InvitedInvestor 
Then Validate that the Address Details of Investor displaying properly on View Investor page
Then Validate that the Account Details of Investor displaying properly on View Investor page <AccountType>, <AdminName>, <AccountNumber>

Examples: 
| User_Email                   | InvestorType | IsMultiAccount | AccountNumber | AccountType | AdminName    | isExisting | isInvited |
| atestmanager3105@yopmail.com | Individual   | No             | 1             | Check       | System Admin | No         | Yes       |


Scenario Outline: To verify that the Individual investor can be added by the NewInvestorAccount button
Given Login to Profile <User_Email>

Given Navigate to Manage profile page
When Click on the New Investor Account button 

Given Click on Investor Type Card on Add Investor page <InvestorType>
Then Validate that the Investor Type displaying at Headline of Add Investor form <InvestorType>
Then Validate investor details section populate email properly <User_Email>
Given Expand The Details Card Contact Details
When Provide details to the Contact Details section of Add Investor form <isInvited>
Given Expand The Details Card Address
When Provide details to the Home Address section of Add Investor form
When Provide details to the Mailing Address section of Add Investor form No
When Provide details to the Business Address section of Add Investor form
Given Close The Details Card Address
Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section of Add Investor form <AccountType>, <AccountNumber>
When Click on Add button

When Click on Continue button
Then Validate success-notification Successfully Successfully



Examples: 
| User_Email                         | InvestorType | IsMultiAccount | AccountNumber | AccountType | AdminName | isExisting | isInvited |
| IndividualInvestor                 | Individual   | No             | 1             | Check       | Jhon Doe  | No         | No        |

