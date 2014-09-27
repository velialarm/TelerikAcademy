use [Company]
Go

-- Get all departments and how many employees there are in each one. 
-- Sort the result by the number of employees in descending order.


SELECT 
	d.Name AS [Department],
	COUNT(e.Id) AS [NumberOfEmployers]
FROM Employer e
INNER JOIN Department d
	ON d.Id = e.DepartmerntId
GROUP BY d.Name
ORDER BY NumberOfEmployers
;