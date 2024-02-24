@BeforeFeatureDontLaunch @AfterStep @M2I
Feature: AddFinder_MRIA

A short summary of the feature

Scenario Outline: To verify that the MRIA Finder can be added successfully using ADD FINDER button
Given Login to Profile <User_Email>
And Navigate to the Manage Finders page
When Click on the Add Finder button
And Provide details to the finder details section of Add finder form <IsMultiAccount>, <FinderType>, <IsInvited>
And Provide details to the Contact details section of Add finder form <IsInvited>, <FinderType>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
And Provide details to the Physical Address section to Add MRIA form

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
| User_Email     | FinderType  | IsMultiAccount | AccountNumber | AccountType    | sameAsBusinessAddress | IsInvited | StatusName |
| CompanyManager | MRIA        | No             | 1             | Checking       | No                    | No        | Initiated  |
| SystemAdmin    | MRIA        | No             | 1             | Checking       |  No                   | No        | Initiated  |


Scenario Outline: To verify that the MRIA Finder can be added successfully using INVITE FINDER button

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
And Provide details to the User details section of Add finder form <IsMultiAccount>, <FinderType>
And Provide details to the Contact details section of Add finder form <IsInvited>, <FinderType>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
And Provide details to the Physical Address section to Add MRIA form
Given Close The Details Card Address
Given Expand The Details Card Bank Account Details
And Provide Bank account details to Add finder form <AccountType>
When Click on Save(Green) button
When Click on Continue button
When Provide Email and Password then login

Then Validate that the status displaying properly at the top <StatusName>
Then Validate that the Finder details section displaying data properly on the finder details page <FinderType>, <IsMultiAccount>
Then Validate that the Contact details section displaying data properly on the finder details page <IsInvited>, <FinderType>
Then Validate that the Address section displaying data properly on the finder details page <FinderType>
Then Validate that the Bank Account details section displaying data properly on the finder details page <AccountType>, <AccountNumber>

Examples: 
| User_Email     | FinderType  | IsMultiAccount | AccountNumber |  AccountType    | sameAsBusinessAddress | IsInvited | StatusName | SearchFinder      |
| CompanyManager | MRIA        | No             | 1             | Savings         |  No                   | Yes       | Initiated  | RIA&BD&Finder&IAR |
| SystemAdmin    | MRIA        | No             | 1             | Savings         |  No                   | Yes       | Initiated  | RIA&BD&Finder&IAR |

Scenario Outline: To verify that the MRIA Finder can be added successfully using INVITE FINDER button when user belongs to MULTIPLE ACCOUNT
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

And  Provide details to the Contact details section of Add finder form <IsInvited>, <FinderType>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
And Provide details to the Physical Address section to Add MRIA form
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
| User_Email                   | FinderType  | IsMultiAccount | AccountNumber | AccountType | sameAsBusinessAddress | IsInvited | StatusName | SearchFinder      |
| CompanyManager               | MRIA        | Yes            | 1             | Savings     | No                    | Yes       | Initiated  | RIA&BD&Finder&IAR |
| SystemAdmin                  | MRIA        | Yes            | 1             | Savings     | No                    | Yes       | Initiated  | RIA&BD&Finder&IAR |



Scenario Outline: To verify that the MRIA finder can be added by SIGN-UP
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
And Provide details to the Physical Address section to Add MRIA form
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
| User_Email                   | FinderType  | IsMultiAccount | AccountNumber | AccountType | AdminName    | sameAsBusinessAddress | IsInvited | StatusName | SearchFinder      |
| atestmanager3105@yopmail.com | MRIA        | Yes            | 1             | Savings     | System Admin | No                    | Yes       | Initiated  | RIA&BD&Finder&IAR |

