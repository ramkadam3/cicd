@BeforeFeatureDontLaunch @AfterStep @M2I
Feature: Edit-Investment

A short summary of the feature


Scenario Outline: Validate that the Investment having Requested status can be edited at investor side

	Given Enter Email_PassWord for Login <User_Email>
	Given Navigate to offering page of investor profile
	When Search for Offer in offering list <OfferName>
	And Click on Offer 
	When Click on Add investment field
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
	And Click on Save button
	Then Validate that Save investment details popup comes up
	And Click on confirm button
	Then Validate success-notification displaying
	Then Validate that the investor eSign section displays details properly
	And Investment Created Successfully

	#Edit Investment action
	Given Navigate to Manage investment page
	When Search for Investor name <InvestorName>,"Requested"
	Given Click on Investment name in investment list
	And Click on Investment details section
	And Click on Edit-Investment button
	Then Validate that Edit button navigate to the investment detail step of investment
	Given Edit Investment amount more than minimum amount <EditInvestment_Amount>, "1"
	When Edit Value in Monthly income field <EditMonthlyIncome>, "1"
	Then Validate Edited Estimated monthly income field show correct value <EditedEstimatedIncome>
	Given Edit Investment amount more than minimum amount <Investment_Amount>, "2"
	When Edit Value in Monthly income field <MonthlyIncome>, "2"
	When Click on Save button
	Then Click on confirm button

	#Continue Investment process
	Given Click on eSign button
	Then Validate that the redirecting alert displaying
  And Complete eSign process
	And Validate that the eSign completion displaying successfully
	When Click on Next button
	Then Validate that it navigates to the Investment Accreditation section
	And Validate that status of investment updated properly at top of the page "Investor Signed"		
	Then Validate that it navigates to the Investment Accreditation section	
	Then Check that it shows details properly
	And Check that the download and view document action item working properly
	When Click on Next button
	Then Validate that it navigates to the Company eSign field

	#Company Side Action
	Given Switch User-Account to <Company_Email>
	And Navigate to investments page
	When Search for Investor name <InvestorName>,"Investor Signed"	
	Given Click on Investment name in investment list	
	When Click on Company eSign step
	And Click on Click to eSign button
	Then Complete Company eSign process
	And validate that Company eSign completion reflected properly
	When Click on Next-button investment page 
	When Click on Confirm button of make payment
	Then validate that it navigate to the Make payment step
	Then validate that the Make Payment show correct Edited Amount <Investment_Amount>, <EditInvestment_Amount>

	#Investor profile
	Given Switch User-Account to <User_Email>
	And Navigate to Manage investment page
	When Search for Investor name <InvestorName>,"Approved"
	Given Click on Investment name in investment list
	When Click on Make Payment step	
	When Click on Next-button investment page 
	Given Select payment channel from popup "Wire Transfer"
	Then validate that it navigate to finalize payment step

	#Company profile
	Given Switch User-Account to <Company_Email>
	Given Navigate to investments page
	When Search for Investor name <InvestorName>,"Amount Transferred"
	Given Click on Investment name in investment list	
    Given Click on Finalize Investments step
	When Enter Payment Receipt Date and Save	
	When Select Finder for commission
	When SetCommision for Finder for multiple Tranche "2"
	When Select Sales Rep for Commission
	When SetCommission for Sales Rep for multiple Tranche "2"
	Then Click on Finalize button
	And Validate that success-notification displaying properly

	And Finalize the investment by clicking on confirm button
	And Validate that success-notification displaying properly
	And Validate that status of investment updated properly at top of the page "Invested"	
	#Validate Edited details
	Given Navigate to investments page
	When Clear the investment Filter
	When Search for Investor name <InvestorName>,"Invested"
	And Click on View investment 
	And Validate the Invested amount reflected properly "2",<EditInvestment_Amount>,<Investment_Amount>
	And Validate that the Monthly income % displaying properly "2",<EditMonthlyIncome>,<MonthlyIncome>

	

	Examples: 
	| User_Email             | Company_Email                | OfferName           | InvestorName | MinimumAmount | Investment_Amount | EditInvestment_Amount | MonthlyIncome | EditMonthlyIncome | MonthlyCompound | EstimatedIncome | EditedEstimatedIncome |
	| 17august23@yopmail.com | atestmanager3105@yopmail.com | Adobe Test Offering | 17august     | 50            | 1000              | 1200                  | 30            | 50                | 70              | 0.74            | 1.97                  |

	Scenario Outline: Validate that the investment have no Requested-status  can not be edited on Investor side 
	Given Enter Email_PassWord for Login <User_Email>
	Given Navigate to Manage investment page
	When Search for Investor name <InvestorName>,"Investor Signed"
	Given Click on Investment name in investment list
	And Click on Investment details section
	Then Validate that the Edit button is not available for the investment


	Examples: 
	| User_Email             | Company_Email                | OfferName           | InvestorName | MinimumAmount | Investment_Amount | EditInvestment_Amount | MonthlyIncome | EditMonthlyIncome | MonthlyCompound | EstimatedIncome | EditedEstimatedIncome |
	| 17august23@yopmail.com | atestmanager3105@yopmail.com | Adobe Test Offering | 17august     | 50            | 1000              | 1200                  | 30            | 50                | 70              | 0.74            | 1.97                  |

	Scenario Outline: Validate that the investment can be Edited at Company side which was not finalized
	Given Enter Email_PassWord for Login <Company_Email>
	Given Navigate to investments page
	When Search for Investor name <InvestorName>,<InvestmentStatus>
	Given Click on Investment name in investment list
	And Click on Investment details section
	When Get Investment details "1"
	Given Click on Edit-Investment button
	Then Validate that simulator displaying proper data "1"
	When Edit Simulator data "1"
	When Click on Save button
	Then Click on confirm button
	Then Validate that status of investment updated properly at top of the page "Requested"




	Examples: 
	| User_Email             | Company_Email                | InvestmentStatus | OfferName           | InvestorName | MinimumAmount | Investment_Amount | EditInvestment_Amount | MonthlyIncome | EditMonthlyIncome | MonthlyCompound | EstimatedIncome | EditedEstimatedIncome |
	| 17august23@yopmail.com | atestmanager3105@yopmail.com |  Investor Signed | Adobe Test Offering | 17august     | 50            | 1000              | 1200                  | 30            | 50                | 70              | 0.74            | 1.97                  |
	| 17august23@yopmail.com | acuser@yopmail.com           |      eSigned     | Adobe Test Offering | 17august     | 50            | 1000              | 1200                  | 30            | 50                | 70              | 0.74            | 1.97                  |
	| 17august23@yopmail.com | acmanager@yopmail.com        |Amount Transferred| Adobe Test Offering | 17august     | 50            | 1000              | 1200                  | 30            | 50                | 70              | 0.74            | 1.97                  |
	| 17august23@yopmail.com | adobemanager@yopmail.com     |     Requested    | Adobe Test Offering | 17august     | 50            | 1000              | 1200                  | 30            | 50                | 70              | 0.74            | 1.97                  |
	
	
Scenario Outline: Validate that the Requested investment can be Edited at Company side by Sales-Rep
	Given Enter Email_PassWord for Login <Company_Email>
	Given Navigate to offering page of investor profile
	When Search for Offer in offering list <OfferName>
	And Click on Offer 
	When Click on Invest for an Investor field
	When Select Investor To invest on behalf of the investor <InvestorName>
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
	And Click on Save button
	Then Validate that Save investment details popup comes up
	And Click on confirm button
	Then Validate success-notification displaying
	
	And Investment Created Successfully
	
	
	
	Given Switch User-Account to <Company_Email>
	Given Navigate to investments page
	When Search for Investor name <InvestorName>,"Requested"
	Given Click on Investment name in investment list
	And Click on Investment details section
	When Get Investment details "1"
	Given Click on Edit-Investment button
	Then Validate that simulator displaying proper data "1"
	When Edit Simulator data "1"
	When Click on Save button
	Then Click on confirm button
	Then Validate that status of investment updated properly at top of the page "Requested"




	Examples: 
	| User_Email               | InvestorName | Company_Email            | Status    | OfferName           | MinimumAmount | Investment_Amount | EditInvestment_Amount | MonthlyIncome | EditMonthlyIncome | MonthlyCompound | EstimatedIncome | EditedEstimatedIncome |
	| AutoInvestor@yopmail.com |AutoInvestor | testsalesrep@yopmail.com | Requested | Adobe Test Offering | 50            | 1000              | 1200                  | 30            | 50                | 70              | 0.74            | 1.97                  |
	
	



Scenario Outline: Validate that the investment can not be Edited at Company side by Sales-Rep when status is non requested
	Given Enter Email_PassWord for Login <Company_Email>
	Given Navigate to offering page of investor profile
	When Search for Offer in offering list <OfferName>
	And Click on Offer 
	When Click on Invest for an Investor field
	When Select Investor To invest on behalf of the investor <InvestorName>
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
	And Click on Save button
	Then Validate that Save investment details popup comes up
	And Click on confirm button
	Then Validate success-notification displaying
	
	Given Switch User-Account to <User_Email>
	Given Navigate to Manage investment page
	When Search for Investor name <InvestorName>,"Requested"
	Given Click on Investment name in investment list
	When Click on Investor eSign step 
	Then Validate that Investor eSign section reflecting record properly 
	Given Click on eSign button
	Then Validate that the redirecting alert displaying
    And Complete eSign process
	And Validate that the eSign completion displaying successfully
	When Click on Next button
	Then Validate that it navigates to the Investment Accreditation section
	And Investment Created Successfully
	
	
	
	Given Switch User-Account to <Company_Email>
	Given Navigate to investments page
	When Search for Investor name <InvestorName>,"Investor Signed"
	Given Click on Investment name in investment list
	And Click on Investment details section
	Then Validate that the Edit button is not available for the investment
	
	
	Examples: 
	| User_Email               | InvestorName | Company_Email            | Status    | OfferName           | MinimumAmount | Investment_Amount | EditInvestment_Amount | MonthlyIncome | EditMonthlyIncome | MonthlyCompound | EstimatedIncome | EditedEstimatedIncome |
	| AutoInvestor@yopmail.com | AutoInvestor | testsalesrep@yopmail.com | Requested | Adobe Test Offering | 50            | 1000              | 1200                  | 30            | 50                | 70              | 0.74            | 1.97                  |
	
	



 Scenario Outline: Validate that the Requested investment can be Edited at Finder profile
	
	Given Enter Email_PassWord for Login <Company_Email>
	Given Navigate to offering page of investor profile
	When Search for Offer in offering list <OfferName>
	And Click on Offer 
	When Click on Invest for an Investor field
	When Select Investor To invest on behalf of the investor <InvestorName>
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
	And Click on Save button
	Then Validate that Save investment details popup comes up
	And Click on confirm button
	Then Validate success-notification displaying
	


	And Investment Created Successfully
	
	
	
	Given Switch User-Account to <Company_Email>
	Given Navigate to investments page
	When Search for Investor name <InvestorName>,"Requested"
	Given Click on Investment name in investment list
	And Click on Investment details section
	When Get Investment details "1"
	Given Click on Edit-Investment button
	Then Validate that simulator displaying proper data "1"
	When Edit Simulator data "1"
	When Click on Save button
	Then Click on confirm button
	Then Validate that status of investment updated properly at top of the page "Requested"




	Examples: 
	| User_Email               | Company_Email                | Status    | OfferName           | InvestorName | MinimumAmount | Investment_Amount | EditInvestment_Amount | MonthlyIncome | EditMonthlyIncome | MonthlyCompound | EstimatedIncome | EditedEstimatedIncome |
	| AutoInvestor@yopmail.com | TestRIA2@yopmail.com         | Requested | Adobe Test Offering | AutoInvestor | 50            | 1000              | 1200                  | 30            | 50                | 70              | 0.74            | 1.97                  |
	               
Scenario Outline: Validate that the investment can not be Edited at Finder profile where the status is non Requested
	
	Given Enter Email_PassWord for Login <Company_Email>
	Given Navigate to offering page of investor profile
	When Search for Offer in offering list <OfferName>
	And Click on Offer 
	When Click on Invest for an Investor field
	When Select Investor To invest on behalf of the investor <InvestorName>
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
	And Click on Save button
	Then Validate that Save investment details popup comes up
	And Click on confirm button
	Then Validate success-notification displaying
	
	Given Switch User-Account to <User_Email>
	Given Navigate to Manage investment page
	When Search for Investor name <InvestorName>,"Requested"
	Given Click on Investment name in investment list
	When Click on Investor eSign step 
	Then Validate that Investor eSign section reflecting record properly 
	Given Click on eSign button
	Then Validate that the redirecting alert displaying
  And Complete eSign process
	And Validate that the eSign completion displaying successfully
	When Click on Next button
	Then Validate that it navigates to the Investment Accreditation section
	And Investment Created Successfully
	
	
	
	Given Switch User-Account to <Company_Email>
	Given Navigate to investments page
	When Search for Investor name <InvestorName>,<Status>
	Given Click on Investment name in investment list
	And Click on Investment details section
	Then Validate that the Edit button is not available for the investment

	



	Examples: 
	| User_Email               | Company_Email                | Status          | OfferName           | InvestorName | MinimumAmount | Investment_Amount | EditInvestment_Amount | MonthlyIncome | EditMonthlyIncome | MonthlyCompound | EstimatedIncome | EditedEstimatedIncome |
	| AutoInvestor@yopmail.com | TestRIA2@yopmail.com         | Investor Signed | Adobe Test Offering | AutoInvestor | 50            | 1000              | 1200                  | 30            | 50                | 70              | 0.74            | 1.97                  |
