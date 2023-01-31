--Problem 01
CREATE DATABASE [Minions]

GO

--Problem 02
USE [Minions]

GO

CREATE TABLE [Minions](
		[Id] INT PRIMARY KEY,
		[Name] NVARCHAR(30) NOT NULL,
		[Age] INT
)

CREATE TABLE [Towns](
		[Id] INT PRIMARY KEY,
		[Name] NVARCHAR(30) NOT NULL
)

GO

--Problem 03

ALTER TABLE [Minions]
        ADD  [TownId] INT FOREIGN KEY REFERENCES [Towns](Id) NOT  NULL

GO

--Problem 04
INSERT INTO [Towns]([Id],[Name])
     VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

GO

INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
     VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

GO

--Problem 05
TRUNCATE TABLE [Minions]

GO

--Problem 06

DROP TABLE [Minions]
DROP TABLE [Towns]

GO

--Problem 07
CREATE TABLE [People](
			 [Id] INT PRIMARY KEY IDENTITY,
			 [Name] NVARCHAR(200) NOT NULL,
			 [Picture] VARBINARY(MAX), 
			 CHECK (DATALENGTH([Picture]) <= 2000000),
			 [Height] DECIMAL(4,2),
			 [Weight] DECIMAL (5,2),
			 [Gender] CHAR(1) NOT NULL,
			 CHECK ([Gender] = 'm' OR [Gender] = 'f'),
			 [Birthdate] DATE NOT NULL,
			 [Biography] NVARCHAR(MAX) 
)
