@BeforeFeatureDontLaunch @AfterStep @M2I
Feature: Add_Joint_Investor

A short summary of the feature
Scenario Outline: To verify that the Joint Investor can be added using Add investor button
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Investor Page
When Click on Add Investor button
And Select Investor Type on Select Investor type pop-up <InvestorType>
When Click on Next button
Then Validate that the Investor Type displaying at Headline of Add Investor form <InvestorType>

When Provide details to the investor details section of Joint investor <IfMultiAccount>, 1
Then Validate that the Role is at the Investor Admin position
Given Expand The Details Card Business Contact Details
When Provide details to the Business Contact details of Joint investor 1
Given Close The Details Card Business Contact Details
When Provide details to the Contact Details section of Add joint Investor form 1, <ifInvited>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
When Provide details to the Home Address section of Add Joint Investor form 1
When Provide details to the Mailing Address section of Add Joint Investor form No, 1
When Provide details to the Business Address section of Add Joint Investor form 1
Given Close The Details Card Address
Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section of Add Investor form <AccountType>, <AccountNumber>

Given Select Investor on add joint investor form 2

When Provide details to the investor details section of Joint investor <IfMultiAccount>, 2
Then Validate that the Role is at the Investor User position
When Provide details to the Contact Details section of Add joint Investor form 2, <ifInvited>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
When Provide details to the Home Address section of Add Joint Investor form 2
When Provide details to the Mailing Address section of Add Joint Investor form No, 2
When Provide details to the Business Address section of Add Joint Investor form 2
Given Close The Details Card Address
#Given Expand The Details Card Send the interest income to
#When Provide details to the Send the interest income to- section of Add Joint Investor form <AccountType>, <AccountNumber>, 2

When Click on Save(Green) button
Then Validate success-notification Successfully Successfully
Then Validate that The Investor details of Joint Investor displaying properly on View Investor page <InvestorType>, 1, <IfMultiAccount>
Then Validate that The Investor details of Joint Investor displaying properly on View Investor page <InvestorType>, 2, <IfMultiAccount>

Then Validate that The Investor details of Joint Business Contact Details displaying properly on View investor page 1

Then Validate that the Contact Details of Joint Investor displaying properly on View Investor page 1
Then Validate that the Contact Details of Joint Investor displaying properly on View Investor page 2

Then Validate that the Address Details of Joint Investor displaying properly on View Investor page 1
Then Validate that the Address Details of Joint Investor displaying properly on View Investor page 2

Then Validate that the Account Details of Investor displaying properly on View Investor page <AccountType>, <AdminName>, <AccountNumber>




Examples: 
| User_Email                    | InvestorType | IfMultiAccount | AccountNumber | AccountType | AdminName         | ifInvited |
| atestmanager3105@yopmail.com  | Joint        | No             | 1             | Check       | Jhon Doe          | No        |
| demosalesrep10aug@yopmail.com | Joint        | No             | 1             | ACH         | jack sulivan      | No        |



Scenario Outline: To verify that the Joint Investor can be added using Add investor button when first investor belongs to multiple account

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Investor Page
Given Search the Investor on the Investor page <SearchInvestor>
When Get the email of the Investor from investor page to Create Joint investor 1    
When Click on Add Investor button
And Select Investor Type on Select Investor type pop-up <InvestorType>
When Click on Next button
Then Validate that the Investor Type displaying at Headline of Add Investor form <InvestorType>
When Check the CheckBox Check this checkbox if user belongs to multiple accounts.


When Provide details to the investor details section of Joint investor <IfMultiAccount>, 1
Then Validate that the Role is at the Investor Admin position
Given Expand The Details Card Business Contact Details
When Provide details to the Business Contact details of Joint investor 1
Given Close The Details Card Business Contact Details
When Provide details to the Contact Details section of Add joint Investor form 1, <ifInvited>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
When Provide details to the Home Address section of Add Joint Investor form 1
When Provide details to the Mailing Address section of Add Joint Investor form No, 1
When Provide details to the Business Address section of Add Joint Investor form 1
Given Close The Details Card Address
Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section of Add Investor form <AccountType>, <AccountNumber>

Given Select Investor on add joint investor form 2

When Provide details to the investor details section of Joint investor No, 2
Then Validate that the Role is at the Investor User position
When Provide details to the Contact Details section of Add joint Investor form 2, <ifInvited>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
When Provide details to the Home Address section of Add Joint Investor form 2
When Provide details to the Mailing Address section of Add Joint Investor form No, 2
When Provide details to the Business Address section of Add Joint Investor form 2
Given Close The Details Card Address

When Click on Save(Green) button
Then Validate success-notification Successfully Successfully
Then Validate that The Investor details of Joint Investor displaying properly on View Investor page <InvestorType>, 1, <IfMultiAccount>
Then Validate that The Investor details of Joint Investor displaying properly on View Investor page <InvestorType>, 2, No

Then Validate that The Investor details of Joint Business Contact Details displaying properly on View investor page 1

Then Validate that the Contact Details of Joint Investor displaying properly on View Investor page 1
Then Validate that the Contact Details of Joint Investor displaying properly on View Investor page 2

Then Validate that the Address Details of Joint Investor displaying properly on View Investor page 1
Then Validate that the Address Details of Joint Investor displaying properly on View Investor page 2

Then Validate that the Account Details of Investor displaying properly on View Investor page <AccountType>, <AdminName>, <AccountNumber>




Examples: 
| User_Email                   | InvestorType | IfMultiAccount | AccountNumber | AccountType | AdminName | SearchInvestor   |
| atestmanager3105@yopmail.com | Joint        | Yes            | 1             | Wire        | Jhon Doe  | Joint&Individual |

@retry
Scenario Outline: To verify that the Joint Investor can be added using Add investor button when second investor belongs to multiple account

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Investor Page

Given Search the Investor on the Investor page <SearchInvestor>
When Get the email of the Investor from investor page to Create Joint investor 2
When Click on Add Investor button
And Select Investor Type on Select Investor type pop-up <InvestorType>
When Click on Next button
Then Validate that the Investor Type displaying at Headline of Add Investor form <InvestorType>


When Provide details to the investor details section of Joint investor No, 1
Then Validate that the Role is at the Investor Admin position
Given Expand The Details Card Business Contact Details
When Provide details to the Business Contact details of Joint investor 1
Given Close The Details Card Business Contact Details
When Provide details to the Contact Details section of Add joint Investor form 1, <ifInvited>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
When Provide details to the Home Address section of Add Joint Investor form 1
When Provide details to the Mailing Address section of Add Joint Investor form No, 1
When Provide details to the Business Address section of Add Joint Investor form 1
Given Close The Details Card Address
Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section of Add Investor form <AccountType>, <AccountNumber>

Given Select Investor on add joint investor form 2

When Check the CheckBox Check this checkbox if user belongs to multiple accounts.
When Provide details to the investor details section of Joint investor <IfMultiAccount>, 2
Then Validate that the Role is at the Investor User position
When Provide details to the Contact Details section of Add joint Investor form 2, <ifInvited>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
When Provide details to the Home Address section of Add Joint Investor form 2
When Provide details to the Mailing Address section of Add Joint Investor form No, 2
When Provide details to the Business Address section of Add Joint Investor form 2
Given Close The Details Card Address

When Click on Save(Green) button
Then Validate success-notification Successfully Successfully
Given Wait until success notification invisible

Then Validate that The Investor details of Joint Investor displaying properly on View Investor page <InvestorType>, 1, No
Then Validate that The Investor details of Joint Investor displaying properly on View Investor page <InvestorType>, 2, <IfMultiAccount>

Then Validate that The Investor details of Joint Business Contact Details displaying properly on View investor page 1

Then Validate that the Contact Details of Joint Investor displaying properly on View Investor page 1
Then Validate that the Contact Details of Joint Investor displaying properly on View Investor page 2

Then Validate that the Address Details of Joint Investor displaying properly on View Investor page 1
Then Validate that the Address Details of Joint Investor displaying properly on View Investor page 2

Then Validate that the Account Details of Investor displaying properly on View Investor page <AccountType>, <AdminName>, <AccountNumber>




Examples: 
| User_Email                   | InvestorType | IfMultiAccount | AccountNumber | AccountType | AdminName | ifInvited | SearchInvestor   |
| atestmanager3105@yopmail.com | Joint        | Yes            | 1             | ACH         | Jhon Doe  | No        | Joint&Individual |



Scenario Outline: To verify that the Joint Investor can be added using INVITE INVESTOR button 

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

#####
Then Validate that the Investor Type displaying at Headline of Add Investor form <InvestorType>

When Provide details to the investor details section of Joint investor <IfMultiAccount>, 1
Given Expand The Details Card Business Contact Details
When Provide details to the Business Contact details of Joint investor 1
Given Close The Details Card Business Contact Details
When Provide details to the Contact Details section of Add joint Investor form 1, <ifInvited>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
When Provide details to the Home Address section of Add Joint Investor form 1
When Provide details to the Mailing Address section of Add Joint Investor form No, 1
When Provide details to the Business Address section of Add Joint Investor form 1
Given Close The Details Card Address
Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section of Add Investor form <AccountType>, <AccountNumber>
#******
Given Select Investor on add joint investor form 2

When Provide details to the investor details section of Joint investor <IfMultiAccount>, 2
When Provide details to the Contact Details section of Add joint Investor form 2, No
Given Close The Details Card Contact Details
Given Expand The Details Card Address
When Provide details to the Home Address section of Add Joint Investor form 2
When Provide details to the Mailing Address section of Add Joint Investor form No, 2
When Provide details to the Business Address section of Add Joint Investor form 2
Given Close The Details Card Address

######
When Click on Add button
When Click on Continue button
Given Set value of LoginEmail for investor 1 
When Provide Email and Password then login
######

Then Validate that The Investor details of Joint Investor displaying properly on View Investor page <InvestorType>, 1, <IfMultiAccount>
Then Validate that The Investor details of Joint Investor displaying properly on View Investor page <InvestorType>, 2, <IfMultiAccount>

Then Validate that The Investor details of Joint Business Contact Details displaying properly on View investor page 1

Then Validate that the Contact Details of Joint Investor displaying properly on View Investor page 1
Then Validate that the Contact Details of Joint Investor displaying properly on View Investor page 2

Then Validate that the Address Details of Joint Investor displaying properly on View Investor page 1
Then Validate that the Address Details of Joint Investor displaying properly on View Investor page 2

Then Validate that the Account Details of Investor displaying properly on View Investor page <AccountType>, <AdminName>, <AccountNumber>




Examples: 
| User_Email                   | InvestorType | IfMultiAccount | AccountNumber | AccountType | AdminName    | isExisting | ifInvited |
| atestmanager3105@yopmail.com | Joint        | No             | 1             | ACH         | System Admin | No         | Yes       |



Scenario Outline: To verify that the Joint Investor can be added using INVITE INVESTOR button when FIRST investor belongs to MULTIPLE ACCOUNT

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Investor Page
##******
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
When Check the CheckBox Check this checkbox if user belongs to multiple accounts.


When Provide details to the investor details section of Joint investor <IfMultiAccount>, 1
Given Expand The Details Card Business Contact Details
When Provide details to the Business Contact details of Joint investor 1
Given Close The Details Card Business Contact Details
When Provide details to the Contact Details section of Add joint Investor form 1, <ifInvited>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
When Provide details to the Home Address section of Add Joint Investor form 1
When Provide details to the Mailing Address section of Add Joint Investor form No, 1
When Provide details to the Business Address section of Add Joint Investor form 1
Given Close The Details Card Address
Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section of Add Investor form <AccountType>, <AccountNumber>
#******
Given Select Investor on add joint investor form 2

When Provide details to the investor details section of Joint investor No, 2
When Provide details to the Contact Details section of Add joint Investor form 2, No
Given Close The Details Card Contact Details
Given Expand The Details Card Address
When Provide details to the Home Address section of Add Joint Investor form 2
When Provide details to the Mailing Address section of Add Joint Investor form No, 2
When Provide details to the Business Address section of Add Joint Investor form 2
Given Close The Details Card Address

######
When Click on Add button
When Click on Continue button
Given Set value of LoginEmail for investor 1 
When Provide Email and Password then login
When Navigate to manage account page          
When Search for Account on Manage Account page <InvestorType>           
When Navigate to the investor details by clicking on account name on Manage profile page
######

Then Validate that The Investor details of Joint Investor displaying properly on View Investor page <InvestorType>, 1, <IfMultiAccount>
Then Validate that The Investor details of Joint Investor displaying properly on View Investor page <InvestorType>, 2, No

Then Validate that The Investor details of Joint Business Contact Details displaying properly on View investor page 1

Then Validate that the Contact Details of Joint Investor displaying properly on View Investor page 1
Then Validate that the Contact Details of Joint Investor displaying properly on View Investor page 2

Then Validate that the Address Details of Joint Investor displaying properly on View Investor page 1
Then Validate that the Address Details of Joint Investor displaying properly on View Investor page 2

Then Validate that the Account Details of Investor displaying properly on View Investor page <AccountType>, <AdminName>, <AccountNumber>




Examples: 
| User_Email                   | InvestorType | IfMultiAccount | AccountNumber | AccountType | AdminName    | isExisting | ifInvited | SearchInvestor   |
| atestmanager3105@yopmail.com | Joint        | Yes            | 1             | Check       | System Admin | No         | Yes       | Joint&Individual |



Scenario Outline: To verify that the Joint Investor can be added using INVITE INVESTOR button when SECOND investor belongs to MULTIPLE ACCOUNT

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Investor Page
##******
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


When Provide details to the investor details section of Joint investor No, 1
Given Expand The Details Card Business Contact Details
When Provide details to the Business Contact details of Joint investor 1
Given Close The Details Card Business Contact Details
When Provide details to the Contact Details section of Add joint Investor form 1, <ifInvited>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
When Provide details to the Home Address section of Add Joint Investor form 1
When Provide details to the Mailing Address section of Add Joint Investor form No, 1
When Provide details to the Business Address section of Add Joint Investor form 1
Given Close The Details Card Address
Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section of Add Investor form <AccountType>, <AccountNumber>
#******
Given Select Investor on add joint investor form 2

When Check the CheckBox Check this checkbox if user belongs to multiple accounts.
When Provide details to the investor details section of Joint investor <IfMultiAccount>, 2
When Provide details to the Contact Details section of Add joint Investor form 2, No
Given Close The Details Card Contact Details
Given Expand The Details Card Address
When Provide details to the Home Address section of Add Joint Investor form 2
When Provide details to the Mailing Address section of Add Joint Investor form No, 2
When Provide details to the Business Address section of Add Joint Investor form 2
Given Close The Details Card Address

######
When Click on Add button
When Click on Continue button
Given Set value of LoginEmail for investor 1 
When Provide Email and Password then login
When Navigate to manage account page          
When Search for Account on Manage Account page <InvestorType>           
When Navigate to the investor details by clicking on account name on Manage profile page
######

Then Validate that The Investor details of Joint Investor displaying properly on View Investor page <InvestorType>, 1, No
Then Validate that The Investor details of Joint Investor displaying properly on View Investor page <InvestorType>, 2, <IfMultiAccount>

Then Validate that The Investor details of Joint Business Contact Details displaying properly on View investor page 1

Then Validate that the Contact Details of Joint Investor displaying properly on View Investor page 1
Then Validate that the Contact Details of Joint Investor displaying properly on View Investor page 2

Then Validate that the Address Details of Joint Investor displaying properly on View Investor page 1
Then Validate that the Address Details of Joint Investor displaying properly on View Investor page 2

Then Validate that the Account Details of Investor displaying properly on View Investor page <AccountType>, <AdminName>, <AccountNumber>




Examples: 
| User_Email                   | InvestorType | IfMultiAccount | AccountNumber | AccountType | AdminName    | isExisting | ifInvited | SearchInvestor   |
| atestmanager3105@yopmail.com | Joint        | Yes            | 1             | Wire        | System Admin | No         | Yes       | Joint&Individual |




Scenario Outline: To verify that the Joint Investor can be added using NEW_INVESTOR_ACCOUNT button


Given Login to Profile <User_Email>
Given Navigate to Manage profile page
When Click on the New Investor Account button 

Given Click on Investor Type Card on Add Investor page <InvestorType>

Then Validate that the Investor Type displaying at Headline of Add Investor form <InvestorType>

Then Validate investor details section populate email properly <User_Email>
Given Expand The Details Card Business Contact Details
When Provide details to the Business Contact details of Joint investor 1
Given Close The Details Card Business Contact Details
When Provide details to the Contact Details section of Add joint Investor form 1, <ifInvited>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
When Provide details to the Home Address section of Add Joint Investor form 1
When Provide details to the Mailing Address section of Add Joint Investor form No, 1
When Provide details to the Business Address section of Add Joint Investor form 1
Given Close The Details Card Address
Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section of Add Investor form <AccountType>, <AccountNumber>

Given Select Investor on add joint investor form 2

When Provide details to the investor details section of Joint investor <IfMultiAccount>, 2
When Provide details to the Contact Details section of Add joint Investor form 2, <ifInvited>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
When Provide details to the Home Address section of Add Joint Investor form 2
When Provide details to the Mailing Address section of Add Joint Investor form No, 2
When Provide details to the Business Address section of Add Joint Investor form 2
Given Close The Details Card Address

When Click on Add button
When Click on Continue button

Then Validate success-notification Successfully Successfully



Examples: 
| User_Email         | InvestorType | IfMultiAccount | AccountNumber | AccountType | ifInvited |
| IndividualInvestor | Joint        | No             | 1             | Check       | No        |



Scenario Outline: To verify that the Joint Investor can be added using SIGN-UP Link

#this navigation code block is pending to design
Given Navigate to the SignUp link Investor
Given Click on Investor Type Card on Add Investor page <InvestorType>

#####
Then Validate that the Investor Type displaying at Headline of Add Investor form <InvestorType>


When Provide details to the investor details section of Joint investor <IfMultiAccount>, 1
Given Expand The Details Card Business Contact Details
When Provide details to the Business Contact details of Joint investor 1
Given Close The Details Card Business Contact Details
When Provide details to the Contact Details section of Add joint Investor form 1, <ifInvited>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
When Provide details to the Home Address section of Add Joint Investor form 1
When Provide details to the Mailing Address section of Add Joint Investor form No, 1
When Provide details to the Business Address section of Add Joint Investor form 1
Given Close The Details Card Address
Given Expand The Details Card Send the interest income to
When Provide details to the Send the interest income to- section of Add Investor form <AccountType>, <AccountNumber>
#******
Given Select Investor on add joint investor form 2

When Provide details to the investor details section of Joint investor No, 2
When Provide details to the Contact Details section of Add joint Investor form 2, No
Given Close The Details Card Contact Details
Given Expand The Details Card Address
When Provide details to the Home Address section of Add Joint Investor form 2
When Provide details to the Mailing Address section of Add Joint Investor form No, 2
When Provide details to the Business Address section of Add Joint Investor form 2
Given Close The Details Card Address

######
When Click on Add button
When Click on Continue button
Given Set value of LoginEmail for investor 1 
When Provide Email and Password then login
When Navigate to manage profile page
######

Then Validate that The Investor details of Joint Investor displaying properly on View Investor page <InvestorType>, 1, <IfMultiAccount>
Then Validate that The Investor details of Joint Investor displaying properly on View Investor page <InvestorType>, 2, No

Then Validate that The Investor details of Joint Business Contact Details displaying properly on View investor page 1

Then Validate that the Contact Details of Joint Investor displaying properly on View Investor page 1
Then Validate that the Contact Details of Joint Investor displaying properly on View Investor page 2

Then Validate that the Address Details of Joint Investor displaying properly on View Investor page 1
Then Validate that the Address Details of Joint Investor displaying properly on View Investor page 2

Then Validate that the Account Details of Investor displaying properly on View Investor page <AccountType>, <AdminName>, <AccountNumber>

Examples: 
| User_Email                   | InvestorType | IfMultiAccount | AccountNumber | AccountType | AdminName    | isExisting | ifInvited | Link                                                                      |
| atestmanager3105@yopmail.com | Joint        | No             | 1             | Check       | System Admin | No         | No        | https://test.m2ifintech.com/#/sign-up/|


