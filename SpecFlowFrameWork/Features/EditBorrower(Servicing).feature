@BeforeFeatureDontLaunch @AfterStep @Origination
Feature: Edit Borrower feature


Scenario:To verify that the Edit Application flow working smoothly
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Borrower page Servicing
Given Click on ApplicationID
When Click on The Edit button 
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


Then Validate that the Borrower details page show Personal details -Servicing- properly
When Close Card of Borrower details Personal Details
Then Validate that the Borrower details page of servicing show Contact details properly
When Close Card of Borrower details Contact Details
When Expand Card of Borrower details Address
Then Validate that the Borrower details page of Servicing show Physical Address properly
Then Validate that the Borrower details page of Servicing show Other details properly
Then Validate that the Borrower details page of Servicing show Mailing Address properly
When Close Card of Borrower details Address
When Expand Card of Borrower details Reference Details
Then Validate that the Borrower details page of Servicing show Reference details properly


When Close Card of Borrower details Reference Details
When Expand Card of Borrower details Employment Details
Then Validate that the Borrower details page of Servicing show Employment details properly
When Close Card of Borrower details Employment Details
When Expand Card of Borrower details Education Detail
Then Validate that the Borrower details page of Servicing show Education details properly
When Close Card of Borrower details Education Detail

Examples:
| User_Email                   | Email                | BestTimeToCall | Message      | Agency | TypeOfLoan | IncomeType | IncomeFrequency | EmploymentType       | EducationDegree  | Relationship |
| yrefyservicinguser@gmail.com | AppEmail@yopmail.com | Any Time       | Successfully | AES    | Education  | Paycheck   | Weekly          | Part Time Employment | Associate Degree |  Spouse      |




Scenario Outline:To verify that the Reference Details Edited successfully

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Borrower page Servicing
Given Click on ApplicationID
When Click on The Edit button 
When Click on Add Application step "Reference Details"


Given Click on Delete button Until only one card remain
Given Click on Edit Reference button
When Edit details of Reference Details <Relationship>
When Edit details of Reference Contact details
When Edit details of Reference Address details

When Click on Save & Next button
Then Validate success-notification Successfully <Message>

Given Navigate to Back Page
When Expand Card of Borrower details Reference Details
Then Validate that the Borrower details page of Servicing show Reference details properly
When Close Card of Borrower details Reference Details




Examples:
| User_Email                   | Email                | BestTimeToCall | Message      | Agency | TypeOfLoan | IncomeType | IncomeFrequency | EmploymentType       | EducationDegree  | Relationship |
| yrefyservicinguser@gmail.com | AppEmail@yopmail.com | Any Time       | Successfully | AES    | Education  | Paycheck   | Weekly          | Part Time Employment | Associate Degree |  Spouse      |



Scenario Outline:To verify that the Financial Details Edited successfully
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Borrower page Servicing
Given Click on ApplicationID
When Click on The Edit button
When Click on Add Application step "Financial Details"
Given Click on Delete button Until only one card remain
When  Click on Edit button of added card of application
When Edit details of Financial details <IncomeType>, <IncomeFrequency>
When Click on Add Income button
Given Wait until success notification invisible
When Edit details of Financial details <IncomeType>, <IncomeFrequency>

Then Validate that the Add income button working properly
When Click on Save & Next button
Then Validate success-notification Successfully <Message>

Given Navigate to Back Page
When Expand Card of Borrower details Financial Details
Then Validate that the Borrower details page of Servicing show Finance details properly
When Close Card of Borrower details Financial Details


Examples:
| User_Email                   | Email                | BestTimeToCall | Message      | Agency | TypeOfLoan | IncomeType | IncomeFrequency | EmploymentType       | EducationDegree  | Relationship |
| yrefyservicinguser@gmail.com | AppEmail@yopmail.com | Any Time       | Successfully | AES    | Education  | Paycheck   | Weekly          | Part Time Employment | Associate Degree |  Spouse      |


Scenario Outline:To verify that the Employment Details Edited successfully
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Borrower page Servicing
Given Click on ApplicationID
When Click on The Edit button
When Click on Add Application step "Employment Details"

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

Given Navigate to Back Page
When Expand Card of Borrower details Employment Details
Then Validate that the Borrower details page of Servicing show Employment details properly
When Close Card of Borrower details Employment Details
Examples:
| User_Email                   | EmploymentType       | EducationDegree  | Relationship | Message      |
| yrefyservicinguser@gmail.com | Part Time Employment | Associate Degree | Spouse       | Successfully |
| yrefyservicinguser@gmail.com | Unemployed           | Associate Degree | Spouse       | Successfully |
| yrefyservicinguser@gmail.com | Retired              | Associate Degree | Spouse       | Successfully |


   
