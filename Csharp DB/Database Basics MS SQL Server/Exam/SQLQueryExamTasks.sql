--Service
--Section 1. DDL (30 pts)

Create Database [Service]

Create Table Users
(
Id Int Primary Key Identity,
Username Nvarchar(30) Unique Not Null,
[Password] Nvarchar(50) Not Null,
[Name] Nvarchar(50),
Birthdate Datetime2,
Age Int CHECK(Age >= 14 AND Age <= 110),
[Email] Nvarchar(50) Not Null
)

Create Table Departments
(
Id Int Primary Key Identity,
[Name] Nvarchar(50) Not Null
)

Create Table Employees
(
Id Int Primary Key Identity,
FirstName Nvarchar(25),
LastName Nvarchar(25),
Birthdate Datetime2,
Age Int CHECK(Age >= 18 AND Age <= 110),
DepartmentId Int REFERENCES Departments(Id)
)

Create Table Categories
(
Id Int Primary Key Identity,
[Name] Nvarchar(50) Not Null,
DepartmentId Int NOT NULL REFERENCES Departments(Id)
)

Create Table [Status]
(
Id Int Primary Key Identity,
Label Nvarchar(30) Not Null,
)

Create Table Reports
(
Id Int Primary Key Identity,
CategoryId Int NOT NULL REFERENCES Categories(Id),
StatusId Int NOT NULL REFERENCES [Status](Id),
OpenDate Datetime2 Not Null,
CloseDate Datetime2,
[Description] Nvarchar(200) Not Null,
UserId Int NOT NULL REFERENCES Users(Id),
EmployeeId Int REFERENCES Employees(Id)
)


--2.	Insert
Insert Into Employees Values
('Marlo',	'O''Malley', '1958-9-21',Null, 1),
('Niki',	'Stanaghan', '1969-11-26',Null,	4),
('Ayrton',	'Senna',	'1960-03-21',Null,	9),
('Ronnie', 'Peterson',	'1944-02-14',Null,	9),
('Giovanna', 'Amati',	'1959-07-20',Null,	5)

Insert Into Reports Values
(1,	1,	'2017-04-13', Null,		'Stuck Road on Str.133',	6,	2),
(6,	3,	'2015-09-05',	'2015-12-06',	'Charity trail running',	3,	5),
(14,	2,	'2015-09-07',Null,	'Falling bricks on Str.58',	5,	2),
(4,	3,	'2017-07-03',	'2017-07-06',	'Cut off streetlight on Str.11',	1,	1)


--3.	Update
Update Reports
Set CloseDate = GETDATE()
Where CloseDate Is Null

--4.	Delete
Delete From Reports
Where StatusId = 4

--5.	Unassigned Reports
Select Description,FORMAT ( OpenDate,'dd-MM-yyyy') As [OpenDate] From Reports as r
Where EmployeeId Is Null
Order By r.OpenDate, Description

--6.	Reports & Categories
Select r.Description, c.Name From Reports as r
Join Categories as c
On r.CategoryId = c.Id
Order by r.Description, c.Name

--7.	Most Reported Category
Select Top(5) c.Name, COUNT(c.Id) as [ReportsNumber] From Reports as r
Join Categories as c
On r.CategoryId = c.Id
Group By c.Name 
Order By ReportsNumber Desc,
c.Name

--8.	Birthday Report
Select u.Username,  c.Name as [CategoryName] From Users as u
Join Reports as r
On u.Id = r.UserId
Join Categories as c
On r.CategoryId = c.Id
Where Datepart(Day, u.Birthdate) =  DATEPART(DAY, r.OpenDate)
Order By u.Username, [CategoryName]

--9.	Users per Employee 
Select CONCAT(e.FirstName, ' ', e.LastName) as [FullName], Count(u.Id) as UsersCount From Employees as e
Left Join Reports as r
On e.Id = r.EmployeeId
Left Join Users as u
On r.UserId = u.Id
Group By CONCAT(e.FirstName, ' ', e.LastName)
Order By UsersCount Desc, [FullName]


--10.	Full Info
Select
Case
When CONCAT(e.FirstName,' ', e.LastName) Is Null Then 'None'
Else
CONCAT(e.FirstName,' ', e.LastName)
End as [Employee],
Case
When d.Name Is Null Then 'None'
Else
d.Name
End as [Department],
Case
When c.Name Is Null Then 'None'
Else
c.Name
End as [Category],
Case
When r.Description Is Null Then 'None'
Else
r.Description
End as [Description], 
Case
When r.OpenDate Is Null Then 'None'
Else
FORMAT ( r.OpenDate,'dd.MM.yyyy')
End As [OpenDate],
Case
When s.Label Is Null Then 'None'
Else 
s.Label 
End as [Status],
Case
When u.Name Is Null Then 'None'
Else
u.Name
End as [User]
  From Employees as e
Join Departments as d
On e.DepartmentId = d.Id
Join Categories as c
On d.Id = c.DepartmentId
 Join Reports as r
On c.Id = r.CategoryId
 Join Status as s
On r.StatusId = s.Id
Join Users as u
On r.UserId = u.Id
Where r.EmployeeId = e.Id and u.Name is not null
Order By  e.FirstName Desc, e.LastName Desc, [Department], [Category], [Description], [OpenDate], [Status], [User]

select * from Reports as r
Join Employees as e
on r.EmployeeId = e.Id
Order By e.FirstName Desc

--11.	Hours to Complete
Create Function udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
Returns Int
As
Begin
	IF(@StartDate IS NULL)
		BEGIN
		      RETURN 0
		END
	IF(@EndDate IS NULL)
		BEGIN
		      RETURN 0
		END
	Declare @timeDiff Int = Datediff(Hour, @StartDate, @EndDate)

	Return @timeDiff
End

--12.	Assign Employee
Create Proc usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
As
Begin 
 If((Select DepartmentId  From Employees
Where Id = @EmployeeId) = (
	Select Top(1) c.DepartmentId From Reports as r	
	Left Join Categories as c
	On r.CategoryId = c.Id
	Where r.Id = @ReportId))
	Begin
	Update Reports
	Set EmployeeId = @EmployeeId
	Where Id = @ReportId
	End
 Else
 Begin
 RAISERROR('Employee doesn''t belong to the appropriate department!',16,1)
 End
End

EXEC usp_AssignEmployeeToReport 30, 1
EXEC usp_AssignEmployeeToReport 17, 2

DROP PROCEDURE usp_AssignEmployeeToReport
Select c.DepartmentId From  Reports as r

Left Join Categories as c
On r.CategoryId = c.Id


Select DepartmentId  From Employees
Where Id = 17

Select  c.DepartmentId From 
 Reports as r
	Join Categories as c
	On r.CategoryId = c.Id
	Where r.Id = 2 