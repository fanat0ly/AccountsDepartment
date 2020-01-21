CREATE VIEW [dbo].[PaymentsHistory]
	AS 
	SELECT [e].[Id] AS EmployeeID, [e].[Name], [e].[Active], 
	       [p].[Id] AS PaymentId, [p].[Salary], [p].[Datetime]
	FROM [Employees] e
	LEFT JOIN [Payments] p ON e.Id = p.EmployeeId
