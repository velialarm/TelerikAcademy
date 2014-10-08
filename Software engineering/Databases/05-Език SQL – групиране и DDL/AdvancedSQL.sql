-- HOMEWORK FOR Advanced-SQL

-------------------------------------------------------------------------------------------------
-- 	1. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the  company. Use a nested SELECT statement. 

select 
	e.FirstName, 
	e.Salary
from Employees e
where e.Salary = (
		select min(em.Salary) from Employees em
	)

-------------------------------------------------------------------------------------------------
-- 	2. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company. 

select 
	e.*
from  Employees e
where e.Salary <= 1.1*(select min(em.Salary) from Employees em)

-------------------------------------------------------------------------------------------------
-- 	3. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department. Use a nested SELECT statement. 

select 
	e.FirstName + ' '+ COALESCE(e.MiddleName,'') + ' ' + e.LastName as [Employer Full Name],
	e.Salary,
	d.Name as Department
from Employees e
inner join Departments d on d.DepartmentID = e.DepartmentID
where e.Salary = (select min(em.Salary) from Employees em where em.DepartmentID = e.DepartmentID);

-------------------------------------------------------------------------------------------------
-- 	4. Write a SQL query to find the average salary in the department #1. 

select 
	AVG(e.Salary)
from Employees e
where e.DepartmentID = 1

-------------------------------------------------------------------------------------------------
-- 	5. Write a SQL query to find the average salary in the "Sales" department. 

select 
	AVG(e.Salary)
from Employees e
inner join Departments d on d.DepartmentID = e.DepartmentID and d.Name = 'Sales';

-------------------------------------------------------------------------------------------------
-- 	6. Write a SQL query to find the number of employees in the "Sales" department. 

select 
	COUNT(e.EmployeeID) as [Nummber of Employers]
from Employees e
inner join Departments d on d.DepartmentID = e.DepartmentID and d.Name = 'Sales';

-------------------------------------------------------------------------------------------------
-- 	7. Write a SQL query to find the number of all employees that have manager. 
select 
	COUNT(e.EmployeeID)
from Employees e
where e.ManagerID is not null

-------------------------------------------------------------------------------------------------
-- 	8. Write a SQL query to find the number of all employees that have no manager. 

select 
	COUNT(e.EmployeeID)
from Employees e
where e.ManagerID is null

-------------------------------------------------------------------------------------------------
-- 	9. Write a SQL query to find all departments and the average salary for each of them. 
select
	d.Name as [Department],
	AVG(e.Salary) as [Average sallary]
from Employees e
inner join Departments d on d.DepartmentID = e.DepartmentID
group by d.DepartmentID, d.Name;

-------------------------------------------------------------------------------------------------
-- 	10. Write a SQL query to find the count of all employees in each department and for each town. 

select
	d.Name as [Department],
	Count(e.EmployeeID) as [Number of Employers],
	t.Name as Town
from Employees e
inner join Departments d on d.DepartmentID = e.DepartmentID
inner join Addresses a on a.AddressID = e.AddressID
inner join Towns t on t.TownID = a.TownID
group by d.DepartmentID, d.Name, t.TownID, t.Name;


-------------------------------------------------------------------------------------------------
-- 	11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and  last name. 
select 
	m.FirstName, 
	m.LastName
from Employees e
inner join Employees m on m.EmployeeID = e.ManagerID
group by m.EmployeeID, m.FirstName, m.LastName
having count(e.EmployeeID) = 5

-------------------------------------------------------------------------------------------------
-- 	12. Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)". 

select 
	e.FirstName + ' '+ COALESCE(e.MiddleName,'') + ' ' + e.LastName as [Employer Full Name],
	COALESCE((m.FirstName + ' '+ COALESCE(m.MiddleName,'') + ' ' + m.LastName),'no manager') as [Manager Full Name]
from Employees e
left join Employees m on m.EmployeeID = e.ManagerID

-------------------------------------------------------------------------------------------------
-- 	13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function. 

select 
	e.FirstName + ' '+ COALESCE(e.MiddleName,'') + ' ' + e.LastName as [Employer Full Name]
from Employees e
where len(e.LastName) = 5

-------------------------------------------------------------------------------------------------
-- 	14. Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds". Search in Google to find how to format dates in SQL Server. 

SELECT CONVERT(VARCHAR(10), GETDATE(), 104) + ' ' + CONVERT(VARCHAR(13), GETDATE(), 114)

-------------------------------------------------------------------------------------------------
-- 	15. Write a SQL statement to create a table Users. Users should have username, password, full name and last login time. 
-- 		Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint. 
-- 		Define the primary key column as identity to facilitate inserting records. Define unique constraint to avoid repeating usernames. 
-- 		Define a check constraint to ensure the password is at least 5 characters long. 

CREATE TABLE Users
(
    UserId INT IDENTITY PRIMARY KEY,
    Username VARCHAR(32) NOT NULL, 
    Password VARCHAR(32) CHECK(LEN(Password) >= 5),
    FullName VARCHAR(32) NOT NULL,
    LastLogin DATETIME
)

-------------------------------------------------------------------------------------------------
-- 	16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today. Test if the view works correctly. 

CREATE VIEW UsersLoggedToday
AS 
SELECT * FROM Users
WHERE 
		DATEPART(DAYOFYEAR, LastLogin) = DATEPART(DAYOFYEAR, GETDATE()) 
	AND DATEPART(YEAR, LastLogin) = DATEPART(YEAR, GETDATE());

INSERT Users VALUES ('user1', 'pass1', 'Name1 Family1', GETDATE());
INSERT Users VALUES ('user2', 'pass2', 'Name2 Family2', DATEADD(DAY, -10, GETDATE()));

SELECT * FROM UsersLoggedToday;


-------------------------------------------------------------------------------------------------
-- 	17. Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint). Define primary key and identity column. 

CREATE TABLE Groups
(
    GroupId INT IDENTITY PRIMARY KEY,
	Name VARCHAR(16) UNIQUE NOT NULL;
);
insert into Groups (name) values('master');
insert into Groups (name) values('slave');

-------------------------------------------------------------------------------------------------
-- 	18. Write a SQL statement to add a column GroupID to the table Users. Fill some data in this new column and as well in the Groups table. 
-- 		Write a SQL statement to add a foreign key constraint between tables Users and Groups tables. 

ALTER TABLE Users
ADD GroupId INT FOREIGN KEY REFERENCES Groups(GroupId);

-------------------------------------------------------------------------------------------------
-- 	19. Write SQL statements to insert several records in the Users and Groups tables. 

INSERT Users VALUES ('pesho', 'passPesho', 'peshka',  GETDATE(), 1);
INSERT Users VALUES ('Stoqn', 'passStoqn', 'stoqn', GETDATE(), 2);

-------------------------------------------------------------------------------------------------
-- 	20. Write SQL statements to update some of the records in the Users and Groups tables. 

UPDATE Groups SET Name = UPPER(Name);
UPDATE Users SET FullName = Username + ' ' + FullName;

-------------------------------------------------------------------------------------------------
-- 	21. Write SQL statements to delete some of the records from the Users and Groups tables. 
DELETE FROM Users 
WHERE FullName LIKE 'Sto%';
DELETE FROM Groups 
WHERE GroupId = 2;

-------------------------------------------------------------------------------------------------
-- 	22. Write SQL statements to insert in the Users table the names of all employees from the Employees table. 
-- 		Combine the first and last names as a full name. For username use the first letter of the first name + the last name (in lowercase). Use the same for the password, and NULL for last login time. 

insert into Users (FullName,Username,Password,LastLogin) 
	select	
	e.FirstName+' '+ e.LastName,
	SUBSTRING(e.FirstName,1,1) + LOWER(e.LastName),
	SUBSTRING(e.FirstName,1,1) + LOWER(e.LastName),
	null 
	from Employees e
	where len(e.LastName)>=4


-------------------------------------------------------------------------------------------------
-- 	23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010. 

update Users
set Password = null
where LastLogin < '10.03.2010' 

-------------------------------------------------------------------------------------------------
-- 	24. Write a SQL statement that deletes all users without passwords (NULL password). 

delete from Users
where Password is null

-------------------------------------------------------------------------------------------------
-- 	25. Write a SQL query to display the average employee salary by department and job title. 

select 
	 d.Name as [Department Name], 
	 e.JobTitle, 
	 AVG(e.Salary) as [Average Sallary]
from Employees e
inner join Departments d on d.DepartmentID = e.DepartmentID 
group by d.Name, e.JobTitle

-------------------------------------------------------------------------------------------------
-- 	26. Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it. 

select 
	 e.LastName, 
	 e.FirstName,
	 d.Name as [Department Name], 
	 e.JobTitle, 
	 MIN(e.Salary) as [Minimal Sallary]
from Employees e
inner join Departments d on d.DepartmentID = e.DepartmentID 
group by d.Name, e.JobTitle, e.LastName, e.FirstName

-------------------------------------------------------------------------------------------------
-- 	27. Write a SQL query to display the town where maximal number of employees work. 

SELECT
	t.Name as Town, 
	COUNT(e.EmployeeID) as [Number of Employers]
FROM Employees e 
INNER JOIN Addresses a ON e.AddressId = a.AddressId
INNER JOIN Towns t ON t.TownId = a.TownId
GROUP BY t.Name
ORDER BY COUNT(e.EmployeeID) DESC;

-------------------------------------------------------------------------------------------------
-- 	28. Write a SQL query to display the number of managers from each town. 

select 
	t.Name,
	count(e.EmployeeID)
from
(
	select
		e.ManagerID
	from Employees e
	group by e.ManagerID
)as map
inner join Employees e on e.EmployeeID = map.ManagerID 
inner join Addresses a on  a.AddressID = e.AddressID
inner join Towns t on t.TownID = a.TownID
group by t.Name

-------------------------------------------------------------------------------------------------
-- 	29. Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments). 
-- 		Don't forget to define identity, primary key and appropriate foreign key.  Issue few SQL statements to insert, update and delete of some data in the table.  
-- 		Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. For each change keep the old record data, the new record data and the command (insert / update / delete). 

CREATE TABLE WorkHours (
  WorkHoursId int IDENTITY,
  EmployeeId int,
  WorkDate date, 
  Task nvarchar(50),
  NumberHours int,
  Comment text,
  CONSTRAINT PK_WorkHours PRIMARY KEY(WorkHoursId), 
  CONSTRAINT FK_WorkHours_Users FOREIGN KEY(EmployeeId) REFERENCES Employees(EmployeeID)
);

insert WorkHours (EmployeeId, WorkDate, Task, NumberHours, Comment) values (1, GETDATE(), 'Task1', 8, 'Comment 01');
insert WorkHours (EmployeeId, WorkDate, Task, NumberHours, Comment) values (1, GETDATE(), 'Task2', 8, 'Comment 02');
insert WorkHours (EmployeeId, WorkDate, Task, NumberHours, Comment) values (1, GETDATE(), 'Task3', 8, 'Comment 03');

UPDATE WorkHours
SET Comment = 'Comment 01'
WHERE Task = 'Task1';

DELETE FROM WorkHours
WHERE Task = 'Task2';

CREATE TABLE WorkHoursLog(
	Id int IDENTITY,
	OldRecord nvarchar(100) NOT NULL,
	NewRecord nvarchar(100) NOT NULL,
	Command nvarchar(10) NOT NULL,
	EmployeeId int NOT NULL,
	CONSTRAINT PK_WorkHoursLog PRIMARY KEY(Id),
	CONSTRAINT FK_WorkHoursLogs_WorkHours FOREIGN KEY(EmployeeId) REFERENCES WorkHours(WorkHoursId)
);

ALTER TRIGGER tr_WorkHoursInsert 
ON WorkHours 
FOR INSERT 
AS
INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId) values(
	'',
	(select 'Number of Hours: ' + CAST(NumberHours as nvarchar(15)) + ', WorkDate: ' + CAST(WorkDate as nvarchar(50)) from Inserted),
	'INSERT',
	(SELECT EmployeeID FROM Inserted))
;

insert WorkHours (EmployeeId, WorkDate, Task, NumberHours, Comment) values (1, GETDATE(), 'Task7', 8, 'Comment 07');
insert WorkHours (EmployeeId, WorkDate, Task, NumberHours, Comment) values (1, GETDATE(), 'Task8', 8, 'Comment 08');

ALTER TRIGGER tr_WorkHoursUpdate
ON WorkHours 
FOR UPDATE
AS
INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId) values(
	(select 'Number of Hours: ' + CAST(NumberHours as nvarchar(15)) + ', WorkDate: ' + CAST(WorkDate as nvarchar(50)) from deleted),
	(select 'Number of Hours: ' + CAST(NumberHours as nvarchar(15)) + ', WorkDate: ' + CAST(WorkDate as nvarchar(50)) from Inserted),
	'UPDATE',
	(SELECT EmployeeID FROM Inserted))
;

CREATE TRIGGER tr_WorkHoursDelete
ON WorkHours 
FOR DELETE
AS
INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId) values(
	(select 'Number of Hours: ' + CAST(NumberHours as nvarchar(15)) + ', WorkDate: ' + CAST(WorkDate as nvarchar(50)) from deleted),
	'',
	'DELETE',
	(SELECT EmployeeID FROM Inserted))
;


select * from WorkHours;
select * from WorkHoursLog;

-------------------------------------------------------------------------------------------------
-- 	30. Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables. At the end rollback the transaction. 

BEGIN TRAN
delete e from Employees e 
inner join Departments d on d.DepartmentID = e.DepartmentID
where d.Name = 'Sales'
ROLLBACK TRAN

-------------------------------------------------------------------------------------------------
-- 	31. Start a database transaction and drop the table EmployeesProjects. Now how you could restore back the lost table data? 

begin tran
delete from EmployeesProjects
rollback tran

-------------------------------------------------------------------------------------------------
-- 	32. Find how to use temporary tables in SQL Server. Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.

create table #LocalTempTable (EmployeeID int NOT NULL, ProjectID int NOT NULL); -- variant I
-- declare @LocalTempTable table(EmployeeID int NOT NULL, ProjectID int NOT NULL); -- variant II


INSERT INTO #LocalTempTable
SELECT EmployeeID, ProjectID
FROM EmployeesProjects;

DROP TABLE EmployeesProjects;

CREATE TABLE EmployeesProjects(
	EmployeeID int NOT NULL,
	ProjectID int NOT NULL,
	CONSTRAINT PK_EmployeesProjects PRIMARY KEY(EmployeeID, ProjectID),
	CONSTRAINT FK_EP_Employee FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID),
	CONSTRAINT FK_EP_Project FOREIGN KEY(ProjectID) REFERENCES Projects(ProjectID)
);

INSERT INTO EmployeesProjects SELECT EmployeeID, ProjectID FROM #LocalTempTable;

