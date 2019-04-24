Use EmployeeDB
Go 
Create Table Employee(
       ID int primary key identity,
	   FirstName nvarchar(50),
	   LastName nvarchar(50),
	   Gender nvarchar(20),
	   Salary int

)
Go
Insert into Employee values('Mark','Hastings','Male',60000)
Insert into Employee values('steve','jobs','Male',50000)
Insert into Employee values('Karim','Rahman','Male',70000)
Insert into Employee values('Rahima','Banu','Female',60000)
Insert into Employee values('Samantha','janina','Female',60000)
Insert into Employee values('karima','khatun','female',60000)
