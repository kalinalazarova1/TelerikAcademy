-- task 1: Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and 
-- Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing. Write a stored 
-- procedure that selects the full names of all persons.

CREATE DATABASE FakeBank
GO
 
USE FakeBank

CREATE TABLE Persons(
	PersonId int IDENTITY,
	FirstName nvarchar(20) NOT NULL,
	LastName nvarchar(20) NOT NULL,
	SSN nchar(10) NOT NULL,
	CONSTRAINT PK_Persons PRIMARY KEY(PersonId)
)
GO

CREATE TABLE Accounts(
	AccountId int IDENTITY,
	PersonId int,
	Balance money NOT NULL,
	CONSTRAINT PK_Accounts PRIMARY KEY(AccountId),
	CONSTRAINT FK_Accounts_Persons FOREIGN KEY(PersonId)
	REFERENCES Persons(PersonId)
)
GO

INSERT Persons
VALUES('Ivan','Botev', 9812301724),
('Maria','Ilieva', 8003126394),
('Philip','Venkov', 9202176488)
GO

INSERT Accounts
VALUES(1, 2345.00),
(1, 98000.00),
(2, 23400.00),
(3, 57100.00)
GO

CREATE PROC dbo.usp_PersonsFullNames
AS
	SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM Persons
GO

EXEC usp_PersonsFullNames
GO

-- task 2: Create a stored procedure that accepts a number as a parameter and returns 
-- all persons who have more money in their accounts than the supplied number.

CREATE PROC dbo.usp_AccountsBiggerThan(@limit money)
AS
	SELECT p.FirstName + ' ' + p.LastName AS [Full Name], a.Balance
	FROM Persons p INNER JOIN Accounts a
	ON p.PersonId = a.PersonId
	WHERE a.Balance > @limit
	ORDER BY a.Balance
GO

EXEC usp_AccountsBiggerThan 50000.00
GO

-- task 3: Create a function that accepts as parameters – sum, yearly interest rate and number of months.
-- It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.

CREATE FUNCTION ufn_CalcInterest(@sum money, @year_interest real, @months int)
	RETURNS money
AS
BEGIN
	IF (@months < 1)
		RETURN @sum
	RETURN @sum + @sum * @year_interest / 12 * @months
END
GO

SELECT dbo.ufn_CalcInterest(10000, 0.60, 4)
GO

-- task 4: Create a stored procedure that uses the function from the previous example to give an interest to a person's
-- account for one month. It should take the AccountId and the interest rate as parameters.

CREATE PROC dbo.udp_CalcOneMonthInterest(@accountId int, @year_interest real)
AS
	UPDATE Accounts SET Balance = dbo.ufn_CalcInterest(Balance, @year_interest, 1)
	WHERE AccountId = @accountId
GO

EXEC dbo.udp_CalcOneMonthInterest 2, 0.60
GO

-- task 5: Add two more stored procedures WithdrawMoney( AccountId, money) and DepositMoney (AccountId, money) that operate in transactions.

CREATE PROC dbo.udp_WithdrawMoney(@accountId int, @sum money)
AS
	BEGIN TRAN
	IF ((SELECT COUNT(*) FROM Accounts WHERE AccountID = @AccountID) = 0)
		BEGIN
			ROLLBACK TRAN
			RAISERROR('Invalid account id', 11, 1)
		END
	ELSE
		BEGIN
			DECLARE @newBalance money = (SELECT Balance - @sum FROM Accounts WHERE AccountId = @accountId);
			IF(@newBalance < 0)
				BEGIN
					ROLLBACK TRAN
					RAISERROR('Not enough money for withdrawal', 11, 1)
				END
			ELSE
				BEGIN
					UPDATE Accounts
					SET Balance = @newBalance
					WHERE AccountId = @accountId
					COMMIT
				END
		END
GO 

CREATE PROC dbo.udp_DepositMoney(@accountId int, @sum money)
AS
	BEGIN TRAN
	IF ((SELECT COUNT(*) FROM Accounts WHERE AccountID = @AccountID) = 0)
		BEGIN
			ROLLBACK TRAN
			RAISERROR('Invalid account id', 11, 1)
		END
	ELSE
		BEGIN
			IF(@sum < 0)
				BEGIN
					ROLLBACK TRAN
					RAISERROR('Could not deposit negative amount', 11, 1)
				END
			ELSE
				BEGIN
					UPDATE Accounts
					SET Balance = Balance + @sum
					WHERE AccountId = @accountId
					COMMIT
				END
		END
GO

EXEC dbo.udp_WithdrawMoney 1, 45
GO

EXEC dbo.udp_DepositMoney 1, 100
GO

-- task 6: Create another table – Logs(LogID, AccountID, OldSum, NewSum). Add a trigger to the Accounts table
-- that enters a new entry into the Logs table every time the sum on an account changes.

CREATE TABLE Logs(
	LogId int IDENTITY,
	AccountId int NOT NULL,
	OldSum money NOT NULL,
	NewSum money NOT NULL
	CONSTRAINT PK_Logs PRIMARY KEY(LogId)
)
GO

CREATE TRIGGER tr_SumChanged ON Accounts FOR UPDATE
AS
	IF((SELECT i.Balance - d.Balance FROM deleted d INNER JOIN inserted i ON d.AccountId = i.AccountId) != 0)
		BEGIN
			INSERT INTO Logs(AccountId, OldSum, NewSum)
			SELECT d.AccountId, d.Balance, i.Balance
			FROM deleted d INNER JOIN inserted i ON d.AccountId = i.AccountId
		END

GO

EXEC dbo.udp_DepositMoney 1, 200 
GO

EXEC dbo.udp_WithdrawMoney 1, 200 
GO

-- task 7: Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name)
-- and all town's names that are comprised of given set of letters. Example 'oistmiahf' will return 'Sofia', 'Smith',
-- … but not 'Rob' and 'Guy'.

USE [TelerikAcademy]
GO

CREATE FUNCTION dbo.udf_IsComprisedOf(@input nvarchar(100), @set nvarchar(100))
RETURNS bit
AS
BEGIN
	DECLARE @curChar char = SUBSTRING(@input, 1, 1),
	@curIndex int = 1

	WHILE(@curIndex <= LEN(@input))
		BEGIN
			IF(CHARINDEX(@curChar, @set) = 0)
				BEGIN
					RETURN 0
				END
			ELSE
				BEGIN
					SET @curIndex = @curIndex + 1
					SET @curChar = SUBSTRING(@input, @curIndex, 1)
				END
		END
	RETURN 1
END
GO

SELECT dbo.udf_IsComprisedOf('sofia', 'oistmiahf')
GO

CREATE FUNCTION dbo.udf_FindNamesWithPattern(@pattern nvarchar(100))
RETURNS @tbl_Names TABLE
  (NamesId int IDENTITY PRIMARY KEY NOT NULL,
  [Matched Name] Nvarchar(100) NOT NULL)
AS
BEGIN
	INSERT @tbl_Names
	SELECT FirstName AS Name FROM Employees
	WHERE dbo.udf_IsComprisedOf(FirstName, @pattern) = 1
	INSERT @tbl_Names
	SELECT MiddleName AS Name FROM Employees
	WHERE dbo.udf_IsComprisedOf(FirstName, @pattern) = 1
	INSERT @tbl_Names
	SELECT LastName AS Name FROM Employees
	WHERE dbo.udf_IsComprisedOf(FirstName, @pattern) = 1
	INSERT @tbl_Names
	SELECT Name FROM Towns
	WHERE dbo.udf_IsComprisedOf(Name, @pattern) = 1
	RETURN
END
GO

SELECT * FROM dbo.udf_FindNamesWithPattern('oistmiahf')

-- task 8: Using database cursor write a T-SQL script that scans all employees and 
-- their addresses and prints all pairs of employees that live in the same town.

DECLARE lineCursor CURSOR READ_ONLY FOR
SELECT e1.FirstName, e1.LastName, e2.FirstName, e2.LastName, t1.Name  
FROM Employees e1  
INNER JOIN Addresses a1 ON a1.AddressID = e1.AddressID
INNER JOIN Towns t1 ON t1.TownID = a1.TownID,  
Employees e2
INNER JOIN Addresses a2 ON a2.AddressID = e2.AddressID
INNER JOIN Towns t2 ON t2.TownID = a2.TownID
WHERE t1.TownID = t2.TownID AND e1.EmployeeID <> e2.EmployeeID;
  
OPEN lineCursor
DECLARE @firstName1 nvarchar(50),
		@lastName1 nvarchar(50),
		@firstName2 nvarchar(50),       
		@lastName2 nvarchar(50),
		@town nvarchar(50);  
DECLARE @resultTable table(
		Employee1 nvarchar(100),     
		Employee2 nvarchar(100),
		Town nvarchar(100));
		
FETCH NEXT FROM lineCursor
INTO @firstName1, @lastName1, @firstName2, @lastName2, @town    
WHILE @@FETCH_STATUS = 0  
	BEGIN   
		INSERT INTO @resultTable
		VALUES (@firstName1 + ' ' + @lastName1, @firstName2 + ' ' + @lastName2, @town);
		FETCH NEXT FROM lineCursor 
		INTO @firstName1, @lastName1, @firstName2, @lastName2, @town
	END
CLOSE lineCursor
DEALLOCATE lineCursor

SELECT * FROM @resultTable;
GO 

-- task 9: * Write a T-SQL script that shows for each town a list of all employees that live in it. Sample output:
-- Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
-- Ottawa -> Jose Saraiva

USE TelerikAcademy
GO

DECLARE townCursor CURSOR READ_ONLY FOR
SELECT Name FROM Towns 
OPEN townCursor
DECLARE @town nvarchar(50);
FETCH NEXT FROM townCursor
INTO @town    
WHILE @@FETCH_STATUS = 0  
	BEGIN   
		DECLARE employeeCursor CURSOR READ_ONLY FOR
			SELECT e.FirstName + ' ' + e.LastName
			FROM Employees e INNER JOIN Addresses a ON e.AddressID = a.AddressID
			INNER JOIN Towns T ON a.TownID = t.TownID
			WHERE t.Name = @town
			OPEN employeeCursor
			DECLARE @result nvarchar(MAX),
			@current nvarchar(30)
			FETCH NEXT FROM employeeCursor
			INTO @current
			SET @result = ''
			WHILE @@FETCH_STATUS = 0
				BEGIN
					SET @result = @result + @current + ', '
					FETCH NEXT FROM employeeCursor
					INTO @current
				END
			CLOSE employeeCursor
			DEALLOCATE employeeCursor 
			PRINT @town + ' -> ' + @result
		FETCH NEXT FROM townCursor 
		INTO @town
	END
CLOSE townCursor
DEALLOCATE townCursor 

-- task 10: Define a .NET aggregate function StrConcat that takes as input a sequence of strings 
-- and return a single string that consists of the input strings separated by ','. 
-- For example the following SQL statement should return a single string:
-- SELECT StrConcat(FirstName + ' ' + LastName) FROM Employees

USE TelerikAcademy; 
GO  

sp_configure 'clr enabled', 1 
GO  

RECONFIGURE
GO 

CREATE ASSEMBLY StrConcat
FROM 'C:\StrConcat.dll'
-- change path where StrConcat.dll is located with that from your computer in order to work correctly
GO

CREATE AGGREGATE StrConcat(@input nvarchar(200)) 
RETURNS nvarchar(max)
EXTERNAL NAME StrConcat.Concatenate;
GO

SELECT dbo.StrConcat(FirstName + ' ' + LastName) FROM Employees