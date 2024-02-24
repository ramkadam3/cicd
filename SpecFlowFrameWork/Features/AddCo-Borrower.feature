@BeforeFeatureDontLaunch @AfterStep @Origination
Feature: AddCo-Borrower


Scenario Outline: To verify that the add contact details form is working properly
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
When Order the loans in "descending" 
Given Click on ApplicationID 
When Click on the Co-Borrower button
Then Validate that the Co-Borrower button navigate to Add Co-Borrower process
When Provide required details to contact details step <Email>, <BestTimeToCall>
Then Validate that navigated to Add-application page
When Click on Save & Next button
Then Validate success-notification Successfully <Message>



Examples:
| User_Email           | Email                | BestTimeToCall | Message      | Agency | TypeOfLoan | IncomeType | IncomeFrequency | EmploymentType       | EducationDegree |
| slaadmin@yopmail.com | AppEmail@yopmail.com | Any Time       | Successfully | AES    | Education  | Paycheck   | Weekly          | Part Time Employment | Associate Degree|





Scenario Outline: To verify that add personal details step is working properly
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
When Order the loans in "descending" 
Given Click on ApplicationID 
When Click on the Co-Borrower button
Then Validate that the Co-Borrower button navigate to Add Co-Borrower process
When Click on Add Application step "Personal Details"
When Provide Required value to Personal details step
When Check IsUSCistizen
When Check IsPermaanentResidence
When Click on Save & Next button
Then Validate success-notification Successfully <Message>
When Click on Back Button
Then Validate that the Back button navigate to back step
When Click on the Cancel button
Then Validate that the Cancel button navigate to Borrower details page

Examples:
| User_Email           | Email                | BestTimeToCall | Message      | Agency | TypeOfLoan | IncomeType | IncomeFrequency | EmploymentType       | EducationDegree |
| slaadmin@yopmail.com | AppEmail@yopmail.com | Any Time       | Unable       | AES    | Education  | Paycheck   | Weekly          | Part Time Employment | Associate Degree|




Scenario Outline: To verify that add address details form is working properly

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
When Order the loans in "descending" 
Given Click on ApplicationID 
When Click on the Co-Borrower button
Then Validate that the Co-Borrower button navigate to Add Co-Borrower process
When Click on Add Application step "Address"
When Provide Required details to Mailing Address
When Provide Required details to Physical Address
When Check the SameAsmailingAddress 
Then Validate that the Same as mailing address working properly
When Provide Required details to Other Address
When Click on Save & Next button
Then Validate success-notification Successfully <Message>

Examples:
| User_Email           | Email                | BestTimeToCall | Message      | Agency | TypeOfLoan | IncomeType | IncomeFrequency | EmploymentType       | EducationDegree |
| slaadmin@yopmail.com | AppEmail@yopmail.com | Any Time       | Unable       | AES    | Education  | Paycheck   | Weekly          | Part Time Employment | Associate Degree|




Scenario Outline: To verify that Reference Details step is working properly
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
When Order the loans in "descending" 
Given Click on ApplicationID 
When Click on the Co-Borrower button
Then Validate that the Co-Borrower button navigate to Add Co-Borrower process
When Click on Add Application step "Reference Details"
When Provide Required details to Reference Details <Relationship>
When Provide Required details to Reference Contact details
When Provide Required details to Reference Address details
When Click on Save & Next button
Then Validate success-notification Successfully <Message>
#Then Validate that data displaying properly on Added Card

When Provide Required details to Reference Details <Relationship>
When Provide Required details to Reference Contact details
When Provide Required details to Reference Address details
When Click on Add Reference button
Then Validate success-notification displaying
Given Click on Edit Reference button
When Edit Reference details
When Click on Add Reference button
Then Validate success-notification Successfully "successfully"
#When Click on Back Button
Given Click on Delete button
Then Validate that the Item deleted successfully


Examples:
| User_Email           | Email                | BestTimeToCall | Message  | Agency | TypeOfLoan | IncomeType | IncomeFrequency | EmploymentType       | EducationDegree  | Relationship |
| slaadmin@yopmail.com | AppEmail@yopmail.com | Any Time       | Unable   | AES    | Education  | Paycheck   | Weekly          | Part Time Employment | Associate Degree |  Spouse      |

@ignore
Scenario Outline: To verify that add Loan Details form is working properly.
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
When Order the loans in "ascending" 
Given Click on ApplicationID 
When Click on the Co-Borrower button
Then Validate that the Co-Borrower button navigate to Add Co-Borrower process
When Click on Add Application step "Loan Details"
When Provide Required details to loan details step <Agency>, <TypeOfLoan>
#When Click on Add loan button
#When Select the All Load Id
When Click on Save & Next button
Then Validate success-notification Successfully <Message>

Examples:
| User_Email           | Email                | BestTimeToCall | Message      | Agency | TypeOfLoan | IncomeType | IncomeFrequency | EmploymentType       | EducationDegree |
| slaadmin@yopmail.com | AppEmail@yopmail.com | Any Time       | Unable       | AES    | Education  | Paycheck   | Weekly          | Part Time Employment | Associate Degree|



Scenario Outline: To verify that add Financial Details form is working properly.

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
When Order the loans in "descending" 
Given Click on ApplicationID 
When Click on the Co-Borrower button
Then Validate that the Co-Borrower button navigate to Add Co-Borrower process
When Click on Add Application step "Financial Details"
When Provide Required details to Financial details <IncomeType>, <IncomeFrequency>
When Click on Add Income button
Given Wait until success notification invisible
When Provide Required details to Financial details <IncomeType>, <IncomeFrequency>
Then Validate that the Add income button working properly
When Click on Save & Next button
Then Validate success-notification Successfully <Message>
When Click on Edit button of added card of application
When Edit finance details
When Click on Add Income button
Then Validate that Finance updated properly


Examples:
| User_Email           | Email                | BestTimeToCall | Message      | Agency | TypeOfLoan | IncomeType | IncomeFrequency | EmploymentType       | EducationDegree |
| slaadmin@yopmail.com | AppEmail@yopmail.com | Any Time       | Unable       | AES    | Education  | Paycheck   | Weekly          | Part Time Employment | Associate Degree|



Scenario Outline: To verify that add Employment Details form is working properly.
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
When Order the loans in "descending" 
Given Click on ApplicationID 
When Click on the Co-Borrower button
Then Validate that the Co-Borrower button navigate to Add Co-Borrower process
When Click on Add Application step "Employment Details"
When Provide Required details to Employee details <EmploymentType>
Then Validate that Still Working check invisible by providing End date 
#Then Validate that End Date field getting disabled by checked Still working 

When Provide Required details to Contact details
When Provide Required details to Address details
When Click on Add Employment button
When Provide Required details to Employee details <EmploymentType>
#Then Validate that Still Working check invisible by providing End date 
Then Validate that End Date field getting disabled by checked Still working 

When Provide Required details to Contact details
When Provide Required details to Address details
When Click on Save & Next button
Then Validate success-notification Successfully <Message>
#When Click on Back Button
When Click on Edit Employment button
When Edit Employment details
When Click on Add Employment button
Then Validate that Finance updated properly


Examples:
| User_Email            | Email                 | BestTimeToCall | Message      | Agency | TypeOfLoan | IncomeType | IncomeFrequency | EmploymentType       | EducationDegree |
| slaadmin@yopmail.com  | AppEmail@yopmail.com  | Any Time       | Unable       | AES    | Education  | Paycheck   | Weekly          | Part Time Employment | Associate Degree|
| slaadmin@yopmail.com  | AppEmail@yopmail.com | Any Time       | Unable       | AES    | Education  | Paycheck   | Weekly           | Unemployed           | Associate Degree|
| slaadmin@yopmail.com  | AppEmail@yopmail.com | Any Time       | Unable       | AES    | Education  | Paycheck   | Weekly           | Self Employed        | Associate Degree|
| slaadmin@yopmail.com  | AppEmail@yopmail.com | Any Time       | Unable       | AES    | Education  | Paycheck   | Weekly           | Retired              | Associate Degree|

#| slamember@yopmail.com | AppEmail@yopmail.com | Any Time       | Unable       | AES    | Education  | Paycheck   | Weekly          | Part Time Employment | Associate Degree|
#| slamember@yopmail.com | AppEmail@yopmail.com | Any Time       | Unable       | AES    | Education  | Paycheck   | Weekly          | Unemployed           | Associate Degree|
#| slamember@yopmail.com | AppEmail@yopmail.com | Any Time       | Unable       | AES    | Education  | Paycheck   | Weekly          | Self Employed        | Associate Degree|
#| slamember@yopmail.com | AppEmail@yopmail.com | Any Time       | Unable       | AES    | Education  | Paycheck   | Weekly          | Retired              | Associate Degree|


Scenario Outline: To verify that Co-Borrower can be added successfully using Add Co-Borrower Button
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
When Order the loans in "descending" 
Given Click on ApplicationID 
When Click on the Co-Borrower button
Then Validate that the Co-Borrower button navigate to Add Co-Borrower process

When Provide required details to contact details step <Email>, <BestTimeToCall>
Then Validate that navigated to Add-application page
When Click on Save & Next button
Then Validate success-notification Successfully <Message>

#Personal Details
When Provide Required value to Personal details step
When Check IsUSCistizen
When Check IsPermaanentResidence
When Click on Save & Next button
Then Validate success-notification Successfully <Message>

#Address Section
When Provide Required details to Mailing Address
When Provide Required details to Physical Address
When Check the SameAsmailingAddress 
When Provide Required details to Other Address
When Click on Save & Next button
Then Validate success-notification Successfully <Message>

#Reference details
When Provide Required details to Reference Details <Relationship>
When Provide Required details to Reference Contact details
When Provide Required details to Reference Address details
When Click on Save & Next button
Then Validate success-notification Successfully <Message>

#Loan Details
#When Provide Required details to loan details step <Agency>, <TypeOfLoan>
#When Select the All Load Id
#When Select the Loan Id <LoanId>
#When Click on Save & Next button
#Then Validate success-notification Successfully <Message>

#Financial Details
When Provide Required details to Financial details <IncomeType>, <IncomeFrequency>
When Click on Add Income button
Given Wait until success notification invisible
When Provide Required details to Financial details <IncomeType>, <IncomeFrequency>
Then Validate that the Add income button working properly
When Click on Save & Next button
Then Validate success-notification Successfully <Message>

#Employment details
When Provide Required details to Employee details <EmploymentType>
Then Validate that Still Working check invisible by providing End date 
#Then Validate that End Date field getting disabled by checked Still working 

When Provide Required details to Contact details
When Provide Required details to Address details
When Click on Save & Next button
Then Validate that the Confirm pop-up displaying properly for less than 2 yr experience the Application
Then Validate success-notification Successfully <Message>


#Education details
When Provide Required details to the Education details step <EducationDegree>
When Click on Save(Green) button
Then Validate success-notification Successfully <Message>

Given Navigate to Co-Borrower section of application <CoApplicant>

Then Validate that the Borrower details page show Co-Borrower Details properly
When Expand Card of Borrower details Contact Details
Then Validate that the Borrower details page show Contact details properly
When Close Card of Borrower details Contact Details
When Expand Card of Borrower details Address
When Click on show more
Then Validate that the Borrower details page show Mailing Address properly
Then Validate that the Borrower details page show Physical Address properly
Then Validate that the Borrower details page show Other details properly
When Close Card of Borrower details Address
When Expand Card of Borrower details Reference Details
Then Validate that the Borrower details page show Reference details properly
When Close Card of Borrower details Reference Details
When Expand Card of Borrower details Employment Details
Then Validate that the Borrower details page show Employment details properly
When Close Card of Borrower details Employment Details
When Expand Card of Borrower details Education Details
Then Validate that the Co-Borrower details page show Education details properly


Examples:
| User_Email           | Email                | BestTimeToCall | Message      | Agency | TypeOfLoan | IncomeType | IncomeFrequency | EmploymentType       | EducationDegree  | Relationship |
| slaadmin@yopmail.com | AppEmail@yopmail.com | Any Time       | Successfully | AES    | Education  | Paycheck   | Weekly          | Part Time Employment | Associate Degree |  Spouse      |



