@BeforeFeatureDontLaunch @AfterStep @M2I
Feature: NotificationMatrix




Scenario Outline:01- To verify that the self permission can be set for any entities (self finder) 
	
	Given Enter Email_PassWord for Login <MRIA_Email>
	When Navigate to manage profile page
	And click on report permission section <Iteration>
	And change the self-permission
	Then validate that the permission set properly
	Examples: 
	| Browser | MRIA_Email             | Iteration |
	| chrome  | TestMRIA1@yopmail.com  | 2          |
	| chrome  | TestRIA5@yopmail.com   | 1          |
	| chrome  | testIAR5@yopmail.com   | 1          |
	| chrome  | 17august23@yopmail.com | 1          |

Scenario Outline:02- To verify that User level Permission can be updated to all it's child entity 

  Given  Enter Email_PassWord for Login <MRIA_Email>
	When Navigate to manage profile page
	And click on report permission section <Iteration>
	And Expand Inner Table of "RIA"
	And Set User-level permission for "2"
	Then validate that the permission set properly

	Given Switch User-Account to <RIA_Email>
	When Navigate to manage profile page
	And click on report permission section <Iterration>
	Then Validate that permission displaying properly
	Given Switch User-Account to <IAR_Email>	
	When Navigate to manage profile page
	And click on report permission section <Iterration>
	Then Validate that permission displaying properly

	Examples: 
	| MRIA_Email            | Iteration | RIA_Email            | IAR_Email            |
	| TestMRIA1@yopmail.com | 2          | TestRIA3@yopmail.com | testIAR3@yopmail.com |


Scenario Outline:03-To verify that User-level permission can be updated by other entity if permission set by parent entity
	
	
	
	Given  Enter Email_PassWord for Login <MRIA_Email>
	When Navigate to manage profile page
	And click on report permission section <Iteration>
	And Expand Inner Table of "IAR"
	And Set User-level permission for "2"
	Then validate that the permission set properly
	
	
	Given Switch User-Account to <RIA_Email>
	When Navigate to manage profile page
	And click on report permission section <Iterration>
	And Expand Inner Table of "IAR"
	And Set User-level permission for "1"
	Then validate that the permission set properly
	Given Switch User-Account to <IAR_Email>
	When Navigate to manage profile page
	And click on report permission section <Iterration>
	Then Validate that permission displaying properly

	When change the self-permission
	Then validate that the permission set properly


	Examples: 
	| MRIA_Email            | Iteration | RIA_Email            | IAR_Email            |
	| TestMRIA1@yopmail.com | 2          | TestRIA2@yopmail.com | testIAR2@yopmail.com |

	Scenario Outline:04- To verify that the Global level permission can update the permission of all entities under inner table

	Given  Enter Email_PassWord for Login <MRIA_Email>
	When Navigate to manage profile page
	And click on report permission section <Iteration>
	And Set Global permission
	And Expand Inner Table of "RIA"
	Then validate all entity set to permission same as global level

	Given Switch User-Account to <RIA_Email>
	When Navigate to manage profile page
	And click on report permission section <Iteration>
	Then Validate that permission displaying properly

	Given Switch User-Account to <RIA3_Email>
	When Navigate to manage profile page
	And click on report permission section <Iteration>
	Then Validate that permission displaying properly

	Given Switch User-Account to <IAR_Email>
	When Navigate to manage profile page
	And click on report permission section <Iteration>
	Then Validate that permission displaying properly

	Examples: 
	| MRIA_Email            | Iteration  | RIA_Email            | RIA3_Email               | IAR_Email            |
	| TestMRIA1@yopmail.com | 2          | TestRIA2@yopmail.com |TestRIA3@yopmail.com      | testIAR2@yopmail.com |
