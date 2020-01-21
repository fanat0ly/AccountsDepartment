CREATE PROCEDURE [sp_CreateEmployee]
    @name nvarchar(50),
	@active bit,
    @id int out
AS
    INSERT INTO [Employees] (Name, Active)  VALUES (@name, @active)
    SET @id=SCOPE_IDENTITY()
GO
