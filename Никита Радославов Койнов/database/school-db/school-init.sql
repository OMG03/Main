use sys;
drop database SchoolDB;

create database SchoolDB;
use school;

create table Courses (
	id int,
    grade smallint not null,
    gradeChar char(1) not null,
    constraint PK_Course primary key (id),
    constraint UQ_Grade_GradeChar unique (grade, gradeChar)
);

create table Students (
	id int,
    firstName varchar(20) not null,
    secondName varchar(20), -- nullable
    lastName varchar(20) not null,
    courseId int not null,
    entryYear date not null,
    constraint PK_Students primary key (id),
    constraint FK_Students_Courses foreign key (courseId) references Courses(id)
);

create table Teachers (
	id int,
    firstName varchar(20) not null,
    secondName varchar(20), -- nullable
    lastName varchar(20) not null,
    yearsExperience smallint, -- nullable
    salary decimal(6, 2) not null,
    constraint PK_Teachers primary key (id)
);

-- drop table TeachersCourses;
-- [ISSUE] does not add foreign key to the first column of the primary key
create table TeachersCourses (
	teacherId int,
    courseId int,
    constraint PK_TeachersCourses primary key (teacherId, courseId)
	-- constraint FK_TeachersCourses_Teachers foreign key (teacherId) references Teachers(id),
    -- constraint FK_TeachersCourses_Courses foreign key (courseId) references Courses(id)
);

create table SubjectType (
	id int,
	label varchar(30) not null,
    constraint PK_SubjectType primary key (id)
);

create table Subjects (
	id int,
    label varchar(30) not null,
    typeId int not null,
    constraint PK_Subjects primary key (id),
    constraint FK_Subjects_SubjectTypes foreign key (typeId) references SubjectType(id)
);
