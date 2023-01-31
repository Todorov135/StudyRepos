GO

USE [SoftUni]
 
GO

--Problem 01
CREATE PROC [usp_GetEmployeesSalaryAbove35000]
AS
BEGIN
SELECT [FirstName]
	   ,[LastName]
  FROM [Employees]
 WHERE [Salary] > 35000
END

GO

--Problem 02
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@salary DECIMAL(18,4))
AS
BEGIN
SELECT [FirstName]
	   ,[LastName]
  FROM [Employees]
 WHERE [Salary] >= @salary
END

GO

--Problem 03
CREATE PROC [usp_GetTownsStartingWith] (@inputString VARCHAR(50))
AS
BEGIN
SELECT [Name] AS [Towns]
  FROM [Towns]
 WHERE [Name] LIKE CONCAT(@inputString, '%')
END

GO

--Problem 04
CREATE PROC [usp_GetEmployeesFromTown] (@town VARCHAR(50))
AS
BEGIN
   SELECT [FirstName]
		  ,[LastName]
     FROM [Employees] AS [e]
LEFT JOIN [Addresses] AS [a]
	   ON [e].[AddressID] = [a].AddressID
LEFT JOIN [Towns] AS [t]
	   ON [a].[TownID] = [t].[TownID]
	WHERE [t].[Name] = @town
END

GO

--Problem 05
CREATE FUNCTION [ufn_GetSalaryLevel] (@salary DECIMAL(18,4))
RETURNS VARCHAR(10) 
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(10)

	IF @salary<30000
	BEGIN
		SET @salaryLevel = 'Low'
	END

	ELSE IF @salary BETWEEN 30000 AND 50000
	BEGIN 
		SET @salaryLevel = 'Average'
	END

	ELSE 
	BEGIN
		SET @salaryLevel = 'High'
	END

	RETURN @salaryLevel

END

GO

--Problem 06
CREATE PROC [usp_EmployeesBySalaryLevel] (@salaryLevel VARCHAR(10))
AS
BEGIN
SELECT [FirstName]
	   ,[LastName]
  FROM (
		SELECT [dbo].[ufn_GetSalaryLevel]([Salary]) 
			AS [SalaryLEvel]
			   ,[FirstName]
			   ,[LastName]
		  FROM [Employees] AS [e]
	   )
	AS [SalaryLavelingSubQuery]
 WHERE [SalaryLavelingSubQuery].[SalaryLEvel] = @salaryLevel
 
END

GO