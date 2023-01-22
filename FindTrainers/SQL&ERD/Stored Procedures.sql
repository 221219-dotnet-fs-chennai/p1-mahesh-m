--- Stored Procedures
create procedure sp_insert1
@userid varchar(900),
@fname varchar(max),
@lname varchar(max),
@email varchar(max),
@phone varchar(max),
@city varchar(max),
@password varchar(max),
@skill_1 varchar(max),
@skill_2 varchar(max),
@skill_3 varchar(max),
@skill_4 varchar(max),
@collegename varchar(max),
@yp varchar(max),
@degree varchar(max),
@branch varchar(max),
@highSchool varchar(max),
@yphsc varchar(max),
@hsccourse varchar(max),
@hsschool varchar(max),
@yps varchar(max)

as
begin
insert into trainers(TrainerId,FirstName,LastName,Email,PhoneNo,City,Password) values(@userid,@fname,@lname,@email,@phone,@city,@password);
end;
begin
insert into Skills (TrainerId,Skill_1,Skill_2,Skill_3,Skill_4) values(@userid,@skill_1,@skill_2,@skill_3,@skill_4);
end;
begin
insert into College_UG (trainerId,CollegeName,YearPassed,Degree,Branch) values(@userid,@collegename,@yp,@degree,@branch);
end;
begin
insert into HighSec(trainerId,SchoolName,Course,YearPassed) values(@userid,@highSchool,@yphsc,@hsccourse);
end;
begin
insert into HighSchool(trainerId,SchoolName,YearPassed) values (@userid,@hsschool,@yps);
end;

select *from trainers
select *from skills
select *from Companies
select * from College_UG
select * from HighSchool
select * from HighSec
select * from Companies

create procedure SP_insertCompanies
@userid varchar(900),
@companyname varchar (max),
@exp varchar(max)
as
begin
insert into Companies(trainerId,LastCompanyName,TotalExp) values (@userid,@companyname,@exp);
end;


create procedure sp_login
@email varchar(200)
as
begin
select email from Trainers where Email=@email;
end;

create procedure sp_loginPass
@password varchar(max)
as
begin
select email from trainers where Password=@password;
end;



create procedure gettrainercompany
@userid varchar(900)
as
begin
select * from Companies where trainerId=@userid
end;

create procedure getAtrainer
@userid varchar(900)
as
begin
select * from trainers t 
inner join Skills s on s.TrainerId=t.TrainerId 
inner join HighSchool h on h.trainerId=t.TrainerId
inner join HighSec hsc on hsc.trainerId=t.TrainerId
inner join College_UG ug on ug.trainerId=t.TrainerId
where t.trainerId=@userid;
end;



create procedure updateskills
@userid varchar (max),
@columnname varchar(max),
@value varchar(max)
as
begin
update Skills set @columnname=@value where trainerid=@userid;
end;

create procedure sp_deleteacc
@userid varchar(max)
as
begin
delete from trainers where TrainerId=@userid;
end;

create procedure sp_updatecompanies
@userid varchar(max),
@newC varchar(max),
@newExp int

as
begin
insert into Companies(trainerId,LastCompanyName,TotalExp) values (@userid,@newC,@newExp);
end;

create procedure sp_deleteCompany
@userid varchar(max),
@cname varchar(max)
as 
begin
delete from companies where lastcompanyname=@cname and trainerid=@userid;
end;
         

create procedure sp_newpass
@email varchar(200),
@pass varchar(max)
as
begin
update trainers set Password=@pass where Email=@email;
end;

create procedure sp_isexistemail
@val varchar(max)
as
begin
select Email from Trainers where Email=@val;
end;

create procedure sp_Getall
as
begin
select firstname,lastname,phoneNo,email,skill_1,city from trainers t inner join skills s on t.TrainerId=s.TrainerId;
end;

