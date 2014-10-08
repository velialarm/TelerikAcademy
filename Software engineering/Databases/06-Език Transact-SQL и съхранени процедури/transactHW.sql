-- TRANSACT HOMEWORK

-------------------------------------------------------------------------------------------------
-- 1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing. Write a stored procedure that selects the full names of all persons.
create database [homeworkTransact];
use [homeworkTransact];
 drop table person;
 drop table Account;
 drop table Log;

CREATE TABLE Person(
	id [int] IDENTITY(1,1) NOT NULL,
	firstName [nvarchar](150) NOT NULL,
	lastname [nvarchar](150) NULL,
	SSN [nvarchar](150) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY(id));

create table Account(
	id [int] IDENTITY(1,1) NOT NULL,
	personId int NOT NULL,
	balance real not null,
	CONSTRAINT PK_Account PRIMARY KEY(id),
	CONSTRAINT FK_Account_Person FOREIGN KEY(personId) REFERENCES Account(id)
);


insert into person (firstName, lastname, ssn) values('Pesho','Ivanov','A10823H');
insert into person (firstName, lastname, ssn) values('Misha','Stop','1233222FG');
insert into person (firstName, lastname, ssn) values('Slon','Slonova','1231232');
insert into person (firstName, lastname, ssn) values('Mul','Luma','2343GSA');
insert into Account (personId,balance) values (1,500.34);
insert into Account (personId,balance) values (2,500.34);
insert into Account (personId,balance) values (2,560.34);
insert into Account (personId,balance) values (2,300.34);
insert into Account (personId,balance) values (3,2454.14);
insert into Account (personId,balance) values (4,545.34);

select * from person p 
inner join Account a on a.personId = p.id;

CREATE PROCEDURE dbo.usp_selectAcountPerson
AS
	BEGIN
		select 
			p.firstName + '' + p.lastname 
		from person p 
	END
;

EXEC dbo.usp_selectAcountPerson;
-------------------------------------------------------------------------------------------------
-- 2. Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.

create proc usp_peopleWithMoney(@money int = 0)
as
	begin
		select
			*
		from Person p
		inner join Account a on a.personId = p.id
		where a.balance > @money
	end
;
EXEC usp_peopleWithMoney;
EXEC usp_peopleWithMoney 500;

-------------------------------------------------------------------------------------------------
-- 3. Create a function that accepts as parameters – sum, yearly interest rate and number of months. It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.

create function ufn_calculateSum(
	@sum money,
	@yearlyInterestRate real,
	@numberOfMonths int
)
returns money
as
	begin 
		declare @rate money = @yearlyInterestRate / 12 * @numberOfMonths
		return @sum + @rate * @sum
	end
;

select dbo.ufn_calculateSum(300.00, 0.75, 3);

-------------------------------------------------------------------------------------------------
-- 4. Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month. It should take the AccountId and the interest rate as parameters.

create proc usp_interestRateToAccount(@accountId int, @interestRate real)
as
	update Account 
	set balance = (select dbo.ufn_calculateSum(Balance, @interestRate, 1))
	where Id = @accountId
;

EXEC usp_interestRateToAccount 2, 10;

-------------------------------------------------------------------------------------------------
-- 5. Add two more stored procedures WithdrawMoney( AccountId, money) and DepositMoney (AccountId, money) that operate in transactions.

create proc usp_deposit(@accountId int, @ammount money)
as
	begin tran
		update Account set balance = balance + @ammount 
		where id = @accountId
	commit tran
;

create proc usp_draw(@accountId int, @ammount money)
as
	begin tran
		update Account set balance = balance - @ammount 
		where id = @accountId
	commit tran
;

select * from Account where id = 1;
exec usp_deposit 1, 50;
select * from Account where id = 1;
exec usp_draw 1,100;
select * from Account where id = 1;

-------------------------------------------------------------------------------------------------
-- 6. Create another table – Logs(LogID, AccountID, OldSum, NewSum). Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.

create table Log(
	logId [int] IDENTITY(1,1) NOT NULL,
	accountId int,
	oldSum money not null,
	newSum money not null,
	constraint PK_Log primary key(logId),
	constraint FK_Log_Account foreign key(accountId) references Account(id) 
);

create trigger tr_updateAccount
on Account after update
as
	declare @accountId int, @oldSum money, @newSum money
	select @accountId = d.id, @oldSum = d.balance from deleted d
	select @newSum = i.balance from inserted i
	insert into Log(accountId, oldSum, newSum) 
	values( @accountId, @oldSum, @newSum)
;


-------------------------------------------------------------------------------------------------
-- 7. Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) and all town's names that are comprised of given set of letters. Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.


CREATE FUNCTION fn_getNames(
        @name NVARCHAR(50),
        @letters NVARCHAR(50)
        )
        RETURNS bit
AS
BEGIN
	DECLARE @contains bit
	SET @contains = 1
	DECLARE @curLetter NVARCHAR(1)
	DECLARE @counter INT
	SET @counter = 1

	WHILE(@counter <= LEN(@name))
		BEGIN
		SET @curLetter = SUBSTRING(@name, @counter, 1)
		IF (CHARINDEX(@curLetter, @letters) = 0)
				SET @contains = 0
		SET @counter = @counter + 1
		END
	RETURN @contains
END

-------------------------------------------------------------------------------------------------
-- 8. Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.


declare empCursor cursor read_only
for
	select 
	*
	from Employees e
	inner join Addresses a on a.AddressID = e.AddressID
	inner join Towns t on t.TownID = a.TownID

open empCursor
declare @firstName char(50), @lastName char(50), @town char(50)
fetch next from empCursor into @firstName, @lastName, @town

while @@FETCH_STATUS = 0
begin
	print @firstName + '' + @lastName
	fetch next from empCursor
	into @firstName, @lastName, @town
end

close empCursor

-------------------------------------------------------------------------------------------------
-- 9. * Write a T-SQL script that shows for each town a list of all employees that live in it. Sample output: Sofia -> Svetlin Nakov, Martin Kulov, George Denchev Ottawa -> Jose Saraiva

SELECT 
	t.Name+ ' -> '+
	STUFF 
	(
		(
			SELECT
				', ' + e.FirstName + ' ' + e.LastName
			FROM   Employees AS e	
			inner join Addresses ad on ad.AddressID = e.AddressID
			inner join Towns tn on tn.TownID = ad.TownID	
			WHERE t.Name = tn.name
			FOR XML PATH('')
		), 1, 1, ''
)as map
from Employees empl
inner join Addresses a on a.AddressID = empl.AddressID
inner join Towns t on t.TownID = a.TownID	
group by t.Name

-------------------------------------------------------------------------------------------------
-- 10. Define a .NET aggregate function StrConcat that takes as input a sequence of strings and return a single string that consists of the input strings separated by ','. 
--		For example the following SQL statement should return a single string:SELECT StrConcat(FirstName + ' ' + LastName)FROM Employees

DECLARE @name nvarchar(MAX);
SET @name = N'';
SELECT @name+=e.FirstName+N','
FROM Employees e
SELECT LEFT(@name,LEN(@name)-1);

