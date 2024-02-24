@BeforeFeatureDontLaunch @AfterStep @Origination

Feature: AddNegotiation

A short summary of the feature

Scenario Outline: 01_To verify that the Negotiation can be added using Add Negotiation button
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
Given Expand Finance details section
Given Navigate to the Negotiate Loan details section

When Select Loan among private student loan
Given Click on Add Negotiation button
Then Validate that the Add Negotiation displaying Loan ID properly
Then Validate that the Total amount displaying properly
When Provide Negotiation name to Add Negotiation field
When Click on Add button
Then Validate success-notification Successfully <Message>
Then Validate that the Added Negotiation details displaying properly




Examples:
| User_Email                       | Message      |
| loanacquisitionadmin@yopmail.com | Successfully |

Scenario Outline: 02_To verify that the Edit bid amount and offer using Edit action item successfully
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
Given Expand Finance details section
Given Navigate to the Negotiate Loan details section

When Click on The Action Button "Edit"
When Click on The Action Button "Close"
Then Validate that the Close button is working fine

When Click on The Action Button "Edit"
And Enter value to the "Agency Offer", 300000
And Enter value to the "Proposed Bid", 4000000
And Click on The Action Button "Done"
Then Validate that the Edit bit amount is not possible when Proposed Bid is greater than Agency Offer <Message>
Given Wait until success notification invisible

When Enter value to the "Agency Offer", 300000
And Enter value to the "Proposed Bid", 3000
And Click on The Action Button "Done"
Then Validate success-notification Successfully "Successfully"


Examples:
| User_Email                       | Message                                          |
| loanacquisitionadmin@yopmail.com | cannot|




Scenario Outline: 03_To verify that the Negotiation History pop-up displaying History properly
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
Given Expand Finance details section
Given Navigate to the Negotiate Loan details section

When Click on The Action Button "History"

Then Validate that the navigation History pop-up displaying data properly <name>


Examples:
| User_Email                       | Message | name            |
| loanacquisitionadmin@yopmail.com | cannot  | negotiationName |


Scenario Outline: 04_To verify that the Expand button working properly
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
Given Expand Finance details section
Given Navigate to the Negotiate Loan details section
When Click on The Action Button "expand_more"

Then Validate that the inner table displaying LoanID properly
Then Validate that the inner table displaying Agency properly
Then Validate that the inner table displaying Loan Type properly
Then Validate that the inner table displaying Loan Amount properly

Examples:
| User_Email                       |
| loanacquisitionadmin@yopmail.com |  


Scenario Outline: 05_To verify that the Approve Negotiation button working properly
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
Given Expand Finance details section
Given Navigate to the Negotiate Loan details section
When Click on The Action Button "Done"
When Click on Confirm button
Then Validate success-notification Successfully  <Message>


Examples:
| User_Email                       | Message   | 
| loanacquisitionadmin@yopmail.com | Approved  | 
