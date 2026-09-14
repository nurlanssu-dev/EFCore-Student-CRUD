# Student Management System

A console-based **Student Management System** developed with **C# and Entity Framework Core**.

The project demonstrates database connectivity, ORM usage, CRUD operations, One-to-Many relationships, Fluent API configuration, LINQ queries, and pagination using SQL Server.

---

# Project Overview

The application manages students and groups stored in a SQL Server database.

The project contains two main entities:

- Student
- Group

A **Group can contain multiple Students**, creating a One-to-Many relationship.

---

# Database Relationship

```
Group
 |
 |---- Student
 |---- Student
 |---- Student
```

Relationship:

```
One Group  →  Many Students
```

---

# Entities

## Student Entity

| Column | Type | Description |
|---|---|---|
| Id | int | Unique identifier |
| Name | string | Student name |
| Age | int | Student age |
| GroupId | int | Foreign Key |

Example:

```
Students
---------
Id
Name
Age
GroupId
```

---

## Group Entity

| Column | Type | Description |
|---|---|---|
| Id | int | Unique identifier |
| Name | string | Group name |

Example:

```
Groups
---------
Id
Name
```

---

# Technologies Used

- C#
- .NET
- Entity Framework Core
- SQL Server
- LINQ
- ORM
- Fluent API
- Console Application

---

# Project Structure

```
ORM.test

│
├── Models
│   ├── Student.cs
│   └── Group.cs
│
├── DATA
│   ├── AppDbContext.cs
│   └── Configurations
│       ├── StudentConfiguration.cs
│       └── GroupConfiguration.cs
│
├── Services
│   ├── StudentService.cs
│   └── GroupService.cs
│
└── Program.cs
```

---

# Entity Relationship Configuration

The relationship is configured using Fluent API.

Example:

```csharp
builder.HasOne(s => s.Group)
       .WithMany(g => g.Students)
       .HasForeignKey(s => s.GroupId);
```

This configuration creates:

```
Group 1 ---- N Students
```

---

# Student CRUD Operations

## Create Student

Adds a new student with a selected group.

Example:

```csharp
AddStudent("Nurlan Suleymanov", 28, 1);
```

---

## Read Students

Implemented operations:

- Get All Students
- Search Student By Name
- Display Student with Group information

Example output:

```
ID: 1
Name: Nurlan Suleymanov
Age: 28
Group: Group 1
```

---

## Update Student

Updates:

- Student Name
- Student Age
- Student Group

Example:

```csharp
UpdateStudent(1,"Nurlan Updated",30,2);
```

---

## Delete Student

Deletes student by ID.

Example:

```csharp
DeleteStudent(1);
```

---

# Group CRUD Operations

## Create Group

Example:

```csharp
AddGroup("Group 1");
```

---

## Read Groups

Implemented:

- Get All Groups
- Get Group By Id

---

## Update Group

Example:

```csharp
UpdateGroup(1,"C# Backend");
```

---

## Delete Group

Deletes group by ID.

---

# Relationship Operations

The project includes operations between Student and Group.

## Add Student To Group

When creating a student, GroupId is assigned.

Example:

```csharp
AddStudent("Ali",20,1);
```

---

## Change Student Group

Moves a student from one group to another.

Example:

```csharp
ChangeStudentGroup(1,3);
```

---

## Get Students By Group

Displays all students inside a group.

Example:

```
Group: C#

Students:

1 Ali
2 Murad
3 Leyla
```

---

# Pagination

Students can be displayed page by page.

Page size:

```
3 students per page
```

Implementation:

```csharp
Skip()
Take()
```

Example:

```
Page 1

1 Ali
2 Murad
3 Leyla
```

---

# Application Flow

Example service usage:

```csharp
var context = new AppDbContext();

var studentService = new StudentService(context);
var groupService = new GroupService(context);


groupService.AddGroup("Group 1");

studentService.AddStudent(
    "Nurlan Suleymanov",
    28,
    1
);

studentService.GetAllStudents();

groupService.GetStudentsByGroup(1);
```

---

# CRUD Summary

| Entity | Create | Read | Update | Delete |
|---|---|---|---|---|
| Student | ✅ | ✅ | ✅ | ✅ |
| Group | ✅ | ✅ | ✅ | ✅ |

---

# Concepts Demonstrated

This project demonstrates:

- Entity Framework Core
- ORM concepts
- Database connection
- Entity relationships
- Foreign Keys
- Navigation Properties
- Fluent API
- CRUD operations
- LINQ queries
- Service Layer architecture
- Pagination
- SQL Server integration

---

# Database Configuration

Connection string example:

```
Server=YOUR_SERVER;
Database=StudentOrmDb;
Trusted_Connection=True;
TrustServerCertificate=True;
```

Replace `YOUR_SERVER` with your SQL Server instance.

---

# How to Run

1. Clone the repository.
2. Open the project in Visual Studio or Rider.
3. Configure SQL Server connection.
4. Apply migrations.
5. Run the application.

---

# Project Purpose

The purpose of this project is to practice:

- Building database-driven applications with C#
- Working with Entity Framework Core
- Understanding ORM relationships
- Implementing CRUD architecture
- Managing related entities using services

---

## Author

Developed as a practical C# Entity Framework Core assignment.
