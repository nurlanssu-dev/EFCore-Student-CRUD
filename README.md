# Student Management System

A console-based **Student Management System** developed with **C# and SQL Server**.

The project demonstrates database connectivity, CRUD operations, ORM usage, raw SQL queries, and pagination in a simple console application.

---

## Project Overview

The application allows users to manage student records stored in a SQL Server database.

Each student contains the following information:

| Column | Type   | Description       |
| ------ | ------ | ----------------- |
| `Id`   | int    | Unique identifier |
| `Name` | string | Student name      |
| `Age`  | int    | Student age       |

### Students Table

```text
Students
--------
Id
Name
Age
```

---

## Technologies Used

* C#
* .NET
* SQL Server
* ORM / Entity Framework
* ADO.NET
* SQL
* Console Application

---

# Features

The project consists of seven main tasks.

## Task 1 — Database Connection & ORM Setup

The application is connected to a SQL Server database and the required ORM configuration is created.

Main responsibilities:

* Configure the database connection
* Create the `Student` entity
* Configure the database context
* Map the `Students` table
* Prepare the application for database operations

---

## Task 2 — Insert Student

The application reads a student's **Name** and **Age** from the console and inserts the new student into the database.

### Example

```text
Enter student name:
Ali

Enter student age:
20

Student added successfully.
```

The inserted data is stored in the `Students` table.

---

## Task 3 — Get All Students

All students stored in the database are retrieved and displayed in the console.

> **Note:** This task is implemented using ORM instead of manually reading the data with `SqlCommand`, `ExecuteReader()` and `SqlDataReader`.

The ORM retrieves the collection of students from the `Students` table and the application displays each record.

### Example Output

```text
1 Ali 20
2 Leyla 21
3 Murad 19
```

This implementation demonstrates how ORM can simplify data retrieval by mapping database records directly to C# objects.

---

## Task 4 — Search Student

The application asks the user to enter a student name.

The database is searched for a matching student and the result is displayed in the console.

### Example

```text
Enter student name:
Ali
```

### Output

```text
1 Ali 20
```

If no matching student exists, the application informs the user that the student was not found.

---

## Task 5 — Update Student

The user enters:

* Student `Id`
* New `Age`

The application finds the corresponding student and updates the age in the database.

### Example

```text
Enter student id:
1

Enter new age:
21

Student updated successfully.
```

---

## Task 6 — Delete Student

The application deletes a student using the entered student ID.

### Example

```text
Enter student id:
3

Student deleted.
```

If a student with the specified ID does not exist, an appropriate message is displayed.

---

## Task 7 — Pagination

The student list is divided into pages.

The page size is:

```text
Page Size: 3
```

### Example

```text
Page 1

1 Ali
2 Murad
3 Leyla
```

Pagination is implemented at the SQL level using:

```sql
OFFSET
FETCH NEXT
```

Example query structure:

```sql
SELECT Id, Name, Age
FROM Students
ORDER BY Id
OFFSET @Offset ROWS
FETCH NEXT @PageSize ROWS ONLY;
```

This approach retrieves only the records required for the requested page instead of loading the entire table into memory.

---

# CRUD Operations

The application demonstrates the four fundamental database operations:

| Operation | Feature                  |
| --------- | ------------------------ |
| Create    | Insert Student           |
| Read      | Get All / Search Student |
| Update    | Update Student           |
| Delete    | Delete Student           |

---

# Application Flow

```text
Student Management System

1. Add Student
2. Get All Students
3. Search Student
4. Update Student
5. Delete Student
6. Show Students with Pagination
0. Exit
```

The user selects an operation from the console menu and the corresponding database action is executed.

---

# Example Student Data

| Id | Name  | Age |
| -: | ----- | --: |
|  1 | Ali   |  20 |
|  2 | Leyla |  21 |
|  3 | Murad |  19 |

---

# Database Configuration

Before running the project, make sure SQL Server is installed and the application has access to the database.

Configure the connection string according to your environment.

Example:

```text
Server=YOUR_SERVER;
Database=StudentDb;
Trusted_Connection=True;
TrustServerCertificate=True;
```

Replace `YOUR_SERVER` with your SQL Server instance name.

---

# How to Run

1. Clone the repository.
2. Open the project in Visual Studio or Rider.
3. Configure the SQL Server connection string.
4. Create or update the database.
5. Run the application.
6. Select the desired operation from the console menu.

---

# Key Concepts Demonstrated

This project demonstrates practical usage of:

* Database connection management
* ORM configuration
* Entity-to-table mapping
* CRUD operations
* Console input handling
* SQL queries
* Parameterized queries
* Data retrieval
* Record searching
* Record updating
* Record deletion
* SQL pagination
* `OFFSET`
* `FETCH NEXT`

---

# ORM Usage

ORM is used in the project to work with database records as C# objects.

In particular, **Task 3 — Get All Students** retrieves student records through ORM.

Instead of manually processing rows with:

```text
SqlCommand
ExecuteReader()
SqlDataReader
```

the ORM maps the database rows directly to `Student` objects.

This makes the code:

* Cleaner
* Easier to maintain
* More readable
* Less repetitive

---

# Project Purpose

The main goal of this project is to practice working with databases in a C# application and understand the differences between:

* ORM-based database operations
* Direct SQL / ADO.NET operations

It also provides practical experience with CRUD operations and server-side pagination.

---

## Author

Developed as a practical C# database assignment.
