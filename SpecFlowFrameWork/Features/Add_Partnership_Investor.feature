@BeforeFeatureDontLaunch @AfterStep @M2I
Feature: Add_Partnership_Investor


Scenario Outline:  To verify that the Partnership Investor can be added using Add investor button

Given Login to Profile <User_Email>
Given Navigate to Investor Page
When Click on Add Investor button
And Select Investor Type on Select Investor type pop-up <InvestorType>
When Click on Next button
Then Validate that the Investor Type displaying at Headline of Add Investor form <InvestorType>
When Provide details to Investor details section of Add PARTNERSHIP investor form 
Given Close The Details Card Investor Details

Given Expand The Details Card Contact Details
When Provide details to the Contact Details section of Add PARTNERSHIP Investor form <isInvited>

Given Expand The Details Card Address
When Provide details to the Registered Address section of Add PARTNERSHIP Investor form
When Provide details to the Mailing Address section of Add PARTNERSHIP Investor form No


Given Close The Details Card Address
Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section of Add PARTNERSHIP Investor form <AccountType>, <AccountNumber>
When Click on Save(Green) button
Then Validate success-notification Successfully Successfully
Then Validate that The Investor details of Investor displaying properly on View PARTNERSHIP Investor page <InvestorType>, <IsMultiAccount>
Then Validate that the Contact Details of Investor displaying properly on View PARTNERSHIP Investor page
Then Validate that the Address Details of Investor displaying properly on View PARTNERSHIP Investor page
Then Validate that the Account Details of Investor displaying properly on View Investor page <AccountType>, <AdminName>, <AccountNumber>


Examples:

| User_Email      | InvestorType | IsMultiAccount | AccountNumber | AccountType | AdminName    | isInvited |
| CompanyManager  | Partnership  | No             | 1             | Check       | Jhon Doe     | No        |
| SalesRep        | Partnership  | No             | 1             | Wire        | jack sulivan | No        |


Scenario Outline:  To verify that the Partnership Investor can be added using INVITE investor button

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
When Provide details to Investor details section of Add PARTNERSHIP investor form 
Given Close The Details Card Investor Details
Then Provide details to the User Details section of Add PARTNERSHIP Investor form <IsMultiAccount>
Given Close The Details Card User Details
Given Expand The Details Card Contact Details
When Provide details to the Contact Details section of Add PARTNERSHIP Investor form <isInvited>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
When Provide details to the Registered Address section of Add PARTNERSHIP Investor form
When Provide details to the Mailing Address section of Add PARTNERSHIP Investor form Yes


Given Close The Details Card Address
Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section of Add PARTNERSHIP Investor form <AccountType>, <AccountNumber>
####
When Click on Add button
When Click on Continue button
When Provide Email and Password then login
####
Then Validate that The Investor details of Investor displaying properly on View PARTNERSHIP Investor page <InvestorType>, <IsMultiAccount>
Then Validate that the Contact Details of Investor displaying properly on View PARTNERSHIP Investor page
Then Validate that the Address Details of Investor displaying properly on View PARTNERSHIP Investor page
Then Validate that the Account Details of Investor displaying properly on View Investor page <AccountType>, <AdminName>, <AccountNumber>


Examples:

| User_Email                   | InvestorType | IsMultiAccount | AccountNumber | AccountType | AdminName     | isExisting | isInvited |
| atestmanager3105@yopmail.com | Partnership  | No             | 1             | Check       | System Admin  | No         | Yes       |



Scenario Outline:  To verify that the PARTNERSHIP Investor can be added using INVITE investor button when user belongs to MULTIPLE account

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
When Provide details to Investor details section of Add PARTNERSHIP investor form 
Given Close The Details Card Investor Details
When Check the CheckBox Check this checkbox if user belongs to multiple accounts.
Then Provide details to the User Details section of Add PARTNERSHIP Investor form <IsMultiAccount>
Given Close The Details Card User Details
Given Expand The Details Card Contact Details
When Provide details to the Contact Details section of Add PARTNERSHIP Investor form <isInvited>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
When Provide details to the Registered Address section of Add PARTNERSHIP Investor form
When Provide details to the Mailing Address section of Add PARTNERSHIP Investor form Yes
Given Close The Details Card Address
Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section of Add PARTNERSHIP Investor form <AccountType>, <AccountNumber>
####
When Click on Add button
When Click on Continue button
When Provide Email and Password then login
####
When Navigate to manage account page          
When Search for Account on Manage Account page <InvestorType>           
When Navigate to the investor details by clicking on account name on Manage profile page
Then Validate that The Investor details of Investor displaying properly on View PARTNERSHIP Investor page <InvestorType>, <IsMultiAccount>
Then Validate that the Contact Details of Investor displaying properly on View PARTNERSHIP Investor page
Then Validate that the Address Details of Investor displaying properly on View PARTNERSHIP Investor page
Then Validate that the Account Details of Investor displaying properly on View Investor page <AccountType>, <AdminName>, <AccountNumber>


Examples:

| User_Email                   | InvestorType | IsMultiAccount | AccountNumber | AccountType | AdminName    | isExisting | isInvited | SearchInvestor   |
| atestmanager3105@yopmail.com | Partnership  | Yes            | 1             | Check       | System Admin | No         | Yes       | Joint&Individual |
