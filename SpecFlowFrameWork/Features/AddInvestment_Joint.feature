@BeforeFeatureDontLaunch @AfterStep @M2I
Feature: AddInvestment_Joint

A short summary of the feature

Scenario Outline:To verify that the joint investor can do Additional Investment successfully
	
	#InvestorSide Action
	Given Enter Email_PassWord for Login <User_Email>
	Given Navigate to offering page of investor profile
	When Search for Offer in offering list <OfferName>
	And Click on Offer 
	When Click on Add investment field <InvestorName>
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
  Then Get InvestmentDetails from investment details section of investment 1
	And Click on Save button
	Then Click on confirm button
  When Click on Investor eSign step
	Given Click on eSign button
	Then Validate that the redirecting alert displaying
	Then Complete eSign process joint1
	And Validate that the eSign completion displaying successfully
  And Validate that status of investment updated properly at top of the page "Investor1 Signed"

  Given Switch User-Account to <User_Email2>
  And Navigate to Manage investment page
  When Search for Investor name <InvestorName>,"Investor1 Signed"
	Given Click on Investment name in investment list
  When Click on Investor eSign step

  Given Click on eSign button
	Then Validate that the redirecting alert displaying
	Then Complete eSign process joint2
	And Validate that the eSign completion displaying successfully
   Given Logout the profile account
	
	#Company Side Action
	 Given Login to Profile <Company_Email>
	And Navigate to investments page
	When Search for Investor name <InvestorName>,<InvestmentStatus>
	Given Click on Investment name in investment list
  When Click on Next button
	When Click on Company eSign step
	And Click on Click to eSign button
	Then Complete Company eSign process
	And validate that Company eSign completion reflected properly
	When Click on Next button 
	When Click on Confirm button of make payment
	Then validate that it navigate to the Make payment step

	#Investor profile
	Given Switch User-Account to <User_Email>
	And Navigate to Manage investment page
	When Search for Investor name <InvestorName>,"Approved"
	Given Click on Investment name in investment list
	When Click on Make Payment step	
	When Click on Next-button investment page 
	Given Select payment channel from popup "Wire Transfer"
	Then validate that it navigate to finalize payment step
   Given Logout the profile account

	#Company profile
	 Given Login to Profile <Company_Email>
	Given Navigate to investments page
	When Search for Investor name <InvestorName>,"Amount Transferred"
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


  #validate all investment details on investment details page

  Then Validate that the Investment Details section displaying properly 1
  Then Validate that the Tranche details section displaying properly <Investment_Amount>, 1
  Then Validate that Reinvestment Section displaying details properly 1, false, 1, 60
  Then Validate that the Monthly Income Breakdown displaying properly
  Then Validate that the Return Simulator displaying data properly 1, <Investment_Amount>



	
	Examples: 
	| User_Email          | User_Email2                 | Company_Email  | OfferName           | InvestorName                                  | MinimumAmount | Investment_Amount | MonthlyIncome | MonthlyCompound | EstimatedIncome | InvestmentStatus |
	| Debra95@yopmail.com | Gustavo.Roberts@yopmail.com | CompanyManager | Adobe Test Offering | Joint1 For Automation & Joint2 For Automation | 50            | 1000              | 30            | 70              | 0.74            | Investor Signed  |

  Scenario Outline:To verify that the joint investor can do Additional investment with second investor
	
	#InvestorSide Action
	Given Enter Email_PassWord for Login <User_Email>
	Given Navigate to offering page of investor profile
	When Search for Offer in offering list <OfferName>
	And Click on Offer 
	When Click on Add investment field <InvestorName>
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
	And Click on Save button
	Then Click on confirm button

  Given Switch User-Account to <User_Email2>
  And Navigate to Manage investment page
  When Search for Investor name <InvestorName>,"Ready to eSign"
	Given Click on Investment name in investment list
  When Click on Investor eSign step
  Given Click on eSign button
	Then Validate that the redirecting alert displaying
	Then Complete eSign process joint1
	And Validate that the eSign completion displaying successfully

  Given Switch User-Account to <User_Email>
  And Navigate to Manage investment page
  When Search for Investor name <InvestorName>,"Investor1 Signed"
  Given Click on Investment name in investment list
  When Click on Investor eSign step
	Given Click on eSign button
	Then Validate that the redirecting alert displaying
	Then Complete eSign process joint2
	And Validate that the eSign completion displaying successfully
	When Click on Next button
	Given Logout the profile account

	#Company profile
	 Given Login to Profile <Company_Email>
	And Navigate to investments page
	When Search for Investor name <InvestorName>,<InvestmentStatus>
	Given Click on Investment name in investment list
  When Click on Next button
	When Click on Company eSign step
	And Click on Click to eSign button
	Then Complete Company eSign process
	And validate that Company eSign completion reflected properly
	When Click on Next button 
	When Click on Confirm button of make payment
	Then validate that it navigate to the Make payment step

	#Investor profile
	Given Switch User-Account to <User_Email>
	And Navigate to Manage investment page
	When Search for Investor name <InvestorName>,"Approved"
	Given Click on Investment name in investment list
	When Click on Make Payment step	
	When Click on Next-button investment page 
	Given Select payment channel from popup "Wire Transfer"
 
  Then Validate that the second Investor can't make the payment Unable


#	Then validate that it navigate to finalize payment step
#  Given Logout the profile account
#
#	#Company profile
#	 Given Login to Profile <Company_Email>
#	Given Navigate to investments page
#	When Search for Investor name <InvestorName>,"Amount Transferred"
#	Given Click on Investment name in investment list	
#  Given Click on Finalize Investments step
#	When Enter Payment Receipt Date and Save	
#	When Select Finder for commission
#	When SetCommision for Finder
#	When Select Sales Rep for Commission
#	When SetCommission for Sales Rep
#	Then Click on Finalize button
#	And Validate that success-notification displaying properly
#	And Finalize the investment by clicking on confirm button
#	And Validate that success-notification displaying properly
#	And Validate that status of investment updated properly at top of the page "Invested"	

	Examples: 
	| User_Email                  |   User_Email2       | Company_Email            | OfferName           | InvestorName                                  | MinimumAmount | Investment_Amount | MonthlyIncome | MonthlyCompound | EstimatedIncome | InvestmentStatus |
	| Gustavo.Roberts@yopmail.com | Debra95@yopmail.com | CompanyManager           | Adobe Test Offering | Joint1 For Automation & Joint2 For Automation | 50            | 1000              | 30            | 70              | 0.74            | Investor Signed  |


  
  Scenario Outline:To verify that the first Investment can be done with accredited investor successfully

   Given Login to Profile <Company_Email>
  Given Navigate to Investor Page
  When Search name of Investor on Investor page with investor status and Type Accredited, Joint
  When Collect Investor details of Joint investor from investor details page
  Given Logout the profile account

	#InvestorSide Action
	When Login to investor of Joint 1
	Given Navigate to offering page of investor profile
	When Search for Offer in offering list <OfferName>
	And Click on Offer 
	When Click on Add investment field Joint1
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
  Then Get InvestmentDetails from investment details section of investment 1
	And Click on Save button
	Then Click on confirm button
  Then If the additional info has been saved then confirm and proceed it
  Given Wait until success notification invisible
  When Click on Investor eSign step
	Given Click on eSign button
	Then Validate that the redirecting alert displaying
	Then Complete eSign process Joint1
	And Validate that the eSign completion displaying successfully
  And Validate that status of investment updated properly at top of the page "Investor1 Signed"
  Given Logout the profile account

  #investor two
  When Login to investor of Joint 2
  Given Navigate to Manage investment page
  When Search for Investor name null,"Investor1 Signed"
	Given Click on Investment name in investment list
  When Click on Investor eSign step

  Given Click on eSign button
	Then Validate that the redirecting alert displaying
	Then Complete eSign process joint2
	And Validate that the eSign completion displaying successfully

	Given Logout the profile account

	#Company profile
	 Given Login to Profile <Company_Email>
	And Navigate to investments page
	When Search for Investor name null,<InvestmentStatus>
	Given Click on Investment name in investment list
  When Click on Next button
	When Click on Company eSign step
	And Click on Click to eSign button
	Then Complete Company eSign process
	And validate that Company eSign completion reflected properly
	When Click on Next button 
	When Click on Confirm button of make payment
	Then validate that it navigate to the Make payment step

	#Investor profile
	Given Switch User-Account to <User_Email>
	And Navigate to Manage investment page
	When Search for Investor name <InvestorName>,"Approved"
	Given Click on Investment name in investment list
	When Click on Make Payment step	
	When Click on Next-button investment page 
	Given Select payment channel from popup "Wire Transfer"
	Then validate that it navigate to finalize payment step

	Given Logout the profile account

	#Company profile
	 Given Login to Profile <Company_Email>
	Given Navigate to investments page	
  When Search for Joint investor with status on Investment page Amount Transferred
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


  #validate all investment details on investment details page

  Then Validate that the Investment Details section displaying properly 1
  Then Validate that the Tranche details section displaying properly <Investment_Amount>, 1
  Then Validate that Reinvestment Section displaying details properly 1, false, 1, 60
  Then Validate that the Monthly Income Breakdown displaying properly
  Then Validate that the Return Simulator displaying data properly 1, <Investment_Amount>



	
	Examples: 
	| User_Email          | User_Email2                 | Company_Email  | OfferName           | InvestorName                                  | MinimumAmount | Investment_Amount | MonthlyIncome | MonthlyCompound | EstimatedIncome | InvestmentStatus |
	| Debra95@yopmail.com | Gustavo.Roberts@yopmail.com | CompanyManager | Adobe Test Offering | Joint1 For Automation & Joint2 For Automation | 50            | 1000              | 30            | 70              | 0.74            | Investor Signed  |


  


  Scenario Outline: To verify that the investment can be added with accreditation successfully

  # Given Enter Email_PassWord for Login <Company_Email>
  Given Login to Profile <Company_Email>
  Given Navigate to Investor Page
  When Search name of Investor on Investor page with investor status and Type Initiated, Joint
  When Collect Investor details of Joint investor from investor details page
  Given Logout the profile account
  

  	#InvestorSide Action
	When Login to investor of Joint 1  
  Given Navigate to the Add invest field <OfferName>	
	When Click on Add investment field Joint1
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
  Then Get InvestmentDetails from investment details section of investment 1
	And Click on Save button
	Then Click on confirm button

  Given Select Investor among joint additional information form 1
  When Fill the Additional info form for joint
  Given Select Investor among joint additional information form 2
  When Fill the Additional info form for joint

  Then If the additional info has been saved then confirm and proceed it
  Given Wait until success notification invisible

  When Click on Investor eSign step
	Given Click on eSign button
	Then Validate that the redirecting alert displaying
  #Given Click on eSign button
	Then Complete eSign process Joint1
	And Validate that the eSign completion displaying successfully
  And Validate that status of investment updated properly at top of the page "Investor1 Signed"
    
	When Click on Investor accreditation step
  When Upload Accreditation letter on Accreditation step
  When Upload document using HandleOpenDialog <FileName>	
	
  Given Logout the profile account

  When Login to investor of Joint 2
  Given Navigate to Manage investment page
  When Search for Investor name null,"Investor1 Signed"
	Given Click on Investment name in investment list
  When Click on Investor eSign step

  Given Click on eSign button
	Then Validate that the redirecting alert displaying
	Then Complete eSign process joint2
	And Validate that the eSign completion displaying successfully
  And Validate that status of investment updated properly at top of the page "Investor Signed"
  Then Validate that it navigates to the Investment Accreditation section	
  When Upload Accreditation letter on Accreditation step
  When Upload document using HandleOpenDialog <FileName>	
	When Click on Next button
	Then Validate that it navigates to the Company eSign field
  Given Logout the profile account
  


  #Company Side Action
	#Given Switch User-Account to <Company_Email>
  Given Login to Profile <Company_Email>
	And Navigate to investments page
	When Search for Joint investor with status on Investment page Investor Signed
	Given Click on Investment name in investment list
  When Click on Investor accreditation step
  When Complete the Accreditation of investment at company side
  When Click on Save(Green) button
  When Click on Next button
  Given Wait until success notification invisible
 # Then Validate that status of investment updated properly at top of the page "Accredited"

	When Click on Company eSign step
	And Click on Click to eSign button
	Then Complete Company eSign process
	And validate that Company eSign completion reflected properly
	When Click on Next button 
	When Click on Confirm button of make payment
	Then validate that it navigate to the Make payment step
  Given Logout the profile account

	#Investor profile
	When Login to investor of Joint 1  
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
	| User_Email          | User_Email2                 | Company_Email      | OfferName           | InvestorName                                  |FileName     | Investment_Amount | MonthlyIncome | MonthlyCompound | EstimatedIncome | InvestmentStatus |
	| Debra95@yopmail.com | Gustavo.Roberts@yopmail.com | CompanyManager     | Adobe Test Offering | Joint1 For Automation & Joint2 For Automation |uploadDoc.png| 1000              | 30            | 70              | 0.74            | Investor Signed  |
