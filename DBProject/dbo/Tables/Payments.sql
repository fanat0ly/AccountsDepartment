CREATE TABLE [dbo].[Payments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Salary] MONEY NOT NULL , 
    [Datetime] DATETIME2 NOT NULL CONSTRAINT DF_Payments_Datetime DEFAULT SYSDATETIME() , 
    [EmployeeId] INT NOT NULL, 
    CONSTRAINT [FK_Payments_Employees] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id]) ON DELETE CASCADE
)
