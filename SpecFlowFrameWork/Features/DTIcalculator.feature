@BeforeFeatureDontLaunch @AfterStep @Origination
Feature: DTI calculator



Scenario Outline: To verify that DTI can be calculated using DTI Calculator button properly

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
And Expand Finance details section
And Create Income for Application
And Create Debt for Application
When Click on DTI Calculator section
And Click on DTI Calculator button
Then Check that income is available on DTI Calculator popup
When Select the income checkbox
Then Check that Debt is available on DTI Calculator popup
When Select debt in debt section
And Click on the calculate button
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible
Then Validate that the Debt to Income Ratio calculated properly



Examples: 
| User_Email           | Message      |
| slaadmin@yopmail.com | Successfully |
#|slamember@yopmail.com | Successfully |

Scenario Outline: To verify that DTI can be calculated using DTI Calculator button through 'Income calculation id' properly

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
And Expand Finance details section

When Click on DTI Calculator section
And Click on DTI Calculator button
Then Check that income is available on DTI Calculator popup
When Select Income Calculation id 
When Select the income checkbox
Then Check that Debt is available on DTI Calculator popup
When Select debt in debt section
And Click on the calculate button
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible
Then Validate that the Debt to Income Ratio calculated properly



Examples: 
| User_Email           | Message      |
| slaadmin@yopmail.com | Successfully |
#|slamember@yopmail.com | Successfully |

Scenario Outline: To verify that DTI can be saved using DTI Calculator button properly

Given Enter Email_PassWord for Login <User_Email>
Given Navigate to Manage Application page
Given Click on ApplicationID
And Expand Finance details section
When Click on DTI Calculator section
And Click on DTI Calculator button
Then Check that income is available on DTI Calculator popup
When Select the income checkbox
Then Check that Debt is available on DTI Calculator popup
When Select debt in debt section
And Click on the calculate and save button
Then Validate success-notification Successfully <Message>
Given Wait until success notification invisible
Then Validate that the Debt to Income Ratio calculated properly
When Close The Popup

Examples: 
| User_Email           | Message      |
| slaadmin@yopmail.com | Successfully |
#|slamember@yopmail.com | Successfully |

