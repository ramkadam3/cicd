@BeforeFeatureDontLaunch @AfterStep @M2I
Feature: Add_Investment

A short summary of the feature


Scenario Outline:To verify that the investor can do Additional Investment successfully

	#InvestorSide Action	
 Given Login to Profile <Investor_Email>	
  Given Navigate With InvestorName And OfferingName to the Add invest field <InvestorName>, <OfferName>	
	When Click on Add investment field <InvestorName>
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
  Then Get InvestmentDetails from investment details section of investment 1
	And Click on Save button
	Then Click on confirm button


	Given Click on eSign button
	Then Validate that the redirecting alert displaying
	Then Complete eSign process <InvestorType>
	And Validate that the eSign completion displaying successfully
	#When Click on Next button
	Then Validate that it navigates to the Investment Accreditation section
#	And Validate that status of investment updated properly at top of the page "Investor Signed"
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
	| Company_Email  | Investor_Email   | OfferName           | Investment_Amount | MonthlyIncome | InvestorType | InvestorName               |
	
	| CompanyManager | ScorpAdmin       | Adobe Test Offering | 1000              | 30            | S-Corp       | S-Corp For Automation      |
	| CompanyManager | CcorpAdmin       | Adobe Test Offering | 2000              | 20            | C-Corp       | C-Corp For Automation      |
	| CompanyManager | TrustAdmin       | Adobe Test Offering | 3000              | 10            | Trust        | Trust For Automation       |
	| CompanyManager | LLCAdmin         | Adobe Test Offering | 4000              | 40            | LLC          | LLC For Automation         |
	| CompanyManager | PartnershipAdmin | Adobe Test Offering | 5000              | 30            | Partnership  | Partnership For Automation |
   

Scenario Outline: To verify that the first Investment can be done with ACCREDITED investor successfully

  Given Login to Profile <Company_Email>
  Given Navigate to Investor Page
  When Search name of Investor on Investor page with investor status and Type Accredited, <InvestorType>
  When Get the Login email and Investor Name of the Investor from investor users page
  Given Logout the profile account

  When Provide Email and Password then login
	Given Navigate to the Add invest field <OfferName>	
	When Click on Add investment field <InvestorType>
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
  Then Get InvestmentDetails from investment details section of investment 1

	And Click on Save button
	Then Click on confirm button
  When Fill the Additional information form <InvestorType>
  Then If the additional info has been saved then confirm and proceed it
  Given Wait until success notification invisible
	Given Click on eSign button
	Then Validate that the redirecting alert displaying
  Then Complete eSign process <InvestorType>
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
	 | Company_Email  | OfferName           | Investment_Amount | MonthlyIncome | InvestorType |
	 | CompanyManager | Adobe Test Offering | 1000              | 30            | S-Corp       |
	 | CompanyManager | Adobe Test Offering | 1000              | 20            | C-Corp       |
	 | CompanyManager | Adobe Test Offering | 1000              | 10            | Trust        |
	 | CompanyManager | Adobe Test Offering | 1000              | 40            | LLC          |
	 | CompanyManager | Adobe Test Offering | 1000              | 30            | Partnership  |
   

  Scenario Outline: 01_ To verify that the investment can be added with accreditation successfully


  Given Login to Profile <Company_Email>
  Given Navigate to Investor Page
  When Search name of Investor on Investor page with investor status and Type Initiated, <InvestorType>
  When Get the Login email and Investor Name of the Investor from investor users page
  Given Logout the profile account

  When Provide Email and Password then login
	Given Navigate to the Add invest field <OfferName>	
	When Click on Add investment field <InvestorType>
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
  Then Get InvestmentDetails from investment details section of investment 1

	And Click on Save button
	Then Click on confirm button
  When Fill the Additional information form <InvestorType>
  Then If the additional info has been saved then confirm and proceed it
  Given Wait until success notification invisible
	Given Click on eSign button
	Then Validate that the redirecting alert displaying
  Then Complete eSign process <InvestorType>
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
	 | Company_Email  | OfferName           | Investment_Amount | MonthlyIncome  | FileName      | InvestorType |
	 | CompanyManager | Adobe Test Offering | 1000              | 30             | uploadDoc.png | S-Corp       |
   | CompanyManager | Adobe Test Offering | 1000              | 40             | uploadDoc.png | C-Corp       |
   | CompanyManager | Adobe Test Offering | 1000              | 60             | uploadDoc.png | Trust        |
   | CompanyManager | Adobe Test Offering | 1000              | 20             | uploadDoc.png | LLC          |
   | CompanyManager | Adobe Test Offering | 1000              | 30             | uploadDoc.png | Partnership  |


   Scenario Outline:To verify that the Re-investment can be done with Update investment button 
	
	#InvestorSide Action
	Given Enter Email_PassWord for Login <User_Email>
	And Navigate to Manage investment page
	When Search for Investor name null,<InvestmentStatus>
  Given Click on Investment name in investment list
  When Click on Update Investment button on investment details page
  Given Expand the Reinvestment field <TrancheNumber>
  And Clear the Reinvested Value <TrancheNumber>
  When Enter the ReInvestent value to the ReInvestment field for Tranche <TrancheNumber>, <ReInvestedTrancheNumber>, <ReInvestedValue>
  When Click on Save(Green) button
 #Then Validate success-notification Successfully Successfully
  #Then Validate that the Tranche details section displaying properly <Investment_Amount>, 1

  Then Validate that Reinvestment Section displaying details properly <TrancheNumber>, true, <ReInvestedTrancheNumber>, <ReInvestedValue>
  Then Validate Re-Investment value and Withdraw value are displaying properly on simulator of respective Tranche <TrancheNumber>, <ReInvestedTrancheNumber>, <ReInvestedValue>









  Examples: 
	| User_Email                   | Company_Email  | OfferName           | InvestorName        | MinimumAmount | Investment_Amount | MonthlyIncome | MonthlyCompound | InvestmentStatus | TrancheNumber | ReInvestedTrancheNumber | ReInvestedValue |
	| Eunice_Aufderhar@yopmail.com | CompanyManager | Adobe Test Offering | Only For Automation | 50            | 1000              | 30            | 70              | Invested         | 1             | 3                       | 40              |
