@BeforeFeatureDontLaunch @AfterStep @M2I
Feature: AddFinder

A short summary of the feature

Scenario Outline: To verify that the Finder can be added successfully using ADD FINDER button
Given Login to Profile <User_Email>
And Navigate to the Manage Finders page
When Click on the Add Finder button
And Provide details to the finder details section of Add finder form <IsMultiAccount>, <FinderType>, <IsInvited>
And Provide details to the Contact details section of Add finder form <IsInvited>, <FinderType>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
And Provide details to the Business Address section
And Provide details to the Mailing Address section <sameAsBusinessAddress>
Given Close The Details Card Address
Given Expand The Details Card Bank Account Details
And Provide Bank account details to Add finder form <AccountType>
When Click on Save(Green) button
Then Validate success-notification Successfully Successfully

Then Validate that the status displaying properly at the top <StatusName>
Then Validate that the Finder details section displaying data properly on the finder details page <FinderType>, <IsMultiAccount>
Then Validate that the Contact details section displaying data properly on the finder details page <IsInvited>, <FinderType>
Then Validate that the Address section displaying data properly on the finder details page <FinderType>
Then Validate that the Bank Account details section displaying data properly on the finder details page <AccountType>, <AccountNumber>


Examples: 
| User_Email                   | FinderType | IsMultiAccount | AccountNumber | AccountType | sameAsBusinessAddress | IsInvited | StatusName |
#for comp manager
| CompanyManager | RIA        | No             | 1             | Checking    |  No                   | No        | Initiated  |
| CompanyManager | RIA        | No             | 1             | Savings     | Yes                   | No        | Initiated  |

| CompanyManager | BD         | No             | 1             | Checking    | No                    | No        | Initiated  |
| CompanyManager | BD         | No             | 1             | Savings     |Yes                    | No        | Initiated  |

| CompanyManager | Finder     | No             | 1             | Checking    | No                    | No        | Initiated  |
| CompanyManager | Finder     | No             | 1             | Savings     | Yes                   | No        | Initiated  |

| CompanyManager | IAR        | No             | 1             | Checking    | No                    | No        | Initiated  |
| CompanyManager | IAR        | No             | 1             | Savings     | Yes                   | No        | Initiated  |
# for system admin
| SystemAdmin | RIA        | No             | 1             | Checking    |  No                   | No        | Initiated  |
| SystemAdmin | RIA        | No             | 1             | Savings     | Yes                   | No        | Initiated  |

| SystemAdmin | BD         | No             | 1             | Checking    | No                    | No        | Initiated  |
| SystemAdmin | BD         | No             | 1             | Savings     |Yes                    | No        | Initiated  |

| SystemAdmin | Finder     | No             | 1             | Checking    | No                    | No        | Initiated  |
| SystemAdmin | Finder     | No             | 1             | Savings     | Yes                   | No        | Initiated  |

| SystemAdmin | IAR        | No             | 1             | Checking    | No                    | No        | Initiated  |
| SystemAdmin | IAR        | No             | 1             | Savings     | Yes                   | No        | Initiated  |


Scenario Outline: To verify that the Finder can be added successfully using ADD FINDER button when user belongs to MULTIPLE ACCOUNT
Given Login to Profile <User_Email>
And Navigate to the Manage Finders page
Given Search the Finder on the Finders page <SearchFinder>
And  Get LoginEmail of Existing Finder from finders page
When Click on the Add Finder button
And Provide details to the finder details section of Add finder form <IsMultiAccount>, <FinderType>, <IsInvited>
And Provide details to the Contact details section of Add finder form <IsInvited>, <FinderType>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
And Provide details to the Business Address section
And Provide details to the Mailing Address section <sameAsBusinessAddress>
Given Close The Details Card Address
Given Expand The Details Card Bank Account Details
And Provide Bank account details to Add finder form <AccountType>
When Click on Save(Green) button
Then Validate success-notification Successfully Successfully

Then Validate that the status displaying properly at the top <StatusName>
Then Validate that the Finder details section displaying data properly on the finder details page <FinderType>, <IsMultiAccount>
Then Validate that the Contact details section displaying data properly on the finder details page <IsInvited>, <FinderType>
Then Validate that the Address section displaying data properly on the finder details page <FinderType>
Then Validate that the Bank Account details section displaying data properly on the finder details page <AccountType>, <AccountNumber>


Examples: 
| User_Email                   | FinderType | IsMultiAccount | AccountNumber | AccountType | sameAsBusinessAddress | IsInvited | StatusName | SearchFinder       |
| CompanyManager | RIA        | Yes            | 1             | Savings     |  No                   | No        | Initiated  |  RIA&BD&Finder&IAR |
| CompanyManager | RIA        | Yes            | 1             | Checking    |  Yes                  | No        | Initiated  |  RIA&BD&Finder&IAR |

| CompanyManager | BD         | Yes            | 1             | Savings     |  No                   | No        | Initiated  |  RIA&BD&Finder&IAR |
| CompanyManager | BD         | Yes            | 1             | Checking    |  Yes                  | No        | Initiated  |  RIA&BD&Finder&IAR |

| CompanyManager | Finder     | Yes            | 1             | Savings     |  No                   | No        | Initiated  |  RIA&BD&Finder&IAR |
| CompanyManager | Finder     | Yes            | 1             | Checking    |  Yes                  | No        | Initiated  |  RIA&BD&Finder&IAR |

| CompanyManager | IAR        | Yes            | 1             | Savings     |  No                   | No        | Initiated  |  RIA&BD&Finder&IAR |
| CompanyManager | IAR        | Yes            | 1             | Checking    |  Yes                  | No        | Initiated  |  RIA&BD&Finder&IAR |



Scenario Outline: To verify that the Finder can be added successfully using INVITE FINDER button
Given Login to Profile <User_Email>
And Navigate to the Manage Finders page
When Click on the Invite Finder button
When Provide Email to invite pop-up <isExisting>
When Click on Send button
Then Validate success-notification Successfully Successfully
Given Navigate to the Email
Then Validate that CreateMyAccount button navigates to the Add finder page <FinderType>
Given Click on Finder Type Card on Add Finder page <FinderType>
Then Validate that the Finder Type displaying at Headline of Add Finder form <FinderType>
When Provide details to the finder details section of Add finder form <IsMultiAccount>, <FinderType>, <IsInvited>
And Provide details to the Contact details section of Add finder form <IsInvited>, <FinderType>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
And Provide details to the Business Address section
And Provide details to the Mailing Address section <sameAsBusinessAddress>
Given Close The Details Card Address
Given Expand The Details Card Bank Account Details
And Provide Bank account details to Add finder form <AccountType>

When Click on Save(Green) button
When Click on Continue button
#Given Set value of LoginEmail for investor 1 
When Provide Email and Password then login

#Then Validate success-notification Successfully Successfully

Then Validate that the status displaying properly at the top <StatusName>
Then Validate that the Finder details section displaying data properly on the finder details page <FinderType>, <IsMultiAccount>
Then Validate that the Contact details section displaying data properly on the finder details page <IsInvited>, <FinderType>
Then Validate that the Address section displaying data properly on the finder details page <FinderType>
Then Validate that the Bank Account details section displaying data properly on the finder details page <AccountType>, <AccountNumber>


Examples: 
| User_Email                   | FinderType | IsMultiAccount | AccountNumber | AccountType |  sameAsBusinessAddress | IsInvited | StatusName |
| CompanyManager | RIA        | No             | 1             | Checking    | No                     | Yes       | Initiated  |
| CompanyManager | RIA        | No             | 1             | Savings     |  Yes                   | Yes       | Initiated  |

| CompanyManager | BD         | No             | 1             | Checking    | No                     | Yes       | Initiated  |
| CompanyManager | BD         | No             | 1             | Savings     | Yes                    | Yes       | Initiated  |

| CompanyManager | Finder     | No             | 1             | Checking    |  No                    | Yes       | Initiated  |
| CompanyManager | Finder     | No             | 1             | Savings     |  Yes                   | Yes       | Initiated  |



Scenario Outline: To verify that the Finder can be added successfully using INVITE FINDER button when user belongs to MULTIPLE ACCOUNT
Given Login to Profile <User_Email>
And Navigate to the Manage Finders page
Given Search the Finder on the Finders page <SearchFinder>
And  Get LoginEmail of Existing Finder from finders page
When Click on the Invite Finder button
When Provide Email to invite pop-up <isExisting>
When Click on Send button
Then Validate success-notification Successfully Successfully
Given Navigate to the Email
Then Validate that CreateMyAccount button navigates to the Add finder page <FinderType>
Given Click on Finder Type Card on Add Finder page <FinderType>
Then Validate that the Finder Type displaying at Headline of Add Finder form <FinderType>

When Provide details to the finder details section of Add finder form <IsMultiAccount>, <FinderType>, <IsInvited>
And Provide details to the Contact details section of Add finder form <IsInvited>, <FinderType>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
And Provide details to the Business Address section
And Provide details to the Mailing Address section <sameAsBusinessAddress>
Given Close The Details Card Address
Given Expand The Details Card Bank Account Details
And Provide Bank account details to Add finder form <AccountType>
When Click on Save(Green) button
When Click on Continue button
When Provide Email and Password then login

When Navigate to manage account page          
When Search for Account on Manage Account page <FinderType>           
When Navigate to the finder details by clicking on account name on Manage profile page <FinderType>

Then Validate that the status displaying properly at the top <StatusName>
Then Validate that the Finder details section displaying data properly on the finder details page <FinderType>, <IsMultiAccount>
Then Validate that the Contact details section displaying data properly on the finder details page <IsInvited>, <FinderType>
Then Validate that the Address section displaying data properly on the finder details page <FinderType>
Then Validate that the Bank Account details section displaying data properly on the finder details page <AccountType>, <AccountNumber>


Examples: 
| User_Email                   | FinderType | IsMultiAccount | AccountNumber | AccountType |  sameAsBusinessAddress | IsInvited | StatusName |SearchFinder       |
| CompanyManager | RIA        | Yes            | 1             | Savings     | No                     | Yes       | Initiated  | RIA&BD&Finder&IAR |
| CompanyManager | RIA        | Yes            | 1             | Checking    | Yes                    | Yes       | Initiated  | RIA&BD&Finder&IAR |

| CompanyManager | BD         | Yes            | 1             | Savings     |  No                    | Yes       | Initiated  | RIA&BD&Finder&IAR |
| CompanyManager | BD         | Yes            | 1             | Checking    |  Yes                   | Yes       | Initiated  | RIA&BD&Finder&IAR |

| CompanyManager | Finder     | Yes            | 1             | Savings     |  No                    | Yes       | Initiated  | RIA&BD&Finder&IAR |
| CompanyManager | Finder     | Yes            | 1             | Checking    |  Yes                   | Yes       | Initiated  | RIA&BD&Finder&IAR |



Scenario Outline: To verify that the finder can be added by SIGN-UP
Given Enter Email_PassWord for Login <User_Email>
And Navigate to the Manage Finders page
Given Search the Finder on the Finders page <SearchFinder>
And  Get LoginEmail of Existing Finder from finders page
Given Logout the profile account

Given Navigate to the SignUp link Finder
Given Click on Finder Type Card on Add Finder page <FinderType>
Then Validate that the Finder Type displaying at Headline of Add Finder form <FinderType>

When Provide details to the finder details section of Add finder form <IsMultiAccount>, <FinderType>, <IsInvited>
And  Provide details to the Contact details section of Add finder form No, <FinderType>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
And Provide details to the Business Address section
And Provide details to the Mailing Address section <sameAsBusinessAddress>
Given Close The Details Card Address
Given Expand The Details Card Bank Account Details
And Provide Bank account details to Add finder form <AccountType>
When Click on Save(Green) button
When Click on Continue button
When Provide Email and Password then login


When Navigate to manage account page          
When Search for Account on Manage Account page <FinderType>           
When Navigate to the finder details by clicking on account name on Manage profile page <FinderType>

Then Validate that the status displaying properly at the top <StatusName>
Then Validate that the Finder details section displaying data properly on the finder details page <FinderType>, <IsMultiAccount>
Then Validate that the Contact details section displaying data properly on the finder details page <IsInvited>, <FinderType>
Then Validate that the Address section displaying data properly on the finder details page <FinderType>
Then Validate that the Bank Account details section displaying data properly on the finder details page <AccountType>, <AccountNumber>


Examples: 
| User_Email                   | FinderType  | IsMultiAccount | AccountNumber | AccountType |sameAsBusinessAddress | IsInvited | StatusName | SearchFinder      |
| atestmanager3105@yopmail.com | RIA         | Yes            | 1             | Savings     | No                   | Yes       | Initiated  | RIA&BD&Finder&IAR |
| atestmanager3105@yopmail.com | Finder      | Yes            | 1             | Savings     | No                   | Yes       | Initiated  | RIA&BD&Finder&IAR |
| atestmanager3105@yopmail.com | BD          | Yes            | 1             | Savings     | No                   | Yes       | Initiated  | RIA&BD&Finder&IAR |








Scenario Outline: To verify that the Approve button working properly

Given Enter Email_PassWord for Login <User_Email>
And Navigate to the Manage Finders page
When Search for the status finder Initiated
And Click on the finder name
And Click on the Approve button
And Click on Confirm button

Then Validate that the status displaying properly at the top Approved

Examples: 
| User_Email                   |
| atestmanager3105@yopmail.com |





#Below scenarios are for Edit finder

Scenario Outline: To verify that the Finder can be Edited using Edit button

Given Login to Profile <User_Email>
And Navigate to the Manage Finders page
Given Search the Finder on the Finders page <SearchFinderType>
And Navigate to the Finder details page of first finder
When Click on Edit button
Given Clear the All input value
When Edit details to the finder details section of Add finder form <IsMultiAccount>, <FinderType>, <IsInvited>
Given Close The Details Card Finder Details

Given Expand The Details Card Contact Details
Given Clear the All input value
When Provide details to the Contact details section of Add finder form <IsInvited>, <FinderType>
Given Close The Details Card Contact Details

Given Expand The Details Card Address
Given Clear the All input value
And Edit details to the Business Address section
Given Close The Details Card Address

Given Expand The Details Card Bank Account Details
Given Clear the All input value
And Edit Bank account details to Add finder form <AccountType>
When Click on Save(Green) button
Then Validate success-notification Successfully Successfully


Then Validate that the Finder details section displaying data properly on the finder details page <FinderType>, <IsMultiAccount>
Then Validate that the Contact details section displaying data properly on the finder details page <IsInvited>, <FinderType>
Then Validate that the Address section displaying data properly on the finder details page <FinderType>
Then Validate that the Edited Bank Account details section displaying data properly on the finder details page <AccountNumber>


Examples: 
| User_Email     | FinderType | AccountNumber | IsInvited | SearchFinderType  |
| CompanyManager | RIA        | 1             | No        | RIA               | 
| CompanyManager | BD         | 1             | No        | BD                |
| CompanyManager | Finder     | 1             | No        | Finder            | 
| CompanyManager | IAR        | 1             | No        | IAR               | 


| SystemAdmin | RIA        | 1             | No        | RIA               | 
| SystemAdmin | BD         | 1             | No        | BD                |
| SystemAdmin | Finder     | 1             | No        | Finder            | 
| SystemAdmin | IAR        | 1             | No        | IAR               | 



Scenario Outline: To verify that the Finder can be Edited using Edit button by different ROLE

Given Login to Profile <User_Email>
And Navigate to Manage profile page
When Click on Edit button
Given Clear the All input value
When Edit details to the finder details section of Add finder form <IsMultiAccount>, <FinderType>, <IsInvited>
Given Close The Details Card Finder Details

Given Expand The Details Card Contact Details
Given Clear the All input value
When Provide details to the Contact details section of Add finder form <IsInvited>, <FinderType>
Given Close The Details Card Contact Details

Given Expand The Details Card Address
Given Clear the All input value
And Edit details to the Business Address section
Given Close The Details Card Address

Given Expand The Details Card Bank Account Details
Given Clear the All input value
And Edit Bank account details to Add finder form <AccountType>
When Click on Save(Green) button
Then Validate success-notification Successfully Successfully


Then Validate that the Finder details section displaying data properly on the finder details page <FinderType>, <IsMultiAccount>
Then Validate that the Contact details section displaying data properly on the finder details page <IsInvited>, <FinderType>
Then Validate that the Address section displaying data properly on the finder details page <FinderType>
Then Validate that the Edited Bank Account details section displaying data properly on the finder details page <AccountNumber>


Examples: 
| User_Email     | FinderType | AccountNumber | IsInvited | SearchFinderType  |
| RIAFinder      | RIA        | 1             | No        | RIA               | 
| BDFinder       | BD         | 1             | No        | BD                |
| FinderFinder   | Finder     | 1             | No        | Finder            | 




