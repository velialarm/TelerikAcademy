use [Company]
Go

-- Get the full name (first name + “ “ + last name)  of every employee and its salary, 
-- for each employee with salary between $100 000 and $150 000, inclusive. 
-- Sort the results by salary in ascending order.

SELECT
	e.FirstName + ' ' + e.LastName AS [FullName],
	e.Salary
FROM Employer e
WHERE e.Salary BETWEEN 100000 AND 150000
ORDER BY e.Salary ASC