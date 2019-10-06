--Problem 1.	Find Names of All Employees by First Name
Select FirstName, LastName From Employees
Where FirstName Like 'sa%'
Go

--Problem 2.	Find Names of All employees by Last Name
Select FirstName, LastName From Employees
Where LastName Like '%ei%'
Go

--Problem 3.	Find First Names of All Employees
Select FirstName From Employees
Where DepartmentID In (3,10)
And DATEPART(Year, HireDate)  Between 1995 and 2005 
Go

--Problem 4.	Find All Employees Except Engineers
Select FirstName, LastName From Employees
Where JobTitle Not Like '%engineer%'
Go

--Problem 5.	Find Towns with Name Length
Select [Name] From Towns
Where LEN([Name]) in (5,6)
Order By [Name] 
Go

--Problem 6.	 Find Towns Starting With
Select TownID, [Name] From Towns
Where [Name] Like '[mkbe]%' 
Order By [Name]
Go

--Problem 7.	Find Towns Not Starting With 
Select TownID, [Name] From Towns
Where [Name] Not Like '[rbd]%' 
Order By [Name]
Go

--Problem 8.	Create View Employees Hired After 2000 Year
Create View V_EmployeesHiredAfter2000 
As
Select FirstName, LastName From Employees
Where Datepart(Year, HireDate) > 2000
Go

--Problem 9.	Length of Last Name
Select FirstName, LastName From Employees
Where LEN(LastName) = 5
Go

--Problem 10. Rank Employees by Salary
Select EmployeeID, FirstName, LastName, Salary, 
Dense_Rank() Over (Partition by Salary Order By EmployeeID)
As [Rank]
From Employees
Where Salary Between(10000) and 50000
Order by Salary desc
Go

--Problem 11. Find All Employees with Rank 2
Select * From
(Select  EmployeeID, FirstName, LastName, Salary, 
Dense_Rank() Over (Partition by Salary Order By EmployeeID)
As [Rank]
From Employees
Where Salary Between(10000) and 50000) As temp
Where temp.[Rank] = 2
Order by temp.[Salary] desc
Go

--Problem 12. Countries Holding 'A'
Select CountryName, IsoCode From Countries
Where CountryName Like '%A%A%A%'
Order by IsoCode

--Problem 13. Mix of Peak and River Names
Select p.PeakName, r.RiverName,LOWER( CONCAT(LEFT(p.PeakName, LEN(p.PeakName) - 1), r.RiverName)) As [Mix] 
From Peaks as p, Rivers as r
Where RIGHT(p.PeakName,1) = LEFT(r.RiverName, 1)
Order By [Mix]
Go

--Alternative--
SELECT PeakName, RiverName, LOWER(PeakName + SUBSTRING(RiverName, 2 , LEN(RiverName))) 
AS Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix
Go

--Problem 14. Games from 2011 and 2012 year
Select Top 50 [Name],Format([Start],'yyyy-MM-dd') as [Start] From Games
Where DATEPART(YEAR,Start) Between 2011 and 2012
ORDER BY [Start], [Name]
Go

--Problem 15. User Email Providers
Select Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email))
As [Email Provider]
From Users
Order by [Email Provider], Username
Go

--Problem 16. Get Users with IPAdress Like Pattern
Select Username, IpAddress From Users
Where IpAddress Like '___.1_%._%.___'
Order By Username
Go

--Problem 17. Show All Games with Duration and Part of the Day
Select [Name] As [Game], 
Case 
 When Datepart(Hour, [Start]) Between 0 and 11 Then 'Morning'
 When Datepart(Hour, [Start]) Between 12 and 17 Then 'Afternoon'
 Else 'Evening'
End As [Part of the Day],
Case
 When Duration <=3 Then 'Extra Short'
 When Duration Between 4 And 6 Then 'Short'
 When Duration > 6 Then 'Long'
 Else 'Extra Long'
End As [Duration]
From Games
Order by [Game], [Duration], [Part of the Day]

--Problem 18. Orders Table
SELECT Productname, OrderDate, DATEADD(DAY, 3, OrderDate) AS [Pay Due],
DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders
 