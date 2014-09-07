use TelerikAcademy

-- task 1: Write a SQL query to find the names and salaries of the employees that take the minimal
-- salary in the company. Use a nested SELECT statement.

SELECT FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName AS Employee, Salary FROM Employees
WHERE Salary = 
(SELECT MIN(Salary) FROM Employees)

-- task 2: Write a SQL query to find the names and salaries of the employees that have a salary
-- that is up to 10% higher than the minimal salary for the company.

SELECT FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName AS Employee, Salary FROM Employees
WHERE Salary BETWEEN
(SELECT MIN(Salary) FROM Employees) AND (SELECT MIN(Salary) FROM Employees) * 1.10

-- task 3: Write a SQL query to find the full name, salary and department of the employees that
-- take the minimal salary in their department. Use a nested SELECT statement.

SELECT e.FirstName + ' ' + ISNULL(e.MiddleName + ' ', '') + e.LastName AS [Full Name], e.Salary, d.Name 
FROM Employees e INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = (SELECT MIN(Salary) FROM Employees WHERE DepartmentID = d.DepartmentID)

-- task 4: Write a SQL query to find the average salary in the department #1

SELECT AVG(Salary) AS [Average Salary Dep#1] FROM Employees
WHERE DepartmentID = 1

-- task 5: Write a SQL query to find the average salary  in the "Sales" department.

SELECT AVG(Salary) AS [Average Salary Sales] FROM Employees e INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

-- task 6: Write a SQL query to find the number of employees in the "Sales" department.

SELECT COUNT(*) AS [Employees Count Sales] FROM Employees e INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

-- task 7: Write a SQL query to find the number of all employees that have manager.

SELECT COUNT(ManagerID) AS [Employees With Manager] FROM Employees

-- task 8: Write a SQL query to find the number of all employees that have no manager.

SELECT COUNT(*) AS [Employees Without Manager] FROM Employees
WHERE ManagerID IS NULL

-- task 9: Write a SQL query to find all departments and the average salary for each of them.

SELECT d.Name AS Department, AVG(Salary) AS [Average Salary]
FROM Employees e INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

-- task 10: Write a SQL query to find the count of all employees in each department and for each town.

SELECT d.Name AS Department, t.Name AS Town, COUNT(*) AS [Employees Count]
FROM Employees e INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
INNER JOIN Addresses a ON a.AddressID = e.AddressID 
INNER JOIN Towns t ON t.TownID = a.TownID
GROUP BY d.Name, t.Name
ORDER BY d.Name, t.Name

-- task 11: Write a SQL query to find all managers that have exactly 5 employees.
-- Display their first name and last name.

SELECT m.FirstName + ' ' + m.LastName AS Manager FROM Employees e
INNER JOIN Employees m ON e.ManagerID = m.EmployeeID
GROUP BY e.ManagerID, m.FirstName, m.LastName
HAVING COUNT(*) = 5

-- task 12: Write a SQL query to find all employees along with their managers.
-- For employees that do not have manager display the value "(no manager)".

SELECT e.FirstName + ' ' + e.LastName AS Employee, COALESCE(m.FirstName + ' ' + m.LastName, '(no manager)') AS Manager 
FROM Employees e LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID

-- task 13: Write a SQL query to find the names of all employees whose last name is exactly 5 characters long.
-- Use the built-in LEN(str) function.

SELECT FirstName + ' ' + LastName AS Employee FROM Employees
WHERE LEN(LastName) = 5

-- task 14: Write a SQL query to display the current date and time in the following format
-- "day.month.year hour:minutes:seconds:milliseconds". Search in Google to find how to format dates in SQL Server.

SELECT CONVERT(VARCHAR, GETDATE(), 113) AS [Current Date]

-- task 15: Write a SQL statement to create a table Users. Users should have username, password, full name and last
-- login time. Choose appropriate data types for the table fields. Define a primary key column with a primary key
-- constraint. Define the primary key column as identity to facilitate inserting records. Define unique constraint
-- to avoid repeating usernames. Define a check constraint to ensure the password is at least 5 characters long.

CREATE TABLE Users (
  UserId int IDENTITY,
  Username nvarchar(50) NOT NULL,
  UserPassword nvarchar(50),
  FullName nvarchar(100),
  LastLoginTime datetime
  CONSTRAINT PK_Users PRIMARY KEY(UserId),
  CONSTRAINT UC_Username UNIQUE (Username),
  CONSTRAINT CC_Password CHECK (LEN(UserPassword) >= 5)
)
GO

INSERT Users
VALUES ('ABCDE', 'ABCDE', 'Ababa Cdcdcd', GETDATE()),
('FGHIJ', 'FGHIJ', 'Fgfgfg Hihihi', GETDATE());
GO

-- task 16: Write a SQL statement to create a view that displays the users from the Users table that have been in 
-- the system today. Test if the view works correctly.

CREATE VIEW [Visited Today] AS
SELECT * FROM Users
WHERE DATEDIFF(DAY, LastLoginTime, GETDATE()) < 1
GO

SELECT * FROM [Visited Today]
GO

-- task 17: Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
-- Define primary key and identity column.

 CREATE TABLE Groups (
  GroupId int IDENTITY,
  Name nvarchar(50) NOT NULL,
  CONSTRAINT PK_Groups PRIMARY KEY(GroupId),
  CONSTRAINT UC_Name UNIQUE (Name),
)
GO

-- task 18: Write a SQL statement to add a column GroupID to the table Users. 
-- Fill some data in this new column and as well in the Groups table. Write a SQL statement to
-- add a foreign key constraint between tables Users and Groups tables.

INSERT Groups
VALUES ('SuperUsers'),
('RegularUsers')
GO

ALTER TABLE Users
ADD GroupId int
GO

UPDATE Users SET GroupId = 1 WHERE UserId = 1
UPDATE Users SET GroupId = 2 WHERE UserId = 2

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups FOREIGN KEY(GroupId)
REFERENCES Groups(GroupId)
GO

-- task 19: Write SQL statements to insert several records in the Users and Groups tables.

INSERT Groups
VALUES ('Moderators')
GO

INSERT Users
VALUES ('Modery', 'Modery', 'First Moderator', GETDATE(), 3),
('Moder', 'Moder', 'Second Moderator', GETDATE(), 3);
GO

-- task 20: Write SQL statements to update some of the records in the Users and Groups tables.

UPDATE Groups SET Name = 'OrdinaryUsers' WHERE GroupId = 2

UPDATE Users SET FullName = 'Kaka Marijka' WHERE UserId = 1
UPDATE Users SET FullName = 'Bat Ivancho' WHERE UserId = 2

-- task 21: Write SQL statements to delete some of the records from the Users and Groups tables.

DELETE FROM Users WHERE UserId = 2

DELETE FROM Groups WHERE GroupId = 2

SELECT * FROM Users
SELECT * FROM Groups

-- task 22: Write SQL statements to insert in the Users table the names of all employees from the
-- Employees table. Combine the first and last names as a full name. For username use the first letter 
-- of the first name + the last name (in lowercase). Use the same for the password, and NULL for last login time.

INSERT INTO Users (UserName, FullName, UserPassword, LastLoginTime)
SELECT LEFT(LOWER(e.FirstName), 1) + LOWER(e.LastName) + CONVERT(nvarchar, e.EmployeeID) AS UserName,
e.FirstName + ' ' + e.LastName AS FullName,
LEFT(LOWER(e.FirstName), 1) + LOWER(e.LastName) + CONVERT(nvarchar, e.EmployeeID) AS UserPassword,
NULL 
FROM Employees e
GO

-- task 23: Write a SQL statement that changes the password to NULL for all users that have not been 
-- in the system since 10.03.2010.

INSERT Users
VALUES ('Dummy', 'Dummy', 'Dummy Dummy', CONVERT(datetime, '01.01.2000',104), 3);
GO

UPDATE Users SET UserPassword = NULL WHERE CONVERT(datetime, LastLoginTime, 104) <= CONVERT(datetime, '01.01.2000',104)

-- task 24: Write a SQL statement that deletes all users without passwords (NULL password).

DELETE FROM Users WHERE UserPassword IS NULL

-- task 25: Write a SQL query to display the average employee salary by department and job title.

SELECT d.Name, JobTitle, AVG(Salary) AS [Average Salary]
FROM Employees e INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, JobTitle

-- task 26: Write a SQL query to display the minimal employee salary by department and job title
-- along with the name of some of the employees that take it.

SELECT em.FirstName, em.LastName, em.DepartmentID, em.JobTitle, em.Salary 
FROM (SELECT e.DepartmentID, e.JobTitle, MIN(Salary) AS [Minimal Salary]
		FROM Employees e
		GROUP BY e.DepartmentID, e.JobTitle) s INNER JOIN Employees em 
		ON em.DepartmentID = s.DepartmentID
		AND em.JobTitle = s.JobTitle
WHERE em.Salary = s.[Minimal Salary]

-- task 27: Write a SQL query to display the town where maximal number of employees work.

SELECT t.Name, COUNT(*) AS [Employees Count] 
FROM Employees e 
INNER JOIN Addresses a ON a.AddressID = e.AddressID 
INNER JOIN Towns t ON t.TownID = a.TownID
GROUP BY t.Name 
HAVING COUNT(*) = (SELECT MAX(c.EmplCount) 
					FROM (SELECT t.Name, COUNT(e.EmployeeID) AS EmplCount 
						FROM Employees e 
						INNER JOIN Addresses a ON e.AddressID = a.AddressID
						INNER JOIN Towns t ON a.TownID = t.TownID
						GROUP BY t.Name) c)

-- task 28: Write a SQL query to display the number of managers from each town.

SELECT t.Name AS Town, COUNT(DISTINCT(e.ManagerID)) AS [Manager Count]
FROM Employees e 
INNER JOIN Employees m ON e.ManagerID = m.EmployeeID
INNER JOIN Addresses a ON a.AddressID = e.AddressID 
INNER JOIN Towns t ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY [Manager Count] DESC

-- task 29: Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
-- Don't forget to define  identity, primary key and appropriate foreign key. 
-- Issue few SQL statements to insert, update and delete of some data in the table.
-- Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
-- For each change keep the old record data, the new record data and the command (insert / update / delete).

CREATE TABLE WorkHours(
TaskId int IDENTITY,
EmployeeID int,
TaskDate datetime NOT NULL,
Task nvarchar(100) NOT NULL,
TaskHours real NOT NULL,
Comments varchar(200)
CONSTRAINT PK_WorkHours PRIMARY KEY(TaskId),
CONSTRAINT CC_TaskHours CHECK (TaskHours > 0 AND TaskHours <= 24),
CONSTRAINT FK_WorkHours_Employees FOREIGN KEY(EmployeeID)
REFERENCES Employees(EmployeeID)
)
GO

CREATE TABLE WorkHoursLogs(
LogId int IDENTITY,
Command varchar(15),
OldTaskId int,
OldEmployeeID int,
OldTaskDate datetime,
OldTask nvarchar(100),
OldTaskHours real,
OldComments varchar(200),
NewTaskId int,
NewEmployeeID int,
NewTaskDate datetime,
NewTask nvarchar(100),
NewTaskHours real,
NewComments varchar(200)
CONSTRAINT PK_WorkHoursLogs PRIMARY KEY(LogId),
)
GO

CREATE TRIGGER tr_WorkHoursInsert ON WorkHours FOR INSERT
AS
INSERT INTO WorkHoursLogs (Command, OldTaskId, OldEmployeeID, OldTaskDate, OldTask, OldTaskHours, OldComments,
NewTaskId, NewEmployeeID, NewTaskDate, NewTask, NewTaskHours, NewComments)
SELECT 'INSERT', NULL, NULL, NULL, NULL, NULL, NULL,
i.TaskId, i.EmployeeID, i.TaskDate, i.Task, i.TaskHours, i.Comments
FROM inserted i
GO

CREATE TRIGGER tr_WorkHoursUpdate ON WorkHours FOR UPDATE
AS
INSERT INTO WorkHoursLogs (Command, OldTaskId, OldEmployeeID, OldTaskDate, OldTask, OldTaskHours, OldComments,
NewTaskId, NewEmployeeID, NewTaskDate, NewTask, NewTaskHours, NewComments)
SELECT 'UPDATE', d.TaskId, d.EmployeeID, d.TaskDate, d.Task, d.TaskHours, d.Comments,
i.TaskId, i.EmployeeID, i.TaskDate, i.Task, i.TaskHours, i.Comments
FROM deleted d INNER JOIN inserted i ON d.TaskId = i.TaskId
GO

CREATE TRIGGER tr_WorkHoursDelete ON WorkHours FOR DELETE
AS
INSERT INTO WorkHoursLogs (Command, OldTaskId, OldEmployeeID, OldTaskDate, OldTask, OldTaskHours, OldComments,
NewTaskId, NewEmployeeID, NewTaskDate, NewTask, NewTaskHours, NewComments)
SELECT 'DELETE', d.TaskId, d.EmployeeID, d.TaskDate, d.Task, d.TaskHours, d.Comments,
NULL, NULL, NULL, NULL, NULL, NULL
FROM deleted d
GO

INSERT WorkHours 
VALUES(1, CONVERT(datetime, '01.03.2014', 104), 'Do homework', 4.5, 'Good work'),
(2, CONVERT(datetime, '21.08.2014', 104), 'Teamwork defence', 0.5, 'Needs more experience'),
(3, CONVERT(datetime, '24.08.2014', 104), 'Nothing to do', 3, 'Marked for deletion');
GO

UPDATE WorkHours
SET Comments = 'Excellent work'
WHERE TaskId = 2
GO

DELETE WorkHours
WHERE Comments = 'Marked for deletion'
GO

-- task 30: Start a database transaction, delete all employees from the 'Sales' department along
-- with all dependent records from the pother tables. At the end rollback the transaction.

BEGIN TRAN 
ALTER TABLE Departments DROP [FK_Departments_Employees]
DELETE FROM Employees
WHERE DepartmentID = (SELECT DepartmentID FROM Departments WHERE Name = 'Sales')
DELETE FROM Departments 
WHERE Name = 'Sales'
ROLLBACK TRAN
GO

-- task 31: Start a database transaction and drop the table EmployeesProjects. Now how you could restore back the lost table data?

BEGIN TRAN 
DROP TABLE EmployeesProjects
ROLLBACK TRAN
GO

-- task 32: Find how to use temporary tables in SQL Server. Using temporary tables backup all records from EmployeesProjects
-- and restore them back after dropping and re-creating the table.

BEGIN TRAN
SELECT * INTO #TempTabl FROM EmployeesProjects
DROP TABLE EmployeesProjects
COMMIT

/****** Object:  Table [dbo].[EmployeesProjects]    Script Date: 25.8.2014 2:56:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeesProjects](
	[EmployeeID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
 CONSTRAINT [PK_EmployeesProjects] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC,
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[EmployeesProjects]  WITH CHECK ADD  CONSTRAINT [FK_EmployeesProjects_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO

ALTER TABLE [dbo].[EmployeesProjects] CHECK CONSTRAINT [FK_EmployeesProjects_Employees]
GO

ALTER TABLE [dbo].[EmployeesProjects]  WITH CHECK ADD  CONSTRAINT [FK_EmployeesProjects_Projects] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ProjectID])
GO

ALTER TABLE [dbo].[EmployeesProjects] CHECK CONSTRAINT [FK_EmployeesProjects_Projects]
GO

INSERT INTO EmployeesProjects
SELECT * FROM #TempTabl
GO