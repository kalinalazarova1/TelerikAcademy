USE ToyStore
SELECT Name, Price FROM Toys
WHERE Type = 'puzzle' AND Price > 10
ORDER BY Price

USE ToyStore
SELECT m.Name, COUNT(*) AS [Toys Count] 
FROM Manufacturers m
INNER JOIN Toys t
ON m.Id = t.ManufacturerId
INNER JOIN AgeRanges r
ON r.Id = t.AgeRangeId
WHERE r.MinAge >= 5 AND r.MaxAge <= 10
GROUP BY m.Name

USE ToyStore
SELECT t.Name, t.Price, t.Color FROM Toys t
INNER JOIN Toys_Categories tc
ON t.Id = tc.ToyId
INNER JOIN Categories c
ON c.Id = tc.CategoryId
WHERE c.Name = 'boys'