CREATE FUNCTION [dbo].[fn_Empl_salaries_list]
(
	@dateBegin datetime2(7),
	@dateEnd datetime2(7)
)
RETURNS TABLE
AS
RETURN
	SELECT [e].[Id] AS [EmployeeId], 
	       [e].[Name],  
	       ISNULL(AVG([SalaryByMonth].[MonthSalary]), 0) AS [AvgSalary], 
	       ISNULL(MAX([SalaryByMonth].[MonthSalary]), 0) AS [MaxSalary], 
		   [e].[Active] 
	FROM [Employees] [e] 
	LEFT JOIN 
		  (
		   SELECT [p].[EmployeeId], SUM([p].[Salary]) AS [MonthSalary]
		   FROM [Payments] [p]
		   WHERE DATEDIFF(month, 0, [p].[Datetime]) BETWEEN DATEDIFF(month, 0, @dateBegin) AND DATEDIFF(month, 0, @dateEnd)
		   GROUP BY [p].[EmployeeId], DATEDIFF(month, 0, [p].[Datetime])
		  ) AS [SalaryByMonth]
	ON  [e].[Id] = [SalaryByMonth].[EmployeeId]
	GROUP BY [e].[Id], [e].[Name], [e].[Active]

