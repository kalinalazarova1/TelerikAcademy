CREATE DATABASE Test
GO

USE Test
GO

CREATE TABLE Logs(
	Id int NOT NULL IDENTITY,
	LogDate datetime,
	LogText nvarchar(200),
	CONSTRAINT PK_Logs_Id PRIMARY KEY (Id)
)
GO

CREATE PROC usp_SeedLogs
AS
DECLARE @counter int = 1
WHILE(@counter <= 200000)
BEGIN
	INSERT INTO Logs(LogDate, LogText)
	VALUES(DATEADD(MINUTE, @counter, GETDATE()), 'Text ' + CONVERT(nvarchar, @counter))
	SET @counter = @counter + 1 
END
GO

EXEC usp_SeedLogs

-- task 1 --
USE Test
CHECKPOINT; DBCC DROPCLEANBUFFERS;
SELECT * FROM Logs
WHERE YEAR(LogDate) BETWEEN 2013 AND 2014 

-- task 2 --
USE Test
CHECKPOINT; DBCC DROPCLEANBUFFERS;
CREATE INDEX IDX_Logs_LogDate ON Logs(LogDate)
SELECT * FROM Logs
WHERE YEAR(LogDate) BETWEEN 2013 AND 2014 -- With index is even slower - does not use the made index

-- task 3 --

---- without index -----

CHECKPOINT; DBCC DROPCLEANBUFFERS
SELECT * FROM Logs
WHERE LogText LIKE 'Text%'

---- with index -----

CREATE FULLTEXT CATALOG LogFullTextCatalog
CREATE FULLTEXT INDEX ON Logs(LogText)
KEY INDEX PK_Logs_Id
ON LogFullTextCatalog
WITH CHANGE_TRACKING AUTO
 
CHECKPOINT; DBCC DROPCLEANBUFFERS
SELECT * FROM Logs
WHERE CONTAINS(LogText, 'Text')
