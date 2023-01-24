create database TrainerDetails;

 CREATE TABLE Trainers( 
 [TrainerId] Varchar(900) not null ,
 [FirstName] Varchar(max),
 [LastName] Varchar(max),
 [PhoneNo] Varchar(12) UNIQUE,
 [Email] varchar(200) UNIQUE,
 [Password] Varchar(max),
 [City] varchar(max),
 Constraint [UK_trainers] Unique(TrainerId),
 Constraint [PK_Users] Primary Key(TrainerId)
 );

  Create table Skills(
 [TrainerId] varchar(900),
 Skill_1 Varchar(max) Not null,
 Skill_2 Varchar(max) Not null,
 Skill_3 Varchar(max) ,
 Skill_4 Varchar(max) ,
 Constraint [PK_Skills] Primary Key(trainerId),
 Constraint [FK_Skills] Foreign Key(trainerId) References trainers(trainerId) on delete cascade
);

Create table College_UG(
 [trainerId] varchar(900),
 CollegeName Varchar(max),
 YearPassed Date,
 Degree Varchar(max),
 Branch varchar(max),
  Constraint [PK_UG] Primary Key(trainerId),
 Constraint [FK_UG] Foreign Key(trainerId) References trainers(trainerId) on delete cascade
 );

 
   Create table HighSchool(
 [trainerId] varchar(900),
 SchoolName Varchar(max),
 YearPassed Date,
 Constraint [PK_HS ] Primary Key(trainerId),
 Constraint [FK_HS] Foreign Key(trainerId) References trainers(trainerId) on delete cascade
 );


   Create table HighSec(
 [trainerId] varchar(900),
 SchoolName Varchar(max),
 YearPassed Date,
 Course varchar(max),
 Constraint [PK_HSC ] Primary Key(trainerId),
 Constraint [FK_HSC] Foreign Key(trainerId) References trainers(trainerid) on delete cascade
 );

    Create table Companies(
 [trainerId] varchar(900),
 LastCompanyName Varchar(max),
 TotalExp int,

 Constraint [FK_Com] Foreign Key(trainerId) References trainers(trainerId) on delete cascade
 );

