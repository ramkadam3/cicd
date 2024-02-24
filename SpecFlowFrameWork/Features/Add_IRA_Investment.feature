@BeforeFeatureDontLaunch @AfterStep @M2I
Feature: Add_IRA_Investment


Scenario Outline:To verify that the IRA investor can do Additional Investment successfully

Given Login to Profile <Company_Email>
When Navigate to the investment page
When Search investment with Name, Offering, Status on Investment page FBO, <OfferName>, Invested
 * Get investment name from investment page
Given Navigate to Investor Page
When Search for Investor name null,null
When Get the Login email of the Investor from investor users page
Given Logout the profile account



	#InvestorSide Action
	
  When Provide Email and Password then login
	Given Navigate to offering page of investor profile
	When Search for Offer in offering list <OfferName>
	And Click on Offer 
	When Click on Add investment field IRA
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
  Then Get InvestmentDetails from investment details section of investment 1
	And Click on Save button
	Then Click on confirm button	
	Given Click on eSign button
	Then Validate that the redirecting alert displaying
	Then Complete eSign process IRA
	And Validate that the eSign completion displaying successfully
	#When Click on Next button
	Then Validate that it navigates to the Investment Accreditation section
	And Validate that status of investment updated properly at top of the page "Investor Signed"
	Then Check that it shows details properly
	And Check that the download and view document action item working properly
	When Click on Next button
	Then Validate that it navigates to the Company eSign field
   Given Logout the profile account

	#Company Side Action
	Given Login to Profile <Company_Email>
	And Navigate to investments page
	When Search for Investor name null,Investor Signed
	Given Click on Investment name in investment list
  When Click on Next button
	When Click on Company eSign step
	And Click on Click to eSign button
	Then Complete Company eSign process
	And validate that Company eSign completion reflected properly
	When Click on Next button 
	When Click on Confirm button of make payment
	Then validate that it navigate to the Make payment step
    Given Logout the profile account

	#Investor profile
	When Provide Email and Password then login
	Given Navigate to Manage investment page
	When Search for Investor name null,"Approved"
	Given Click on Investment name in investment list
	When Click on Make Payment step	
	When Click on Next-button investment page 
	Given Select payment channel from popup "Check"
	Then validate that it navigate to finalize payment step
  Given Logout the profile account

	#Company profile
Given Login to Profile <Company_Email>
	Given Navigate to investments page
	When Search for Investor name null,"Amount Transferred"
	Given Click on Investment name in investment list	
  Given Click on Finalize Investments step
	When Enter Payment Receipt Date and Save	
	When Select Finder for commission
	When SetCommision for Finder
	When Select Sales Rep for Commission
	When SetCommission for Sales Rep
	Then Click on Finalize button
	And Validate that success-notification displaying properly
	And Finalize the investment by clicking on confirm button
	And Validate that success-notification displaying properly
	And Validate that status of investment updated properly at top of the page "Invested"	


  Then Validate that the Investment Details section displaying properly 1
  Then Validate that the Tranche details section displaying properly <Investment_Amount>, 1
  Then Validate that Reinvestment Section displaying details properly 1, false, 1, 60
  Then Validate that the Monthly Income Breakdown displaying properly
  Then Validate that the Return Simulator displaying data properly 1, <Investment_Amount>

	Examples: 
	| Company_Email | OfferName          | MinimumAmount | Investment_Amount | MonthlyIncome | MonthlyCompound | 
	| CompanyManager|Adobe Test Offering |  50           | 1000              | 30            | 70              |


  Scenario Outline: To verify that the first Investment can be done with ACCREDITED IRA investor successfully

  Given Login to Profile <Company_Email>
  Given Navigate to Investor Page
   When Search name of Investor on Investor page with investor status and Type Accredited, IRA
  When Get the Login email of the Investor from investor users page
  Given Logout the profile account

  When Provide Email and Password then login
	Given Navigate to the Add invest field <OfferName>	
	When Click on Add investment field IRA
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
  Then Get InvestmentDetails from investment details section of investment 1

	And Click on Save button
	Then Click on confirm button
  When Fill the Additional information form IRA
  Then If the additional info has been saved then confirm and proceed it
  Given Wait until success notification invisible
	Given Click on eSign button
	Then Validate that the redirecting alert displaying
  Then Complete eSign process Individual
	And Validate that the eSign completion displaying successfully
	#When Click on Next button
	Then Validate that it navigates to the Investment Accreditation section
	And Validate that status of investment updated properly at top of the page "Investor Signed"
	Then Check that it shows details properly
	And Check that the download and view document action item working properly
	When Click on Next button
	Then Validate that it navigates to the Company eSign field
   Given Logout the profile account

	#Company Side Action
	  Given Login to Profile <Company_Email>
	And Navigate to investments page
	When Search for Investor name null,Investor Signed
	Given Click on Investment name in investment list
  When Click on Next button
	When Click on Company eSign step
	And Click on Click to eSign button
	Then Complete Company eSign process
	And validate that Company eSign completion reflected properly
	When Click on Next button 
	When Click on Confirm button of make payment
	Then validate that it navigate to the Make payment step
  Given Logout the profile account

	#Investor profile
	When Provide Email and Password then login
	Given Navigate to Manage investment page
	When Search for Investor name null,Approved
	Given Click on Investment name in investment list
	When Click on Make Payment step	
	When Click on Next-button investment page 
	Given Select payment channel from popup "Wire Transfer"
	Then validate that it navigate to finalize payment step
  Given Logout the profile account

	#Company profile
	Given Login to Profile <Company_Email>
	Given Navigate to investments page
	When Search for Investor name null,"Amount Transferred"
	Given Click on Investment name in investment list	
  Given Click on Finalize Investments step
	When Enter Payment Receipt Date and Save	
	When Select Finder for commission
	When SetCommision for Finder
	When Select Sales Rep for Commission
	When SetCommission for Sales Rep
	Then Click on Finalize button
	And Validate that success-notification displaying properly
	And Finalize the investment by clicking on confirm button
	And Validate that success-notification displaying properly
	And Validate that status of investment updated properly at top of the page "Invested"	


  Then Validate that the Investment Details section displaying properly 1
  Then Validate that the Tranche details section displaying properly <Investment_Amount>, 1
  Then Validate that Reinvestment Section displaying details properly 1, false, 1, 60
  Then Validate that the Monthly Income Breakdown displaying properly
  Then Validate that the Return Simulator displaying data properly 1, <Investment_Amount>

	Examples: 
	 | Company_Email  | OfferName          |   MinimumAmount | Investment_Amount | MonthlyIncome | MonthlyCompound | EstimatedIncome | 
	 | CompanyManager |Adobe Test Offering |   50            | 1000              | 30            | 70              | 0.74            |


  Scenario Outline: To verify that the investment can be added with accreditation successfully


  Given Login to Profile <Company_Email>
  Given Navigate to Investor Page
  When Search name of Investor on Investor page with investor status and Type Initiated, IRA
  When Get the Login email of the Investor from investor users page
  Given Logout the profile account

  When Provide Email and Password then login
	Given Navigate to the Add invest field <OfferName>	
	When Click on Add investment field IRA
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
  Then Get InvestmentDetails from investment details section of investment 1

	And Click on Save button
	Then Click on confirm button
  When Fill the Additional information form IRA
  Then If the additional info has been saved then confirm and proceed it
  Given Wait until success notification invisible
	Given Click on eSign button
	Then Validate that the redirecting alert displaying
  Then Complete eSign process Individual
	And Validate that the eSign completion displaying successfully
	#When Click on Next button
	Then Validate that it navigates to the Investment Accreditation section
	And Validate that status of investment updated properly at top of the page "Investor Signed"


  When Upload Accreditation letter on Accreditation step
  When Upload document using HandleOpenDialog <FileName>	
	When Click on Next button
	Then Validate that it navigates to the Company eSign field
   Given Logout the profile account

	#Company Side Action
 Given Login to Profile <Company_Email>
	And Navigate to investments page
	When Search for Investor name null,Investor Signed
	Given Click on Investment name in investment list
  When Click on Investor accreditation step
  When Complete the Accreditation of investment at company side
  When Click on Save(Green) button
  When Click on Next button
  Given Wait until success notification invisible
  Then Validate that status of investment updated properly at top of the page "Accredited"

	When Click on Company eSign step
	And Click on Click to eSign button
	Then Complete Company eSign process
	And validate that Company eSign completion reflected properly
	When Click on Next button 
	When Click on Confirm button of make payment
	Then validate that it navigate to the Make payment step
  Given Logout the profile account

	#Investor profile
	When Provide Email and Password then login
	Given Navigate to Manage investment page
	When Search for Investor name null,Approved
	Given Click on Investment name in investment list
	When Click on Make Payment step	
	When Click on Next-button investment page 
	Given Select payment channel from popup "ACH"         
	Then validate that it navigate to finalize payment step
   Given Logout the profile account

	#Company profile
	Given Login to Profile <Company_Email>
	Given Navigate to investments page
	When Search for Investor name null,"Amount Transferred"
	Given Click on Investment name in investment list	
  Given Click on Finalize Investments step
	When Enter Payment Receipt Date and Save	
	When Select Finder for commission
	When SetCommision for Finder
	When Select Sales Rep for Commission
	When SetCommission for Sales Rep
	Then Click on Finalize button
	And Validate that success-notification displaying properly
	And Finalize the investment by clicking on confirm button
	And Validate that success-notification displaying properly
	And Validate that status of investment updated properly at top of the page "Invested"	


  Then Validate that the Investment Details section displaying properly 1
  Then Validate that the Tranche details section displaying properly <Investment_Amount>, 1
  Then Validate that Reinvestment Section displaying details properly 1, false, 1, 60
  Then Validate that the Monthly Income Breakdown displaying properly
  Then Validate that the Return Simulator displaying data properly 1, <Investment_Amount>

	Examples: 
	 | Company_Email  | OfferName           | MinimumAmount | Investment_Amount | MonthlyIncome | MonthlyCompound | EstimatedIncome | InvestmentStatus | FileName      |
	 | CompanyManager | Adobe Test Offering | 50            | 1000              | 30            | 70              | 0.74            | Investor Signed  | uploadDoc.png |
