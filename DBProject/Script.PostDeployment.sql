/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF NOT EXISTS (SELECT * FROM Employees)
BEGIN
	BEGIN TRANSACTION
	ALTER TABLE [dbo].[Payments] DROP CONSTRAINT [FK_Payments_Employees]
	SET IDENTITY_INSERT [dbo].[Employees] ON
	INSERT INTO [dbo].[Employees] ([Id], [Name], [Active]) VALUES (1, N'Вадим', 0)
	INSERT INTO [dbo].[Employees] ([Id], [Name], [Active]) VALUES (3, N'Анна', 0)
	INSERT INTO [dbo].[Employees] ([Id], [Name], [Active]) VALUES (4, N'Елена', 1)
	INSERT INTO [dbo].[Employees] ([Id], [Name], [Active]) VALUES (5, N'Сергей', 1)
	INSERT INTO [dbo].[Employees] ([Id], [Name], [Active]) VALUES (6, N'Анатолий', 1)
	SET IDENTITY_INSERT [dbo].[Employees] OFF
	SET IDENTITY_INSERT [dbo].[Payments] ON
	INSERT INTO [dbo].[Payments] ([Id], [Salary], [Datetime], [EmployeeId]) VALUES (1, 25000.0000, '20191113 12:30:00.0000000', 1)
	INSERT INTO [dbo].[Payments] ([Id], [Salary], [Datetime], [EmployeeId]) VALUES (2, 30000.0000, '20191113 12:35:00.0000000', 3)
	INSERT INTO [dbo].[Payments] ([Id], [Salary], [Datetime], [EmployeeId]) VALUES (3, 27000.0000, '20191113 12:40:00.0000000', 5)
	INSERT INTO [dbo].[Payments] ([Id], [Salary], [Datetime], [EmployeeId]) VALUES (4, 10000.0000, '20191119 12:30:00.0000000', 5)
	INSERT INTO [dbo].[Payments] ([Id], [Salary], [Datetime], [EmployeeId]) VALUES (5, 31000.0000, '20191128 11:00:00.0000000', 1)
	INSERT INTO [dbo].[Payments] ([Id], [Salary], [Datetime], [EmployeeId]) VALUES (6, 19000.0000, '20191128 11:10:00.0000000', 5)
	INSERT INTO [dbo].[Payments] ([Id], [Salary], [Datetime], [EmployeeId]) VALUES (7, 29000.0000, '20191210 17:40:00.0000000', 1)
	INSERT INTO [dbo].[Payments] ([Id], [Salary], [Datetime], [EmployeeId]) VALUES (8, 47000.0000, '20191210 17:43:00.0000000', 4)
	INSERT INTO [dbo].[Payments] ([Id], [Salary], [Datetime], [EmployeeId]) VALUES (9, 35000.0000, '20191210 17:45:00.0000000', 5)
	INSERT INTO [dbo].[Payments] ([Id], [Salary], [Datetime], [EmployeeId]) VALUES (10, 21000.0000, '20191230 15:50:00.0000000', 1)
	INSERT INTO [dbo].[Payments] ([Id], [Salary], [Datetime], [EmployeeId]) VALUES (11, 43000.0000, '20191230 15:51:00.0000000', 4)
	INSERT INTO [dbo].[Payments] ([Id], [Salary], [Datetime], [EmployeeId]) VALUES (12, 39000.0000, '20191230 15:52:00.0000000', 5)
	INSERT INTO [dbo].[Payments] ([Id], [Salary], [Datetime], [EmployeeId]) VALUES (13, 20000.0000, '20200110 10:51:27.0000000', 4)
	INSERT INTO [dbo].[Payments] ([Id], [Salary], [Datetime], [EmployeeId]) VALUES (14, 17000.0000, '20200110 12:51:36.0000000', 5)
	INSERT INTO [dbo].[Payments] ([Id], [Salary], [Datetime], [EmployeeId]) VALUES (15, 19000.0000, '20200118 12:51:46.0000000', 4)
	INSERT INTO [dbo].[Payments] ([Id], [Salary], [Datetime], [EmployeeId]) VALUES (16, 17500.0000, '20200129 13:53:36.0000000', 6)
	INSERT INTO [dbo].[Payments] ([Id], [Salary], [Datetime], [EmployeeId]) VALUES (17, 40000.0000, '20200129 13:53:46.0000000', 4)
	INSERT INTO [dbo].[Payments] ([Id], [Salary], [Datetime], [EmployeeId]) VALUES (18, 32600.0000, '20200129 13:53:55.0000000', 5)
	SET IDENTITY_INSERT [dbo].[Payments] OFF
	ALTER TABLE [dbo].[Payments]
		ADD CONSTRAINT [FK_Payments_Employees] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employees] ([Id]) ON DELETE CASCADE
	COMMIT TRANSACTION
END