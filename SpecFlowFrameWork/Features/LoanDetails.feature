@BeforeFeatureDontLaunch @AfterStep @Origination
Feature: LoanDetails feature

A short summary of the feature

Scenario Outline: To verify that private loan can be added using the Add load button
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
Given Expand Finance details section
Given Navigate to the Loan details section
When Click on the Add Loan button
When Provide required details to the add loan pop-up and save it <LaonType>, <LoanCategory>
Then Validate that the Add button navigate to the Add loan popup
Then Validate success-notification Successfully <Message>
Then Validate that the Loan added successfully <LaonType>, <LoanCategory>

Examples:
| User_Email           | LaonType | LoanCategory | Message      |
| slaadmin@yopmail.com | Personal | Private      | Successfully |


Scenario Outline: To verify that federal loan can be added using the Add load button
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
Given Expand Finance details section
Given Navigate to the Loan details section
When Click on the Add Loan button
When Provide required details to the add loan pop-up and save it <LaonType>, <LoanCategory>
Then Validate that the Add button navigate to the Add loan popup
Then Validate success-notification Successfully <Message>
Then Validate that the Loan added successfully <LaonType>, <LoanCategory>

Examples:
| User_Email           | LaonType | LoanCategory | Message      |
| slaadmin@yopmail.com | Personal | Federal      | Successfully |

Scenario Outline: To verify that the document uploaded successfully

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
Given Expand Finance details section
Given Navigate to the Loan details section
And   Expand Inner table of loan details
When Upload document "Bank Statement", <FileName>
Then Validate success-notification Successfully <Message>
Then Validate that the document uploaded successfully <FileName>
When Upload document "Academic Proof", <FileName>
Then Validate that the document uploaded successfully <FileName>
When Upload document "Collateral document", <FileName>
Then Validate that the document uploaded successfully <FileName>


Examples:
| User_Email           | LaonType | BestTimeToCall | Message      | FileName      |
| slaadmin@yopmail.com | Personal | Any Time       | Successfully | uploadDoc.png |

Scenario Outline: To verify that the delete button working properly

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
Given Expand Finance details section
Given Navigate to the Loan details section
When Click on Delete loan button
Then Validate success-notification Successfully <Message>




Examples:
| User_Email           | LaonType | BestTimeToCall | Message      | FileName      |
| slaadmin@yopmail.com | Personal | Any Time       | Successfully | uploadDoc.png |
