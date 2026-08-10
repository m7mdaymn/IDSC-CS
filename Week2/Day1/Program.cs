using System;
using System.Collections.Generic;

namespace IDSCTraining.Week2;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("============================");
        Console.WriteLine("Week 2 - OOP (30 Drills)");
        Console.WriteLine("============================");
        Console.Write("Choose a drill number (1-30): ");

        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 30)
        {
            Console.WriteLine("Invalid drill number.");
            return;
        }

        Console.WriteLine();

        switch (choice)
        {
            case 1: Drill01.Run(); break;
            case 2: Drill02.Run(); break;
            case 3: Drill03.Run(); break;
            case 4: Drill04.Run(); break;
            case 5: Drill05.Run(); break;
            case 6: Drill06.Run(); break;
            case 7: Drill07.Run(); break;
            case 8: Drill08.Run(); break;
            case 9: Drill09.Run(); break;
            case 10: Drill10.Run(); break;
            case 11: Drill11.Run(); break;
            case 12: Drill12.Run(); break;
            case 13: Drill13.Run(); break;
            case 14: Drill14.Run(); break;
            case 15: Drill15.Run(); break;
            case 16: Drill16.Run(); break;
            case 17: Drill17.Run(); break;
            case 18: Drill18.Run(); break;
            case 19: Drill19.Run(); break;
            case 20: Drill20.Run(); break;
            case 21: Drill21.Run(); break;
            case 22: Drill22.Run(); break;
            case 23: Drill23.Run(); break;
            case 24: Drill24.Run(); break;
            case 25: Drill25.Run(); break;
            case 26: Drill26.Run(); break;
            case 27: Drill27.Run(); break;
            case 28: Drill28.Run(); break;
            case 29: Drill29.Run(); break;
            case 30: Drill30.Run(); break;
        }
    }

    // ============================================================
    // 01 - Person Class + Object
    // ============================================================
    static class Drill01
    {
        public class Person
        {
            public string Name { get; set; } = string.Empty;
            public int Age { get; set; }
        }

        public static void Run()
        {
            Person person = new()
            {
                Name = "Mohamed",
                Age = 22
            };

            Console.WriteLine($"Name: {person.Name}");
            Console.WriteLine($"Age: {person.Age}");
        }
    }

    // ============================================================
    // 02 - Student Class with Name, Age, GPA
    // ============================================================
    static class Drill02
    {
        public class Student
        {
            public string Name { get; set; } = string.Empty;
            public int Age { get; set; }
            public double GPA { get; set; }

            public void DisplayInfo()
            {
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Age: {Age}");
                Console.WriteLine($"GPA: {GPA}");
            }
        }

        public static void Run()
        {
            Student student = new()
            {
                Name = "Ahmed",
                Age = 21,
                GPA = 3.6
            };

            student.DisplayInfo();
        }
    }

    // ============================================================
    // 03 - Multiple Objects from Same Class
    // ============================================================
    static class Drill03
    {
        public class Student
        {
            public string Name { get; set; } = string.Empty;
            public int Age { get; set; }

            public void Display()
            {
                Console.WriteLine($"Name: {Name}, Age: {Age}");
            }
        }

        public static void Run()
        {
            Student student1 = new() { Name = "Ahmed", Age = 20 };
            Student student2 = new() { Name = "Sara", Age = 21 };
            Student student3 = new() { Name = "Omar", Age = 22 };

            student1.Display();
            student2.Display();
            student3.Display();
        }
    }

    // ============================================================
    // 04 - Class vs Object using Car
    // ============================================================
    static class Drill04
    {
        public class Car
        {
            public string Brand { get; set; } = string.Empty;
            public string Model { get; set; } = string.Empty;
            public int Year { get; set; }

            public void Display()
            {
                Console.WriteLine($"{Brand} {Model} - {Year}");
            }
        }

        public static void Run()
        {
            Car car1 = new() { Brand = "Toyota", Model = "Corolla", Year = 2022 };
            Car car2 = new() { Brand = "BMW", Model = "320i", Year = 2023 };
            Car car3 = new() { Brand = "Kia", Model = "Sportage", Year = 2024 };

            car1.Display();
            car2.Display();
            car3.Display();

            Console.WriteLine("\nCar is the class. car1, car2, and car3 are objects created from it.");
        }
    }

    // ============================================================
    // 05 - Default Constructor
    // ============================================================
    static class Drill05
    {
        public class Employee
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public decimal Salary { get; set; }

            public Employee()
            {
                Name = "Default Employee";
                Id = 1;
                Salary = 5000m;
            }

            public void Display()
            {
                Console.WriteLine($"Id: {Id}, Name: {Name}, Salary: {Salary:F2}");
            }
        }

        public static void Run()
        {
            Employee employee = new();
            employee.Display();
        }
    }

    // ============================================================
    // 06 - Parameterized Constructor
    // ============================================================
    static class Drill06
    {
        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }

            public Book(string title, string author)
            {
                Title = title;
                Author = author;
            }

            public void Display()
            {
                Console.WriteLine($"Title: {Title}");
                Console.WriteLine($"Author: {Author}");
            }
        }

        public static void Run()
        {
            Book book = new("Clean Code", "Robert C. Martin");
            book.Display();
        }
    }

    // ============================================================
    // 07 - Constructor Overloading
    // ============================================================
    static class Drill07
    {
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Salary { get; set; }

            public Employee()
            {
                Id = 0;
                Name = "Unknown";
                Salary = 0;
            }

            public Employee(int id, string name)
            {
                Id = id;
                Name = name;
                Salary = 0;
            }

            public Employee(int id, string name, decimal salary)
            {
                Id = id;
                Name = name;
                Salary = salary;
            }

            public void Display()
            {
                Console.WriteLine($"Id: {Id}, Name: {Name}, Salary: {Salary:F2}");
            }
        }

        public static void Run()
        {
            new Employee().Display();
            new Employee(1, "Ahmed").Display();
            new Employee(2, "Sara", 12000).Display();
        }
    }

    // ============================================================
    // 08 - this Keyword: Fields vs Parameters
    // ============================================================
    static class Drill08
    {
        public class Person
        {
            private string name;
            private int age;

            public Person(string name, int age)
            {
                this.name = name;
                this.age = age;
            }

            public void Display()
            {
                Console.WriteLine($"Name: {name}, Age: {age}");
            }
        }

        public static void Run()
        {
            Person person = new("Mohamed", 22);
            person.Display();
        }
    }

    // ============================================================
    // 09 - this Keyword: Constructor Chaining
    // ============================================================
    static class Drill09
    {
        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }

            public Product() : this("Unknown", 0, 0)
            {
            }

            public Product(string name) : this(name, 0, 0)
            {
            }

            public Product(string name, decimal price, int quantity)
            {
                Name = name;
                Price = price;
                Quantity = quantity;
            }

            public void Display()
            {
                Console.WriteLine($"Name: {Name}, Price: {Price}, Quantity: {Quantity}");
            }
        }

        public static void Run()
        {
            new Product().Display();
            new Product("Laptop").Display();
            new Product("Phone", 20000, 2).Display();
        }
    }

    // ============================================================
    // 10 - Return Current Object using this
    // ============================================================
    static class Drill10
    {
        public class Counter
        {
            public int Value { get; private set; }

            public Counter Increment()
            {
                Value++;
                return this;
            }

            public Counter Add(int amount)
            {
                Value += amount;
                return this;
            }
        }

        public static void Run()
        {
            Counter counter = new();

            counter
                .Increment()
                .Increment()
                .Add(5);

            Console.WriteLine($"Counter: {counter.Value}");
        }
    }

    // ============================================================
    // 11 - public, private, protected
    // ============================================================
    static class Drill11
    {
        public class Person
        {
            public string Name = "Ahmed";
            private int nationalId = 123456;
            protected int Age = 30;

            public void DisplayPrivateValue()
            {
                Console.WriteLine($"Private National Id: {nationalId}");
            }
        }

        public class Employee : Person
        {
            public void DisplayProtectedValue()
            {
                Console.WriteLine($"Protected Age: {Age}");
            }
        }

        public static void Run()
        {
            Employee employee = new();

            Console.WriteLine($"Public Name: {employee.Name}");
            employee.DisplayPrivateValue();
            employee.DisplayProtectedValue();
        }
    }

    // ============================================================
    // 12 - internal Access Modifier
    // ============================================================
    static class Drill12
    {
        internal class InternalService
        {
            internal string Message { get; } = "Accessible inside the same assembly/project.";

            internal void Display()
            {
                Console.WriteLine(Message);
            }
        }

        public static void Run()
        {
            InternalService service = new();
            service.Display();
        }
    }

    // ============================================================
    // 13 - Encapsulation with Private Fields + Methods
    // ============================================================
    static class Drill13
    {
        public class BankAccount
        {
            private decimal balance;

            public void Deposit(decimal amount)
            {
                if (amount > 0)
                {
                    balance += amount;
                }
            }

            public decimal GetBalance()
            {
                return balance;
            }
        }

        public static void Run()
        {
            BankAccount account = new();
            account.Deposit(1000);

            Console.WriteLine($"Balance: {account.GetBalance():F2}");
        }
    }

    // ============================================================
    // 14 - Manual Getter and Setter Methods
    // ============================================================
    static class Drill14
    {
        public class Student
        {
            private string name = string.Empty;
            private double grade;

            public void SetName(string value)
            {
                name = value;
            }

            public string GetName()
            {
                return name;
            }

            public void SetGrade(double value)
            {
                if (value >= 0 && value <= 100)
                {
                    grade = value;
                }
            }

            public double GetGrade()
            {
                return grade;
            }
        }

        public static void Run()
        {
            Student student = new();
            student.SetName("Ahmed");
            student.SetGrade(90);

            Console.WriteLine($"Name: {student.GetName()}");
            Console.WriteLine($"Grade: {student.GetGrade()}");
        }
    }

    // ============================================================
    // 15 - Properties instead of Getter/Setter Methods
    // ============================================================
    static class Drill15
    {
        public class Student
        {
            public string Name { get; set; } = string.Empty;
            public double Grade { get; set; }
        }

        public static void Run()
        {
            Student student = new()
            {
                Name = "Sara",
                Grade = 95
            };

            Console.WriteLine($"Name: {student.Name}");
            Console.WriteLine($"Grade: {student.Grade}");
        }
    }

    // ============================================================
    // 16 - Age Property Validation (18 to 60)
    // ============================================================
    static class Drill16
    {
        public class Employee
        {
            private int age;

            public int Age
            {
                get => age;
                set
                {
                    if (value >= 18 && value <= 60)
                    {
                        age = value;
                    }
                    else
                    {
                        Console.WriteLine("Age must be between 18 and 60.");
                    }
                }
            }
        }

        public static void Run()
        {
            Employee employee = new();

            employee.Age = 25;
            Console.WriteLine($"Valid Age: {employee.Age}");

            employee.Age = 70;
            Console.WriteLine($"Age after invalid assignment: {employee.Age}");
        }
    }

    // ============================================================
    // 17 - BankAccount: Balance changed only through methods
    // ============================================================
    static class Drill17
    {
        public class BankAccount
        {
            public decimal Balance { get; private set; }

            public void Deposit(decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Deposit amount must be positive.");
                    return;
                }

                Balance += amount;
            }

            public void Withdraw(decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Withdrawal amount must be positive.");
                    return;
                }

                if (amount > Balance)
                {
                    Console.WriteLine("Insufficient balance.");
                    return;
                }

                Balance -= amount;
            }
        }

        public static void Run()
        {
            BankAccount account = new();

            account.Deposit(5000);
            account.Withdraw(1200);

            Console.WriteLine($"Balance: {account.Balance:F2}");
        }
    }

    // ============================================================
    // 18 - Rectangle Properties + Area Method
    // ============================================================
    static class Drill18
    {
        public class Rectangle
        {
            public double Length { get; set; }
            public double Width { get; set; }

            public double CalculateArea()
            {
                return Length * Width;
            }
        }

        public static void Run()
        {
            Rectangle rectangle = new()
            {
                Length = 10,
                Width = 5
            };

            Console.WriteLine($"Area: {rectangle.CalculateArea()}");
        }
    }

    // ============================================================
    // 19 - Animal -> Dog Inheritance
    // ============================================================
    static class Drill19
    {
        public class Animal
        {
            public string Name { get; set; } = string.Empty;

            public void DisplayAnimalInfo()
            {
                Console.WriteLine($"Animal Name: {Name}");
            }
        }

        public class Dog : Animal
        {
            public string Breed { get; set; } = string.Empty;

            public void DisplayDogInfo()
            {
                DisplayAnimalInfo();
                Console.WriteLine($"Breed: {Breed}");
            }
        }

        public static void Run()
        {
            Dog dog = new()
            {
                Name = "Max",
                Breed = "German Shepherd"
            };

            dog.DisplayDogInfo();
        }
    }

    // ============================================================
    // 20 - Multilevel Inheritance Person -> Employee -> Manager
    // ============================================================
    static class Drill20
    {
        public class Person
        {
            public string Name { get; set; } = string.Empty;
        }

        public class Employee : Person
        {
            public decimal Salary { get; set; }
        }

        public class Manager : Employee
        {
            public string Department { get; set; } = string.Empty;

            public void Display()
            {
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Salary: {Salary:F2}");
                Console.WriteLine($"Department: {Department}");
            }
        }

        public static void Run()
        {
            Manager manager = new()
            {
                Name = "Mohamed",
                Salary = 25000,
                Department = "Software"
            };

            manager.Display();
        }
    }

    // ============================================================
    // 21 - Derived Class Accessing Protected Member
    // ============================================================
    static class Drill21
    {
        public class Person
        {
            protected string NationalId = "123456789";
        }

        public class Employee : Person
        {
            public void DisplayNationalId()
            {
                Console.WriteLine($"National Id: {NationalId}");
            }
        }

        public static void Run()
        {
            Employee employee = new();
            employee.DisplayNationalId();
        }
    }

    // ============================================================
    // 22 - Base Parameterized Constructor using base
    // ============================================================
    static class Drill22
    {
        public class Person
        {
            public string Name { get; }
            public int Age { get; }

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }

        public class Employee : Person
        {
            public decimal Salary { get; }

            public Employee(string name, int age, decimal salary)
                : base(name, age)
            {
                Salary = salary;
            }

            public void Display()
            {
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Age: {Age}");
                Console.WriteLine($"Salary: {Salary:F2}");
            }
        }

        public static void Run()
        {
            Employee employee = new("Ahmed", 28, 18000);
            employee.Display();
        }
    }

    // ============================================================
    // 23 - Virtual + Override DisplayInfo
    // ============================================================
    static class Drill23
    {
        public class Person
        {
            public string Name { get; set; } = string.Empty;

            public virtual void DisplayInfo()
            {
                Console.WriteLine($"Person Name: {Name}");
            }
        }

        public class Employee : Person
        {
            public decimal Salary { get; set; }

            public override void DisplayInfo()
            {
                Console.WriteLine($"Employee Name: {Name}");
                Console.WriteLine($"Salary: {Salary:F2}");
            }
        }

        public static void Run()
        {
            Person person = new Employee
            {
                Name = "Sara",
                Salary = 15000
            };

            person.DisplayInfo();
        }
    }

    // ============================================================
    // 24 - Method Overloading vs Method Overriding
    // ============================================================
    static class Drill24
    {
        public class Calculator
        {
            public int Add(int first, int second)
            {
                return first + second;
            }

            public double Add(double first, double second)
            {
                return first + second;
            }
        }

        public class Animal
        {
            public virtual void MakeSound()
            {
                Console.WriteLine("Animal sound");
            }
        }

        public class Dog : Animal
        {
            public override void MakeSound()
            {
                Console.WriteLine("Dog barks");
            }
        }

        public static void Run()
        {
            Calculator calculator = new();

            Console.WriteLine($"Overloading int: {calculator.Add(2, 3)}");
            Console.WriteLine($"Overloading double: {calculator.Add(2.5, 3.5)}");

            Animal animal = new Dog();
            Console.Write("Overriding: ");
            animal.MakeSound();
        }
    }

    // ============================================================
    // 25 - Overload CalculateArea for Square, Rectangle, Circle
    // ============================================================
    static class Drill25
    {
        public class AreaCalculator
        {
            public double CalculateArea(double side)
            {
                return side * side;
            }

            public double CalculateArea(double length, double width)
            {
                return length * width;
            }

            public double CalculateArea(double radius, bool isCircle)
            {
                return Math.PI * radius * radius;
            }
        }

        public static void Run()
        {
            AreaCalculator calculator = new();

            Console.WriteLine($"Square Area: {calculator.CalculateArea(5)}");
            Console.WriteLine($"Rectangle Area: {calculator.CalculateArea(10, 4)}");
            Console.WriteLine($"Circle Area: {calculator.CalculateArea(3, true):F2}");
        }
    }

    // ============================================================
    // 26 - Vehicle -> Car / Motorcycle Override StartEngine
    // ============================================================
    static class Drill26
    {
        public class Vehicle
        {
            public virtual void StartEngine()
            {
                Console.WriteLine("Vehicle engine started.");
            }
        }

        public class Car : Vehicle
        {
            public override void StartEngine()
            {
                Console.WriteLine("Car engine started with push button.");
            }
        }

        public class Motorcycle : Vehicle
        {
            public override void StartEngine()
            {
                Console.WriteLine("Motorcycle engine started.");
            }
        }

        public static void Run()
        {
            Vehicle[] vehicles =
            {
                new Car(),
                new Motorcycle()
            };

            foreach (Vehicle vehicle in vehicles)
            {
                vehicle.StartEngine();
            }
        }
    }

    // ============================================================
    // 27 - Shape Hierarchy + Area Override
    // ============================================================
    static class Drill27
    {
        public abstract class Shape
        {
            public abstract double CalculateArea();
        }

        public class Circle : Shape
        {
            public double Radius { get; set; }

            public Circle(double radius)
            {
                Radius = radius;
            }

            public override double CalculateArea()
            {
                return Math.PI * Radius * Radius;
            }
        }

        public class Rectangle : Shape
        {
            public double Length { get; set; }
            public double Width { get; set; }

            public Rectangle(double length, double width)
            {
                Length = length;
                Width = width;
            }

            public override double CalculateArea()
            {
                return Length * Width;
            }
        }

        public class Triangle : Shape
        {
            public double Base { get; set; }
            public double Height { get; set; }

            public Triangle(double @base, double height)
            {
                Base = @base;
                Height = height;
            }

            public override double CalculateArea()
            {
                return 0.5 * Base * Height;
            }
        }

        public static void Run()
        {
            Shape[] shapes =
            {
                new Circle(3),
                new Rectangle(10, 5),
                new Triangle(8, 4)
            };

            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"{shape.GetType().Name} Area: {shape.CalculateArea():F2}");
            }
        }
    }

    // ============================================================
    // 28 - Library System
    // ============================================================
    static class Drill28
    {
        public class Book
        {
            private string title;
            private string author;
            private decimal price;

            public string Title
            {
                get => title;
                set => title = value;
            }

            public string Author
            {
                get => author;
                set => author = value;
            }

            public decimal Price
            {
                get => price;
                set
                {
                    if (value >= 0)
                    {
                        price = value;
                    }
                }
            }

            public Book(string title, string author, decimal price)
            {
                this.title = title;
                this.author = author;
                Price = price;
            }

            public void DisplayDetails()
            {
                Console.WriteLine($"Title: {Title}");
                Console.WriteLine($"Author: {Author}");
                Console.WriteLine($"Price: {Price:F2}");
            }
        }

        public class Library
        {
            private readonly List<Book> books = new();

            public void AddBook(Book book)
            {
                books.Add(book);
            }

            public void DisplayBooks()
            {
                foreach (Book book in books)
                {
                    Console.WriteLine("--------------------");
                    book.DisplayDetails();
                }
            }
        }

        public static void Run()
        {
            Library library = new();

            library.AddBook(new Book("Clean Code", "Robert C. Martin", 900));
            library.AddBook(new Book("C# in Depth", "Jon Skeet", 1200));

            library.DisplayBooks();
        }
    }

    // ============================================================
    // 29 - School Management System
    // ============================================================
    static class Drill29
    {
        public class Person
        {
            public string Name { get; private set; }
            public int Age { get; private set; }

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public virtual void DisplayInfo()
            {
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Age: {Age}");
            }
        }

        public class Student : Person
        {
            public double GPA { get; private set; }

            public Student(string name, int age, double gpa)
                : base(name, age)
            {
                GPA = gpa;
            }

            public override void DisplayInfo()
            {
                Console.WriteLine("Student");
                base.DisplayInfo();
                Console.WriteLine($"GPA: {GPA}");
            }
        }

        public class Teacher : Person
        {
            public string Subject { get; private set; }

            public Teacher(string name, int age, string subject)
                : base(name, age)
            {
                Subject = subject;
            }

            public override void DisplayInfo()
            {
                Console.WriteLine("Teacher");
                base.DisplayInfo();
                Console.WriteLine($"Subject: {Subject}");
            }
        }

        public static void Run()
        {
            Person[] people =
            {
                new Student("Ahmed", 20, 3.7),
                new Teacher("Mona", 35, "Programming")
            };

            foreach (Person person in people)
            {
                Console.WriteLine("====================");
                person.DisplayInfo();
            }
        }
    }

    // ============================================================
    // 30 - Bank System
    // ============================================================
    static class Drill30
    {
        public class Account
        {
            public string AccountNumber { get; private set; }
            public string OwnerName { get; private set; }
            public decimal Balance { get; protected set; }

            public Account()
            {
                AccountNumber = "N/A";
                OwnerName = "Unknown";
                Balance = 0;
            }

            public Account(string accountNumber, string ownerName)
                : this(accountNumber, ownerName, 0)
            {
            }

            public Account(string accountNumber, string ownerName, decimal balance)
            {
                AccountNumber = accountNumber;
                OwnerName = ownerName;
                Balance = balance >= 0 ? balance : 0;
            }

            public void Deposit(decimal amount)
            {
                if (amount > 0)
                {
                    Balance += amount;
                }
            }

            public virtual void Withdraw(decimal amount)
            {
                if (amount > 0 && amount <= Balance)
                {
                    Balance -= amount;
                }
                else
                {
                    Console.WriteLine("Withdrawal failed.");
                }
            }

            public virtual void DisplayInfo()
            {
                Console.WriteLine($"Account: {AccountNumber}");
                Console.WriteLine($"Owner: {OwnerName}");
                Console.WriteLine($"Balance: {Balance:F2}");
            }
        }

        public class SavingAccount : Account
        {
            public decimal MinimumBalance { get; }

            public SavingAccount(
                string accountNumber,
                string ownerName,
                decimal balance,
                decimal minimumBalance)
                : base(accountNumber, ownerName, balance)
            {
                MinimumBalance = minimumBalance;
            }

            public override void Withdraw(decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Invalid amount.");
                    return;
                }

                if (Balance - amount < MinimumBalance)
                {
                    Console.WriteLine("Cannot withdraw below minimum balance.");
                    return;
                }

                Balance -= amount;
            }

            public override void DisplayInfo()
            {
                Console.WriteLine("Saving Account");
                base.DisplayInfo();
                Console.WriteLine($"Minimum Balance: {MinimumBalance:F2}");
            }
        }

        public class CurrentAccount : Account
        {
            public decimal OverdraftLimit { get; }

            public CurrentAccount(
                string accountNumber,
                string ownerName,
                decimal balance,
                decimal overdraftLimit)
                : base(accountNumber, ownerName, balance)
            {
                OverdraftLimit = overdraftLimit;
            }

            public override void Withdraw(decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Invalid amount.");
                    return;
                }

                if (Balance - amount < -OverdraftLimit)
                {
                    Console.WriteLine("Overdraft limit exceeded.");
                    return;
                }

                Balance -= amount;
            }

            public override void DisplayInfo()
            {
                Console.WriteLine("Current Account");
                base.DisplayInfo();
                Console.WriteLine($"Overdraft Limit: {OverdraftLimit:F2}");
            }
        }

        public static void Run()
        {
            SavingAccount saving = new(
                "S-1001",
                "Ahmed",
                10000,
                2000);

            CurrentAccount current = new(
                "C-2001",
                "Sara",
                5000,
                3000);

            saving.Deposit(1000);
            saving.Withdraw(3000);

            current.Withdraw(7000);

            Console.WriteLine("====================");
            saving.DisplayInfo();

            Console.WriteLine("====================");
            current.DisplayInfo();
        }
    }
}
