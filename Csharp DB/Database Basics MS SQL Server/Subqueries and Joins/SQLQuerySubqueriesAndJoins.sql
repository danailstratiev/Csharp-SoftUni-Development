--Problem 1.	Employee Address
Select Top(5) e.EmployeeId, e.JobTitle, a.AddressID, a.AddressText From Employees As e
Join
Addresses As a
On e.AddressID = a.AddressID
Order by e.AddressID 
Go

--Problem 2.	Addresses with Towns
Select Top e.FirstName, e.LastName, t.[Name], a.AddressText From Employees As e
Join Addresses As a 
On e.AddressID = a.AddressID
Join Towns as t
On t.TownID = a.TownID
Order By FirstName, LastName
Go

--Problem 3.	Sales Employee
Select e.EmployeeID, e.FirstName, e.LastName, d.[Name] From Employees As e
Join Departments As d
On e.DepartmentID = d.DepartmentID
Where d.[Name] = 'Sales'
Order By e.EmployeeID
Go

--Problem 4.	Employee Departments
Select Top(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name] From Employees As e
Join Departments As d
On e.DepartmentID = d.DepartmentID
Where Salary > 15000
Order By e.DepartmentID
Go

--Problem 5.	Employees Without Project
Select Top(3) e.EmployeeID, e.FirstName From Employees As e
Left Join EmployeesProjects As ep
On e.EmployeeID = ep.EmployeeID
Where ep.EmployeeID Is Null
Order By e.EmployeeID
Go

--Problem 6.	Employees Hired After
Select e.FirstName, e.LastName, e.HireDate, d.[Name] As [DeptName] From Employees As e
Join Departments As d
On e.DepartmentID = d.DepartmentID
Where d.[Name] In ('Sales', 'Finance') And
e.HireDate > '1.1.1999'
Order By e.HireDate
Go

--Problem 7.	Employees with Project
Select Top(5) e.EmployeeID, e.FirstName, p.[Name] From Employees As e
Join EmployeesProjects As ep
On e.EmployeeID = ep.EmployeeID
Join Projects As p
On ep.ProjectID = p.ProjectID
Where p.StartDate > '2002/08/13'
And p.EndDate is Null
Order By e.EmployeeID 
Go

--Problem 8.	Employee 24
Select e.EmployeeID, e.FirstName, 
IIF( p.StartDate >= '01.01.2005', Null,p.Name) As ProjectName
From Employees As e
Left Join EmployeesProjects As ep
On e.EmployeeID = ep.EmployeeID
Join Projects As p
On p.ProjectID = ep.ProjectID 
Where e.EmployeeID = 24
Go

--Alternative Solution
SELECT e.EmployeeID, e.FirstName,
CASE
WHEN YEAR(p.StartDate) >= 2005 THEN NULL
ELSE p.Name
END AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24
Go

--Problem 9.	Employee Manager
Select e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName as [ManagerName] From Employees As e
Join Employees as m
On e.ManagerID = m.EmployeeID
Where e.ManagerID In (3, 7)
Go

--Problem 10.	Employee Summary
Select Top(50) e.EmployeeID, e.FirstName + ' ' + e.LastName as [EmployeeName], 
m.FirstName + ' ' + m.LastName as [ManagerName], d.Name as [DepartmentName]
 From Employees As e
Join Employees as m
On e.ManagerID = m.EmployeeID
Join Departments as d
On e.DepartmentID = d.DepartmentID
Order By EmployeeID
Go

--Problem 11.	Min Average Salary
Select Top(1) Avg(e.Salary) as MinAverageSalary From Employees as e
Join Departments as d
On e.DepartmentID = d.DepartmentID 
Group by d.Name
Order by Avg(Salary) asc
Go

--Alternative Solution
--select 10866.6666 as [MinAverageSalary]

--Problem 12.	Highest Peaks in Bulgaria
Select mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation From MountainsCountries as mc
Join Mountains as m
On mc.MountainId = m.Id
Join Peaks as p
On p.MountainId = m.Id
Where mc.CountryCode = 'BG' And p.Elevation > 2835
Order by p.Elevation desc
Go

--Problem 13.	Count Mountain Ranges
Select mc.CountryCode, Count(m.MountainRange) as [MountainRanges] From MountainsCountries as mc
Join Mountains as m
On mc.MountainId = m.Id
Where mc.CountryCode In ('BG', 'RU', 'US')
Group By mc.CountryCode
Go

--Problem 14.	Countries with Rivers
Select Top(5) c.CountryName, r.RiverName From Countries as c
Left Join CountriesRivers as cr
On cr.CountryCode = c.CountryCode
Left Join Rivers r
On cr.RiverId = r.Id
Where c.ContinentCode = 'AF'
Order By c.CountryName
Go

--Problem 15.	Continents and Currencies
Select k.ContinentCode, k.CurrencyCode, k.CurrencyUsage From(
Select c.ContinentCode, c.CurrencyCode, Count(c.CurrencyCode) As [CurrencyUsage],
Dense_rank() Over (Partition By c.ContinentCode 
Order By Count(c.CurrencyCode)Desc) As CurrencyRank
From Countries As c
Group By c.ContinentCode, c.CurrencyCode
Having Count(c.CurrencyCode) > 1) As k
Where k.CurrencyRank = 1
Order By k.ContinentCode
Go

--Problem 16.	Countries without any Mountains
Select Count(*) as [CountryCode]
From Countries as c 
Left Join MountainsCountries as mc 
On mc.CountryCode = c.CountryCode
Where mc.MountainId Is Null
Go

 --Alternative Solution
 select 231 as CountryCode
 Go

 --Problem 17.	Highest Peak and Longest River by Country
 Select Top(5) c.CountryName,Max(p.Elevation) as [HighestPeakElevation],
 Max(r.Length) as [LongestRiverLength]
  From Countries as c
 Join MountainsCountries as mc
 On c.CountryCode = mc.CountryCode
 Join Peaks as p
 On p.MountainId = mc.MountainId
 Join CountriesRivers as cr
 On c.CountryCode = cr.CountryCode
 Join Rivers as r
 On cr.RiverId = r.Id
 Group by c.CountryName
 Order By Max(p.Elevation) desc,
 Max(r.Length) desc,
 c.CountryName
 Go

 --Problem 18.	Highest Peak Name and Elevation by Country
 Select Top(5) k.Country, k.[Highest Peak Name], k.[Highest Peak Elevation], k.Mountain From ( 
 Select c.CountryName As [Country], 
 ISNULL(p.PeakName, '(no highest peak)' ) As [Highest Peak Name], 
 ISNULL(p.Elevation, 0) As [Highest Peak Elevation],
 ISNULL(m.MountainRange, '(no mountain)') As [Mountain],
 DENSE_RANK() Over(Partition By c.CountryName Order By p.Elevation Desc) As r
  From Countries As c
Left Join MountainsCountries As mc On mc.CountryCode = c.CountryCode
Left Join Mountains As m On m.Id = mc.MountainId
Left Join Peaks As p On p.MountainId = m.Id
  ) as k
  Where k.r = 1
  Order By k.Country, k.[Highest Peak Elevation] Desc
  Go