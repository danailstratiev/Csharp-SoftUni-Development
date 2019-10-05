--2.	Find All Information About Departments
Select * From Departments

Go

--3.	Find all Department Names
Select Name From Departments

Go

--4.	Find Salary of Each Employee
Select FirstName, LastName, Salary From Employees

Go

--5.	Find Full Name of Each Employee
Select FirstName, MiddleName , LastName From Employees

Go

--6.	Find Email Address of Each Employee
Select FirstName + '.' + LastName + '@' +  'softuni.bg' 
As [Full Email Address]
From Employees

Go

--7.	Find All Different Employee’s Salaries
Select Distinct Salary From Employees 
Go

--8.	Find all Information About Employees
Select * From Employees 
Where JobTitle = 'Sales Representative'
Go

--9.	Find Names of All Employees by Salary in Range
Select FirstName, LastName, JobTitle From Employees
Where Salary Between 20000 and 30000
Go

--10.	 Find Names of All Employees 
Select FirstName + ' ' + MiddleName + ' ' + LastName As [Full Name]
From Employees
Where Salary = 25000 Or
Salary = 14000 Or
Salary = 12500 Or
Salary = 23600

Go

--11.	 Find All Employees Without Manager
Select FirstName, LastName From Employees
Where ManagerID is Null
Go

--12.	 Find All Employees with Salary More Than 50000
Select FirstName, LastName, Salary From Employees
Where Salary > 50000
Order by Salary DESC 
Go

--13.	 Find 5 Best Paid Employees.
Select top(5) FirstName, LastName From Employees
Order by Salary DESC 
Go

--14.	Find All Employees Except Marketing
Select FirstName, LastName From Employees
Where DepartmentID != 4
Go

--15.	Sort Employees Table
Select * From Employees
Order by Salary Desc,
FirstName Asc,
LastName Desc,
MiddleName Asc
 
Go

--16.	 Create View Employees with Salaries
Create View V_EmployeesSalaries As
Select FirstName, LastName, Salary From Employees
Go

--17.	Create View Employees with Job Titles
Create View V_EmployeeNameJobTitle 
As
Select FirstName + ' ' + ISNULL(MiddleName,'') + '' + LastName 
As [Full Name], JobTitle
As [Job Title]
From Employees
Select *
From V_EmployeeNameJobTitle
Go

--18.	 Distinct Job Titles
Select Distinct [JobTitle]  from Employees
Go

--19.	Find First 10 Started Projects
Select Top(10) * From Projects 
Order by StartDate, Name
Go

--20.	 Last 7 Hired Employees
Select Top(7) FirstName, LastName, HireDate From Employees
Order by HireDate Desc
Go


--21.	Increase Salaries
Update Employees

Set Salary *= 1.12
Where DepartmentID = 1 Or
DepartmentID = 2 Or
DepartmentID = 4 Or 
DepartmentID = 11

Select Salary From Employees
Go


--22.	 All Mountain Peaks
Select [PeakName] From Peaks
Order by PeakName asc
Go
 
 --23.	 Biggest Countries by Population
Select Top(30) [CountryName], [Population] From Countries
Where ContinentCode = 'EU'
Order by Population desc
Go

--24.	 Countries and Currency (Euro / Not Euro)
Select CountryName, CountryCode,
Case When CurrencyCode = 'EUR' Then 'Euro'
Else 'Not Euro'
End As [Currency]
From Countries
Order by CountryName
Go

--25.	 All Diablo Characters
Select [Name] From Characters
Order by Name asc
Go