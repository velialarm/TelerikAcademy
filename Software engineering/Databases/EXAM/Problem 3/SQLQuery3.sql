use [Company]
Go


-- Get each employee’s full name (first name + “ “ + last name), 
-- project’s name, department’s name, starting and ending date for each employee in project. 
-- Additionally get the number of all reports, which time of reporting 
-- is between the start and end date. 
-- Sort the results first by the employee id, 
-- then by the project id. (This query is slow, be patient!)


SELECT
	e.FirstName + ' ' + e.LastName AS [FullName],
	pr.Name AS [ProjectName],
	d.Name AS [DepartmentName],
	ep.StartingDate AS [StartingDate],
	ep.EndingDate AS [EndingDate],
	r.Id AS [Report Id], --as uniqe number for report
	r.CreatedDate AS [ReportCreateDate]
FROM Employer e
INNER JOIN Department d
	ON d.Id = e.DepartmerntId
LEFT JOIN EmployerProject ep
	ON ep.EmployerId = e.Id
LEFT JOIN Project pr
	ON pr.Id = ep.ProjectId
LEFT JOIN Report r
	ON r.EmployerId = e.Id
ORDER BY e.Id, pr.Id