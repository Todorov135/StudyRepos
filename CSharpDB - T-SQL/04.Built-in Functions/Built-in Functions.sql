USE [SoftUni]

--Problem 1
SELECT [FirstName], [LastName]
  FROM [Employees]
 --WHERE [FirstName] Like 'Sa%'
 WHERE LEFT([FirstName], 2) = 'Sa'

 --Problem 2
SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [LastName] LIKE '%ei%'

 --Problem 3
 SELECT [FirstName]
  FROM [Employees]
 WHERE [DepartmentID] IN (3,10) AND DATEPART (YEAR,[HireDate]) BETWEEN 1995 AND 2005 

 --Problem 4
 SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [JobTitle] NOT LIKE '%engineer%'

 --Problem 5
  SELECT [Name]
    FROM [Towns]
   WHERE LEN([Name]) IN (5,6)
ORDER BY [Name]

--Problem 6
  SELECT *
    FROM [Towns]
   WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name]

--Problem 7
  SELECT *
    FROM [Towns]
   WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name]

--Problem 8
CREATE VIEW [V_EmployeesHiredAfter2000]
         AS
	 SELECT [FirstName], [LastName]
	   FROM [Employees]
	  WHERE DATEPART(YEAR, [HireDate]) > 2000

--Problem 9
SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE LEN([LastName]) = 5 

--Problem 10
  SELECT [EmployeeID], [FirstName], [LastName], [Salary],
    	   DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
    FROM [Employees]
   WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

--Problem 11
  SELECT *
    FROM (
	    	SELECT [EmployeeID], [FirstName], [LastName], [Salary],
                 DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
            FROM [Employees]
           WHERE [Salary] BETWEEN 10000 AND 50000
         )
      AS [RankingSubquery]
   WHERE [Rank] = 2
ORDER BY [Salary] DESC

--Problem 12
GO

USE [Geography]

GO

  SELECT [CountryName], [IsoCode]
    FROM [Countries]
   WHERE LOWER([CountryName]) LIKE '%a%a%a%'
ORDER BY [IsoCode]

--Problem 13
   SELECT [PeakName], [RiverName],
   	      LOWER(CONCAT(LEFT([p].[PeakName],LEN([p].[PeakName])-1),[r].[RiverName]))
    	AS [Mix]
     FROM [Peaks] AS [p]
   	   ,[Rivers] AS [r]	   
    WHERE RIGHT([p].[PeakName],1) = LEFT([r].[RiverName],1)
 ORDER BY [Mix]

--Problem 14
GO

USE [Diablo]

GO

SELECT TOP (50) [Name]
				, FORMAT([Start], 'yyyy-MM-dd')
      FROM [Games]
     WHERE DATEPART (YEAR,[Start]) BETWEEN 2011 and 2012
  ORDER BY [Start], [Name]

--Problem 15
  SELECT [Username]
	     ,SUBSTRING([Email], CHARINDEX('@', [Email])+1, LEN([Email]))
	  AS [Email Provider]
    FROM [Users]
ORDER BY [Email Provider], [Username]

--Problem 16
  SELECT [Username],[IpAddress]
    FROM [Users]
   WHERE [IpAddress] LIKE '___.1_%._%.___'
ORDER BY [Username]

--Problem 17
SELECT [Name]
	   , CASE 
			 WHEN DATEPART (HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
			 WHEN DATEPART (HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
			 ELSE 'Evening'
	     END AS [Part of the Day]
	   , CASE
			 WHEN [Duration] <=3 THEN 'Extra Short'
			 WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
			 WHEN [Duration] > 6 THEN 'Long'
			 ELSE 'Extra Long'
		 END AS [Duration]
  FROM [Games] AS [g]
ORDER BY [g].[Name], [Duration]

--Problem 18
GO

CREATE DATABASE [Demo]

GO
GO

USE [Demo]

GO

CREATE TABLE [Orders](
			 [Id] INT PRIMARY KEY IDENTITY,
			 [ProductName] NVARCHAR(100) NOT NULL,
			 [OrderDate] DATETIME2 NOT NULL
)
INSERT INTO [Orders]([ProductName], [OrderDate])
	 VALUES
			('Butter', '2016-09-19 00:00:00.000'),
			('Milk', '2016-09-30 00:00:00.000'),
			('Cheese', '2016-09-04 00:00:00.000'),
			('Bread', '2015-12-20 00:00:00.000'),
			('Tomatoes', '2015-12-30 00:00:00.000')

SELECT [ProductName],
	   [OrderDate],
	   DATEADD(DAY,3,[OrderDate])
	AS [Pay Due],
       DATEADD(MONTH,1,[OrderDate])
	AS [Deliver Due]
  FROM [Orders] 