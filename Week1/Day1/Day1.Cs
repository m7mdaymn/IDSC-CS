//The first 30 drills

using System;

namespace IDSCTraining.Day01;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("============================");
        Console.WriteLine("Day 1 - C# Basics (30 Drills)");
        Console.WriteLine("============================");
        Console.Write("Choose a drill number (1-30): ");

        if (!int.TryParse(Console.ReadLine(), out int choice) ||
            choice < 1 || choice > 30)
        {
            Console.WriteLine("Invalid drill number.");
            return;
        }

        Console.WriteLine();

        switch (choice)
        {
            case 1: Drill01(); break;
            case 2: Drill02(); break;
            case 3: Drill03(); break;
            case 4: Drill04(); break;
            case 5: Drill05(); break;
            case 6: Drill06(); break;
            case 7: Drill07(); break;
            case 8: Drill08(); break;
            case 9: Drill09(); break;
            case 10: Drill10(); break;
            case 11: Drill11(); break;
            case 12: Drill12(); break;
            case 13: Drill13(); break;
            case 14: Drill14(); break;
            case 15: Drill15(); break;
            case 16: Drill16(); break;
            case 17: Drill17(); break;
            case 18: Drill18(); break;
            case 19: Drill19(); break;
            case 20: Drill20(); break;
            case 21: Drill21(); break;
            case 22: Drill22(); break;
            case 23: Drill23(); break;
            case 24: Drill24(); break;
            case 25: Drill25(); break;
            case 26: Drill26(); break;
            case 27: Drill27(); break;
            case 28: Drill28(); break;
            case 29: Drill29(); break;
            case 30: Drill30(); break;
        }
    }

    // ============================================================
    // 01 - Hello World + Full Name
    // ============================================================
    static void Drill01()
    {
        const string fullName = "Your Full Name";

        Console.WriteLine("Hello World");
        Console.WriteLine(fullName);
    }

    // ============================================================
    // 02 - Different Data Types
    // ============================================================
    static void Drill02()
    {
        int age = 22;
        double height = 178.5;
        decimal salary = 15000.75m;
        bool isStudent = true;
        char grade = 'A';
        string name = "Mohamed";

        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Height: {height}");
        Console.WriteLine($"Salary: {salary}");
        Console.WriteLine($"Is Student: {isStudent}");
        Console.WriteLine($"Grade: {grade}");
    }

    // ============================================================
    // 03 - Constants
    // ============================================================
    static void Drill03()
    {
        const double Pi = Math.PI;
        const int DaysInWeek = 7;

        Console.WriteLine($"Pi: {Pi}");
        Console.WriteLine($"Days in a week: {DaysInWeek}");
    }

    // ============================================================
    // 04 - Read Student Data
    // ============================================================
    static void Drill04()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter age: ");
        int age = int.Parse(Console.ReadLine()!);

        Console.Write("Enter GPA: ");
        double gpa = double.Parse(Console.ReadLine()!);

        Console.WriteLine(
            $"Student: {name}, Age: {age}, GPA: {gpa}");
    }

    // ============================================================
    // 05 - Arithmetic Operations
    // ============================================================
    static void Drill05()
    {
        Console.Write("Enter first number: ");
        double first = double.Parse(Console.ReadLine()!);

        Console.Write("Enter second number: ");
        double second = double.Parse(Console.ReadLine()!);

        Console.WriteLine($"Sum: {first + second}");
        Console.WriteLine($"Subtraction: {first - second}");
        Console.WriteLine($"Multiplication: {first * second}");

        if (second != 0)
        {
            Console.WriteLine($"Division: {first / second}");
        }
        else
        {
            Console.WriteLine("Division: Cannot divide by zero.");
        }
    }

    // ============================================================
    // 06 - Circle Area + Circumference
    // ============================================================
    static void Drill06()
    {
        Console.Write("Enter radius: ");
        double radius = double.Parse(Console.ReadLine()!);

        double area = Math.PI * radius * radius;
        double circumference = 2 * Math.PI * radius;

        Console.WriteLine($"Area: {area:F2}");
        Console.WriteLine(
            $"Circumference: {circumference:F2}");
    }

    // ============================================================
    // 07 - Celsius <-> Fahrenheit
    // ============================================================
    static void Drill07()
    {
        Console.WriteLine("1. Celsius to Fahrenheit");
        Console.WriteLine("2. Fahrenheit to Celsius");

        Console.Write("Choose: ");
        int choice = int.Parse(Console.ReadLine()!);

        Console.Write("Enter temperature: ");
        double temperature =
            double.Parse(Console.ReadLine()!);

        if (choice == 1)
        {
            double fahrenheit =
                (temperature * 9 / 5) + 32;

            Console.WriteLine(
                $"{temperature} C = {fahrenheit:F2} F");
        }
        else if (choice == 2)
        {
            double celsius =
                (temperature - 32) * 5 / 9;

            Console.WriteLine(
                $"{temperature} F = {celsius:F2} C");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    // ============================================================
    // 08 - Implicit + Explicit Casting
    // ============================================================
    static void Drill08()
    {
        int integerNumber = 100;

        // Implicit Casting
        double implicitCast = integerNumber;

        double decimalNumber = 99.75;

        // Explicit Casting
        int explicitCast = (int)decimalNumber;

        Console.WriteLine(
            $"Original int: {integerNumber}");

        Console.WriteLine(
            $"Implicit int -> double: {implicitCast}");

        Console.WriteLine(
            $"Original double: {decimalNumber}");

        Console.WriteLine(
            $"Explicit double -> int: {explicitCast}");
    }

    // ============================================================
    // 09 - Unicode Value
    // ============================================================
    static void Drill09()
    {
        Console.Write("Enter a character: ");
        string? input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine(
                "No character entered.");

            return;
        }

        char character = input[0];

        int unicodeValue = character;

        Console.WriteLine(
            $"Character: {character}");

        Console.WriteLine(
            $"Unicode value: {unicodeValue}");
    }

    // ============================================================
    // 10 - Assignment Operators
    // ============================================================
    static void Drill10()
    {
        int number = 20;

        Console.WriteLine(
            $"Initial value: {number}");

        number = 10;

        Console.WriteLine(
            $"After = 10: {number}");

        number += 5;

        Console.WriteLine(
            $"After += 5: {number}");

        number -= 3;

        Console.WriteLine(
            $"After -= 3: {number}");

        number *= 2;

        Console.WriteLine(
            $"After *= 2: {number}");

        number /= 4;

        Console.WriteLine(
            $"After /= 4: {number}");

        number %= 3;

        Console.WriteLine(
            $"After %= 3: {number}");
    }

    // ============================================================
    // 11 - Prefix vs Postfix Increment
    // ============================================================
    static void Drill11()
    {
        int x = 5;

        int prefixResult = ++x;

        Console.WriteLine(
            $"After prefix ++x: x = {x}, result = {prefixResult}");

        x = 5;

        int postfixResult = x++;

        Console.WriteLine(
            $"After postfix x++: x = {x}, result = {postfixResult}");
    }

    // ============================================================
    // 12 - Concatenate First + Last Name
    // ============================================================
    static void Drill12()
    {
        Console.Write("Enter first name: ");

        string firstName =
            Console.ReadLine() ?? string.Empty;

        Console.Write("Enter last name: ");

        string lastName =
            Console.ReadLine() ?? string.Empty;

        string fullName =
            firstName + " " + lastName;

        Console.WriteLine(
            $"Full Name: {fullName}");
    }

    // ============================================================
    // 13 - Relational Operators
    // ============================================================
    static void Drill13()
    {
        Console.Write("Enter first integer: ");
        int first = int.Parse(Console.ReadLine()!);

        Console.Write("Enter second integer: ");
        int second = int.Parse(Console.ReadLine()!);

        Console.WriteLine(
            $"{first} == {second}: {first == second}");

        Console.WriteLine(
            $"{first} != {second}: {first != second}");

        Console.WriteLine(
            $"{first} > {second}: {first > second}");

        Console.WriteLine(
            $"{first} < {second}: {first < second}");

        Console.WriteLine(
            $"{first} >= {second}: {first >= second}");

        Console.WriteLine(
            $"{first} <= {second}: {first <= second}");
    }

    // ============================================================
    // 14 - Voting Eligibility
    // ============================================================
    static void Drill14()
    {
        Console.Write("Enter age: ");

        int age =
            int.Parse(Console.ReadLine()!);

        if (age >= 18)
        {
            Console.WriteLine(
                "Eligible to vote.");
        }
        else
        {
            Console.WriteLine(
                "Not eligible to vote.");
        }
    }

    // ============================================================
    // 15 - Positive / Negative / Zero
    // ============================================================
    static void Drill15()
    {
        Console.Write("Enter a number: ");

        double number =
            double.Parse(Console.ReadLine()!);

        if (number > 0)
        {
            Console.WriteLine("Positive");
        }
        else if (number < 0)
        {
            Console.WriteLine("Negative");
        }
        else
        {
            Console.WriteLine("Zero");
        }
    }

    // ============================================================
    // 16 - Maximum of Three Numbers Using Nested If
    // ============================================================
    static void Drill16()
    {
        Console.Write("Enter first number: ");
        int a = int.Parse(Console.ReadLine()!);

        Console.Write("Enter second number: ");
        int b = int.Parse(Console.ReadLine()!);

        Console.Write("Enter third number: ");
        int c = int.Parse(Console.ReadLine()!);

        int max;

        if (a >= b)
        {
            if (a >= c)
            {
                max = a;
            }
            else
            {
                max = c;
            }
        }
        else
        {
            if (b >= c)
            {
                max = b;
            }
            else
            {
                max = c;
            }
        }

        Console.WriteLine(
            $"Maximum: {max}");
    }

    // ============================================================
    // 17 - Student Grade
    // ============================================================
    static void Drill17()
    {
        Console.Write(
            "Enter score (0-100): ");

        double score =
            double.Parse(Console.ReadLine()!);

        if (score < 0 || score > 100)
        {
            Console.WriteLine(
                "Invalid score.");
        }
        else if (score >= 90)
        {
            Console.WriteLine("Grade: A");
        }
        else if (score >= 80)
        {
            Console.WriteLine("Grade: B");
        }
        else if (score >= 70)
        {
            Console.WriteLine("Grade: C");
        }
        else if (score >= 60)
        {
            Console.WriteLine("Grade: D");
        }
        else
        {
            Console.WriteLine("Grade: F");
        }
    }

    // ============================================================
    // 18 - Vowel or Consonant
    // ============================================================
    static void Drill18()
    {
        Console.Write(
            "Enter a character: ");

        string? input =
            Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine(
                "Invalid input.");

            return;
        }

        char character =
            char.ToLower(input[0]);

        if (!char.IsLetter(character))
        {
            Console.WriteLine(
                "The entered character is not a letter.");
        }
        else if (
            character == 'a' ||
            character == 'e' ||
            character == 'i' ||
            character == 'o' ||
            character == 'u')
        {
            Console.WriteLine("Vowel");
        }
        else
        {
            Console.WriteLine("Consonant");
        }
    }

    // ============================================================
    // 19 - Arithmetic Menu Using Switch
    // ============================================================
    static void Drill19()
    {
        Console.Write(
            "Enter first number: ");

        double first =
            double.Parse(Console.ReadLine()!);

        Console.Write(
            "Enter second number: ");

        double second =
            double.Parse(Console.ReadLine()!);

        Console.Write(
            "Enter operation (+, -, *, /): ");

        char operation =
            char.Parse(Console.ReadLine()!);

        switch (operation)
        {
            case '+':
                Console.WriteLine(
                    $"Result: {first + second}");
                break;

            case '-':
                Console.WriteLine(
                    $"Result: {first - second}");
                break;

            case '*':
                Console.WriteLine(
                    $"Result: {first * second}");
                break;

            case '/':
                if (second == 0)
                {
                    Console.WriteLine(
                        "Cannot divide by zero.");
                }
                else
                {
                    Console.WriteLine(
                        $"Result: {first / second}");
                }

                break;

            default:
                Console.WriteLine(
                    "Invalid operation.");
                break;
        }
    }

    // ============================================================
    // 20 - Number of Days in Month Using Switch
    // ============================================================
    static void Drill20()
    {
        Console.Write(
            "Enter month number (1-12): ");

        int month =
            int.Parse(Console.ReadLine()!);

        Console.Write(
            "Enter year: ");

        int year =
            int.Parse(Console.ReadLine()!);

        int days;

        switch (month)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                days = 31;
                break;

            case 4:
            case 6:
            case 9:
            case 11:
                days = 30;
                break;

            case 2:
                days =
                    DateTime.IsLeapYear(year)
                        ? 29
                        : 28;

                break;

            default:
                Console.WriteLine(
                    "Invalid month.");

                return;
        }

        Console.WriteLine(
            $"Number of days: {days}");
    }

    // ============================================================
    // 21 - Print 1 to 100 Using While
    // ============================================================
    static void Drill21()
    {
        int number = 1;

        while (number <= 100)
        {
            Console.WriteLine(number);

            number++;
        }
    }

    // ============================================================
    // 22 - Factorial Using While
    // ============================================================
    static void Drill22()
    {
        Console.Write(
            "Enter a non-negative integer: ");

        int number =
            int.Parse(Console.ReadLine()!);

        if (number < 0)
        {
            Console.WriteLine(
                "Factorial is not defined for negative numbers.");

            return;
        }

        long factorial = 1;

        int current = number;

        while (current > 1)
        {
            factorial *= current;

            current--;
        }

        Console.WriteLine(
            $"{number}! = {factorial}");
    }

    // ============================================================
    // 23 - Password Using Do-While
    // ============================================================
    static void Drill23()
    {
        const string CorrectPassword =
            "1234";

        string password;

        do
        {
            Console.Write(
                "Enter password: ");

            password =
                Console.ReadLine()
                ?? string.Empty;

            if (password != CorrectPassword)
            {
                Console.WriteLine(
                    "Wrong password. Try again.");
            }

        } while (password != CorrectPassword);

        Console.WriteLine(
            "Correct password.");
    }

    // ============================================================
    // 24 - Simple Login System
    // ============================================================
    static void Drill24()
    {
        const string CorrectUsername =
            "admin";

        const string CorrectPassword =
            "1234";

        string username;
        string password;

        do
        {
            Console.Write(
                "Username: ");

            username =
                Console.ReadLine()
                ?? string.Empty;

            Console.Write(
                "Password: ");

            password =
                Console.ReadLine()
                ?? string.Empty;

            if (
                username != CorrectUsername ||
                password != CorrectPassword)
            {
                Console.WriteLine(
                    "Invalid username or password.\n");
            }

        } while (
            username != CorrectUsername ||
            password != CorrectPassword);

        Console.WriteLine(
            "Login successful.");
    }

    // ============================================================
    // 25 - Simple Sales System
    // ============================================================
    static void Drill25()
    {
        decimal totalBill = 0;

        char addAnother;

        int productNumber = 1;

        do
        {
            Console.WriteLine(
                $"\nProduct #{productNumber}");

            Console.Write(
                "Product name: ");

            string productName =
                Console.ReadLine()
                ?? string.Empty;

            Console.Write(
                "Price: ");

            decimal price =
                decimal.Parse(
                    Console.ReadLine()!);

            Console.Write(
                "Quantity: ");

            int quantity =
                int.Parse(
                    Console.ReadLine()!);

            if (price < 0 || quantity < 0)
            {
                Console.WriteLine(
                    "Price and quantity cannot be negative.");
            }
            else
            {
                decimal productTotal =
                    price * quantity;

                totalBill += productTotal;

                Console.WriteLine(
                    $"{productName} Total: {productTotal:F2}");

                productNumber++;
            }

            Console.Write(
                "Add another product? (Y/N): ");

            string? input =
                Console.ReadLine();

            addAnother =
                string.IsNullOrEmpty(input)
                    ? 'N'
                    : char.ToUpper(input[0]);

        } while (addAnother == 'Y');

        Console.WriteLine(
            $"\nFinal Bill: {totalBill:F2}");
    }

    // ============================================================
    // 26 - Multiplication Table
    // ============================================================
    static void Drill26()
    {
        Console.Write(
            "Enter a number: ");

        int number =
            int.Parse(Console.ReadLine()!);

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(
                $"{number} x {i} = {number * i}");
        }
    }

    // ============================================================
    // 27 - Even Numbers 1 to 100
    // ============================================================
    static void Drill27()
    {
        for (int i = 1; i <= 100; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
            }
        }
    }

    // ============================================================
    // 28 - Prime Numbers 1 to 100
    // ============================================================
    static void Drill28()
    {
        for (
            int number = 2;
            number <= 100;
            number++)
        {
            bool isPrime = true;

            for (
                int divisor = 2;
                divisor * divisor <= number;
                divisor++)
            {
                if (number % divisor == 0)
                {
                    isPrime = false;

                    break;
                }
            }

            if (isPrime)
            {
                Console.WriteLine(number);
            }
        }
    }

    // ============================================================
    // 29 - Break + Continue
    // ============================================================
    static void Drill29()
    {
        for (int i = 1; i <= 20; i++)
        {
            // Skip multiples of 3
            if (i % 3 == 0)
            {
                continue;
            }

            // Stop the loop completely
            if (i == 17)
            {
                break;
            }

            Console.WriteLine(i);
        }
    }

    // ============================================================
    // 30 - Repeating Menu: Switch + Do-While
    // ============================================================
    static void Drill30()
    {
        int choice;

        do
        {
            Console.WriteLine(
                "\n====================");

            Console.WriteLine(
                "Simple Calculator");

            Console.WriteLine(
                "====================");

            Console.WriteLine(
                "1. Add");

            Console.WriteLine(
                "2. Subtract");

            Console.WriteLine(
                "3. Multiply");

            Console.WriteLine(
                "4. Divide");

            Console.WriteLine(
                "5. Exit");

            Console.Write(
                "Choose: ");

            choice =
                int.Parse(Console.ReadLine()!);

            if (choice == 5)
            {
                Console.WriteLine(
                    "Goodbye.");

                break;
            }

            if (choice < 1 || choice > 4)
            {
                Console.WriteLine(
                    "Invalid choice.");

                continue;
            }

            Console.Write(
                "Enter first number: ");

            double first =
                double.Parse(
                    Console.ReadLine()!);

            Console.Write(
                "Enter second number: ");

            double second =
                double.Parse(
                    Console.ReadLine()!);

            switch (choice)
            {
                case 1:
                    Console.WriteLine(
                        $"Result: {first + second}");
                    break;  

                case 2:
                    Console.WriteLine(
                        $"Result: {first - second}");
                    break;

                case 3:
                    Console.WriteLine(
                        $"Result: {first * second}");
                    break;

                case 4:
                    if (second == 0)
                    {
                        Console.WriteLine(
                            "Cannot divide by zero.");
                    }
                    else
                    {
                        Console.WriteLine(
                            $"Result: {first / second}");
                    }

                    break;
            }

        } while (choice != 5);
    }
}