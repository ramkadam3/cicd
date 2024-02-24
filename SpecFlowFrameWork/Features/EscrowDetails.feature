@BeforeFeatureDontLaunch @AfterStep @Origination
Feature: EscrowDetails

A short summary of the feature

Scenario Outline: To verify that the Schedule Escrow can be added using Add Schedule Escrow button
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Create an Application with Contact details
Given Navigate to Manage Application page
Given Click on ApplicationID
And Navigate to the Escrow Details section
Then Check that the "add" Schedule Escrow button is available, Click on button if available
When Provide details to Schedule Escrow pop-up <frequency>, <escrowAmount>
Then Validate that the No of Escrow payments field shows default value two and it is disabled
Then Click on the Set button
Then Validate success-notification Successfully <Message>
Then Validate that the Added Escrow details displaying properly <frequency>, <escrowAmount>




Examples: 
| User_Email           | Message      | frequency  | escrowAmount |
| slaadmin@yopmail.com | Successfully |Semi Monthly| 10000        |
| slaadmin@yopmail.com | Successfully | Weekly     | 10000        |
| slaadmin@yopmail.com | Successfully | Monthly    | 10000        |



Scenario Outline: To verify that the Schedule Escrow can be Edited using Edit Schedule Escrow button
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
And Navigate to the Escrow Details section
Then Check that the "edit" Schedule Escrow button is available, Click on button if available
When Edit details of Schedule Escrow pop-up <frequency>, <escrowAmount>
Then Validate that the No of Escrow payments field shows default value two and it is disabled
Then Validate that the Escrow Start date field is disabled by default
Then Click on the Set button
Then Validate success-notification Successfully <Message>
Then Validate that the Edited Escrow details displaying properly <frequency>, <escrowAmount>


Examples: 
| User_Email           | Message      | frequency   | escrowAmount |
| slaadmin@yopmail.com | Successfully | Weekly      | 50000        |
| slaadmin@yopmail.com | Successfully | Semi Monthly| 50000        |
| slaadmin@yopmail.com | Successfully | Monthly     | 50000        |


Scenario Outline: To verify that the Escrow details section shows proper details
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
And Navigate to the Escrow Details section
Then Validate that the Card of Escrow details displaying properly
Then Validate that the Card show proper data




Examples: 
| User_Email           |
| slaadmin@yopmail.com |

