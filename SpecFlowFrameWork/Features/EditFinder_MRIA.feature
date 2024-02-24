@BeforeFeatureDontLaunch @AfterStep @M2I
Feature: EditFinder_MRIA

MRIA

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
Then Validate that the Physical Address section of Edit finder form populate data properly
Given Close The Details Card Address

Given Expand The Details Card Bank Account Details
Then Validate that the Bank account details of Edit finder form populate data properly


Examples: 
| User_Email                   | FinderType | AccountNumber | IsInvited | SearchFinderType  |
| CompanyManager | MRIA       | 1             | No        |MRIA               |
| SystemAdmin | MRIA       | 1             | No        |MRIA               |

Scenario Outline: To verify that the MRIA Finder can be Edited using Edit button

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
And Edit details to the Physical Address section to Edit MRIA form
Given Close The Details Card Address

Given Expand The Details Card Bank Account Details
Given Clear the All input value
And Edit Bank account details to Add finder form <AccountType>
When Click on Save(Green) button
Then Validate success-notification Successfully Successfully
Given Wait until success notification invisible


Then Validate that the Finder details section displaying data properly on the finder details page <FinderType>, <IsMultiAccount>
Then Validate that the Contact details section displaying data properly on the finder details page <IsInvited>, <FinderType>
Then Validate that the Address section displaying data properly on the finder details page <FinderType>
Then Validate that the Edited Bank Account details section displaying data properly on the finder details page <AccountNumber>


Examples: 
| User_Email     | FinderType | AccountNumber | IsInvited | SearchFinderType  |
| CompanyManager | MRIA       | 1             | No        | MRIA              |
| SystemAdmin    | MRIA       | 1             | No        | MRIA              |

Scenario Outline: To verify that the MRIA Finder can be Edited using Edit button by ROLES of MRIA

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
And Edit details to the Physical Address section to Edit MRIA form
Given Close The Details Card Address

Given Expand The Details Card Bank Account Details
Given Clear the All input value
And Edit Bank account details to Add finder form <AccountType>
When Click on Save(Green) button
Then Validate success-notification Successfully Successfully
Given Wait until success notification invisible

Then Validate that the Finder details section displaying data properly on the finder details page <FinderType>, <IsMultiAccount>
Then Validate that the Contact details section displaying data properly on the finder details page <IsInvited>, <FinderType>
Then Validate that the Address section displaying data properly on the finder details page <FinderType>
Then Validate that the Edited Bank Account details section displaying data properly on the finder details page <AccountNumber>


Examples: 
| User_Email        | FinderType | AccountNumber | IsInvited | SearchFinderType  |
| MRIAAdmin         | MRIA       | 1             | No        | MRIA              |
| MRIAAccountManager| MRIA       | 1             | No        | MRIA              |
#| MRIAAccountUser   | MRIA       | 1             | No        | MRIA              |
#| MRIAUser          | MRIA       | 1             | No        | MRIA              |

