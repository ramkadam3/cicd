@BeforeFeatureDontLaunch @AfterStep @Origination
Feature: AddWelcomeLetter




Scenario: To verify that Add Welcome Letter pop-up can send welcome letter successfully 

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
And  Click on ApplicationID 
When Click on Welcome Letters section of Borrower
And Click on Add Welcome letter button
And Select Borrower Type <BorrowerType>
Then Validate that the BorrowerName displaying properly <BorrowerName>
When Enter Email value <Email>
#Then Validate that the email populated properly
When Enter Loan amount <LoanAmount>
And Enter Loan term <LoanTerm>
#And Enter Current Loan term "6"
And Enter APR <APR>
Then Validate that the Payment amount displaying properly <LoanTerm>, <LoanAmount>
When Click on Send button
Then Validate success-notification displaying
Then Validate that the Email Received on the email <Message>, <Email>
When Delete the Email


Examples: 
| User_Email           | BorrowerType | Email                 | LoanAmount | LoanTerm | Message        | APR |
| slaadmin@yopmail.com | Applicant    | AutoEmail@yopmail.com | 2000       | 3        | Welcome Letter | 6   |


Scenario: To verify that Add Welcome Letter pop-up can send welcome letter  for Co-Applicant successfully

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
And  Click on ApplicationID
Then Check that the Borrower has a CoBorrower then Click on it Borrower details
When Click on Welcome Letters section
When Click on Add Welcome letter button
When Select Borrower Type <BorrowerType>
When Select Co-Borrower name
When Enter Email value <Email>
When Enter Loan amount <LoanAmount>
When Enter Loan term <LoanTerm>
And Enter APR <APR>
Then Validate that the Payment amount displaying properly <LoanTerm>, <LoanAmount>
When Click on Send button
Then Validate success-notification displaying
Then Validate that the Email Received on the email <Message>, <Email>
When Delete the Email


Examples: 
| User_Email           | BorrowerType | APR | Email                 | LoanAmount | LoanTerm | Message        |
| slaadmin@yopmail.com | Co-Applicant |   5 | AutoEmail@yopmail.com | 2000       | 3        | Welcome Letter |
	
	
Scenario: To verify that the data reflect in Welcome letter list properly 

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
And  Click on ApplicationID 
When Click on Welcome Letters section of Borrower
When Click on Add Welcome letter button
When Select Borrower Type <BorrowerType>
Then Validate that the BorrowerName displaying properly <BorrowerName>
When Enter Email value <Email>
When Enter Loan amount <LoanAmount>
When Enter Loan term <LoanTerm>
And Enter APR <APR>
Then Validate that the Payment amount displaying properly <LoanTerm>, <LoanAmount>
When Click on Send button
Then Validate success-notification displaying
Then Validate that the Borrower name displaying properly
And validate that the Email displaying properly <Email>
And Validate that the BorrowerType Displaying properly <BorrowerType>
And Validate that the loan amount displaying properly <LoanAmount>
And Validate that the PaymentAmount Displaying properly <LoanAmount>, <LoanTerm>
And validate that the Resend action button is enable      
#now the enableness of Resend button validated 


Examples: 
| User_Email           | BorrowerType | APR | Email                 | LoanAmount | LoanTerm | Message        |
| slaadmin@yopmail.com | Applicant    |    5| AutoEmail@yopmail.com | 2000       | 3        | Welcome Letter |
