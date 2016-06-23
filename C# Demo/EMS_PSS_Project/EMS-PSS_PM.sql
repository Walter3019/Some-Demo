-- 0. Create database named "EMSPSS".
-- each table with prefix EMS
CREATE DATABASE EMSPSS;
GO
USE	EMSPSS;





/*
	Table Name : EMS_Person
	Table Prefix : EMS
	Table Description : The Person table keep track of and contains
						all person specific informatin including the person ID, First Name, Last Name,
						Date of birth, and SIN.
*/

CREATE TABLE EMS_Person(
Person_ID INT PRIMARY KEY IDENTITY(1,1), -- PK
First_Name VARCHAR(50),
Last_Name VARCHAR(50),
Date_Of_Birth VARCHAR(10),
Social_Insurance_Number VARCHAR(10) UNIQUE NOT NULL
)





/*
	Table name : EMS_EmployeeType
	Table prefix : EMS
	Table Description : The emplyoeeType table keep track of and contains
						all employee type information including employee type ID 
						and employee type description.
*/

CREATE TABLE EMS_EmployeeType(
Employee_Type_ID INT PRIMARY KEY IDENTITY(1,1), -- PK
Employee_Type_Description VARCHAR(10)
)

-- insert into four type employee.
INSERT INTO EMS_EmployeeType(Employee_Type_Description) 
SELECT 'FullTime' 
UNION ALL 
SELECT 'PartTime' 
UNION ALL
SELECT 'Contract'
UNION ALL
SELECT 'Seasonal';




/*
	Table Name : EMS_Company
	Table Prefix : EMS
	Table Description : The Company table keep track of and contains 
						all Company specific information including the company name.
*/

CREATE TABLE EMS_Company(
Company_ID INT PRIMARY KEY IDENTITY(1,1),-- PK
Company_Name NVARCHAR NOT NULL,
-- Employee_Type_ID INT, -- FK															<---- What information will be stored here?
FOREIGN KEY (Employee_Type_ID) REFERENCES EMS_EmployeeType(Employee_Type_ID)
)




-->SELECT *, First_Name, Last_Name, Date_Of_Birth, Company_Name FROM EMS_Fulltime_Employee
/*
	Table Name : EMS_Fulltime_Employee
	Table Prefix : EMS
	Table Description : The Part-time Employee table keeps track of and contains 
						all Part-time Employees and their personal information, company of employment, 
                        SIN, date of hire, date of Termination, Reason_For_Leaving, Salary, status, and completion.
*/

CREATE TABLE EMS_Fulltime_Employee(
Social_Insurance_Number VARCHAR(10) PRIMARY KEY, -- PK, FK(Person table(Social_Insurance_Number))
Person_ID INT, -- FK														<---- Do we need Person ID? SIN is already unique & companyID FK takes care of having more than one job
Company_ID INT, -- FK
Date_Of_Hire VARCHAR(10),
Date_Of_Termination VARCHAR(10),
Reason_For_Leaving NVARCHAR, -- cannot image how many charactors that need it, so nvarchar
Salary MONEY, -- float or money.
Status BIT,
Completion BIT,
FOREIGN KEY (Social_Insurance_Number) REFERENCES EMS_Person(Social_Insurance_Number),
FOREIGN KEY (Person_ID) REFERENCES EMS_Person(Person_ID),
FOREIGN KEY (Company_ID) REFERENCES EMS_Company(Company_ID)
)




/*
	Table Name : EMS_Parttime_Employee
	Table Prefix : EMS
	Table Description : The part-time Employee table keeps track of and contains
						all contrack employees and their personal information, company of employment,
						SIN, date of hire, date of Termination, Reason_For_Leaving, hourly rate, status, and completion.
*/

CREATE TABLE EMS_Parttime_Employee(
Social_Insurance_Number VARCHAR(10) PRIMARY KEY, -- PK, FK(Person table(Social_Insurance_Number))
Person_ID INT, -- FK
Company_ID INT, -- FK
Date_Of_Hire VARCHAR(10),
Date_Of_Termination VARCHAR(10),
Reason_For_Leaving NVARCHAR, -- cannot image how many charactors that need it, so nvarchar
Hourly_Rate MONEY, -- float or money.
Status BIT,
Completion BIT,
FOREIGN KEY (Social_Insurance_Number) REFERENCES EMS_Person(Social_Insurance_Number),
FOREIGN KEY (Person_ID) REFERENCES EMS_Person(Person_ID),
FOREIGN KEY (Company_ID) REFERENCES EMS_Company(Company_ID)
)





/*
	Table Name : EMS_Contract_Employee
	Table Prefix : EMS
	Table Description : The contract employee table keeps track of and contians 
						all contract employees and their personal inffromation, company of employment,
                        SIN, date of hire, date of Termination, Reason_For_Leaving, Fixed_Contract_Amount, statusm completion.
*/

CREATE TABLE EMS_Contract_Employee(
Social_Insurance_Number VARCHAR(10) PRIMARY KEY, -- PK, FK(Person table(Social_Insurance_Number))
Person_ID INT, -- FK
Company_ID INT, -- FK
Date_Of_Hire VARCHAR(10),			---> Have to remember to change DOH & DOT when displaying table in GUI to Contract_Start_Date & Contract_Stop_Date
Date_Of_Termination VARCHAR(10),	--->
Reason_For_Leaving NVARCHAR, -- cannot image how many charactors that need it, so nvarchar
Fixed_Contract_Amount MONEY, -- float or money.
Status BIT,
Completion BIT,
FOREIGN KEY (Social_Insurance_Number) REFERENCES EMS_Person(Social_Insurance_Number),
FOREIGN KEY (Person_ID) REFERENCES EMS_Person(Person_ID),
FOREIGN KEY (Company_ID) REFERENCES EMS_Company(Company_ID)
)






/*
	Table Name : EMS_Season
	Table Prefix : EMS
	Table Description : The season table keeps track of and containts 
						season information including seasonID, Season, and Season_Year.
*/
CREATE TABLE EMS_Season(
Season_ID INT PRIMARY KEY IDENTITY(1,1), -- PK
Season VARCHAR(10) NOT NULL, -- FALL SPRING SUMMER WINTER
Season_Year VARCHAR(10),
, -- person ID (For saving all seasons worked past and present)
CONSTRAINT SeansonCheck CHECK (Season = 'FALL' or Season = 'SPRING' or Season = 'SUMMER' or Season = 'WINTER')
)





/*
	Table Name : EMS_Seasonal_Employee
	Table Prefix : EMS
	Table Description : The Seasonal employee table keeps track of and contains 
						all Seasonal employees and their peosonal information, company of employment,
                        SIN, sate of hire, date fo termination, Reason_For_Leaving, Season_ID, 
                        
*/
-- USING PIECECard TABLE.
CREATE TABLE EMS_Seasonal_Employee(
-- Seasonal_Employee_ID INT PRIMARY KEY, -- PK						<----- Do we need Social Insurance Number?.... what is your idea here?
-- SIN #
Person_ID INT, -- FK
Company_ID INT, -- FK
Season_ID INT, -- FK
Date_Of_Hire VARCHAR(10),
Reason_For_Leaving NVARCHAR, -- cannot image how many charactors that need it, so nvarchar
Piece_pay MONEY, -- float or money USING PIECECard TABLE.
Status BIT,
Completion BIT,
FOREIGN KEY (Person_ID) REFERENCES EMS_Person(Person_ID),
FOREIGN KEY (Company_ID) REFERENCES EMS_Company(Company_ID),
FOREIGN KEY (Season_ID) REFERENCES EMS_Season(Season_ID)
)





/*
	Table Name : EMS_PayWeek
	Table Prefix : EMS
	Table Description : The PayWeek table is used to contain 
						current pay week (strat and end data).
*/

CREATE TABLE EMS_PayWeek(
PayWeek_ID INT PRIMARY KEY, --PK
Starting_Date VARCHAR(10),
Ending_Date VARCHAR(10)
)





/*
	Table Name : EMS_PieceCard
	Table Prefix : EMS
	Table Description : The Piece Table track of and contains 
						all Seasonal employees piece amounts made on a daily basis.
*/

CREATE TABLE EMS_PieceCard(
Piece_Card_ID INT PRIMARY KEY, -- PK
Monday FLOAT,
Tuesday FLOAT,
Wendnesday FLOAT,						-- <-------- Wednesday
Thursday FLOAT,
Friday FLOAT,
Saturday FLOAT,
Sunday FLOAT
)






/*
	Table Name : EMS_TimeCard
	Table Prefix : EMS
	Table Description : The Time-Card Table will keep track of and contain 
						all hours woeked by all Employee ecvept Contract Employees. 
						Hours for each day of the week will be captured
*/

CREATE TABLE EMS_TimeCard(
Time_Card_ID INT PRIMARY KEY IDENTITY(1,1), -- PK
Piece_Card_ID INT, -- FK
Person_ID INT, -- FK
Company_ID INT, -- FK
Social_Insurance_Number VARCHAR(10), -- FK ? 
Seasonal_Employee_ID INT, -- FK
PayWeek_ID INT, -- FK
Employee_Type_ID INT, -- FK
Monday FLOAT,
Tuesday FLOAT,
Wendnesday FLOAT,      --- <------ Wednesday
Thursday FLOAT,
Friday FLOAT,
Saturday FLOAT,
Sunday FLOAT,
FOREIGN KEY (Piece_Card_ID) REFERENCES EMS_PieceCard(Piece_Card_ID),
FOREIGN KEY (Person_ID) REFERENCES EMS_Person(Person_ID),
FOREIGN KEY (Company_ID) REFERENCES EMS_Company(Company_ID),
FOREIGN KEY (PayWeek_ID) REFERENCES EMS_PayWeek(PayWeek_ID),
FOREIGN KEY (Social_Insurance_Number) REFERENCES EMS_Person(Social_Insurance_Number),
FOREIGN KEY (Employee_Type_ID) REFERENCES EMS_EmployeeType(Employee_Type_ID),
FOREIGN KEY (Seasonal_Employee_ID) REFERENCES EMS_Seasonal_Employee(Seasonal_Employee_ID)
) 




/*
	Table Name : EMS_SecurityLevel
	Table Prefix : EMS
	Table Description : The EMS_SecurityLevel table will Keep track of and containt
						all level of security including General and Admin.
*/

CREATE TABLE EMS_SecurityLevel(
SecurityLevel_ID INT PRIMARY KEY IDENTITY(1,1), -- PK
ScurityDescription VARCHAR(10), -- General or Admin
CONSTRAINT DescriptionRangeCheck CHECK (ScurityDescription = 'General' or ScurityDescription = 'Admin')
)

-- insert into two type security level.
INSERT INTO EMS_SecurityLevel(ScurityDescription) 
SELECT 'Admin'
UNION ALL 
SELECT 'General';




/*
	Table Name : EMS_Users
	Table Prefix : EMS
	Table Description : The EMS_Users table will keep track of and containt 
						all EMS-PSS General and Administrative users' information
*/

CREATE TABLE EMS_Users(
User_ID INT PRIMARY KEY IDENTITY(1,1),
First_Name VARCHAR(50), -- real user name
Last_Name VARCHAR(50), -- real user name
SecurityLevel_ID INT, -- FK
User_Name NVARCHAR NOT NULL, -- 
PassWord VARCHAR(50), -- Using md5  Website : http://www.cnblogs.com/stone_w/archive/2012/05/22/2513581.html		<---- Do we use a special key for the encrypt/decrypt?
FOREIGN KEY (SecurityLevel_ID) REFERENCES EMS_SecurityLevel(SecurityLevel_ID)
)






/*
	Table name : EMS_Audits
	Table prefix : EMS
	Table Description : The EMS_Audits table keeps track of and contains all employee record changes an additions.
						The Audit table will keep track of the user that performed the change along with the
                        element taht was changed, data and tiem it was changed an the new and previous data.
*/

CREATE TABLE EMS_Audits(
Audit_ID INT PRIMARY KEY IDENTITY(1,1), -- PK
User_ID INT NOT NULL, -- FK
Social_Insurance_Number VARCHAR(10), -- FK
Seasonal_Employee_ID INT, -- FK															<---- PURPOSE OF SEPARATE SEASONAL EMPLOYEE ID?
Company_ID INT NOT NULL, -- FK
Date_Edited VARCHAR(10) NOT NULL, -- Date timeStamp
Action_Commited NVARCHAR NOT NULL,
Attribute NVARCHAR NOT NULL,
New_Value VARCHAR(10) NOT NULL,
Old_Value VARCHAR(10) NOT NULL,
FOREIGN KEY (User_ID) REFERENCES EMS_Users(User_ID),
FOREIGN KEY (Company_ID) REFERENCES EMS_Company(Company_ID),
FOREIGN KEY (Social_Insurance_Number) REFERENCES EMS_Person(Social_Insurance_Number),
FOREIGN KEY (Seasonal_Employee_ID) REFERENCES EMS_Seasonal_Employee(Seasonal_Employee_ID)
)

SELECT * FROM EMS_EmployeeType;
SELECT * FROM EMS_SecurityLevel;