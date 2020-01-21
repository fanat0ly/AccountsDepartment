CREATE PROCEDURE [sp_CreatePayment]
    @salary money,
	@datetime datetime2(7),
    @empId int,
	@id int out
AS
    INSERT INTO [Payments] (Salary, Datetime, EmployeeId)  VALUES (@salary, @datetime, @empId)
    SET @id=SCOPE_IDENTITY()
GO