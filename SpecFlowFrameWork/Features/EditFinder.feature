@BeforeFeatureDontLaunch @AfterStep @M2I
Feature: EditFinder

This feature file contains BD, Finder, IAR, RIA Edit finder


Scenario Outline: To verify that the Edit finder page shows correct data by clicking on the Edit button

Given Login to Profile <User_Email>
And Navigate to the Manage Finders page
Given Search the Finder on the Finders page <SearchFinderType>
And Navigate to the Finder details page of first finder
And Get Finder Details from Finder details page <FinderType>
When Click on Edit button
Then Validate that the finder details section of edit Finder form populate data properly <IsMultiAccount>, <FinderType>, <IsInvited>
Then Validate that the Contact details section of edit Finder form populate data properly <IsInvited>, <FinderType>
Given Close The Details Card Contact Details
Given Expand The Details Card Address
Then Validate that the Business Address section of Edit finder form populate data properly
Then Validate that the Mailing Address section of Edit finder form populate data properly
Given Close The Details Card Address
Given Expand The Details Card Bank Account Details
Then Validate that the Bank account details of Edit finder form populate data properly

Examples: 
| User_Email     | FinderType | AccountNumber | IsMultiAccount | IsInvited | SearchFinderType |
| CompanyManager | RIA        | 1             | No             | No        | RIA              |
| CompanyManager | BD         | 1             | No             | No        | BD               |                 #for role of company manager
| CompanyManager | Finder     | 1             | No             | No        | Finder           |
| CompanyManager | IAR        | 1             | No             | No        | IAR              |

| SystemAdmin | RIA        | 1             | No             | No        | RIA              |
| SystemAdmin | BD         | 1             | No             | No        | BD               |                 #for role of company manager
| SystemAdmin | Finder     | 1             | No             | No        | Finder           |
| SystemAdmin | IAR        | 1             | No             | No        | IAR              |









