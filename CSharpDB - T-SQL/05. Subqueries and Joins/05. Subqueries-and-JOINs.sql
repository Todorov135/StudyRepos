GO

USE [SoftUni]

GO

--Problem 1
SELECT TOP (5) [e].[EmployeeID]
			   ,[e].[JobTitle]
			   ,[a].[AddressID]
			   ,[a].[AddressText]
          FROM [Employees] AS [e]
	INNER JOIN [Addresses] AS [a]
			ON [e].[AddressID] = [a].[AddressID]
	  ORDER BY [a].[AddressID]

--Prolem 2
SELECT TOP(50) [e].[FirstName]
		      ,[e].[LastName]
		      ,[t].[Name] AS [Town]
		      ,[a].[AddressText]
         FROM [Employees] AS [e]
   INNER JOIN [Addresses] AS [a]
   		   ON [a].[AddressID] = [e].AddressID
   INNER JOIN [Towns] AS [t]
		   ON [a].[TownID] = [t].[TownID]
	 ORDER BY [e].[FirstName],[e].[LastName]

--Problem 3
    SELECT [e].[EmployeeID]
	       ,[e].[FirstName]
		   ,[e].[LastName]
		   ,[d].[Name] AS [DepartmentName]
      FROM [Employees] AS [e]
INNER JOIN [Departments] AS [d]
		ON [e].DepartmentID = [d].[DepartmentID]
     WHERE [d].Name = 'Sales'
  ORDER BY [e].[EmployeeID]

--Problem 4
SELECT TOP (5) [e].[EmployeeID]
			   ,[e].[FirstName]
			   ,[e].[Salary]
			   ,[d].[Name] AS [DepartmentName]
          FROM [Employees] AS [e]
    INNER JOIN [Departments] AS [d]
	    	ON [e].DepartmentID = [d].[DepartmentID]
		 WHERE [e].[Salary] > 15000
	  ORDER BY [d].[DepartmentID]

--Problem 5
SELECT TOP (3) [e].[EmployeeID]
			   ,[e].[FirstName]
          FROM [Employees] AS [e]
     LEFT JOIN [EmployeesProjects] AS [ep]
	        ON [e].[EmployeeID] = [ep].[EmployeeID]
	     WHERE [ep].[ProjectID] IS NULL
	  ORDER BY [e].[EmployeeID]

--Problem 6
    SELECT [e].[FirstName]
	       ,[e].[LastName]
		   ,[e].[HireDate]
		   ,[d].[Name] AS [DeptName]
      FROM [Employees] AS [e]
INNER JOIN [Departments] AS [d]
		ON [e].[DepartmentID] = [d].[DepartmentID]
     WHERE [e].[HireDate] > '1999/01/01' AND [d].[Name] IN ('Sales', 'Finance')
  ORDER BY [e].[HireDate]

--Problem 7
SELECT TOP (5) [e].[EmployeeID]
		       ,[e].[FirstName]
		       ,[p].[Name] AS [ProjectName]
          FROM [Employees] AS [e]
     LEFT JOIN [EmployeesProjects] AS [ep]
	    	ON [e].[EmployeeID] = [ep].EmployeeID
     LEFT JOIN [Projects] AS [p]
            ON [ep].[ProjectID] = [p].[ProjectID]
         WHERE [StartDate] > '2002/08/13' AND [EndDate] IS NULL
      ORDER BY [e].[EmployeeID]

--Problem 8
   SELECT [e].[EmployeeID]
          ,[e].[FirstName]
	      ,CASE
		       WHEN DATEPART(YEAR, [p].[StartDate]) >= 2005 THEN NULL
			   ELSE [p].[Name]
			END AS [ProjectName]
     FROM [Employees] AS [e]
LEFT JOIN [EmployeesProjects] AS [ep]
	   ON [e].[EmployeeID] = [ep].EmployeeID
LEFT JOIN [Projects] AS [p]
       ON [ep].[ProjectID] = [p].[ProjectID]
    WHERE [e].[EmployeeID] = 24

--Problem 9
    SELECT [e].[EmployeeID]
		   ,[e].[FirstName]
		   ,[m].[EmployeeID] AS [ManagerID]
		   ,[m].[FirstName] AS [ManagerName]
      FROM [Employees] AS [e]
INNER JOIN [Employees] AS [m]
	    ON [e].[ManagerID] = [m].[EmployeeID]
	 WHERE [m].[EmployeeID] IN (3,7)
  ORDER BY [e].[EmployeeID]

--Problem 10
SELECT TOP (50) [e].[EmployeeID]
				,CONCAT([e].[FirstName], ' ', [e].[LastName]) AS [EmployeeName]
				,CONCAT([m].[FirstName], ' ', [m].[LastName]) AS [ManagerName]
				,[d].[Name] AS [DepartmentName]
		   FROM [Employees] AS [e]
	 INNER JOIN [Employees] AS [m]
		     ON [e].[ManagerID] = [m].[EmployeeID]
	 INNER JOIN [Departments] AS [d]
			 ON [e].[DepartmentID] = [d].[DepartmentID] 
	   ORDER BY [e].[EmployeeID]

--Problem 11
SELECT MIN([AverageSalary]) AS [MinAverageSalary]
  FROM    (
            SELECT AVG([e].[Salary]) AS [AverageSalary]
              FROM [Employees] AS [e]
        INNER JOIN [Departments] AS [d]
		        ON [e].[DepartmentID] = [d].[DepartmentID]
          GROUP BY [d].[Name]
           ) AS [AverageSalarySubQuery]

--Problem 12
 GO

 USE [Geography]

 GO

    SELECT [c].[CountryCode]
		   ,[m].[MountainRange]
		   ,[p].[PeakName]
		   ,[p].[Elevation]
      FROM [Countries] AS [c]
INNER JOIN [MountainsCountries] AS [mc]
		ON [c].[CountryCode] = [mc].[CountryCode]
INNER JOIN [Mountains] AS [m]
		ON [m].[Id] = [mc].[MountainId]
INNER JOIN [Peaks] AS [p]
		ON [m].[Id] = [p].[MountainId]
	 WHERE [c].[CountryName] = 'Bulgaria' AND [p].[Elevation] > 2835
  ORDER BY [p].[Elevation] DESC

--Problem 13
    SELECT [c].[CountryCode],
	       COUNT([c].[CountryName]) AS [MountainRanges]
      FROM [Countries] AS [c]
INNER JOIN [MountainsCountries] AS [mc]
		ON [c].[CountryCode] = [mc].[CountryCode]
INNER JOIN [Mountains] AS [m]
		ON [m].[Id] = [mc].[MountainId]
	 WHERE [c].[CountryName] IN ('Bulgaria', 'Russia' , 'United States')
  GROUP BY [c].[CountryCode], [c].[CountryName]

--Problem 14
SELECT TOP(5) [c].[CountryName]
			  ,[r].[RiverName]
	     FROM [Continents] AS [cnt]
	LEFT JOIN [Countries] AS [c]
           ON [cnt].[ContinentCode] = [c].[ContinentCode]
    LEFT JOIN [CountriesRivers] AS [cr]
           ON [c].[CountryCode] = [cr].[CountryCode]
    LEFT JOIN [Rivers] AS [r]
           ON [cr].[RiverId] = [r].[Id]
	    WHERE [cnt].[ContinentName] = 'Africa'
     ORDER BY [c].[CountryName]

--Problem 16
   SELECT COUNT([c].[ContinentCode]) AS [Count]
     FROM [Countries] AS [c]
LEFT JOIN [MountainsCountries] AS [mc]
	   ON [c].[CountryCode] = [mc].[CountryCode]
LEFT JOIN [Mountains] AS [m]
	   ON [mc].[MountainId] = [m].[Id]
	WHERE [m].[MountainRange] IS NULL

--Problem 17
SELECT TOP(5) [c].[CountryName]
			  ,MAX([p].[Elevation]) AS [HighestPeakElevation]
			  ,MAX([r].[Length]) AS [LongestRiverLength]
         FROM [Countries] AS [c]
    LEFT JOIN [MountainsCountries] AS [mc]
           ON [c].[CountryCode] = [mc].[CountryCode]
    LEFT JOIN [Mountains] AS [m]
	       ON [mc].[MountainId] = [m].[Id]
    LEFT JOIN [Peaks] AS [p]
           ON [m].[Id] = [p].[MountainId]
    LEFT JOIN [CountriesRivers] AS [cr]
	       ON [c].[CountryCode] = [cr].[CountryCode]
    LEFT JOIN [Rivers] AS [r]
		   ON [cr].RiverId = [r].[Id]
	 GROUP BY [c].[CountryName]
	 ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, [c].[CountryName]