CREATE DATABASE railway;
use railway; 

create table employee(employee_id int primary key , 
                      first_name  nvarchar(30) not null,
                      last_name  nvarchar(30)  not null,
                      address      nvarchar(50) not null,
                      sup_ID int
                       
);
create table employee_phone(employee_phone_id int primary key , 
                      phone_number varchar(15) not null,
                      employee_id int
);
create table Train_employee(train_employee_id int primary key , 
                      No_trips int not null,
                      employee_id int 
);

create table Station_employee(station_employee_id int primary key , 
                       No_hours int not null,
					   employee_id int
);

create table Train (  train_id int primary key ,
                     train_name nvarchar(30) not null,
                     capacity  int not null,
                     train_model  nvarchar(30),
                     train_employee_id int,
                     schedule_ID int 
);


create table stations(  stations_id int primary key,
                       station_name  nvarchar(30) not null,
                       station_capacity  int not null,
                       station_type     nvarchar(50),
                       station_employee_id int
);

create table schedule_train(  schedule_ID int primary key,
                       Date_schedule  date not null,
                       No_slots  int not null,
                       Train_number int not null,
                       Start_time time not null,
                       End_time time not null
);

create table Passenger( Passenger_ID int primary key ,
                       first_name nvarchar(30) not null,
                       last_name  nvarchar(30) not null,
                       address  nvarchar(50) not null,
                       Ticket_ID int
);
create table Passenger_phone(Passenger_Phone_ID int primary key , 
                      phone_number varchar(15) not null,
                      Passenger_ID int
);
create table Ticket( Ticket_ID int primary key ,
					Trip_time time not null,
					Ticket_price  decimal not null,
					reservation_time time not null,
					Ticket_type varchar(15) not null,
					Seat_no int not null,
					From_station varchar(15) not null,
                    To_station varchar(15) not null,
                    train_id int
);

ALTER TABLE employee
ADD FOREIGN KEY(sup_ID)
REFERENCES employee(employee_ID)
On delete CASCADE
On update CASCADE;

ALTER TABLE employee_phone
ADD FOREIGN KEY(employee_ID)
REFERENCES employee(employee_ID)
On delete CASCADE
On update CASCADE;

ALTER TABLE Train_employee
ADD FOREIGN KEY(train_employee_id)
REFERENCES employee(employee_ID)
On delete CASCADE
On update CASCADE;

ALTER TABLE Station_employee
ADD FOREIGN KEY(employee_ID)
REFERENCES employee(employee_ID)
On delete CASCADE
On update CASCADE;

ALTER TABLE Train
ADD FOREIGN KEY(train_employee_id)
REFERENCES Train_employee(train_employee_id)
On delete CASCADE
On update CASCADE;

ALTER TABLE Train
ADD FOREIGN KEY(schedule_ID)
REFERENCES schedule_train(schedule_ID)
On delete CASCADE
On update CASCADE;

ALTER TABLE Train
ADD FOREIGN KEY(schedule_ID)
REFERENCES schedule_train(schedule_ID)
On delete CASCADE
On update CASCADE;

ALTER TABLE stations
ADD FOREIGN KEY(station_employee_id)
REFERENCES Station_employee(station_employee_id)
On delete CASCADE
On update CASCADE;

ALTER TABLE Passenger
ADD FOREIGN KEY(Ticket_ID)
REFERENCES Ticket(Ticket_ID)
On delete CASCADE
On update CASCADE;
 
ALTER TABLE Passenger_phone
ADD FOREIGN KEY(Passenger_ID)
REFERENCES Passenger(Passenger_ID)
On delete CASCADE
On update CASCADE; 
 
ALTER TABLE Ticket
ADD FOREIGN KEY(train_id)
REFERENCES Train(train_id)
On delete CASCADE
On update CASCADE;  
 
 
 
 
 INSERT INTO Passenger(Passenger_ID ,first_name,last_name, address)
VALUES(2323,'youssef','elatar','Helwan');

SELECT Passenger_ID,first_name,last_name, address FROM Passenger;









