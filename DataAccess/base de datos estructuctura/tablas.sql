CREATE TABLE Producto (
	Id int Primary Key identity,
	Nombre nvarchar(200)
)

go

CREATE TABLE Usuario (
	Id int primary key identity,
	username nvarchar(100) UNIQUE NOT NULL,
	passwd nvarchar(100) NOT NULL,
	rol nvarchar(100) NOT NULL
)