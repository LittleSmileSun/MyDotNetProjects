USE [Company]
GO

SELECT e.[Id], e.FirstName, e.LastName as EmployeeLastName, e.DepartmentId, 
d.[Id], d.[Name] as DepartmentName
FROM [dbo].[Employee] as e
INNER JOIN [dbo].[Department] as d
ON e.DepartmentId = d.[Id]
GO

-- SELECT e.[Id], e.FirstName, e.LastName as EmployeeLastName, e.DepartmentId, 
-- d.[Id], d.[Name] as DepartmentName
-- FROM [dbo].[Employee] as e
-- LEFT JOIN [dbo].[Department] as d
-- ON e.DepartmentId = d.[Id]
-- GO

-- SELECT e.[Id], e.FirstName, e.LastName as EmployeeLastName, e.DepartmentId, 
-- d.[Id], d.[Name] as DepartmentName
-- FROM [dbo].[Employee] as e
-- RIGHT JOIN [dbo].[Department] as d
-- ON e.DepartmentId = d.[Id]
-- GO

-- SELECT e.[Id], e.FirstName, e.LastName as EmployeeLastName, e.DepartmentId, 
-- d.[Id], d.[Name] as DepartmentName
-- FROM [dbo].[Employee] as e
-- FULL JOIN [dbo].[Department] as d
-- ON e.DepartmentId = d.[Id]
-- GO

-- SELECT e.[Id], e.FirstName, e.LastName as EmployeeLastName, e.DepartmentId, 
-- d.[Id], d.[Name] as DepartmentName
-- FROM [dbo].[Employee] as e
-- CROSS JOIN [dbo].[Department] as d
-- GO

-- SELECT * FROM Employee, Department
-- GO