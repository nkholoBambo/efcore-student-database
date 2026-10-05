Losman Student Database — Entity Framework Core

A C# console application demonstrating Entity Framework Core connected to a real SQL Server database, replacing raw ADO.NET (SqlConnection/ SqlCommand) with LINQ-based data access.

What it does:
-Defines a Student class mapped to a Students table in SQL Server
-Uses a custom AppDbContext (DbContext) to manage the database connection and expose a DbSet<Student> representing the table
-Reads all students using LINQ (context.Students.ToList()) instead of a raw SELECT query
-Inserts a new student using context.Students.Add() and context.SaveChanges(), with a duplicate check (.Any()) before inserting, to avoid adding the same student twice

Tech used:
-C#
-Entity Framework Core (Microsoft.EntityFrameworkCore.SqlServer, Microsoft.EntityFrameworkCore.Design)
-SQL Server Express (local instance)

Database setup
This project expects a Students table to already exist. Run this in SQL Server Management Studio (SSMS) against your target database first:

sql
CREATE TABLE Students (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Mark INT
);

Update the connection string in AppDbContext.cs to match your own server name and database name before running.


How to run:
-Clone this repo
-Ensure SQL Server Express is installed and the Students table exists (see above)
-Run:
   1. dotnet restore
   2. dotnet run

Concepts practiced:
-DbContext and DbSet<T> — mapping C# classes to database tables
-LINQ queries running directly against a real database, not just an in-memory list
-Add() vs SaveChanges() — staging a change in memory versus actually committing it to the database
-Preventing duplicate inserts using .Any() to check for an existing match before adding a new record

Bugs found and fixed during development
-An early version read the student list into a variable before adding a new student, so newly added records didn't appear in the printed output until the next run. Fixed by moving the read to after the insert logic.
-Running the insert logic multiple times without a duplicate check created several duplicate records. Fixed by checking context.Students.Any(s => s.Name == "...") before adding, so a matching record is only ever inserted once.

Note:
This builds directly on an earlier raw ADO.NET version of the same database (SqlConnection/SqlCommand), which is kept as a separate project to show the progression from manual SQL to Entity Framework Core.
