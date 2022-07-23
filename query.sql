CREATE TABLE UserLogin (
IdUser int IDENTITY(1,1) PRIMARY KEY,
Name varchar(50) NOT NULL,
Email varchar(50) NOT NULL,
Password varchar(50) NOT NULL
)

insert into UserLogin values ('Admin', 'admin@email.com', 'admin123')

