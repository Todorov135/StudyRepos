GO

CREATE DATABASE [Table Relations]

GO

GO

USE [Table Relations]

GO
--Problem 1
CREATE TABLE [Passports](
			 [PassportID] INT PRIMARY KEY IDENTITY(101,1),
			 [PassportNumber] VARCHAR(20) 
)

CREATE TABLE [Persons](
			 [PersonID] INT PRIMARY KEY IDENTITY,
			 [FistName] NVARCHAR(30) NOT NULL,
			 [Salary] DECIMAL(7,2) NOT NULL,
			 [PassportID] INT FOREIGN KEY REFERENCES [Passports]([PassportID]) UNIQUE
)

--Problem 2
CREATE TABLE [Manufacturers](
			 [ManufacturerID] INT PRIMARY KEY IDENTITY,
			 [Name] VARCHAR(30) NOT NULL,
			 [EstablishedOn] DATE NOT NULL
)
CREATE TABLE [Models](
			 [ModelID] INT PRIMARY KEY IDENTITY(101,1),
			 [Name] VARCHAR(50) NOT NULL,
			 [ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers]([ManufacturerID])
)

--Problem 3
CREATE TABLE [Students](
			 [StudentID] INT PRIMARY KEY IDENTITY,
			 [Name] NVARCHAR(30) NOT NULL
)
CREATE TABLE [Exams](
			 [ExamID] INT PRIMARY KEY IDENTITY(101,1),
			 [Name] NVARCHAR(50) NOT NULL
)
CREATE TABLE [StudentsExams](
			 [StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]),
			 [ExamID] INT FOREIGN KEY REFERENCES [Exams]([ExamID]),
			 PRIMARY KEY ([StudentID],[ExamID])
)

--Problem 4
CREATE TABLE [Teachers](
			 [TeacherID] INT PRIMARY KEY IDENTITY(101,1),
			 [Name] NVARCHAR(30) NOT NULL,
			 [ManagerID] INT FOREIGN KEY REFERENCES [Teachers]([TeacherID])
)

--Problem 5
CREATE TABLE [Cities*](
			 [CityID] INT PRIMARY KEY IDENTITY,
			 [Name] VARCHAR(50) NOT NULL
)
CREATE TABLE [Customers*](
			 [CustomerID] INT PRIMARY KEY IDENTITY,
			 [Name] VARCHAR(50) NOT NULL,
			 [Birthday] DATE NOT NULL,
			 [CityID] INT FOREIGN KEY REFERENCES [Cities*]([CityID]) NOT NULL
)
CREATE TABLE [Orders*](
			 [OrderID] INT PRIMARY KEY IDENTITY,
			 [CustomerID] INT FOREIGN KEY REFERENCES [Customers*]([CustomerID]) NOT NULL
)
CREATE TABLE [ItemTypes*](
			 [ItemTypeID] INT PRIMARY KEY IDENTITY,
			 [Name] VARCHAR(50) NOT NULL
)
CREATE TABLE [Items*](
			 [ItemID] INT PRIMARY KEY IDENTITY,
			 [Name] VARCHAR(50) NOT NULL,
			 [ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes*]([ItemTypeID])NOT NULL
)
CREATE TABLE [OrderItems*](
			 [OrderID] INT FOREIGN KEY REFERENCES [Orders*]([OrderID]) NOT NULL,
			 [ItemID] INT FOREIGN KEY REFERENCES [Items*]([ItemID]) NOT NULL
			 PRIMARY KEY ([OrderID],[ItemID])
)
