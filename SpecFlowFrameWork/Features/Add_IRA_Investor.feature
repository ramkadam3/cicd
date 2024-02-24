@BeforeFeatureDontLaunch @AfterStep @M2I
Feature: Add_IRA_Investor

A short summary of the feature

Scenario Outline: To verify that the IRA investor can be added using Add Investor button

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Investor Page
When Click on Add Investor button
And Select Investor Type on Select Investor type pop-up <InvestorType>
When Click on Next button
Then Validate that the Investor Type displaying at Headline of Add Investor form <InvestorType>
When Provide details to Custodian details section of Add IRA Investor form <isInvited>
Given Read value of the Custodian Tax id from IRA Custodian Tax Id
Then Validate that the Trust Name created properly

Given Close The Details Card IRA Custodian Details

Given Expand The Details Card IRA Custodian Contact Details
When Read values of Contact details section of Add IRA Investor form 


Given Expand The Details Card Address
When Read values of the Custodian Registered Address of Add IRA Investor form
Given Navigate to the card Custodian Mailing Address
When Read values of the Custodian Mailing Address of Add IRA Investor form
Given Navigate to the card Investor Mailing Address
When Provide details to the Investor Mailing Address ofAdd IRA Investor form 
Given Close The Details Card Address


Given Expand The Details Card Send the interest income to
When Read values of the Account details <AccountNumber>

When Click on Save(Green) button
Then Validate success-notification Successfully Successfully
Then Validate that the IRA Custodian Details of Investor displaying properly <InvestorType>
Then Validate that the IRA Custodian Contact Details of Investor displaying properly <isInvited>
Then Validate that the Address details of IRA investor are displaying properly <isInvited>
Then Validate that the Account Details of Investor displaying properly on View Investor page <InvestorType>, <AdminName>, <AccountNumber>


Examples:

| User_Email                   | InvestorType | IsMultiAccount | AccountNumber | AccountType | AdminName | isInvited |
| atestmanager3105@yopmail.com | IRA          | No             | 1             | Wire        | Jhon Doe  | No        |



Scenario Outline: To verify that the IRA investor can be added using the INVITE INVESTOR button

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
When Provide details to Custodian details section of Add IRA Investor form <isInvited>

Then Validate that the Trust Name created properly
Given Close The Details Card IRA Custodian Details
Then Provide details to the User Details section CommonStep of Add Investor form <IsMultiAccount>
Given Close The Details Card User Details
Given Expand The Details Card IRA Custodian Contact Details
When Provide details to the Contact Details section CommonStep of Add Investor form <isInvited>

Given Expand The Details Card Address
When Read values of the Custodian Registered Address of Add IRA Investor form
Given Navigate to the card Custodian Mailing Address
When Provide details to the Custodian Registered Address section of Add IRA Investor form
When Provide details to the Custodian Mailing Address section of Add IRA Investor form Yes
Given Navigate to the card Investor Mailing Address
When Provide details to the Investor Mailing Address ofAdd IRA Investor form 
Given Close The Details Card Address

Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section of Add Investor form <AccountType>, <AccountNumber>

When Click on Add button
When Click on Continue button
When Provide Email and Password then login

Then Validate that the IRA Custodian Details of Investor displaying properly <InvestorType>
Then Validate that the IRA Custodian Contact Details of Investor displaying properly <isInvited>
Then Validate that the Address details of IRA investor are displaying properly <isInvited>
Then Validate that the Account Details of Investor displaying properly on View Investor page <AccountType>, <AdminName>, <AccountNumber>

Examples: 
| User_Email                   | InvestorType | IsMultiAccount | AccountNumber | AccountType | AdminName    | isExisting | isInvited |
| atestmanager3105@yopmail.com | IRA          | No             | 1             | Check       | System Admin | No         | Yes       |


Scenario Outline: To verify that the IRA investor can be added using the INVITE INVESTOR button when user belongs to MULTIPLE ACCOUNTS

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Investor Page
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

Then Validate that the Investor Type displaying at Headline of Add Investor form <InvestorType>
When Provide details to Custodian details section of Add IRA Investor form <isInvited>

Then Validate that the Trust Name created properly
Given Close The Details Card IRA Custodian Details
When Check the CheckBox Check this checkbox if user belongs to multiple accounts.
Then Provide details to the User Details section CommonStep of Add Investor form <IsMultiAccount>
Given Close The Details Card User Details

Given Expand The Details Card IRA Custodian Contact Details
When Provide details to the Contact Details section CommonStep of Add Investor form <isInvited>

Given Expand The Details Card Address
When Read values of the Custodian Registered Address of Add IRA Investor form
Given Navigate to the card Custodian Mailing Address
When Provide details to the Custodian Registered Address section of Add IRA Investor form
When Provide details to the Custodian Mailing Address section of Add IRA Investor form Yes
Given Navigate to the card Investor Mailing Address
When Provide details to the Investor Mailing Address ofAdd IRA Investor form 
Given Close The Details Card Address
Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section of Add Investor form <AccountType>, <AccountNumber>
####
When Click on Add button
When Click on Continue button
When Provide Email and Password then login
####
When Navigate to manage account page          
When Search for Account on Manage Account page  <InvestorType>          
When Navigate to the investor details by clicking on account name on Manage profile page
Then Validate that the IRA Custodian Details of Investor displaying properly <InvestorType>
Then Validate that the IRA Custodian Contact Details of Investor displaying properly <isInvited>
Then Validate that the Address details of IRA investor are displaying properly <isInvited>
Then Validate that the Account Details of Investor displaying properly on View Investor page <AccountType>, <AdminName>, <AccountNumber>



Examples: 
| User_Email                   | InvestorType | IsMultiAccount | AccountNumber | AccountType | AdminName    | isExisting | isInvited |  SearchInvestor   |
| atestmanager3105@yopmail.com | IRA          | Yes            | 1             | ACH         | System Admin | No         | Yes       | Joint&Individual  |

@ignore
Scenario Outline: To verify that the data of Custodian are reflecting properly on Add IRA investor form
#this scenario will be automated with custodian

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Custodian
When Click on first Custodian Name
Then Collect data of the custodian

Given Switch User-Account to <Comp_Email>
Given Navigate to Investor Page
When Click on Add Investor button
And Select Investor Type on Select Investor type pop-up <InvestorType>
When Click on Next button
Then Validate that the Investor Type displaying at Headline of Add Investor form <InvestorType>
When Provide details to Custodian details section of Add IRA Investor form <CustodianName>

Then Validate that the Custodian Tax id populated properly
Then Validate details to the Contact details section of Add IRA Investor form populated properly <isInvested>
Then Validate details to the Custodian Registered Address of Add IRA Investor form populated properly
Then Validate details to the Custodian Mailing Address of Add IRA Investor form populated properly

Then Validate that the Account details populated data properly
Examples:

| User_Email              | Comp_Email                   | InvestorType | IsMultiAccount | AccountNumber | AccountType | AdminName | isInvited | CustodianName |
| yrefytestuser@gmail.com | atestmanager3105@yopmail.com | IRA          | No             | 1             | Wire        | Jhon Doe  | No        | Gated         |

@ignore
Scenario Outline: To verify that the IRA investor can be added using Add Investor button by different ROLE

Given Login to Profile <User_Email>
Given Navigate to Investor Page
When Click on Add Investor button
And Select Investor Type on Select Investor type pop-up <InvestorType>
When Click on Next button
Then Validate that the Investor Type displaying at Headline of Add Investor form <InvestorType>
When Provide details to Custodian details section of Add IRA Investor form <isInvited>
Given Read value of the Custodian Tax id from IRA Custodian Tax Id
Then Validate that the Trust Name created properly

Given Close The Details Card IRA Custodian Details

Given Expand The Details Card IRA Custodian Contact Details
When Read values of Contact details section of Add IRA Investor form 


Given Expand The Details Card Address
When Read values of the Custodian Registered Address of Add IRA Investor form
Given Navigate to the card Custodian Mailing Address
When Read values of the Custodian Mailing Address of Add IRA Investor form
Given Navigate to the card Investor Mailing Address
When Provide details to the Investor Mailing Address ofAdd IRA Investor form 
Given Close The Details Card Address


Given Expand The Details Card Send the interest income to
When Read values of the Account details <AccountNumber>

When Click on Save(Green) button
Then Validate success-notification Successfully Successfully
Then Validate that the IRA Custodian Details of Investor displaying properly <InvestorType>
Then Validate that the IRA Custodian Contact Details of Investor displaying properly <isInvited>
Then Validate that the Address details of IRA investor are displaying properly <isInvited>
Then Validate that the Account Details of Investor displaying properly on View Investor page <InvestorType>, <AdminName>, <AccountNumber>


Examples:

| User_Email | InvestorType | IsMultiAccount | AccountNumber | AccountType | AdminName | isInvited |
| IRAAdmin   | IRA          | No             | 1             | Wire        | IRA Admin | No        |
| IRAUser    | IRA          | No             | 1             | Wire        | IRA User  | No        |
