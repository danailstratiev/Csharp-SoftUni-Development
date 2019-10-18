--Section I. Functions and Procedures

--Problem 1. Employees with Salary Above 35000
Create Proc usp_GetEmployeesSalaryAbove35000 As
Select FirstName As [First Name], LastName As [Last Name] From Employees
Where Salary > 35000
Go

--Problem 2. Employees with Salary Above Number
Create Proc usp_GetEmployeesSalaryAboveNumber @inputNumber DECIMAL(18,4) As
Select FirstName As [First Name], LastName As [Last Name] From Employees
Where Salary >= @inputNumber
Go

--Problem 3. Town Names Starting With
Create Proc usp_GetTownsStartingWith @townName Nvarchar(50) As
Select [Name] As [Town] From Towns
Where LEFT([Name], Len(@townName)) = @townName
Go

--Problem 4. Employees from Town
Create Proc usp_GetEmployeesFromTown @townName Nvarchar(50) As
Select FirstName As [First Name], LastName As [Last Name] From Employees As e
Join Addresses As a On a.AddressID = e.AddressID
Join Towns As t On t.TownID = a.TownID
Where t.Name = @townName
Go

--Problem 5. Salary Level Function
Create Function ufn_GetSalaryLevel(@salary DECIMAL(18,4))
Returns Varchar(7)
As
Begin
Declare @salaryLevel Char(7)
If @salary < 30000
Begin
Set @salaryLevel = 'Low'
End
Else If 
@salary Between 30000 and 50000
Begin
Set @salaryLevel = 'Average'
End
Else
Begin
Set @salaryLevel = 'High'
End
Return @salaryLevel
End
Go

--Problem 6. Employees by Salary Level
Create Proc usp_EmployeesBySalaryLevel (@salaryLevel Nvarchar(50))
As
Begin 
Select FirstName As [First Name], LastName As [Last Name] From Employees As e
Where dbo.ufn_GetSalaryLevel(e.Salary) = @salaryLevel
End
Exec dbo.usp_EmployeesBySalaryLevel 'High'
Go

--Problem 7. Define Function
Create Function ufn_IsWordComprised(@setOfLetters Nvarchar(30), @word Nvarchar(30))
Returns Bit
As
Begin 
	Declare @counter Int = 1;
	Declare @currentLetter Char;

	While(@counter <= Len(@word))
	Begin
	Set @currentLetter = Substring(@word,@counter,1);

	Declare @charIndex Int = Charindex(@currentLetter, @setOfLetters);

	If(@charIndex <= 0)
	Begin
	Return 0;
	End

	Set @counter += 1;
	End

	Return 1;
End

Go

--Problem 8.  Delete Employees and Departments
Create Proc usp_DeleteEmployeesFromDepartment (@departmentId INT)
As
Begin 
--Delete all working on projects by people that are intended to be deleted
  Delete From EmployeesProjects
  Where EmployeeID In (
--People I want to delete
  Select EmployeeID 
  From Employees
  Where DepartmentID = @departmentId
  )

--Set ManagerId to Null on all people whose manager is to be deleted
  Update Employees
  Set ManagerID = Null
  Where ManagerID In (
  Select EmployeeID 
  From Employees
  Where DepartmentID = @departmentId
  )

--Set column ManagerId(Departments) to be nullable
  Alter Table Departments
  Alter Column ManagerID Int 

--Set ManagerId to Null for all departments whose manager was deleted
  Update Departments
  Set ManagerID = Null
  Where DepartmentID = @departmentId

--As Employees have no more relations we can safely delete all employees in wanted department
  Delete From Employees
  Where DepartmentID = @departmentId

--As Employees have no more relations we can safely delete the whole department
  Delete From Departments
  Where DepartmentID = @departmentId

  Select Count(*) From Employees
  Where DepartmentID = @departmentId
End

--Problem 9. Find Full Name
Create Proc usp_GetHoldersFullName
As
Select Concat(Firstname, ' ', LastName)As [Full Name] From AccountHolders
Go

--Problem 10. People with Balance Higher Than
Create Proc usp_GetHoldersWithBalanceHigherThan @money Decimal(18,2)
As
Begin
Select FirstName As [First Name], LastName As [Last Name] From AccountHolders As ah
Join Accounts As a
On a.AccountHolderId = ah.Id
Group By ah.FirstName, ah.LastName
Having Sum(a.Balance) > @money
Order By ah.FirstName, ah.LastName
End
Go


--Problem 11. Future Value Function
Create Function ufn_CalculateFutureValue (@sum Money, @yearlyInterestRate Float, @numberOfYears Int)
Returns Decimal(24,4)
As 
Begin
	Declare @Result Decimal(24, 4)
	Set @Result = @sum*(Power((1 + @yearlyInterestRate), @numberOfYears))
Return @Result
End
Go

--Problem 12. Calculating Interest
Create Proc usp_CalculateFutureValueForAccount @AccountId Int, @yearlyInterestRate Float
As
Begin 
Select a.Id as [Id], FirstName As [First Name], LastName As [Last Name],
a.Balance as [Current Balance],
dbo.ufn_CalculateFutureValue(a.Balance, @yearlyInterestRate, 5) as [Balance in 5 years]
From AccountHolders As ah
Join Accounts As a
On a.AccountHolderId = ah.Id
Where a.Id = @AccountId
End
Go

--Problem 13. *Scalar Function: Cash in User Games Odd Rows
Create Function ufn_CashInUsersGames (@gameName Varchar(Max))
Returns Table
As
Return (
	Select SUM(e.Cash) As SumCash
	FROM ( 
		Select g.Id, ug.Cash, ROW_NUMBER() Over(Order By ug.Cash DESC) As [RowNumber]
		From Games As g
		INNER JOIN UsersGames As ug
		On ug.GameId = g.Id
		Where g.[Name] = @GameName
	) As e
	Where e.RowNumber % 2 = 1 
	)
Go

