CREATE DATABASE yoyo

go

use yoyo

go

CREATE TABLE SKUTable(
SKU NVARCHAR(8) PRIMARY KEY,
ProductDescription NVARCHAR(50),
Colour NVARCHAR(24)
)


CREATE TABLE ScheduleTable(
ScheduleTable_ID INT identity(1,1) PRIMARY KEY,
StartTime DATETIME,
EndTime DATETIME,
SKUID NVARCHAR(8),
WorkArea NVARCHAR(50),
FOREIGN KEY (SKUID) REFERENCES SKUTable(SKU)
)


CREATE TABLE RejectTable(
RejectID INT identity(1,1) PRIMARY KEY,
InspectionalLocation INT,
TypeOfAction NVARCHAR(50),
Reason NVARCHAR(50)
)


CREATE TABLE ProductionStateTable(
StateID INT identity(1,1) PRIMARY KEY,
TheState NVARCHAR(50), 
StateDescription NVARCHAR(50)
)


CREATE TABLE YoyoLog(
WorkArea NVARCHAR(50),
YoYoID NVARCHAR(128),
LineNumber NVARCHAR(8),
ProdState NVARCHAR(128),
InspectionDecision NVARCHAR(128),
DateTimeOfCompletion DATETIME,
SKU NVARCHAR(8)
)


CREATE TABLE UsersTable(
ID INT identity(1,1) PRIMARY KEY,
Name NVARCHAR(50),
ThePassword NVARCHAR(128),
SecurityLevel INT
)



INSERT INTO SKUTable(SKU, ProductDescription, Colour)
SELECT 'Y001-1', 'Prestige Classic', 'Red'
UNION ALL
SELECT 'Y001-2', 'Prestige Classic', 'Blue'
UNION ALL
SELECT 'Y001-3', 'Prestige Classic', 'Green'
UNION ALL
SELECT 'Y002-0', 'Clear Plastic', 'Clear'
UNION ALL
SELECT 'Y005-1', 'Whistler', 'Red'
UNION ALL
SELECT 'Y005-2', 'Whistler', 'Blue'
UNION ALL
SELECT 'Y005-3', 'Whistler', 'Green'




INSERT INTO ProductionStateTable(TheState, StateDescription)
SELECT 'MOLD', 'In the Mold process'
UNION ALL
SELECT 'QUEUE_INSPECTION_1', 'On the conveyor to inspection station 1'
UNION ALL
SELECT 'INSPECTION_1', 'At inspection station 1'
UNION ALL
SELECT 'INSPECTION_1_SCRAP', 'In scrap (end of process for that particular yoyo)'
UNION ALL
SELECT 'QUEUE_PAINT', 'On the conveyor to the paint process'
UNION ALL
SELECT 'PAINT', 'In the paint process'
UNION ALL
SELECT 'QUEUE_INSPECTION_2', 'On the cinveyor to inspection station 2'
UNION ALL
SELECT 'INSPECTION_2', 'At inspection station 2'
UNION ALL
SELECT 'INSPECTION_2_REWORK', 'Being reworked and sent back to paint'
UNION ALL
SELECT 'INSPECTION_2_SCRAP', 'In scrap (end of process for that particular yoyo)'
UNION ALL
SELECT 'QUEUE_ASSEMBLY', 'On the conveyor to the assembly process'
UNION ALL
SELECT 'ASSEMBLY', 'In the assembly process'
UNION ALL
SELECT 'QUEUE_INSEOCTION_3', 'On the conveyor to inspection station 3'
UNION ALL
SELECT 'INSPECTION_3', 'At inspection station 3'
UNION ALL
SELECT 'INSPECTION_3_REWORK', 'Being reworked and sent back to assembly'
UNION ALL
SELECT 'INSPECTION_3_SCRAP', 'In scrap (end of process for that particular yoyo)'
UNION ALL
SELECT 'PACKAGE', 'In package (end of process for a good yoyo)'



INSERT INTO RejectTable(InspectionalLocation, TypeOfAction, Reason)
SELECT 1, 'Reject', 'INCONSISTENT_THICKNESS'
UNION ALL
SELECT 1, 'Reject', 'PITTING'
UNION ALL
SELECT 1, 'Reject', 'WARPING'
UNION ALL
SELECT 2, 'Reject', 'PRIMER_DEFECT'
UNION ALL
SELECT 2, 'Rework', 'DRIP_MARK'
UNION ALL
SELECT 2, 'Rework', 'FINAL_COAT_FLAW'
UNION ALL
SELECT 3, 'Reject', 'BROKEN_SHELL'
UNION ALL
SELECT 3, 'Rework', 'BROKEN_AXLE'
UNION ALL
SELECT 3, 'Rework', 'TANGLED_STRING'
UNION ALL
SELECT 3, 'Rework', 'FINAL_COAT_FLAW'



INSERT INTO UsersTable ( Name, ThePassword, SecurityLevel) VALUES ( 'Admin', '1234', 10);	
INSERT INTO UsersTable ( Name, ThePassword, SecurityLevel) VALUES ( 'bridget', 'password', 5);	
INSERT INTO UsersTable ( Name, ThePassword, SecurityLevel) VALUES ( 'tong', 'ilovepie', 5);	
INSERT INTO UsersTable ( Name, ThePassword, SecurityLevel) VALUES ( 'ibrahim', 'yoyomaster', 5);
			
	
CREATE TABLE Yield(	
Station INT ,	
YoyoNumber INT,	
Reject INT,	
Rework INT	
)
			
	
CREATE TABLE FinalYoyo(	
YoyoID NVARCHAR(50) PRIMARY KEY,	
Line INT,	
StateFinal INT,	
StartTime DATETIME 	
) 
