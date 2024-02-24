@BeforeFeatureDontLaunch @AfterStep @M2I
Feature: Add_Scorp_investor

A short summary of the feature

Scenario Outline: To Verify That the S-CORP Investor can be added using Add Investor button


Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Investor Page
When Click on Add Investor button
And Select Investor Type on Select Investor type pop-up <InvestorType>
When Click on Next button
Then Validate that the Investor Type displaying at Headline of Add Investor form <InvestorType>
When Provide details to Investor details section CommonStep of Add investor form <InvestorType> 
Given Close The Details Card Investor Details

Given Expand The Details Card Contact Details
When Provide details to the Contact Details section CommonStep of Add Investor form <isInvited>

Given Expand The Details Card Address
When Provide details to the Registered Address section CommonStep of Add Investor form
When Provide details to the Mailing Address section CommonStep of Add Investor form Yes



Given Close The Details Card Address
Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section CommonStep of Add Investor form <AccountType>, <AccountNumber>
When Click on Save(Green) button
Then Validate success-notification Successfully Successfully
Then Validate that The Investor details of Investor displaying properly CommonStep on View Investor page <InvestorType>, <IsMultiAccount>
Then  Validate that the Contact Details of Investor displaying properly commonstep on View Investor page
Then Validate that the Address Details of Investor displaying properly CommonStep on View Investor page
Then Validate that the Account Details of Investor displaying properly on View Investor page <AccountType>, <AdminName>, <AccountNumber>


Examples:

| User_Email                   | InvestorType | IsMultiAccount | AccountNumber | AccountType | AdminName | isInvited |
| atestmanager3105@yopmail.com | S-Corp       | No             | 1             | Wire        | Jhon Doe  | No        |
| atestmanager3105@yopmail.com | C-Corp       | No             | 1             | Wire        | Jhon Doe  | No        |
| atestmanager3105@yopmail.com | LLC          | No             | 1             | Wire        | Jhon Doe  | No        |
| atestmanager3105@yopmail.com | Trust        | No             | 1             | Wire        | Jhon Doe  | No        |


Scenario Outline: To Verify That the S-CORP Investor can be added using INVITE Investor button


Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Investor Page
#####
When Click on the Invite Investor button
When Select offering on Invite Investor
When Provide Email to invite pop-up <isExisting>
When Click on Send button
Then Validate success-notification Successfully Successfully
Given Navigate to the Email
Then Validate that CreateMyAccount button navigates to the Add investor page <InvestorType>
Given Click on Investor Type Card on Add Investor page <InvestorType>
#####
Then Validate that the Investor Type displaying at Headline of Add Investor form <InvestorType>
When Provide details to Investor details section CommonStep of Add investor form <InvestorType> 
Given Close The Details Card Investor Details
Then Provide details to the User Details section CommonStep of Add Investor form <IsMultiAccount>
Given Close The Details Card User Details
Given Expand The Details Card Contact Details
When Provide details to the Contact Details section CommonStep of Add Investor form <isInvited>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
When Provide details to the Registered Address section CommonStep of Add Investor form
When Provide details to the Mailing Address section CommonStep of Add Investor form Yes


Given Close The Details Card Address
Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section CommonStep of Add Investor form <AccountType>, <AccountNumber>
####
When Click on Add button
When Click on Continue button
When Provide Email and Password then login
####
Then Validate that The Investor details of Investor displaying properly CommonStep on View Investor page <InvestorType>, <IsMultiAccount>
Then  Validate that the Contact Details of Investor displaying properly commonstep on View Investor page
Then Validate that the Address Details of Investor displaying properly CommonStep on View Investor page
Then Validate that the Account Details of Investor displaying properly on View Investor page <AccountType>, <AdminName>, <AccountNumber>


Examples:

| User_Email                   | InvestorType | IsMultiAccount | AccountNumber | AccountType | AdminName     | isExisting | isInvited |
| atestmanager3105@yopmail.com | S-Corp       | No             | 1             | Check       | System Admin  | No         | Yes       |
| atestmanager3105@yopmail.com | C-Corp       | No             | 1             | ACH         | System Admin  | No         | Yes       |
| atestmanager3105@yopmail.com | LLC          | No             | 1             | ACH         | System Admin  | No         | Yes       |
| atestmanager3105@yopmail.com | Trust          | No             | 1             | Wire        | System Admin  | No         | Yes       |




Scenario Outline:  To verify that the S-CORP Investor can be added using INVITE investor button when user belongs to MULTIPLE account

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Investor Page
#####
Given Search the Investor on the Investor page <SearchInvestor>
When Get the email of the Investor from investor page to Create Joint investor 1
When Click on the Invite Investor button
When Select offering on Invite Investor
When Provide Email to invite pop-up <isExisting>
When Click on Send button
Then Validate success-notification Successfully Successfully
Given Navigate to the Email

Then Validate that CreateMyAccount button navigates to the Add investor page <InvestorType>
Given Click on Investor Type Card on Add Investor page <InvestorType>
#####
Then Validate that the Investor Type displaying at Headline of Add Investor form <InvestorType>
When Provide details to Investor details section CommonStep of Add investor form <InvestorType> 
Given Close The Details Card Investor Details
When Check the CheckBox Check this checkbox if user belongs to multiple accounts.
Then Provide details to the User Details section CommonStep of Add Investor form <IsMultiAccount>
Given Close The Details Card User Details
Given Expand The Details Card Contact Details
When Provide details to the Contact Details section CommonStep of Add Investor form <isInvited>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
When Provide details to the Registered Address section CommonStep of Add Investor form
When Provide details to the Mailing Address section CommonStep of Add Investor form Yes
Given Close The Details Card Address
Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section CommonStep of Add Investor form <AccountType>, <AccountNumber>
####
When Click on Add button
When Click on Continue button
When Provide Email and Password then login
####
#When Navigate to manage profile page
When Navigate to manage account page          
When Search for Account on Manage Account page  <InvestorType>          
When Navigate to the investor details by clicking on account name on Manage profile page
Then Validate that The Investor details of Investor displaying properly CommonStep on View Investor page <InvestorType>, <IsMultiAccount>
Then Validate that the Contact Details of Investor displaying properly commonstep on View Investor page
Then Validate that the Address Details of Investor displaying properly CommonStep on View Investor page
Then Validate that the Account Details of Investor displaying properly on View Investor page <AccountType>, <AdminName>, <AccountNumber>


Examples:

| User_Email                   | InvestorType | IsMultiAccount | AccountNumber | AccountType | AdminName    | isExisting | isInvited | SearchInvestor   |
| atestmanager3105@yopmail.com | S-Corp       | Yes            | 1             | Check       | System Admin | No         | Yes       | Joint&Individual |
| atestmanager3105@yopmail.com | C-Corp       | Yes            | 1             | ACH         | System Admin | No         | Yes       | Joint&Individual |
| atestmanager3105@yopmail.com | LLC          | Yes            | 1             | Wire        | System Admin | No         | Yes       | Joint&Individual |
| atestmanager3105@yopmail.com | Trust        | Yes            | 1             | Wire        | System Admin | No         | Yes       | Joint&Individual |


@ignore
Scenario Outline: To Verify That the Investor can be added using Add Investor button by different ROLE


Given Login to Profile <User_Email>
Given Navigate to Investor Page
When Click on Add Investor button
And Select Investor Type on Select Investor type pop-up <InvestorType>
When Click on Next button
Then Validate that the Investor Type displaying at Headline of Add Investor form <InvestorType>
When Provide details to Investor details section CommonStep of Add investor form <InvestorType> 
Given Close The Details Card Investor Details

Given Expand The Details Card Contact Details
When Provide details to the Contact Details section CommonStep of Add Investor form <isInvited>

Given Expand The Details Card Address
When Provide details to the Registered Address section CommonStep of Add Investor form
When Provide details to the Mailing Address section CommonStep of Add Investor form Yes



Given Close The Details Card Address
Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section CommonStep of Add Investor form <AccountType>, <AccountNumber>
When Click on Save(Green) button
Then Validate success-notification Successfully Successfully
Then Validate that The Investor details of Investor displaying properly CommonStep on View Investor page <InvestorType>, <IsMultiAccount>
Then  Validate that the Contact Details of Investor displaying properly commonstep on View Investor page
Then Validate that the Address Details of Investor displaying properly CommonStep on View Investor page
Then Validate that the Account Details of Investor displaying properly on View Investor page <AccountType>, <AdminName>, <AccountNumber>


Examples:

| User_Email                   | InvestorType | IsMultiAccount | AccountNumber | AccountType | AdminName   | isInvited |
|CcorpAdmin                    | C-Corp       | No             | 1             | Wire        | Ccorp Admin | No        |
|LLCUser                       | LLC          | No             | 1             | Wire        | LLC User    | No        |
|TrustAdmin                    | Trust        | No             | 1             | Wire        |Trust Admin  | No        |

