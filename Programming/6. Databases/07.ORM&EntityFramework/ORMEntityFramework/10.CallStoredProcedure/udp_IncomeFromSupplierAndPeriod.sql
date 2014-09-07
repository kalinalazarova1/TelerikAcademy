use Northwind
GO

CREATE PROC dbo.IncomeFromSupplierAndPeriod(@start DateTime, @end DateTime, @supplierId int)
AS
	SELECT SUM(d.Quantity * d.UnitPrice) AS [Income]
	FROM Products p 
	INNER JOIN Suppliers s
	ON s.SupplierID = p.SupplierID
	INNER JOIN [Order Details] d
	ON d.ProductID = p.ProductID
	INNER JOIN Orders o 
	ON o.OrderDate BETWEEN @start AND @end
	WHERE s.SupplierID = @supplierId
	GROUP BY s.SupplierID
GO

DECLARE @start datetime = CONVERT(datetime, '24.08.1997', 104);
DECLARE @end datetime = CONVERT(datetime, '31.08.1997', 104);
EXEC dbo.udp_IncomeFromSupplierAndPeriod  @start, @end, 1
GO