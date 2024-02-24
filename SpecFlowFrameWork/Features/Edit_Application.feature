@BeforeFeatureDontLaunch @AfterStep @Origination
Feature: Edit Application feature


Scenario Outline: To verify that the add contact details form is working properly
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
When Click on Edit-Application button
When Edit details of contact details step <Email>, <BestTimeToCall>
Then Validate that navigated to Add-application page
When Click on Save & Next button
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible


Examples:
| User_Email           | Email                | BestTimeToCall | Message      |TypeOfLoan | IncomeType | IncomeFrequency | EmploymentType        | EducationDegree |
| slaadmin@yopmail.com | AppEmail@yopmail.com | Any Time       | Successfully | Education  | Paycheck   | Weekly         | Part Time Employment | Associate Degree|


Scenario Outline: To verify that add personal details step is working properly
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
When Click on Edit-Application button
When Click on Add Application step "Personal Details"
When Edit Required value to Personal details step     
When Check IsUSCistizen
When Check IsPermaanentResidence
When Click on Save & Next button
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible
When Click on Back Button
Then Validate that the Back button navigate to back step
When Click on the Cancel button
Then Validate that the Cancel button navigate to Application list page

Examples:
| User_Email           | Email                | BestTimeToCall | Message      |
| slaadmin@yopmail.com | AppEmail@yopmail.com | Any Time       | Successfully |

Scenario Outline: To verify that add address details form is working properly

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
When Click on Edit-Application button
When Click on Add Application step "Address"
When Edit details of Mailing Address
When Edit details of Physical Address
When Check the SameAsmailingAddress 
Then Validate that the Same as mailing address working properly
When Edit details of Other Address
When Click on Save & Next button
Then Validate success-notification Successfully <Message>

Examples:
| User_Email           | Email                | BestTimeToCall | Message      | Agency | TypeOfLoan | IncomeType | IncomeFrequency | EmploymentType        | EducationDegree |
| slaadmin@yopmail.com | AppEmail@yopmail.com | Any Time       | Successfully | AES    | Education  | Paycheck   | Weekly          | Part Time Employment | Associate Degree|

@ignore
Scenario Outline: To verify that Reference Details step is working properly
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
When Click on Edit-Application button
When Click on Add Application step "Address"
When Edit details of Mailing Address
When Edit details of Physical Address
When Click on Save & Next button
When Click on Add Application step "Reference Details"
When Edit details of Reference Details <Relationship>
When Edit details of Reference Contact details
When Edit details of Reference Address details
When Click on Save & Next button
Then Validate success-notification displaying 
Given Wait until success notification invisible
When Click on Back Button
Given Click on Delete button Until only one card remain
#Then Validate Edited data displaying properly on Added Card
Then Validate that data displaying properly on Added Card

When Provide Required details to Reference Details <Relationship>
When Provide Required details to Reference Contact details
When Provide Required details to Reference Address details
#When Click on Add Reference button
When Click on Save & Next button
Then Validate success-notification displaying
Given Wait until success notification invisible
When Click on Back Button
When Click on Edit button of added card of application
When Edit Reference details
When Click on Save & Next button
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible
When Click on Back Button
Given Click on Delete button
Then Validate that the Item deleted successfully



Examples:
| User_Email           | Email                | BestTimeToCall | Message  | Agency | TypeOfLoan | IncomeType | IncomeFrequency | EmploymentType        | EducationDegree  | Relationship |
| slaadmin@yopmail.com | AppEmail@yopmail.com | Any Time       | Successfully| AES    | Education  | Paycheck   | Weekly          | Part Time Employment | Associate Degree |  Spouse      |


Scenario Outline: To verify that add Loan Details form is working properly.
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
When Click on Edit-Application button
When Click on Add Application step "Loan Details"
Given Click on Delete button Until only one card remain
Given Click on Edit loan button
When Edit details of loan details step <Agency>, <TypeOfLoan>
When Click on Save & Next button
Given Wait until success notification invisible
When Click on Back Button
When Click on Add loan button
When Provide Required details to loan details step <Agency>, <TypeOfLoan>
Then Validate that Add Loan button working properly
When Click on Save & Next button
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible
When Click on Back Button


Examples:
| User_Email           | Email                | BestTimeToCall | Message      | Agency | TypeOfLoan | IncomeType | IncomeFrequency | EmploymentType       | EducationDegree |
| slaadmin@yopmail.com | AppEmail@yopmail.com | Any Time       | Successfully | AES    | Education  | Paycheck   | Weekly          | Part Time Employment | Associate Degree|

Scenario Outline: To verify that add Financial Details form is working properly.

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
When Click on Edit-Application button
When Click on Add Application step "Financial Details"
When Click on Edit button of added card of application
When Edit details of Financial details <IncomeType>, <IncomeFrequency>
When Click on Add Income button
Given Wait until success notification invisible
When Provide Required details to Financial details <IncomeType>, <IncomeFrequency>
Then Validate that the Add income button working properly
When Click on Save & Next button
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible

Examples:
| User_Email           | Email                | BestTimeToCall | Message      | Agency | TypeOfLoan | IncomeType | IncomeFrequency | EmploymentType       | EducationDegree  |
| slaadmin@yopmail.com | AppEmail@yopmail.com | Any Time       | Successfully | AES    | Education  | Paycheck   | Weekly          | Part Time Employment | Associate Degree |


Scenario Outline: To verify that add Employment Details form is working properly.
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
When Click on Edit-Application button
When Click on Add Application step "Employment Details"
Given Click on Delete button Until only one card remain
When Click on Edit button of added card of application
When Edit details of Employee details <EmploymentType>

Then Validate that the input field reflected as per Employment Type <EmploymentType>
Then Validate that Still Working check invisible by providing End date
#OR
#Then Validate that End Date field getting disabled by checked Still working 

When Provide Required details to Contact details
When Provide Required details to Address details
When Click on Add Employment button
When Edit details of Employee details <EmploymentType>
#Then Validate that Still Working check invisible by providing End date
#OR
Then Validate that End Date field getting disabled by checked Still working 

When Provide Required details to Contact details
When Provide Required details to Address details
When Click on Save & Next button
Then Click on Confirm popup
Then Validate success-notification Successfully <Message>
When Click on Back Button
When Click on Edit Employment button
When Edit Employment details
When Click on Save & Next button
Then Validate that Finance updated properly


Examples:
| User_Email           | Message     | EmploymentType       |
| slaadmin@yopmail.com |Successfully | Part Time Employment |
| slaadmin@yopmail.com |Successfully | Unemployed           |
| slaadmin@yopmail.com |Successfully | Retired              |

Scenario:To verify that the Edit Application flow working smoothly
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
When Click on Edit-Application button
When Edit details of contact details step <Email>, <BestTimeToCall>
Then Validate that navigated to Add-application page
When Click on Save & Next button
Then Validate success-notification Successfully <Message>

#Personal Details
When Edit details of Personal details step
When Check IsUSCistizen
When Check IsPermaanentResidence
When Click on Save & Next button
Then Validate success-notification Successfully <Message>

#Address Section
When Edit details of Mailing Address
When Edit details of Physical Address
When Check the SameAsmailingAddress
When Edit details of Other Address

When Click on Save & Next button
Then Validate success-notification Successfully <Message>

#Reference details
Given Click on Delete button Until only one card remain
Given Click on Edit Reference button
When Edit details of Reference Details <Relationship>
When Edit details of Reference Contact details
When Edit details of Reference Address details

When Click on Save & Next button
Then Validate success-notification Successfully <Message>

#Loan Details
Given Click on Delete button Until only one card remain
Given Click on Edit loan button
When Edit details of loan details step <Agency>, <TypeOfLoan>
When Click on Add loan button
Given Wait until success notification invisible
When Edit details of loan details step <Agency>, <TypeOfLoan>
Then Validate that Add Loan button working properly
When Click on Save & Next button
Then Validate success-notification Successfully <Message>

#Financial Details
Given Click on Delete button Until only one card remain
When  Click on Edit button of added card of application
When Edit details of Financial details <IncomeType>, <IncomeFrequency>
When Click on Add Income button
Given Wait until success notification invisible
When Edit details of Financial details <IncomeType>, <IncomeFrequency>

Then Validate that the Add income button working properly
When Click on Save & Next button
Then Validate success-notification Successfully <Message>

#Employment details
Given Click on Delete button Until only one card remain
When Click on Edit Employment button
When Edit details of Employee details <EmploymentType>
Then Validate that Still Working check invisible by providing End date 
#Then Validate that End Date field getting disabled by checked Still working 

When Edit details of Contact details
When Edit details of Address details
When Click on Save & Next button
Then Click on Confirm popup
Then Validate success-notification Successfully <Message>


#Education details
When Edit details of the Education details step <EducationDegree>
When Click on Save(Green) button
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible

Then Validate that the Borrower details page show Personal details properly
When Expand Card of Borrower details Contact Details
Then Validate that the Borrower details page show Contact details properly
When Close Card of Borrower details Contact Details
When Expand Card of Borrower details Address
When Click on show more
Then Validate that the Borrower details page show Physical Address properly
Then Validate that the Borrower details page show Other details properly
Then Validate that the Borrower details page show Mailing Address properly
When Close Card of Borrower details Address
When Expand Card of Borrower details Reference Details
Then Validate that the Borrower details page show Reference details properly
When Close Card of Borrower details Reference Details
When Expand Card of Borrower details Employment Details
Then Validate that the Borrower details page show Employment details properly
When Close Card of Borrower details Employment Details
When Expand Card of Borrower details Education Details
Then Validate that the Borrower details page show Education details properly


Examples:
| User_Email           | Email                | BestTimeToCall | Message      | Agency | TypeOfLoan | IncomeType | IncomeFrequency | EmploymentType       | EducationDegree  | Relationship |
| slaadmin@yopmail.com | AppEmail@yopmail.com | Any Time       | Successfully | AES    | Education  | Paycheck   | Weekly          | Part Time Employment | Associate Degree |  Spouse      |



	
