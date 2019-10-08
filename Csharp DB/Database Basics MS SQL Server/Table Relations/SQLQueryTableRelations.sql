--Problem 1.	One-To-One Relationship

Create Table Persons
(
PersonID Int Primary Key,
FirstName Varchar(30),
Salary Decimal(15,2),
PassportID Int Not Null
)

Create Table Passports
(
PassportID Int Primary Key,
PassportNumber Char(8) Not Null
)

Alter Table Persons
Add Constraint FK_Persons_Passports
Foreign Key(PassportID)
References Passports(PassportID)

Alter Table Persons
Add Unique(PassportID)
Go


--Problem 2.	One-To-Many Relationship
Create Table Models
(
ModelID Int Primary Key,
[Name] Nvarchar(30),
ManufacturerID Int Not Null
)

Create Table Manufacturers
(
ManufacturerID Int Primary Key,
[Name] Nvarchar(30),
EstablishedOn Datetime2
)

Alter Table Models
Add Constraint FK_Models_Manufacturers
Foreign Key(ManufacturerID)
References Manufacturers(ManufacturerID)
Go

--Problem 3.	Many-To-Many Relationship
Create Table Students
(
StudentID Int Primary Key,
[Name] Nvarchar(30)
)

Create Table Exams
(
ExamID Int Primary Key,
[Name] Nvarchar(30)
)

Create Table StudentsExams
(
StudentID Int Foreign Key References Students(StudentID),
ExamID Int Foreign Key References Exams(ExamID),
Constraint PK_CompositeStudentIDExamID
Primary Key(StudentID,ExamID)
)
Go

--Problem 4.	Self-Referencing
Create Table Teachers
(
TeacherID Int Primary Key Identity Not Null,
[Name] Nvarchar(30) Not Null,
ManagerID Int Foreign Key References Teachers(TeacherID)
)

--Problem 5.	Online Store Database
Create Table Cities
(
CityID Int Primary Key Identity,
[Name] Varchar(50) Not Null
)

Create Table ItemTypes
(
ItemTypeID Int Primary Key Identity,
[Name] Varchar(50) Not Null
)
 
Create Table Items
(
ItemID Int Primary Key Identity,
[Name] Varchar(50) Not Null,
ItemTypeID Int Foreign Key References ItemTypes(ItemTypeID)
)

Create Table Customers
(
CustomerID Int Primary Key Identity,
[Name] Varchar(50) Not Null,
Birthday Date,
CityID Int Foreign Key References Cities(CityID)
)

Create Table Orders
(
OrderID Int Primary Key Identity,
CustomerID Int Foreign Key References Customers(CustomerID)
)

Create Table OrderItems
(
OrderID Int Foreign Key References Orders(OrderID),
ItemID Int Foreign Key References Items(ItemID),
Constraint PK_CompositeOrderIDItemID
Primary Key(OrderID,ItemID)
)


--Problem 6.	University Database
Create Table Majors
(
MajorID Int Primary Key Identity,
[Name] Nvarchar(50) Not Null
)

Create Table Students
(
StudentID Int Primary Key,
[StudentNumber] Int Not Null,
[StudentName] Nvarchar(50),
MajorID Int Foreign Key References Majors(MajorID)
)

Create Table Subjects
(
SubjectID Int Primary Key,
[SubjectName] Nvarchar(50)
)

Create Table Agenda
(
StudentID Int Foreign Key References Students(StudentID),
SubjectID Int Foreign Key References Subjects(SubjectID),
Constraint PK_CompositeStudentIDSubjectID
Primary Key(StudentID,SubjectID)
)

Create Table Payments
(
PaymentsID Int Primary Key,
PaymentDate Datetime2,
PaymentAmount Decimal,
StudentID Int Foreign Key References Students(StudentID),
)

--Problem 9.	Peaks in Rila
select * from Peaks
Select MountainRange, PeakName, Elevation From Mountains,Peaks
Where MountainRange = 'Rila'
And MountainId = 17
Order By Elevation Desc

