use CompanyDB;

insert into Employees
values(1, 'test', 'testov', 1, 200.20);

insert into Employees(firstName, lastName, experience, salary)
values('goshko', 'vasilev', 0, 30.20);

insert into Employees(firstName, lastName, experience, salary)
values	('pesho', 'peshev', 10, 3230.50),
		('tosho', 'kukata', 0, 2.05),
		('glavniq', 'iliev', 50, 90000.50);

select * from Employees;

insert into Teams(name)
values 	('MG team'),
		('MangoGang'),
        ('Loko Plovdiv');
        
update Teams
SET name = 'Mango Gang'
WHERE name = 'MangoGang';
        
        
insert into EmployeesTeams(employeeId, teamID)
values (
	(select id from Employees 
	 where lastName = 'iliev'), 
	(select id from Teams 
	 where name = 'MG team')
);

insert into EmployeesTeams(employeeId, teamID)
values 
(
	(select id from Employees 
	 where firstName = 'test'), 
	(select id from Teams 
	 where name = 'MG team')
),
(
	(select id from Employees 
	 where firstName = 'tosho'), 
	(select id from Teams 
	 where name = 'Loko Plovdiv')
);

insert into EmployeesTeams(employeeId, teamID)
SELECT 
    id,
    (SELECT t.id FROM Teams AS t WHERE name = 'Mango Gang') AS 'Team'
FROM EmployeesTeams AS et 
RIGHT JOIN Employees AS e ON et.employeeId = e.id
WHERE et.employeeID IS NULL;

SELECT 
    t.name AS 'Team',
    CONCAT(e.firstName, ' ', e.lastName) AS 'Employee'
FROM EmployeesTeams AS et
	JOIN Employees AS e ON et.employeeId = e.id
	JOIN Teams AS t ON et.teamId = t.id;
    
select * from Tasks;

-- deletes all entries
-- truncate table Tasks;
    
insert into Tasks(description, startDate, dueDate, teamID)
values ('create database', now(), DATE_ADD(now(), INTERVAL 2 DAY), (select id from Teams where name = 'MG team'));

insert into Tasks(description, startDate, dueDate, teamID)
values 	('steal iron', now(), DATE_ADD(now(), INTERVAL 3 DAY), (select id from Teams where name = 'Mango Gang')),
		('sell iron', DATE_ADD(now(), INTERVAL 3 DAY), DATE_ADD(now(), INTERVAL 4 DAY), (select id from Teams where name = 'Mango Gang')),
		('beat mangos', now(), DATE_ADD(now(), INTERVAL 10 DAY), (select id from Teams where name = 'Loko Plovdiv'));

-- MG team
-- Mango Gang
-- Loko Plovdiv
