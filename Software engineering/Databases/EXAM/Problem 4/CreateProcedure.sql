USE [Company]
GO

CREATE PROCEDURE CompanyResult 
  @CandidateNames Names READONLY
AS
DECLARE #LocalTempTable TABLE (
	FullName VARCHAR(32) NOT NULL,
	ProjectName VARCHAR(32),
	DepartmentName VARCHAR(32),
	StartingDate DATETIME,
	EndingDate DATETIME,
	ReportId INT,
	ReportCreateDate DATETIME
)
INSERT INTO #LocalTempTable 
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

GO