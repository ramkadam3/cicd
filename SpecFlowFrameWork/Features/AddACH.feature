@BeforeFeatureDontLaunch @AfterStep @Origination
Feature: AddACH

A short summary of the feature

Scenario Outline: To verify that the ACH can be added using Add ACH button successfully
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
And Navigate to the Escrow Details section
When Click on Add ACH button
Then Validate that Add ACH button navigates to the Add ACH details pop-up
When Provide input to the Add ACH Details pop-up <accountHolderType>, <accountType>, <paymentMode>
When Save the details
Then Validate success-notification Successfully <Message>
Then Validate that data of Added ACH displaying properly <accountType>, <accountHolderType>





Examples: 
| User_Email           | Message      | accountHolderType | accountType | paymentMode |
| slaadmin@yopmail.com | Successfully | Personal          | Saving      | Yes         |
| slaadmin@yopmail.com | Successfully | Personal          | Saving      | No          |
| slaadmin@yopmail.com | Successfully | Personal          | Checking    | Yes         |
| slaadmin@yopmail.com | Successfully | Personal          | Checking    | No          |
| slaadmin@yopmail.com | Successfully | Business          | Saving      | Yes         |
| slaadmin@yopmail.com | Successfully | Business          | Saving      | No          |
| slaadmin@yopmail.com | Successfully | Business          | Checking    | Yes         |
| slaadmin@yopmail.com | Successfully | Business          | Checking    | No          |





Scenario Outline: To verify that the ACH can be Edited using Edit button successfully
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
And Navigate to the Escrow Details section
When Click on Edit action button
Then Validate that Add ACH button navigates to the Edit ACH details pop-up
When  Edit details of ACH <accountHolderType>, <accountType>, <paymentMode>
When Save the details
Then Validate success-notification Successfully <Message>
Then Validate that data of Added ACH displaying properly <accountType>, <accountHolderType>
When Click on ACH Changes button
Then Validate that ACH Changes pop-up show changes properly <accountType>




Examples: 
| User_Email           | Message      | accountHolderType | accountType | paymentMode |
| slaadmin@yopmail.com | Successfully | Personal          | Saving      | Yes         |



Scenario Outline: To verify that the ACH can be deleted using delete button successfully
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
And Navigate to the Escrow Details section
When Click on Delete button
Then Click on Confirm popup
Then Validate success-notification Successfully <Message>


Examples: 
| User_Email           | Message      |
| slaadmin@yopmail.com | Successfully |
