using ORM.test.DATA;
using ORM.test.Models;


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

AppDbContext context = new AppDbContext();

Console.Write("Enter student name: ");
string name = Console.ReadLine()!;

var student = context.Students
    .FirstOrDefault(s => s.Name == name);

if (student != null)
{
    Console.WriteLine($"ID: {student.Id} StudentName: {student.Name} Age: {student.Age}");
}
else
{
    Console.WriteLine("Student not found.");
}
