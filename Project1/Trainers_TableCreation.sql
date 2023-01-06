CREATE DATABASE TrainerInformations;

 CREATE TABLE Users( 
 [UserId] int,
 [FirstName] Varchar(max),
 [LastName] Varchar(max),
 [PhoneNo] int UNIQUE,
 [Email] int UNIQUE, 
 [City] varchar(max)
 Constraint [PK_Users] Primary Key(UserId)
 );

 alter table users
 alter Column Email varchar(max);

 

 Create table Skills(
 [UserId] int,
 Skill_1 Varchar(max) Not null,
 Skill_2 Varchar(max) Not null,
 Skill_3 Varchar(max) ,
 Skill_4 Varchar(max) ,
 Constraint [PK_Skills] Primary Key(UserId),
 Constraint [FK_Skills] Foreign Key(UserId) References Users(UserId)
);


Create table College_UG(
 [UserId] int,
 CollegeName Varchar(max),
 YearPassed Date,
 Degree Varchar(max),
 Branch varchar(max),
  Constraint [PK_UG] Primary Key(UserId),
 Constraint [FK_UG] Foreign Key(UserId) References Users(UserId)
 );

 Create table College_PG(
 [UserId] int,
 CollegeName Varchar(max),
 YearPassed Date,
 Degree Varchar(max),
 Branch varchar(max),
  Constraint [PK_PG] Primary Key(UserId),
 Constraint [FK_PG] Foreign Key(UserId) References Users(UserId)
 );

  Create table HighSchool(
 [UserId] int,
 SchoolName Varchar(max),
 YearPassed Date,
 Constraint [PK_HS ] Primary Key(UserId),
 Constraint [FK_HS] Foreign Key(UserId) References Users(UserId)
 );

  Create table HighSec(
 [UserId] int,
 SchoolName Varchar(max),
 YearPassed Date,
 Course varchar(max),
 Constraint [PK_HSC ] Primary Key(UserId),
 Constraint [FK_HSC] Foreign Key(UserId) References Users(UserId)
 );


    Create table Companies(
 [UserId] int,
 LastCompanyName Varchar(max),
 TotalExp int,
 Constraint [PK_Com ] Primary Key(UserId),
 Constraint [FK_Com] Foreign Key(UserId) References Users(UserId)
 );

