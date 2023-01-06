insert into Users (UserId,FirstName,LastName,PhoneNo,Email,City) 
Values(102,'krishna','raj',931098321,'someone@gmail.com','Chennai'),
(103,'Martin','raj',931098311,'someone@gmail.com','Chennai'),
(104,'shalin','raj',931098121,'someone@gmail.com','Chennai');


insert into Skills Values
(101,'app development','Web dev','Azure','Aws'),
(102,'web dev','linux','excel','agile methodology'),
(103,'UIUX','Angular','Java','JS'),
(104,'Android','Data engineering','mongo db','swift');

select u.firstName,u.LastName,Concat(s.skill_1,', ',s.skill_2,', ',s.skill_3,', ',skill_4) as Skills from users u
inner join skills s on u.userId=s.userId;

select 