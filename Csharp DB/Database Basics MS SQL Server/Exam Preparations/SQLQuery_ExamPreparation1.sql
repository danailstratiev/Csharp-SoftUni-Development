--Section 1. DDL (30 pts)

Create Database Airport

Create Table Planes 
(
Id Int Primary Key Identity,
[Name] Nvarchar(30) Not Null,
Seats Int Not Null,
[Range] Int Not Null
)

Create Table Flights
(
Id Int Primary Key Identity,
DepartureTime Datetime2,
ArrivalTime Datetime2,
Origin Nvarchar(50) Not Null,
Destination Nvarchar(50) Not Null,
PlaneId Int Foreign Key References Planes(Id) Not Null
)

Create Table Passengers
(
Id Int Primary Key Identity,
FirstName Nvarchar(30) Not Null,
LastName Nvarchar(30) Not Null,
Age Int Not Null,
[Address] Nvarchar(30) Not Null,
PassportId Char(11) Not Null
)

Create Table LuggageTypes
(
Id Int Primary Key Identity,
[Type] Nvarchar(30) Not Null
)

Create Table Luggages
(
Id Int Primary Key Identity,
LuggageTypeId Int Foreign Key References LuggageTypes(Id) Not Null,
PassengerId Int Foreign Key References Passengers(Id) Not Null
)

Create Table Tickets
(
Id Int Primary Key Identity,
PassengerId Int Foreign Key References Passengers(Id) Not Null,
FlightId Int Foreign Key References Flights(Id) Not Null,
LuggageId Int Foreign Key References Luggages(Id) Not Null,
Price Decimal (16,2) Not Null
)

--Section 2. DML (10 pts)

--2.	Insert

Insert Into Planes Values
('Airbus 336', 112, 5132),
('Airbus 330', 432, 5325),
('Boeing 369', 231, 2355),
('Stelt 297', 254, 2143),
('Boeing 338', 165, 5111),
('Airbus 558', 387, 1342),
('Boeing 128', 345, 5541)

Insert Into LuggageTypes Values
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

--3.	Update

Update Tickets
Set Price = Price * 1.13
Where FlightId = 41

--Alternative
Where FlightId In (Select [Id] From Flights
Where Destination = 'Carlsbad')

--4.	Delete

Select * from Flights 
where Destination = 'Ayn Halagim'

Delete From Tickets
Where FlightId = 30

Delete From Flights
Where Id = 30

--5.	The "Tr" Planes

Select * From Planes
Where [Name] Like '%tr%'

--Alternative
Select * From Planes
Where CHARINDEX('tr', [Name]) > 0
Order By [Id], [Name], [Seats], [Range]

--6.	Flight Profits
Select f.Id as [FlightId], Sum(t.Price) as [Price] From Flights as f
Join Tickets as t
On f.Id = t.FlightId
Group By f.Id
Order By Price Desc, [FlightId]

Select * from Tickets

--7.	Passenger Trips
Select p.FirstName + ' ' + p.LastName  As [Full Name], f.Origin, f.Destination  From Passengers as p
Join Tickets as t On p.Id = t.PassengerId
Join Flights as f On t.FlightId = f.Id
Order by p.FirstName + ' ' + p.LastName Asc, Origin, Destination

--8.	Non Adventures People
Select p.FirstName as [First Name], p.LastName as [Last Name], p.Age from Passengers as p
Where p.Id Not In (Select PassengerId From Tickets)
Order by p.Age Desc, p.FirstName, p.LastName

--9.	Full Info
Select  p.FirstName + ' ' + p.LastName As [Full Name],
pl.[Name] as [Plane Name], f.Origin + ' - ' + f.Destination as [Trip],
lt.[Type] as [Luggage Type]
From Passengers as p
Join Tickets as t
On   t.PassengerId = p.Id
Join Flights as f
On t.FlightId = f.Id
Join Planes as pl
On f.PlaneId = pl.Id
Join Luggages as l
On t.LuggageId = l.Id
Join LuggageTypes as lt
On l.LuggageTypeId = lt.Id
Order By [Full Name], [Plane Name], f.Origin, f.Destination, lt.[Type]

--10.	PSP
Select p.[Name], p.Seats, Count(t.Id) as [Passengers Count] From Planes as p
Left Join Flights as f
On f.PlaneId = p.Id
Left Join Tickets as t
On t.FlightId = f.Id
Group by p.[Name], p.Seats
Order by [Passengers Count] Desc, p.Name, p.Seats

--11.	Vacation
Create Function udf_CalculateTickets (@origin Nvarchar(30), @destination Nvarchar(30), @peopleCount Int)
Returns Nvarchar(50)
As 
Begin
	If (@peopleCount <= 0)
	Begin 
	Return 'Invalid people count!';
	End

	Declare @flightId Int = (Select Top(1) Id From Flights 
						  Where Origin = @origin And Destination = @destination);
	If(@flightId Is Null)
	Begin
	Return 'Invalid flight!'
	End

	Declare @pricePerPerson Decimal(18,2) = (Select Top(1) Price From Tickets as t
											 Join Flights as f
											 On t.FlightId = f.Id
											 Where f.Id = @flightId)
    Declare @totalPrice Decimal(24,2) = @pricePerPerson * @peopleCount

	Return Concat('Total price ', @totalPrice)
End

--12.	Wrong Data
Create Proc usp_CancelFlights
As
Begin
  Update Flights 
  Set DepartureTime = Null, ArrivalTime = Null
  Where DATEDIFF(SECOND, DepartureTime, ArrivalTime) > 0
End