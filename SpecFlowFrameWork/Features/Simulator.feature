@BeforeFeatureDontLaunch @BeforeStep @M2I
Feature: Simulator

A short summary of the feature

    Scenario Outline: To verify that the re-investment section calculates value properly
    Given Enter Email_PassWord for Login <User_Email>
	Given Navigate to offering page of investor profile
	When Search for Offer in offering list <OfferName>
	And Click on Offer 
	When Click on the Simulate My investment section
	Given Enter Investment amount more than minimum amount <Investment_Amount>, <ParentTrancheNumber>
	When Enter Value in Monthly income field <MonthlyIncome>, <ParentTrancheNumber>
	And Enter re-investment value to tranche <ParentTrancheNumber>, <TrancheName>, <re-investmentValue>
	Then Validate that the withdraw section show value properly <ParentTrancheNumber>, <re-investmentValue>
	When  Click on Simulate button 
	When Click on Tranche in calculation table <TrancheName>
	Then Validate data of calculation table <Investment_Amount>, <AnnualInterestRate>, <MonthlyIncome>, <Invest_ReInvest>


	Examples: 
	| User_Email                   | OfferName | Investment_Amount | MonthlyIncome | AnnualInterestRate | ParentTrancheNumber | TrancheName | re-investmentValue | Invest_ReInvest |
	| Eunice_Aufderhar@hotmail.com | SLP4      | 1200.00           | 50            | 7.5                | 1                   | Tranche 3   | 100                | ReInvest        |



    Scenario:To verify that the Calculation table shows proper data
	Given Enter Email_PassWord for Login <User_Email>
	Given Navigate to offering page of investor profile
	When Search for Offer in offering list <OfferName>
	And Click on Offer 
	When Click on the Simulate My investment section
    Given Enter Investment amount more than minimum amount <Investment_Amount>, <ParentTrancheNumber>
	When Enter Value in Monthly income field <MonthlyIncome>, <ParentTrancheNumber>
	
	When  Click on Simulate button 

	Then Validate data of calculation table <Investment_Amount>, <AnnualInterestRate>, <MonthlyIncome>, <Invest_ReInvest>

	Examples: 
	| User_Email             | OfferName | Investment_Amount | MonthlyIncome | AnnualInterestRate | Invest_ReInvest |
	| Eunice_Aufderhar@hotmail.com | SLP4      | 1200              | 50            | 6.25               | Invest          |

	
	Scenario: To verify that Estimated monthly income calculated properly
	Given Enter Email_PassWord for Login <User_Email>
	Given Navigate to offering page of investor profile
	When Search for Offer in offering list <OfferName>
	And Click on Offer 
	When Click on the Simulate My investment section
	Given Enter Investment amount more than minimum amount <Investment_Amount>, <ParentTrancheNumber>
	When Enter Value in Monthly income field <MonthlyIncome>, <ParentTrancheNumber>
	Then Validate that the Estimated monthly income calculated properly <ParentTrancheNumber>, <Investment_Amount>, <AnnualInterestRate>, <Bonus>, <MonthlyIncome>
	When Click on the SAVE & INVEST NOW Button
	Then Validate that SAVE & INVEST NOW button navigate to investment process
	
	
	Examples: 
	| User_Email                  | OfferName | Investment_Amount | MonthlyIncome | AnnualInterestRate | Bonus | Invest_ReInvest | ParentTrancheNumber |
	| Eunice_Aufderhar@hotmail.com| SLP4      | 1200              | 50            | 6.25               | 0.00  | Invest          | 1                   |

