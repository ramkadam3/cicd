@BeforeFeatureDontLaunch @AfterStep @Origination
Feature: Login Function

A short summary of the feature

@MyModuleName
@Browser_Firefox

Scenario Outline: To Verify The login to the Yrefy application
	#Given launch the application 'Firefox'
  When enter the email <User_Email>
  And enter the password <User_Passward>
  And click on submit button
  Then verify Home page

Examples:
  | User_Email              | User_Passward |
	| yrefytestuser@gmail.com | Yrefy@123     |
	| hosp%$ital@rovic.com    | Yrefy@123     |
	| yrefytestuser@gmail.com | Roass@321     |
	| *&%&*8@rovare.com       | Roass@321     |


  #| STEWARD94@ICLOUD.COM            | Yrefy@123    |
  #| BMAC1441@YAHOO.COM              | Yrefy@123    |
  #| KEB041388@GMAIL.COM             | Yrefy@123    |
  #| ALFIE8715@GMAIL.COM             | Yrefy@123    |
  #| RESPAILLAT0822@GMAIL.COM        | Yrefy@123    |
  #| ritaluciano@gmail.com           | Yrefy@123    |
  #| WHITTAKER.REBECCA@GMAIL.COM     | Yrefy@123    |
  #| marybeth.morris.72@gmail.com    | Yrefy@123    |
  #| THREEMONKEYS37S@GMAIL.COM       | Yrefy@123    |
  #| RAMEYRICE1@GMAIL.COM            | Yrefy@123    |
  #| TERRELLMOM@GMAIL.COM            | Yrefy@123    |
  #| SPALDING.KATE85@GMAIL.COM       | Yrefy@123    |
  #| DAVENPORT.NATHAN@SC.SYSCO.COM   | Yrefy@123    |
  #| CRAFTYJAYHAWK@YAHOO.COM         | Yrefy@123    |
  #| kimberlywach@gmail.com          | Yrefy@123    |
  #| SUESAMSTEW@YAHOO.COM            | Yrefy@123    |
  #| JORGEBONILLA4@GMAIL.COM         | Yrefy@123    |
  #| STACEYSANKOW@GMAIL.COM          | Yrefy@123    |
  #| dotalford@hotmail.com           | Yrefy@123    |
  #| rnmommyoftwo@yahoo.com          | Yrefy@123    |
  #| JESSICA_456@LIVE.COM            | Yrefy@123    |
  #| PDRAHMANN@GMAIL.COM             | Yrefy@123    |
  #| ANNACASAREZHERRERA@GMAIL.COM    | Yrefy@123    |
  #| PRINCESSJAY1093@GMAIL.COM       | Yrefy@123    |
  #| THOMAS.MERIN2011@GMAIL.COM      | Yrefy@123    |
  #| URANJUAN111@GMAIL.COM           | Yrefy@123    |
  #| PHICWIN96@GMAIL.COM             | Yrefy@123    |
  #| BCHEVRES@HOTMAIL.COM            | Yrefy@123    |
  #| F3LIX7@YAHOO.COM                | Yrefy@123    |
  #| SC.NWOGU@GMAIL.COM              | Yrefy@123    |
  #| TAYLORRUTH1996@GMAIL.COM        | Yrefy@123    |
  #| JENNIFERRUBERT27@GMAIL.COM      | Yrefy@123    |
  #| ATERRALO4@GMAIL.COM             | Yrefy@123    |
  #| DAKOTA.FCB@GMAIL.COM            | Yrefy@123    |
  #| SJBAKKE13@GMAIL.COM             | Yrefy@123    |
  #| TDELORISMCGEE@GMAIL.COM         | Yrefy@123    |
  #| SHERRYT416@GMAIL.COM            | Yrefy@123    |
  #| ASHLEYGOCLANO@AOL.COM           | Yrefy@123    |
  #| N_GALICIA18@YAHOO.COM           | Yrefy@123    |
  #| BRITTANYSAWYER00@GMAIL.COM      | Yrefy@123    |
  #| JTKKNIGHT777@AOL.COM            | Yrefy@123    |
  #| CAROLINAGIRL216@HOTMAIL.COM     | Yrefy@123    |
  #| SECHILDS1987@YAHOO.COM          | Yrefy@123    |
  #| TMOCK05@ME.COM                  | Yrefy@123    |
  #| CHEYENNEKENNEDY1994@OUTLOOK.COM | Yrefy@123    |
  #| LENGEL1998@YAHOO.COM            | Yrefy@123    |
  #| SAVAGEDANAE@GMAIL.COM           | Yrefy@123    |
  #| AJSCONSULTING01@GMAIL.COM       | Yrefy@123    |
  #| NELSONII.ANTHONY@GMAIL.COM      | Yrefy@123    |
  #| JWEAVER7572@COMCAST.NET         | Yrefy@123    |
  #| MICHALEC1845@GMAIL.COM          | Yrefy@123    |
  #| DANGT1992@GMAIL.COM             | Yrefy@123    |
  #| ANEESHAPIERCE@YAHOO.COM         | Yrefy@123    |
  #| CKEELER0617@YAHOO.COM           | Yrefy@123    |
  #| DURANGO456@GMAIL.COM            | Yrefy@123    |
  #| IRIDIANAYALA68@GMAIL.COM        | Yrefy@123    |
  #| MARIBELCHAVEZ13@YAHOO.COM       | Yrefy@123    |
  #| MSBRIANNAMILLER@YAHOO.COM       | Yrefy@123    |
  #| AJEE.SPENCER.AS@GMAIL.COM       | Yrefy@123    |
  #| DASHAUNAROBINSON@GMAIL.COM      | Yrefy@123    |
  #| SARAWALTON36@GMAIL.COM          | Yrefy@123    |
  #| JINIGU44@GMAIL.COM              | Yrefy@123    |
  #| 6941MPOLICE@GMAIL.COM           | Yrefy@123    |
  #| JORDYNGILLINGS@GMAIL.COM        | Yrefy@123    |
  #| AUSTINDFITZWATER@GMAIL.COM      | Yrefy@123    |
  #| KGLOVERHILL@OUTLOOK.COM         | Yrefy@123    |
  #| DIETLIM128@GMAIL.COM            | Yrefy@123    |
  #| MDOUGHERTY360@GMAIL.COM         | Yrefy@123    |
  #| NEILJCALERO@GMAIL.COM           | Yrefy@123    |
  #| RAFAELDRCARVALHO@GMAIL.COM      | Yrefy@123    |
  #| LOGEORGE27@GMAIL.COM            | Yrefy@123    |
  #| M.SAMANTHA48@YAHOO.COM          | Yrefy@123    |
  #| GERALDPSMITH78@GMAIL.COM        | Yrefy@123    |
  #| FIORAMONTI1945@GMAIL.COM        | Yrefy@123    |
  #| DENESIALEE@GMAIL.COM            | Yrefy@123    |
  #| SHEENALONG7@GMAIL.COM           | Yrefy@123    |
  #| MS.AMINAZAID@GMAIL.COM          | Yrefy@123    |
  #| JAKIN0408@GMAIL.COM             | Yrefy@123    |
  #| HUNTER224@LIVE.COM              | Yrefy@123    |
  #| AMANDA.C.ARREDONDO@GMAIL.COM    | Yrefy@123    |
  #| BRUCEMONTGOMERY@YMAIL.COM       | Yrefy@123    |
  #| DAVID_JASKOWIAK@YAHOO.COM       | Yrefy@123    |
  #| NEWTONH@DAVENPORTSCHOOLS.ORG    | Yrefy@123    |
  #| TLOY2121@YAHOO.COM              | Yrefy@123    |
  #| PATRICKLUCKETT@YMAIL.COM        | Yrefy@123    |
  #| APIERALDIS@ATT.NET              | Yrefy@123    |
  #| AISHA.MGENI@GMAIL.COM           | Yrefy@123    |
  #| CHADTLUCKY7@GMAIL.COM           | Yrefy@123    |
  #| D.CRANDALL26@GMAIL.COM          | Yrefy@123    |
  #| DIANE.A.TAI7@PROTONMAIL.COM     | Yrefy@123    |
  #| JAYMES.SHORTER87@GMAIL.COM      | Yrefy@123    |
  #| H.JEAN.AND@GMAIL.COM            | Yrefy@123    |
  #| PGMT43@GMAIL.COM                | Yrefy@123    |
  #| BUCKEYEDOG5@AOL.COM             | Yrefy@123    |
  #| TRAVIS.VERRETT94@YAHOO.COM      | Yrefy@123    |
  #| CHEFININDO@GMAIL.COM            | Yrefy@123    |
  #| SPROKOP28@GMAIL.COM             | Yrefy@123    |
  #| LORLORFITZPATRICK@GMAIL.COM     | Yrefy@123    |
  #| JNBRATT44@AOL.COM               | Yrefy@123    |
	 #                    
