Create Table Students(
	Id Int Primary Key Identity,
	FirstName Nvarchar(30) Not Null,
	MiddleName Nvarchar(25),
	LastName Nvarchar(30) Not Null,
	Age Smallint Check(Age Between 5 and 100),
	[Address] Nvarchar(50),
	Phone Nchar(10) 
)

Create Table Subjects(
	Id Int Primary Key Identity,
	[Name] Nvarchar(20)	Not Null,
	Lessons Int Check(Lessons > 0) Not Null	
)

Create Table StudentsSubjects(
	Id Int Primary Key Identity,
	StudentId Int Foreign Key References Students(Id) Not Null,
	SubjectId Int Foreign Key References Subjects(Id) Not Null,
	Grade Decimal(3, 2) Check(Grade Between 2 and 6) Not Null
)

Create Table Exams(
	Id Int Primary Key Identity,
	[Date] Datetime2,
	SubjectId Int Foreign Key References Subjects(Id) Not Null,
)

Create Table StudentsExams(
	StudentId Int Foreign Key References Students(Id) Not Null,
	ExamId Int Foreign Key References Exams(Id) Not Null,
	Grade Decimal(3,2) Check(Grade Between 2 And 6) Not Null,
	Constraint PK_CompositeStudentIdExamId
	Primary Key(StudentId, ExamId)
)

Create Table Teachers(
	Id Int Primary Key Identity,
	FirstName Nvarchar(20) Not Null,
	LastName Nvarchar(20) Not Null,
	[Address] Nvarchar(20),
	Phone Char(10),
	SubjectId Int Foreign Key References Subjects(Id) Not Null	 
)

Create Table StudentsTeachers(
	StudentId Int Foreign Key References Students(Id) Not Null,
	TeacherId Int Foreign Key References Teachers(Id) Not Null,
	Constraint PK_CompositeStudentIdTeacherId
	Primary Key (StudentId, TeacherId)
)

Insert Into Subjects([Name], [Lessons]) Values
('Geometry', 12),
('Health',	10),
('Drama', 7),
('Sports', 9)

Insert Into Teachers([FirstName], [LastName], [Address], [Phone], [SubjectId]) Values
('Ruthanne', 'Bamb', '84948 Mesta Junction',3105500146,	6),
('Gerrard', 'Lowin', '370 Talisman Plaza',3324874824, 2),
('Merrile', 'Lambdin', '81 Dahle Plaza',4373065154,	5),
('Bert', 'Ivie', '2 Gateway Circle',4409584510,	4)

Update StudentsSubjects
Set Grade = 6.00
Where SubjectId In (1, 2) And Grade >= 5.50

Delete From StudentsTeachers
Where TeacherId In (
Select Id
From Teachers
Where Phone Like '%72%'
)

Delete From Teachers
Where CHARINDEX('72', Phone) > 0	


Select FirstName, LastName, Age From Students
Where Age >= 12
Order By FirstName, LastName


Select FirstName, LastName, COUNT(st.TeacherId) As [TeachersCount] From Students As s
Left Join StudentsTeachers As st
On st.StudentId = s.Id 
Group By s.FirstName, s.LastName


Select Concat(FirstName, ' ', LastName) As [Full Name] From Students As s
Left Join StudentsExams As se
On se.StudentId = s.Id
Where se.StudentId Is Null
Order By [Full Name]

Select Top 10 FirstName, LastName, CAST(AVG(se.Grade) As Decimal(3,2)) As Grade  From Students As s
Left Join StudentsExams As se
On se.StudentId = s.Id
Group By s.FirstName, s.LastName
Order By Grade Desc, s.FirstName, s.LastName


Select CONCAT(s.FirstName, ' ', s.MiddleName + ' ', s.LastName) As [Full Name] From Students As s
Left Join StudentsSubjects As ss
On s.Id = ss.StudentId
Where ss.SubjectId Is Null
Order By [Full Name]


Select s.Name, AVG(ss.Grade) as	AverageGrade From Subjects As s
Join StudentsSubjects As ss
On s.Id = ss.SubjectId
Group By s.Id, s.Name
Order By s.Id


Create Function udf_ExamGradesToUpdate(@studentId Int, @grade Decimal(3,2))
Returns Nvarchar(100)
As
Begin
	Declare @studentName Nvarchar(30) = 
	(Select FirstName From Students
	 Where Id = @studentId 
	)
	If (@studentName Is Null)
	Begin
		Return 'The student with provided id does not exist in the school!'
	End

	If (@grade > 6.00)
	Begin
		Return 'Grade cannot be above 6.00!'
	End

	Declare @studentGradesCount Int = 
	(Select Count(Grade) 
	 From StudentsExams
	 Where StudentId = @studentId And (Grade >= @grade And Grade <= (Grade + 0.50)))

	 Return Concat('You have to update', @studentGradesCount, 'grades for the student ', @studentName)	
End