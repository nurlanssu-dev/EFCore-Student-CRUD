using Microsoft.EntityFrameworkCore;
using ORM.test.DATA;
using ORM.test.Models;
using ORM.test.Services;
#region tasklarin proqram.cs icinde yazilmasi
//-------------------Task2-----------------


//AppDbContext context = new AppDbContext();

//Console.Write("Enter name: ");
//string name = Console.ReadLine()!;

//Console.Write("Enter age: ");
//int age = int.Parse(Console.ReadLine()!);

//Student student = new Student
//{
//    Name = name,
//    Age = age
//};

//context.Students.Add(student);

//context.SaveChanges();

//Console.WriteLine("Student added successfully.");

//-------------------Task3-----------------

//AppDbContext context = new AppDbContext();

//var students = context.Students
//    .ToList();

//foreach (var student in students)
//{
//    Console.WriteLine($"ID : {student.Id} StudentName: {student.Name} Age: {student.Age}");
//}

//-------------------Task4-----------------

//AppDbContext context = new AppDbContext();

//Console.Write("Enter student name: ");
//string name = Console.ReadLine()!;

//var student = context.Students
//    .FirstOrDefault(s => s.Name == name);

//if (student != null)
//{
//    Console.WriteLine($"ID: {student.Id} StudentName: {student.Name} Age: {student.Age}");
//}
//else
//{
//    Console.WriteLine("Student not found.");
//}

//-------------------Task5-----------------

//AppDbContext context = new AppDbContext();
//Console.Write("Enter student ID ");
//int id = int.Parse(Console.ReadLine()!);

//Console.Write("Enter student newAge: ");
//int newAge = int.Parse(Console.ReadLine()!);

//var student = context.Students
//    .FirstOrDefault(s => s.Id == id);

//if (student != null)
//{
//    student.Age = newAge;
//    context.SaveChanges();
//    Console.WriteLine("Student age updated successfully.");
//}
//else
//{
//    Console.WriteLine("Student not found.");
//}

//-------------------Task6-----------------

//AppDbContext context = new AppDbContext();

//Console.Write("Enter student ID: ");
//int id = int.Parse(Console.ReadLine()!);

//var student = context.Students
//    .FirstOrDefault(s => s.Id == id);

//if (student != null)
//{
//    context.Students.Remove(student);
//    context.SaveChanges();
//    Console.WriteLine("Student deleted");
//}
//else
//{
//    Console.WriteLine("Student not found.");
//}

//-------------------Task7-----------------

//AppDbContext context = new AppDbContext();

//int pageSize = 3;

//Console.Write("Enter page number: ");
//int pageNumber = int.Parse(Console.ReadLine()!);

//int offset = (pageNumber - 1) * pageSize;

//var students = context.Students
//    .FromSqlInterpolated($@"
//        SELECT * FROM Students
//        ORDER BY Id
//        OFFSET {offset} ROWS
//        FETCH NEXT {pageSize} ROWS ONLY")
//    .ToList();

//Console.WriteLine($"Page {pageNumber}");

//foreach (var student in students)
//{
//    Console.WriteLine($"{student.Id} {student.Name}");
//}
#endregion

#region tasklarin service icinde yazilib methodlarin cagirildigi yer
AppDbContext context = new AppDbContext();

var studentService = new StudentService(context);

studentService.AddStudent("SNurlan", 28);
studentService.GetStudentByName("SNurlan");
studentService.GetAllStudents();
studentService.UpdateStudentAge(1, 30);
studentService.DeleteStudent(1);
studentService.GetStudentsByPage(1);

#endregion