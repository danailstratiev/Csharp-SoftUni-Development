--Problem 1.	Records’ Count
Select Count(*) As [Count] From WizzardDeposits
Go
--Problem 2.	Longest Magic Wand
Select Max(MagicWandSize) As [LongestMagicWand] From WizzardDeposits
Go
--Problem 3.	Longest Magic Wand per Deposit Groups
Select DepositGroup, Max(MagicWandSize) As [LongestMagicWand] From WizzardDeposits
Group by DepositGroup
Go

--Problem 4.	* Smallest Deposit Group per Magic Wand Size
Select Top(2) DepositGroup From WizzardDeposits
Group by DepositGroup
Order By Avg(MagicWandSize)
Go

--Alternative

Select DepositGroup From 
(Select Top(2) DepositGroup,Avg(MagicWandSize) As [AvgWandSize]  From WizzardDeposits
Group by DepositGroup
Order By [AvgWandSize]) As AvgSizeTable
Go

--Problem 5.	Deposits Sum
Select DepositGroup, Sum(DepositAmount) As [TotalSum]  From WizzardDeposits
Group by DepositGroup
Go

--Problem 6.	Deposits Sum for Ollivander Family
Select DepositGroup, Sum(DepositAmount) As [TotalSum]  From WizzardDeposits
Where MagicWandCreator = 'Ollivander family'
Group by DepositGroup
Go

--Problem 7.	Deposits Filterkk
Select DepositGroup, Sum(DepositAmount) As [TotalSum]  From WizzardDeposits w
Where MagicWandCreator = 'Ollivander family'
Group by DepositGroup
Having
Sum(DepositAmount) < 150000
Order by TotalSum Desc
Go

--Problem 8.	Deposit Charge
Select DepositGroup, MagicWandCreator, Min(DepositCharge) As [MinDepositCharge] 
From WizzardDeposits
Group By DepositGroup,MagicWandCreator
Order by MagicWandCreator,DepositGroup

--Problem 9.	Age Groups
Select
Case 
 When Age Between 0 and 10 Then '[0-10]'
 When Age Between 11 and 20 Then '[11-20]'
 When Age Between 21 and 30 Then '[21-30]'
 When Age Between 31 and 40 Then '[31-40]'
 When Age Between 41 and 50 Then '[41-50]'
 When Age Between 51 and 60 Then '[51-60]'
 Else '[61+]'
 End As [AgeGroup],
 Count(*) As [WizardCount]
 From WizzardDeposits
 Group By Case 
 When Age Between 0 and 10 Then '[0-10]'
 When Age Between 11 and 20 Then '[11-20]'
 When Age Between 21 and 30 Then '[21-30]'
 When Age Between 31 and 40 Then '[31-40]'
 When Age Between 41 and 50 Then '[41-50]'
 When Age Between 51 and 60 Then '[51-60]'
 Else '[61+]'
 End
 Go

 --Problem 10.   First Letter
 Select Left(FirstName, 1) As FirstLetter From WizzardDeposits
 Group By FirstName


 --Problem 11.	Average Interest 
Select DepositGroup, IsDepositExpired, AVG(DepositInterest) As AverageInterest From WizzardDeposits
Where DepositStartDate > '01/01/1985'
Group By DepositGroup, IsDepositExpired
Order By DepositGroup Desc, IsDepositExpired
Go

--Problem 12.	Rich Wizard, Poor Wizard
Select SUM([Difference]) As SumDifference From (Select FirstName As [HostWizard],
DepositAmount As [Host Wizard Deposit],
LEAD(FirstName) Over(Order By Id) As [Guest Wizard],
LEAD(DepositAmount) Over(Order By Id) As [Guest Wizard Deposit],
DepositAmount - LEAD(DepositAmount) Over(Order By Id) As [Difference]
From WizzardDeposits) As DiffTable
Go

--Problem 13.	Departments Total Salaries
Select DepartmentID, SUM(Salary) As [TotalSalary] From Employees
Group By DepartmentID
Order By DepartmentID
Go

--Problem 14.	Employees Minimum Salaries
Select DepartmentID, Min(Salary) As MinimumSalary From Employees
Where DepartmentID In (2,5,7) And
 HireDate > '01/01/2000'
Group By DepartmentID
Go

--Problem 15.	Employees Average Salaries
Select * Into NewEmployeeTable From Employees 
Where Salary > 30000

Delete From NewEmployeeTable
Where ManagerID = 42

Update NewEmployeeTable
Set Salary += 5000
Where DepartmentID = 1

Select DepartmentID, AVG(Salary) As [AverageSalary] From NewEmployeeTable
Group By DepartmentID
Go

--Problem 16.	Employees Maximum Salaries
Select DepartmentID, Max(Salary) As MaxSalary From Employees
Group By DepartmentID
Having Max(Salary) Not Between 30000 and 70000
Go

--Problem 17.	Employees Count Salaries
Select Count(FirstName) As [Count] From Employees
Where ManagerID is Null

--Problem 18.	3rd Highest Salary
Select Distinct DepartmentId, Salary As [ThirdHighestSalary] From (
Select DepartmentID, Salary, DENSE_RANK() Over(Partition By DepartmentID Order By Salary Desc)
As [Ranking]	
From Employees) As [RankTable]
Where Ranking = 3
Go

--Problem 19.	Salary Challenge
Select Top(10) FirstName, LastName, DepartmentId 
From Employees As e1
Where Salary > (
Select AVG(Salary) As [AvgSalary]
From Employees As e2 
Where e2.DepartmentId = e1.DepartmentId
Group By DepartmentID
)
Order By e1.DepartmentID
Go