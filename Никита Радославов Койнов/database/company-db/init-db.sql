create database CompanyDB;
use CompanyDB;

create table Employees(
id int auto_increment,
firstName varchar(40) not null,
lastName varchar(40) not null,
experience int check(experience >= 0 and experience <= 70),
salary decimal(9,2) check(salary > 0),
constraint PK_Employees primary key(id));

create table Teams(
id int auto_increment,
name varchar(50) not null,
constraint PK_Teams primary key(id));

create table EmployeesTeams(
employeeID int,
teamID int,
constraint PK_EmployeesTeams primary key(employeeID, teamID),
constraint FK_EmployeesTeams_Employees foreign key(employeeID)
references Employees(id),
constraint FK_EmployeesTeams_Teams foreign key(teamID)
references Teams(id)
);

create table Tasks(
id int auto_increment,
description text not null,
startDate date not null,
dueDate date not null,
teamID int not null,
constraint PK_Tasks primary key(id),
constraint FK_Tasks_Teams foreign key(teamID)
references Teams(id));
