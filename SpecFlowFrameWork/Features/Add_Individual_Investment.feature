@BeforeFeatureDontLaunch @AfterStep @M2I
Feature:Add_Individual_Investment

In this feature Add investment feature has been tested with all scenarios


Scenario Outline:01- To verify that the field invest now navigate to the investment process

	Given Enter Email_PassWord for Login <User_Email>
	Given Navigate to offering page of investor profile
	When Search for Offer in offering list <OfferName>
	And Click on Offer 
	When Click on Add investment field <InvestorName>
	Then Validate InvestNow field navigate to the investment process

	Examples: 
	| User_Email                   |   InvestorName     | OfferName           |
	| Eunice_Aufderhar@yopmail.com | Only For Automation| Adobe Test Offering |
 


	Scenario Outline:02- To verify that the investment details section working properly

	Given Enter Email_PassWord for Login <User_Email>
	Given Navigate to offering page of investor profile
	When Search for Offer in offering list <OfferName>
	And Click on Offer 
	When Click on Add investment field <InvestorName>
	And Enter Investment Less than minimum investment amount required <MinimumAmount>
	And Click on Save button
	Then Validate that Alert notification displaying for Minimum investment amount
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
	Then validate Monthly compound field show correct value <MonthlyCompound>
	Then Validate Estimated monthly income field show correct value <EstimatedIncome>

	Given Enter value in the Monthly compound field <MonthlyCompound1>
  Then Validate monthly income field shows correct value <MonthlyIncome1>
	
	Given Scroll the Bar to new position
	Then validate that Monthly income and Monthly compound  section show correct value

	And Click on Save button
	Then Validate that Save investment details popup comes up
	And Click on confirm button
	Then Validate success-notification displaying
	Then validate it navigated to investor eSign section

	Examples: 
	| User_Email                   | InvestorName        | OfferName           | MinimumAmount | Investment_Amount | MonthlyIncome | MonthlyCompound | EstimatedIncome | MonthlyIncome1 | MonthlyCompound1 |
	| Eunice_Aufderhar@yopmail.com | Only For Automation | Adobe Test Offering | 50            | 1000              | 30            | 70              | 0.74            | 70             | 30               |

	Scenario Outline:03- To verify that the Investor eSign section working properly

	Given Enter Email_PassWord for Login <User_Email>
	Given Navigate to offering page of investor profile
	When Search for Offer in offering list <OfferName>
	And Click on Offer 
	When Click on Add investment field <InvestorName>
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
	And Click on Save button
	Then Validate that Save investment details popup comes up
	And Click on confirm button
	Then Validate success-notification displaying
	Then Validate that the investor eSign section displays details properly
	
	Given Click on eSign button
	Then Validate that the redirecting alert displaying
	And Complete eSign process Individual
	And Validate that the eSign completion displaying successfully
	And Validate that status of investment updated properly at top of the page "Investor Signed"

	
	Then Validate that it navigates to the Investment Accreditation section
  When Click on Investor eSign step
	Then Validate that the View Document Action item working properly            
	And Validate that the Download document Action item working properly      

	Examples: 
	| User_Email                   | InvestorName        | OfferName           | MinimumAmount | Investment_Amount | MonthlyIncome | MonthlyCompound | EstimatedIncome | MonthlyIncome1 | MonthlyCompound1 |
	| Eunice_Aufderhar@yopmail.com | Only For Automation | Adobe Test Offering | 50            | 1000              | 30            | 70              | 0.74            | 70             | 30               |

	Scenario Outline:04- To verify that the investor Accreditation section working properly
	Given Enter Email_PassWord for Login <User_Email>
	Given Navigate to offering page of investor profile
	When Search for Offer in offering list <OfferName>
	And Click on Offer 
	When Click on Add investment field <InvestorName>
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
	And Click on Save button
	Then Click on confirm button	
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

	Examples: 
	| User_Email                   | InvestorName         | OfferName          | MinimumAmount | Investment_Amount | MonthlyIncome | MonthlyCompound | EstimatedIncome | MonthlyIncome1 | MonthlyCompound1 |
	| Eunice_Aufderhar@yopmail.com |  Only For Automation |Adobe Test Offering | 50            | 1000              | 30            | 70              | 0.74            | 70             | 30               |

	Scenario Outline:05- To verify that the investor couldn't do action in Company eSign, Make payment and Finalize investment section till the company  confirm the investment
	Given Enter Email_PassWord for Login <User_Email>
	Given Navigate to offering page of investor profile
	When Search for Offer in offering list <OfferName>
	And Click on Offer 
	When Click on Add investment field <InvestorName>
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
	And Click on Save button
	Then Click on confirm button	
	Given Click on eSign button
	Then Validate that the redirecting alert displaying
	Then Complete eSign process Individual
	And Validate that the eSign completion displaying successfully
	#When Click on Next button
	Then Validate that it navigates to the Investment Accreditation section
	And Validate that status of investment updated properly at top of the page "Investor Signed"
	When Click on Next button
	Then Validate that it navigates to the Company eSign field

	Then Validate that the Company eSign, Make Payment, Finalize Investment sections are not accessible to investor till Company-signature

	Examples: 
	| User_Email                   |InvestorName         | OfferName           | MinimumAmount | Investment_Amount | MonthlyIncome | MonthlyCompound | EstimatedIncome | MonthlyIncome1 | MonthlyCompound1 |
	| Eunice_Aufderhar@yopmail.com | Only For Automation | Adobe Test Offering | 50            | 1000              | 30            | 70              | 0.74            | 70             | 30               |



	Scenario Outline:06- To verify that the investment is displaying properly in the company profile on the investment page
	Given Login to Profile <User_Email>
	And Navigate to investments page
	When Search for Investor name <InvestorName>,<InvestmentStatus>
	Then Validate that the status of Investment reflecting properly <InvestmentStatus>
	

	Examples: 
	| User_Email     | InvestorName        | MinimumAmount | Investment_Amount | MonthlyIncome | MonthlyCompound | EstimatedIncome | InvestmentStatus |
	| CompanyManager | Only For Automation | 50            | 1000              | 30            | 70              | 0.74            | Investor Signed  |



	Scenario Outline:07- To verify that the investment details are displaying properly to the company click on the view investment action item
	Given Login to Profile <User_Email>
	And Navigate to investments page
	When Search for Investor name <InvestorName>,<InvestmentStatus>
	Then Validate that the status of Investment reflecting properly <InvestmentStatus>
	Given Click on Investment name in investment list
	When Click on Investment Details step
	Then Validate that Investment Details section display record properly <Investment_Amount>, <MonthlyIncome>, <MonthlyCompound>,<EstimatedIncome>
	
	When Click on Investor eSign step 
	Then Validate that Investor eSign section reflecting record properly 
	When Click on Investor accreditation step 
	Then Validate that the Accreditation details reflects record properly 


	Examples: 
	| User_Email     | InvestorName        | MinimumAmount | Investment_Amount | MonthlyIncome | MonthlyCompound | EstimatedIncome | InvestmentStatus |
	| CompanyManager | Only For Automation | 50            | 1000              | 30            | 70              | 0.74            | Investor Signed  |
	

	Scenario Outline:08- To verify that the company can confirm the investment by eSigning the investment
	Given Login to Profile <User_Email>
	And Navigate to investments page
	When Search for Investor name <InvestorName>,<InvestmentStatus>
	Given Click on Investment name in investment list
	
	When Click on Company eSign step
	And Click on Click to eSign button
	Then Complete Company eSign process
	And validate that Company eSign completion reflected properly
	When Click on Next-button investment page
	When Click on Confirm button of make payment
	Then validate that it navigate to the Make payment step

	Examples: 
	| User_Email     | InvestorName       | MinimumAmount | Investment_Amount | MonthlyIncome | MonthlyCompound | EstimatedIncome |InvestmentStatus |
	| CompanyManager | Only For Automation| 50            | 1000              | 30            | 70              | 0.74            | Investor Signed |


	Scenario Outline:09- To verify that the Company can do action in the Make Payment section
		Given Login to Profile <User_Email>
	  And Navigate to investments page
  	When Search for Investor name <InvestorName>,<InvestmentStatus>
	  Given  Click on Investment name in investment list
	
    When Click on Make Payment step	
	  When  Click on Next-button investment page 
	  Given  Select payment channel from popup <PaymentChannelName>
	  Then  validate that it navigate to finalize payment step

	Examples: 
	| User_Email     | InvestorName        | MinimumAmount | Investment_Amount | MonthlyIncome | MonthlyCompound | EstimatedIncome | InvestmentStatus | PaymentChannelName |
	| CompanyManager | Only For Automation | 50            | 1000              | 30            | 70              | 0.74            | Approved         | Check              |
	
	Scenario Outline:10- To verify that the company can finalize investment properly
	
	Given Login to Profile <User_Email>
	And Navigate to investments page
	When Search for Investor name <InvestorName>,<InvestmentStatus>
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
	And Validate that status of investment updated properly at top of the page <InvestmentStatus2>	
	Given Navigate to investments page
	When Search for Investor name <InvestorName>,<InvestmentStatus2>
	Then Validate that the status of investment got updated

	
	Examples: 
	| User_Email     | InvestorName        | MinimumAmount | Investment_Amount | InvestmentStatus2 | MonthlyCompound | EstimatedIncome | InvestmentStatus  | PaymentChannelName |
	| CompanyManager | Only For Automation | 50            | 1000              | Invested          | 70              | 0.74            | Amount Transferred| Check              |
	
	Scenario Outline:To verify that the additional investment can be done with Add investment button 
	
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


  Then Validate that the Investment Details section displaying properly 1
  Then Validate that the Tranche details section displaying properly <Investment_Amount>, 1
  Then Validate that Reinvestment Section displaying details properly 1, false, 1, 60
  Then Validate that the Monthly Income Breakdown displaying properly
  Then Validate that the Return Simulator displaying data properly 1, <Investment_Amount>

	Examples: 
	| User_Email                  | Company_Email            | OfferName          | InvestorName            | MinimumAmount | Investment_Amount | MonthlyIncome | MonthlyCompound | EstimatedIncome | InvestmentStatus |
	|Eunice_Aufderhar@yopmail.com | CompanyManager           |Adobe Test Offering | Only For Automation     | 50            | 1000              | 30            | 70              | 0.74            | Investor Signed  |


  Scenario Outline: To verify that the first Investment can be done with accredited investor successfully

  Given Login to Profile <Company_Email>
  Given Navigate to Investor Page
  When Search for Investor name null,Accredited
  Given Search the Investor on the Investor page Individual
  When Get the email of the Investor from investor page
  Given Logout the profile account

  When Provide Email and Password then login
	Given Navigate to the Add invest field <OfferName>	
	When Click on Add investment field null
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
  Then Get InvestmentDetails from investment details section of investment 1

	And Click on Save button
	Then Click on confirm button
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
	 | Company_Email  | OfferName          |   MinimumAmount | Investment_Amount | MonthlyIncome | MonthlyCompound | EstimatedIncome | InvestmentStatus |
	 | CompanyManager |Adobe Test Offering |   50            | 1000              | 30            | 70              | 0.74            | Investor Signed  |




   
   Scenario Outline: To verify that the investment can be added with accreditation successfully


  Given Login to Profile <Company_Email>
  Given Navigate to Investor Page
  When Search for Investor name null,Initiated
  Given Search the Investor on the Investor page Individual
  When Get the email of the Investor from investor page
  Given Logout the profile account

  When Provide Email and Password then login
	Given Navigate to the Add invest field <OfferName>	
	When Click on Add investment field null
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
  Then Get InvestmentDetails from investment details section of investment 1

	And Click on Save button
	Then Click on confirm button
  When Fill the Additional information form Individual
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
	 | Company_Email  | OfferName           | MinimumAmount | Investment_Amount | MonthlyIncome | MonthlyCompound | EstimatedIncome | InvestmentStatus | FileName      |
	 | CompanyManager | Adobe Test Offering | 50            | 1000              | 30            | 70              | 0.74            | Investor Signed  | uploadDoc.png |


   @ignore
   Scenario Outline: To verify that the Additional information reflecting properly on eSign Document

    Given Login to Profile <Company_Email>
  Given Navigate to Investor Page
  When Search for Investor name null,Initiated
  Given Search the Investor on the Investor page Individual
  When Get the email of the Investor from investor page
  Given Logout the profile account

  When Provide Email and Password then login
	Given Navigate to offering page of investor profile
	When Search for Offer in offering list <OfferName>
	And Click on Offer 
	When Click on Add investment field null
	Given Enter Investment amount more than minimum amount <Investment_Amount>, "1"
	When Enter Value in Monthly income field <MonthlyIncome>, "1"
  Then Get InvestmentDetails from investment details section of investment 1

	And Click on Save button
	Then Click on confirm button
  When Fill the Additional information form Individual
  Then If the additional info has been saved then confirm and proceed it
  Given Wait until success notification invisible
	Given Click on eSign button
	Then Validate that the redirecting alert displaying
  Then Complete eSign process Individual
	And Validate that the eSign completion displaying successfully
	
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


  Examples: 
	 | Company_Email   | OfferName          |   MinimumAmount | Investment_Amount | MonthlyIncome | MonthlyCompound |
	 | CompanyManager  |Adobe Test Offering |   50            | 1000              | 30            | 70              |
