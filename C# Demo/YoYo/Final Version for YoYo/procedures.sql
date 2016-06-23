use yoyo

go

CREATE PROCEDURE userName
@userName NVARCHAR(50),
@pword NVARCHAR(50)
AS
BEGIN
	DECLARE @result INT = 0;
	--error checking if fields are blank
	SELECT @result = SecurityLevel FROM UsersTable 
	WHERE Name = @userName AND ThePassword = @pword

	RETURN @result

END

go

 CREATE PROCEDURE yields
 @startDate DATETIME,
 @endDate DATETIME,
 @product NVARCHAR(20),
 @colour NVARCHAR(20),
 @defect NVARCHAR(50)
 AS 
 BEGIN

    INSERT INTO yield(Station,Reject,Rework) SELECT RT.InspectionalLocation, SUM(CASE WHEN RT.TypeOfAction='Reject'THEN 1 END) AS Rejects,
  SUM(CASE WHEN RT.TypeOfAction='Rework'THEN 1 END) AS Reworks FROM RejectTable RT GROUP BY RT.InspectionalLocation

  -- check and see what filters are applied
  -- add to yield table
 END

 go


CREATE PROCEDURE GetColours

AS
BEGIN
	SELECT DISTINCT Colour FROM SKUTable;
END

go

CREATE PROCEDURE GetProducts
AS
BEGIN
	SELECT DISTINCT SKU FROM SKUTable;
END

go

Create Procedure Praeto
AS
BEGIN

CREATE TABLE VirtualTable(
TheDefect NVARCHAR(128),
DefectCount INT
)

INSERT INTO VirtualTable VALUES 
( 
(SELECT Reason FROM RejectTable where RejectID = 1), 
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  RejectId = 1)
);

INSERT INTO VirtualTable VALUES 
( 
(SELECT Reason FROM RejectTable where RejectID = 2), 
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  RejectId = 2)
);

INSERT INTO VirtualTable VALUES 
( 
(SELECT Reason FROM RejectTable where RejectID = 3), 
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  RejectId = 3)
);

INSERT INTO VirtualTable VALUES 
( 
(SELECT Reason FROM RejectTable where RejectID = 4), 
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  RejectId = 4)
);

INSERT INTO VirtualTable VALUES 
( 
(SELECT Reason FROM RejectTable where RejectID = 5), 
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  RejectId = 5)
);

INSERT INTO VirtualTable VALUES 
( 
(SELECT Reason FROM RejectTable where RejectID = 6), 
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  RejectId = 6)
);

INSERT INTO VirtualTable VALUES 
( 
(SELECT Reason FROM RejectTable where RejectID = 7), 
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  RejectId = 7)
);

INSERT INTO VirtualTable VALUES 
( 
(SELECT Reason FROM RejectTable where RejectID = 8), 
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  RejectId = 8)
);

INSERT INTO VirtualTable VALUES 
( 
(SELECT Reason FROM RejectTable where RejectID = 9), 
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  RejectId = 9)
);

INSERT INTO VirtualTable VALUES 
( 
(SELECT Reason FROM RejectTable where RejectID = 10), 
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  RejectId = 10)
);

SELECT * FROM VirtualTable ORDER BY DefectCount DESC;
DROP TABLE VirtualTable;
END

go


CREATE PROCEDURE GetUsers
AS
BEGIN
	SELECT DISTINCT Name FROM UsersTable;
END

go

CREATE PROCEDURE InsertUser
 @UserName NVARCHAR(50) = NULL,
 @ThePassword NVARCHAR(128) = NULL,
 @SecurityLevel INT = 0
AS

DECLARE @returnValue AS INT

BEGIN
IF ((SELECT COUNT(UsersTable.Name) FROM UsersTable WHERE Name=@UserName) <= 0)
	Begin
		Insert INTO UsersTable (Name, ThePassword,SecurityLevel) VALUES (@UserName,@ThePassword,@SecurityLevel);
		SET @returnValue = 1;
	End
ELSE
	Begin
		SET @returnValue = 0;
	End

	RETURN @returnValue;
END

go

CREATE PROCEDURE DeleteUser
 @UserName NVARCHAR(50) = NULL
AS
BEGIN
IF NOT EXISTS(
	SELECT Name 
	FROM UsersTable
	WHERE Name=@UserName
  )
  RETURN 0
ELSE
  DELETE FROM UsersTable WHERE Name=@UserName;
  RETURN 1
END

go

CREATE PROCEDURE ModifyUser
 @UserName NVARCHAR(50) = NULL,
 @Password NVARCHAR(128) = NULL,
 @SecurityLevel INT = NULL
AS
BEGIN
IF NOT EXISTS(
	SELECT Name 
	FROM UsersTable
	WHERE Name=@UserName
  )
  RETURN 0
ELSE
  UPDATE UsersTable SET ThePassword=@Password, SecurityLevel=@SecurityLevel WHERE Name=@UserName;
  RETURN 1
END

go

CREATE PROCEDURE InsertIntoSchedule
 @StartDateTime DATETIME = NULL,
 @EndDateTime DATETIME = NULL,
 @Product NVARCHAR(50) = NULL,
 @WorkArea NVARCHAR(50) = NULL
AS
BEGIN

	INSERT INTO ScheduleTable (StartTime,EndTime,SKUID,WorkArea) VALUES (@StartDateTime, @EndDateTime, @Product, @WorkArea);

END

go

CREATE PROCEDURE GetDefects
AS
BEGIN
	SELECT DISTINCT Reason FROM RejectTable;
END

go


CREATE PROCEDURE finalYield
 @passedInID NVARCHAR(50) = '',
 @passedInColour NVARCHAR (50) = '',
 @passedInState NVARCHAR (50) = '',
 @passedInReject NVARCHAR (50) = '',
 @passedInStartTime DATETIME = '',
 @passedInEndTime DATETIME = ''
AS
BEGIN

Declare @theID NVARCHAR(50) = '%' + @passedInID;
Declare @theColour NVARCHAR(50) = '%' + @passedInColour;
Declare @theState NVARCHAR(50) =  'INSPECTION_1';
Declare @theRejectReason NVARCHAR(50) = '%'+ @passedInReject;

CREATE TABLE FinalYieldTempTable(YoyoNumber INT)

IF @passedInStartTime != '' and @passedInEndTime != ''
	BEGIN
		INSERT INTO FinalYieldTempTable VALUES (
		(SELECT COUNT(*) FROM YoYolog yl
		INNER JOIN ScheduleTable st ON st.WorkArea = yl.WorkArea
		INNER JOIN SKUTable skuT ON skuT.SKU = st.SKUID
		WHERE SKUID LIKE @theID
		AND Colour LIKE @theColour
		AND yl.InspectionDecision LIKE @theRejectReason
		AND yl.ProdState = @theState
		AND  yl.DateTimeOfCompletion BETWEEN @passedInStartTime
		AND @passedInEndTime
		));

		INSERT INTO FinalYieldTempTable VALUES (
		(SELECT COUNT(*) FROM YoYolog yl
		INNER JOIN ScheduleTable st ON st.WorkArea = yl.WorkArea
		INNER JOIN SKUTable skuT ON skuT.SKU = st.SKUID
		INNER JOIN RejectTable rt ON yl.InspectionDecision = rt.Reason
		WHERE SKUID LIKE @theID
		AND Colour LIKE @theColour
		AND yl.InspectionDecision LIKE @theRejectReason
		AND  yl.DateTimeOfCompletion BETWEEN @passedInStartTime
		AND @passedInEndTime
		AND TypeOfAction = 'Reject'
		));
	END
else
	BEGIN
		INSERT INTO FinalYieldTempTable VALUES (
		(SELECT COUNT(*) FROM YoYolog yl
		INNER JOIN ScheduleTable st ON st.WorkArea = yl.WorkArea
		INNER JOIN SKUTable skuT ON skuT.SKU = st.SKUID
		WHERE SKUID LIKE @theID
		AND Colour LIKE @theColour
		AND yl.InspectionDecision LIKE @theRejectReason
		AND yl.ProdState = @theState
		));

		INSERT INTO FinalYieldTempTable VALUES (
		(SELECT COUNT(*) FROM YoYolog yl
		INNER JOIN ScheduleTable st ON st.WorkArea = yl.WorkArea
		INNER JOIN SKUTable skuT ON skuT.SKU = st.SKUID
		INNER JOIN RejectTable rt ON yl.InspectionDecision = rt.Reason
		WHERE SKUID LIKE @theID
		AND Colour LIKE @theColour
		AND yl.InspectionDecision LIKE @theRejectReason
		AND TypeOfAction = 'Reject'
		));
	END

	SELECT * FROM FinalYieldTempTable;

	DROP TABLE FinalYieldTempTable;

END

go

CREATE PROCEDURE firstYield
 @passedInID NVARCHAR(50) = '',
 @passedInColour NVARCHAR (50) = '',
 @passedInState NVARCHAR (50) = '',
 @passedInReject NVARCHAR (50) = '',
 @passedInStartTime DATETIME = '',
 @passedInEndTime DATETIME = ''
AS
BEGIN

Declare @theID NVARCHAR(50) = '%' + @passedInID;
Declare @theColour NVARCHAR(50) = '%' + @passedInColour;
Declare @theState NVARCHAR(50) =  'INSPECTION_1';
Declare @theRejectReason NVARCHAR(50) = '%'+ @passedInReject;


CREATE TABLE FirstYieldTempTablee(	
Station INT ,	
YoyoNumber INT,	
Reject INT,	
Rework INT	
)

IF @passedInStartTime != '' and @passedInEndTime != ''
	BEGIN
		INSERT INTO FirstYieldTempTablee VALUES (
		('1'),
		(SELECT COUNT(*) FROM YoYolog yl
		INNER JOIN ScheduleTable st ON st.WorkArea = yl.WorkArea
		INNER JOIN SKUTable skuT ON skuT.SKU = st.SKUID
		WHERE SKUID LIKE @theID
		AND Colour LIKE @theColour
		AND yl.InspectionDecision LIKE @theRejectReason
		AND yl.ProdState = 'INSPECTION_1'
		AND  yl.DateTimeOfCompletion BETWEEN @passedInStartTime
		AND @passedInEndTime
		)
		,
		(SELECT COUNT(*) FROM YoYolog yl
		INNER JOIN ScheduleTable st ON st.WorkArea = yl.WorkArea
		INNER JOIN SKUTable skuT ON skuT.SKU = st.SKUID
		INNER JOIN RejectTable rt ON yl.InspectionDecision = rt.Reason
		WHERE SKUID LIKE @theID
		AND Colour LIKE @theColour
		AND yl.InspectionDecision LIKE @theRejectReason
		AND  yl.DateTimeOfCompletion BETWEEN @passedInStartTime
		AND @passedInEndTime
		AND yl.ProdState = 'INSPECTION_1_SCRAP'
		)
		,
		0
		);
		
	END
else
	BEGIN
				INSERT INTO FirstYieldTempTablee VALUES (
		('1'),
		(SELECT COUNT(*) FROM YoYolog yl
		INNER JOIN ScheduleTable st ON st.WorkArea = yl.WorkArea
		INNER JOIN SKUTable skuT ON skuT.SKU = st.SKUID
		WHERE SKUID LIKE @theID
		AND Colour LIKE @theColour
		AND yl.InspectionDecision LIKE @theRejectReason
		AND yl.ProdState = 'INSPECTION_1'
		)
		,
		(SELECT COUNT(*) FROM YoYolog yl
		INNER JOIN ScheduleTable st ON st.WorkArea = yl.WorkArea
		INNER JOIN SKUTable skuT ON skuT.SKU = st.SKUID
		INNER JOIN RejectTable rt ON yl.InspectionDecision = rt.Reason
		WHERE SKUID LIKE @theID
		AND Colour LIKE @theColour
		AND yl.InspectionDecision LIKE @theRejectReason
		AND yl.ProdState = 'INSPECTION_1_SCRAP'
		)
		,
		0
		);
	END
	----------------TWO
	IF @passedInStartTime != '' and @passedInEndTime != ''
	BEGIN
		INSERT INTO FirstYieldTempTablee VALUES (
		('2'),
		(SELECT COUNT(*) FROM YoYolog yl
		INNER JOIN ScheduleTable st ON st.WorkArea = yl.WorkArea
		INNER JOIN SKUTable skuT ON skuT.SKU = st.SKUID
		WHERE SKUID LIKE @theID
		AND Colour LIKE @theColour
		AND yl.InspectionDecision LIKE @theRejectReason
		AND yl.ProdState = 'INSPECTION_2'
		AND  yl.DateTimeOfCompletion BETWEEN @passedInStartTime
		AND @passedInEndTime
		)
		,
		(SELECT COUNT(*) FROM YoYolog yl
		INNER JOIN ScheduleTable st ON st.WorkArea = yl.WorkArea
		INNER JOIN SKUTable skuT ON skuT.SKU = st.SKUID
		INNER JOIN RejectTable rt ON yl.InspectionDecision = rt.Reason
		WHERE SKUID LIKE @theID
		AND Colour LIKE @theColour
		AND yl.InspectionDecision LIKE @theRejectReason
		AND  yl.DateTimeOfCompletion BETWEEN @passedInStartTime
		AND @passedInEndTime
		AND yl.ProdState = 'INSPECTION_2_SCRAP'
		)
		,
		(SELECT COUNT(*) FROM YoYolog yl
		INNER JOIN ScheduleTable st ON st.WorkArea = yl.WorkArea
		INNER JOIN SKUTable skuT ON skuT.SKU = st.SKUID
		INNER JOIN RejectTable rt ON yl.InspectionDecision = rt.Reason
		WHERE SKUID LIKE @theID
		AND Colour LIKE @theColour
		AND yl.InspectionDecision LIKE @theRejectReason
		AND  yl.DateTimeOfCompletion BETWEEN @passedInStartTime
		AND @passedInEndTime
		AND yl.ProdState = 'INSPECTION_2_REWORK'
		));
		
	END
else
	BEGIN
				INSERT INTO FirstYieldTempTablee VALUES (
		('2'),
		(SELECT COUNT(*) FROM YoYolog yl
		INNER JOIN ScheduleTable st ON st.WorkArea = yl.WorkArea
		INNER JOIN SKUTable skuT ON skuT.SKU = st.SKUID
		WHERE SKUID LIKE @theID
		AND Colour LIKE @theColour
		AND yl.InspectionDecision LIKE @theRejectReason
		AND yl.ProdState = 'INSPECTION_2'
		)
		,
		(SELECT COUNT(*) FROM YoYolog yl
		INNER JOIN ScheduleTable st ON st.WorkArea = yl.WorkArea
		INNER JOIN SKUTable skuT ON skuT.SKU = st.SKUID
		INNER JOIN RejectTable rt ON yl.InspectionDecision = rt.Reason
		WHERE SKUID LIKE @theID
		AND Colour LIKE @theColour
		AND yl.InspectionDecision LIKE @theRejectReason
		AND yl.ProdState = 'INSPECTION_2_SCRAP'
		)
		,
		(SELECT COUNT(*) FROM YoYolog yl
		INNER JOIN ScheduleTable st ON st.WorkArea = yl.WorkArea
		INNER JOIN SKUTable skuT ON skuT.SKU = st.SKUID
		INNER JOIN RejectTable rt ON yl.InspectionDecision = rt.Reason
		WHERE SKUID LIKE @theID
		AND Colour LIKE @theColour
		AND yl.InspectionDecision LIKE @theRejectReason
		AND yl.ProdState = 'INSPECTION_2_REWORK'
		));
	END
		----------------Three
	IF @passedInStartTime != '' and @passedInEndTime != ''
	BEGIN
		INSERT INTO FirstYieldTempTablee VALUES (
		('3'),
		(SELECT COUNT(*) FROM YoYolog yl
		INNER JOIN ScheduleTable st ON st.WorkArea = yl.WorkArea
		INNER JOIN SKUTable skuT ON skuT.SKU = st.SKUID
		WHERE SKUID LIKE @theID
		AND Colour LIKE @theColour
		AND yl.InspectionDecision LIKE @theRejectReason
		AND yl.ProdState = 'INSPECTION_3'
		AND  yl.DateTimeOfCompletion BETWEEN @passedInStartTime
		AND @passedInEndTime
		)
		,
		(SELECT COUNT(*) FROM YoYolog yl
		INNER JOIN ScheduleTable st ON st.WorkArea = yl.WorkArea
		INNER JOIN SKUTable skuT ON skuT.SKU = st.SKUID
		INNER JOIN RejectTable rt ON yl.InspectionDecision = rt.Reason
		WHERE SKUID LIKE @theID
		AND Colour LIKE @theColour
		AND yl.InspectionDecision LIKE @theRejectReason
		AND  yl.DateTimeOfCompletion BETWEEN @passedInStartTime
		AND @passedInEndTime
		AND yl.ProdState = 'INSPECTION_3_SCRAP'
		)
		,
		(SELECT COUNT(*) FROM YoYolog yl
		INNER JOIN ScheduleTable st ON st.WorkArea = yl.WorkArea
		INNER JOIN SKUTable skuT ON skuT.SKU = st.SKUID
		INNER JOIN RejectTable rt ON yl.InspectionDecision = rt.Reason
		WHERE SKUID LIKE @theID
		AND Colour LIKE @theColour
		AND yl.InspectionDecision LIKE @theRejectReason
		AND  yl.DateTimeOfCompletion BETWEEN @passedInStartTime
		AND @passedInEndTime
		AND yl.ProdState = 'INSPECTION_3_REWORK'
		));
		
	END
else
	BEGIN
				INSERT INTO FirstYieldTempTablee VALUES (
		('3'),
		(SELECT COUNT(*) FROM YoYolog yl
		INNER JOIN ScheduleTable st ON st.WorkArea = yl.WorkArea
		INNER JOIN SKUTable skuT ON skuT.SKU = st.SKUID
		WHERE SKUID LIKE @theID
		AND Colour LIKE @theColour
		AND yl.InspectionDecision LIKE @theRejectReason
		AND yl.ProdState = 'INSPECTION_3'
		)
		,
		(SELECT COUNT(*) FROM YoYolog yl
		INNER JOIN ScheduleTable st ON st.WorkArea = yl.WorkArea
		INNER JOIN SKUTable skuT ON skuT.SKU = st.SKUID
		INNER JOIN RejectTable rt ON yl.InspectionDecision = rt.Reason
		WHERE SKUID LIKE @theID
		AND Colour LIKE @theColour
		AND yl.InspectionDecision LIKE @theRejectReason
		AND yl.ProdState = 'INSPECTION_3_SCRAP'
		)
		,
		(SELECT COUNT(*) FROM YoYolog yl
		INNER JOIN ScheduleTable st ON st.WorkArea = yl.WorkArea
		INNER JOIN SKUTable skuT ON skuT.SKU = st.SKUID
		INNER JOIN RejectTable rt ON yl.InspectionDecision = rt.Reason
		WHERE SKUID LIKE @theID
		AND Colour LIKE @theColour
		AND yl.InspectionDecision LIKE @theRejectReason
		AND yl.ProdState = 'INSPECTION_3_REWORK'
		));
	END

	SELECT * FROM FirstYieldTempTablee;

	DROP TABLE FirstYieldTempTablee;

END
