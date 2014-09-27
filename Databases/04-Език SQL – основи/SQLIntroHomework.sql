-- HOMEWORK SQL Intro
-------------------------------------------------------------------------------------------------

-- 1. What is SQL? What is DML? What is DDL? Recite the most important SQL commands.
	--  What is SQL? - The Structured Query Language (SQL) is the set of instructions used to interact with a relational database. In fact, SQL is the only language that most databases actually understand. Whenever you interact with such a database, the software translates your commands (whether they are mouse clicks or form entries) into SQL statement that the database knows how to interpret. 
	--  What is DDL? - A data manipulation language (DML) is a family of syntax elements similar to a computer programming language used for selecting, inserting, deleting and updating data in a database. Performing read-only queries of data is sometimes also considered a component of DML.
	--  Most important SQL commands are SELECT, INSERT, UPDATE, DELETE
-------------------------------------------------------------------------------------------------
-- 2. What is Transact-SQL (T-SQL)?
	-- Transact-SQL (T-SQL) is Microsoft's and Sybase's proprietary extension to SQL. SQL, the acronym for Structured Query Language, is a standardized computer language that was originally developed by IBM for querying, altering and defining relational databases, using declarative statements. T-SQL expands on the SQL standard to include procedural programming, local variables, various support functions for string processing, date processing, mathematics, etc. and changes to the DELETE and UPDATE statements. 

-------------------------------------------------------------------------------------------------
-- 3. Start SQL Management Studio and connect to the database TelerikAcademy. Examine the major tables in the "TelerikAcademy" database.

use TelerikAcademy;

-------------------------------------------------------------------------------------------------
-- 4. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).

select 
	d.Name as DepartmentName,
	e.FirstName +' '+e.LastName as ManagerName 
from Departments as d
inner join Employees as e on e.ManagerID = d.ManagerID
order by d.Name;

-------------------------------------------------------------------------------------------------
-- 5. Write a SQL query to find all department names.

select d.Name from Departments d;

-------------------------------------------------------------------------------------------------
-- 6. Write a SQL query to find the salary of each employee

select 
	e.FirstName+' '+e.LastName as EmployerName,
	e.Salary
from Employees as e;

-------------------------------------------------------------------------------------------------
-- 7. Write a SQL to find the full name of each employee.

select 
	e.FirstName + ' '+ COALESCE(e.MiddleName,'') + ' ' + e.LastName as [Employer Full Name]
from Employees as e;

-------------------------------------------------------------------------------------------------
-- 8. Write a SQL query to find the email addresses of each employee (by his first and last name). 
-- 	Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses".

select 
	e.FirstName + ' '+ COALESCE(e.MiddleName,'') + ' ' + e.LastName as [Employer Full Name],
	e.FirstName + '.' + e.LastName + '@telerik.com' as [Email Address]
from Employees e;

-------------------------------------------------------------------------------------------------
-- 9. Write a SQL query to find all different employee salaries.

select 
	e.Salary
from Employees as e
group by e.Salary;

-------------------------------------------------------------------------------------------------
-- 10. Write a SQL query to find all information about the employees whose job title is "Sales Representative".

select * from Employees e
where e.JobTitle = 'Sales Representative';

-------------------------------------------------------------------------------------------------
-- 11. Write a SQL query to find the names of all employees whose first name starts with "SA".

select 
	e.FirstName,
	e.MiddleName,
	e.LastName
from Employees e
where e.FirstName LIKE 'SA%';

-------------------------------------------------------------------------------------------------
-- 12. Write a SQL query to find the names of all employees whose last name contains "ei".

select 
	e.FirstName,
	e.MiddleName,
	e.LastName
from Employees e
where e.LastName LIKE '%ei%';

-------------------------------------------------------------------------------------------------
-- 13. Write a SQL query to find the salary of all employees whose salary is in the range [20000...30000].

select * from Employees e
where e.Salary between 20000 and 30000;

-------------------------------------------------------------------------------------------------
-- 14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.

select * from Employees e
where e.Salary in (25000, 14000, 12500, 23600);

-------------------------------------------------------------------------------------------------
-- 15. Write a SQL query to find all employees that do not have manager.

select * from Employees e
where e.ManagerID IS NULL;

-------------------------------------------------------------------------------------------------
-- 16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary

select * from Employees e
where e.Salary > 50000;

-------------------------------------------------------------------------------------------------
-- 17. Write a SQL query to find the top 5 best paid employees.

select top 5 * from Employees e
order by e.Salary DESC;

-------------------------------------------------------------------------------------------------
-- 18. Write a SQL query to find all employees along with their address. Use inner join with ON clause.

select * from Employees e
inner join Addresses a on a.AddressID = e.AddressID;

-------------------------------------------------------------------------------------------------
-- 19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).

select * from Employees e, Addresses a
where e.AddressID = a.AddressID;

-------------------------------------------------------------------------------------------------
-- 20. Write a SQL query to find all employees along with their manager.
select 
	e.FirstName +' '+e.LastName as Employe,
	m.FirstName +' '+m.LastName as Manager 
from Employees e
inner join Employees m on m.EmployeeID = e.ManagerID;

-------------------------------------------------------------------------------------------------
-- 21. Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.

select 
	e.FirstName +' '+e.LastName as Employe,
	m.FirstName +' '+m.LastName as Manager,
	a.AddressText as [Manager Address]
from Employees e
inner join Employees m on m.EmployeeID = e.ManagerID
inner join Addresses a on a.AddressID = m.AddressID;

-------------------------------------------------------------------------------------------------
-- 22. Write a SQL query to find all departments and all town names as a single list. Use UNION.

select d.Name from Departments d
union
select t.Name from Towns t;

-------------------------------------------------------------------------------------------------
-- 23. Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join.

select 
	e.FirstName +' '+e.LastName as Employe,
	m.FirstName +' '+m.LastName as Manager 
from Employees e
join Employees m on m.EmployeeID = e.ManagerID;

select
	e.FirstName +' '+e.LastName as Employe,
	m.FirstName +' '+m.LastName as Manager 
from Employees m
right join Employees e on e.ManagerID = m.EmployeeID

-------------------------------------------------------------------------------------------------
-- 24. Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.

select
	e.FirstName,
	e.MiddleName,
	e.LastName
from Employees e
inner join Departments d 
	on d.DepartmentID = e.DepartmentID 
		and d.Name in('Sales', 'Finance')
where YEAR(e.HireDate) between 1995 and 2005

