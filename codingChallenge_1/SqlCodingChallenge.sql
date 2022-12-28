create database codingChallenge;

--table employee creation

create table employee
(Id int not null ,
 [FistName] Varchar(max),
  [LastName] Varchar(max),
  [SSN] BigInt,
  [Department_id] Int 

  Constraint [Pk_employee] Primary key(Id),
  Constraint [Fk_employee] Foreign key(Department_id) references Department(ID) );



--Department table creation

create table department (
[ID] int not null,
[Name] varchar(max),
[Location] varchar(max)

Constraint [Pk_department] Primary key(Id));

-- employee_details table

Create table empDetails(
[ID] int not null,
[EmployeeId] int Unique,
[salary] float,
[Address1] varchar(max),
[Address2] varchar(max),
[City] varchar(max),
[State]varchar(max),
[Country] varchar(max)

Constraint [Pk_empDetails] Primary Key(ID),
Constraint [Fk_empDetails] Foreign Key(EmployeeID) references employee(Id)
);

-- Insertion of values

Insert into department ([Id],[name],[Location]) 
values (101,'Marketing', 'Chennai'),
(102,'System Admin', 'Chennai'),
(103,'DBS', 'Chennai'), 
(104,'Employee Engagement', 'Chennai');

Insert into employee
([ID],[FistName],[LastName]	,[SSN],[Department_id]) 
values (10101,'Tina','Smith',012111,101),
(10102,'Jonas','Michael',011123,101),
(10103,'Martha','Ulrich',011223,101),
(10201,'Octavia','Blake',019231,102),
(10301, 'Quintin','Tarantino',012919,103),
(10401, 'Jinga' , 'Hagane',012871,104);


Insert into empDetails
([ID],EmployeeId,salary,Address1,Address2,City,[State],Country)
values(1,10101,25000,'new street','kk nagar','chennai','Tamil Nadu','India'),
(2,10102,23000,'new street','kk nagar','chennai','Tamil Nadu','India'),
(3,10103,25000,'new street','kk nagar','chennai','Tamil Nadu','India'),
(4,10201,45000,'new street','kk nagar','chennai','Tamil Nadu','India'),
(5,10301,35000,'new street','kk nagar','chennai','Tamil Nadu','India'),
(6,10401,25000,'new street','kk nagar','chennai','Tamil Nadu','India');



--- checking
select * from department;
select * from employee;
select * from empDetails;
alter table employee
add Constraint [UK_employeeID] Unique (ID);

alter table employee
add Constraint [UK_employeeSSN] Unique(SSN);

---all employee from marketing

select FistName as FirstName, LastName,e.Department_id,d.Name from employee e
inner join department d on e.Department_id=d.ID
where d.Name='Marketing';

-- total salary of marketing

select sum(salary)as totalSalaryOfMarketing from empDetails e
where e.EmployeeId in (select e.id from employee e
inner join department d on e.Department_id=d.ID
where d.Name='Marketing');

-- total employees by department

select Count(*) as EmployeeCount, d.Name from employee e
inner join department d on e.Department_id=d.ID
group by d.Name;

-- Increasing salary of tina smith to 90000
update empDetails
set salary =90000
from employee e
inner join empDetails ed on e.id=ed.EmployeeId
where e.FistName like 'Tina';