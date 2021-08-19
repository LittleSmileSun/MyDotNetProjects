USE [Company]
GO

-- CREATE TABLES

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Department](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Chief] [nvarchar](50) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Employee](
	[Id] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NULL,
	[Salary] [int] NULL,
	[DepartmentId] [int] NOT NULL
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- INSERT DATA

INSERT INTO [dbo].[Department]
           ([Id]
           ,[Name]
           ,[Chief])
     VALUES
           (1, 'Development', 'Ischenko'),
		   (2, 'Design', 'Rudkevych'),
		   (3, 'Testing', 'Ivanov'),
		   (4, 'Analytics', 'Karpova')
GO

INSERT INTO [dbo].[Employee]
           ([Id]
           ,[FirstName]
           ,[LastName]
           ,[Position]
           ,[Salary]
		   ,[DepartmentId])
     VALUES
           (1, 'Den', 'Karpov', 'Junior', NULL, 1),
           (2, 'Mary', 'Stolyar', 'Middle', 100000, 1),
		   (3, 'Petro', 'Marchenko', NULL, 500000, 3),
		   (4, 'Sveta', 'Cat', 'Seniur', 1000000, 4),
		   (5, 'Boris', 'Didenko', 'Middle', 300000, 10),
		   (6, 'Mika', 'Savchenko', 'Junior', 10000, 3)
GO

-- SELECT DATA

SELECT [Id]
      ,[Name]
      ,[Chief]
  FROM [dbo].[Department]

GO

SELECT [Id]
      ,[FirstName]
      ,[LastName]
      ,[Position]
      ,[Salary]
	  ,[DepartmentId]
  FROM [dbo].[Employee]

GO