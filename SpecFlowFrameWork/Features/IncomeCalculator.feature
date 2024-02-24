@BeforeFeatureDontLaunch @AfterStep @Origination
Feature: IncomeCalculator

A short summary of the feature

Scenario Outline: To verify that the income calculator button can calculate income
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
And Expand Finance details section
When Click on Income Calculator section
And Click on income calculator button
Then Check that income is available on income calculator popup
When Click on the income checkbox
And Click on the calculate button
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible
Then Validate that the Average value calculated properly
Then Validate that the Total value calculated properly


Examples: 
| User_Email           | Message      |
| slaadmin@yopmail.com | Successfully |


Scenario Outline: To verify that Income calculation can be added using income calculation button 
Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
And Expand Finance details section
When Click on Income Calculator section
And Click on income calculator button
Then Check that income is available on income calculator popup
When Click on the income checkbox
And Click on the calculate and save button
Then Validate success-notification Successfully <Message>
Then Validate that the Average value calculated properly
Then Validate that the Total value calculated properly
When Close The Popup

Examples: 
| User_Email           |Message      |
| slaadmin@yopmail.com |Successfully |
