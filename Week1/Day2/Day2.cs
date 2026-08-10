using System;

namespace IDSCTraining.Day02;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("============================");
        Console.WriteLine("Day 2 - C# Level 1 (30 Drills)");
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
    // 01 - Right Triangle Pattern
    // ============================================================
    static void Drill01()
    {
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine()!);

        for (int i = 1; i <= rows; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }
    }

    // ============================================================
    // 02 - Inverted Triangle Pattern
    // ============================================================
    static void Drill02()
    {
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine()!);

        for (int i = rows; i >= 1; i--)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }
    }

    // ============================================================
    // 03 - Number Pyramid
    // Example:
    //    1
    //   222
    //  33333
    // 4444444
    // ============================================================
    static void Drill03()
    {
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine()!);

        for (int i = 1; i <= rows; i++)
        {
            for (int space = 1; space <= rows - i; space++)
            {
                Console.Write(" ");
            }

            int numberCount = 2 * i - 1;

            for (int j = 1; j <= numberCount; j++)
            {
                Console.Write(i);
            }

            Console.WriteLine();
        }
    }

    // ============================================================
    // 04 - Multiplication Tables from 1 to 10
    // ============================================================
    static void Drill04()
    {
        for (int number = 1; number <= 10; number++)
        {
            Console.WriteLine($"\n--- Table of {number} ---");

            for (int multiplier = 1; multiplier <= 10; multiplier++)
            {
                Console.WriteLine($"{number} x {multiplier} = {number * multiplier}");
            }
        }
    }

    // ============================================================
    // 05 - Skip Numbers Divisible by 5
    // ============================================================
    static void Drill05()
    {
        for (int i = 1; i <= 100; i++)
        {
            if (i % 5 == 0)
            {
                continue;
            }

            Console.WriteLine(i);
        }
    }

    // ============================================================
    // 06 - First Number Divisible by 7 and 11
    // ============================================================
    static void Drill06()
    {
        int number = 1;

        while (true)
        {
            if (number % 7 == 0 && number % 11 == 0)
            {
                Console.WriteLine($"First number divisible by both 7 and 11: {number}");
                break;
            }

            number++;
        }
    }

    // ============================================================
    // 07 - Generate Random Password
    // ============================================================
    static void Drill07()
    {
        const string characters =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        Console.Write("Enter password length: ");
        int length = int.Parse(Console.ReadLine()!);

        if (length <= 0)
        {
            Console.WriteLine("Password length must be greater than zero.");
            return;
        }

        Random random = new();
        char[] password = new char[length];

        for (int i = 0; i < length; i++)
        {
            int index = random.Next(characters.Length);
            password[i] = characters[index];
        }

        Console.WriteLine($"Generated Password: {new string(password)}");
    }

    // ============================================================
    // 08 - Generate 10 Random Numbers + Find Largest
    // ============================================================
    static void Drill08()
    {
        Random random = new();
        int largest = int.MinValue;

        Console.WriteLine("Generated Numbers:");

        for (int i = 1; i <= 10; i++)
        {
            int number = random.Next(1, 101);
            Console.Write(number + " ");

            if (number > largest)
            {
                largest = number;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"Largest Number: {largest}");
    }

    // ============================================================
    // 09 - Current Date and Time
    // ============================================================
    static void Drill09()
    {
        DateTime now = DateTime.Now;

        Console.WriteLine($"Current Date and Time: {now}");
    }

    // ============================================================
    // 10 - Calculate Age From Birth Date
    // ============================================================
    static void Drill10()
    {
        Console.Write("Enter birth date (yyyy-MM-dd): ");

        if (!DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
        {
            Console.WriteLine("Invalid date.");
            return;
        }

        DateTime today = DateTime.Today;

        if (birthDate.Date > today)
        {
            Console.WriteLine("Birth date cannot be in the future.");
            return;
        }

        int age = today.Year - birthDate.Year;

        if (birthDate.Date > today.AddYears(-age))
        {
            age--;
        }

        Console.WriteLine($"Age: {age}");
    }

    // ============================================================
    // 11 - Number of Days Between Two Dates
    // ============================================================
    static void Drill11()
    {
        Console.Write("Enter first date (yyyy-MM-dd): ");

        if (!DateTime.TryParse(Console.ReadLine(), out DateTime firstDate))
        {
            Console.WriteLine("Invalid first date.");
            return;
        }

        Console.Write("Enter second date (yyyy-MM-dd): ");

        if (!DateTime.TryParse(Console.ReadLine(), out DateTime secondDate))
        {
            Console.WriteLine("Invalid second date.");
            return;
        }

        TimeSpan difference = secondDate.Date - firstDate.Date;

        Console.WriteLine($"Difference: {Math.Abs(difference.Days)} days");
    }

    // ============================================================
    // 12 - Display Date in Different Formats
    // ============================================================
    static void Drill12()
    {
        Console.Write("Enter date (yyyy-MM-dd): ");

        if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            Console.WriteLine("Invalid date.");
            return;
        }

        Console.WriteLine(date.ToString("dd/MM/yyyy"));
        Console.WriteLine(date.ToString("MMMM dd, yyyy"));
        Console.WriteLine(date.ToString("dddd, MMMM dd"));
    }

    // ============================================================
    // 13 - Weekend or Working Day
    // ============================================================
    static void Drill13()
    {
        Console.Write("Enter date (yyyy-MM-dd): ");

        if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            Console.WriteLine("Invalid date.");
            return;
        }

        bool isWeekend =
            date.DayOfWeek == DayOfWeek.Friday ||
            date.DayOfWeek == DayOfWeek.Saturday;

        Console.WriteLine(
            isWeekend
                ? "Weekend"
                : "Working Day");
    }

    // ============================================================
    // 14 - Method to Calculate Sum
    // ============================================================
    static void Drill14()
    {
        Console.Write("Enter first number: ");
        double first = double.Parse(Console.ReadLine()!);

        Console.Write("Enter second number: ");
        double second = double.Parse(Console.ReadLine()!);

        Console.WriteLine($"Sum: {Add(first, second)}");
    }

    static double Add(double first, double second)
    {
        return first + second;
    }

    // ============================================================
    // 15 - Methods for Basic Arithmetic Operations
    // ============================================================
    static void Drill15()
    {
        Console.Write("Enter first number: ");
        double first = double.Parse(Console.ReadLine()!);

        Console.Write("Enter second number: ");
        double second = double.Parse(Console.ReadLine()!);

        Console.WriteLine($"Addition: {Add(first, second)}");
        Console.WriteLine($"Subtraction: {Subtract(first, second)}");
        Console.WriteLine($"Multiplication: {Multiply(first, second)}");

        if (second == 0)
        {
            Console.WriteLine("Division: Cannot divide by zero.");
        }
        else
        {
            Console.WriteLine($"Division: {Divide(first, second)}");
        }
    }

    static double Subtract(double first, double second)
    {
        return first - second;
    }

    static double Multiply(double first, double second)
    {
        return first * second;
    }

    static double Divide(double first, double second)
    {
        return first / second;
    }

    // ============================================================
    // 16 - Method to Check Prime Number
    // ============================================================
    static void Drill16()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine()!);

        Console.WriteLine(
            IsPrime(number)
                ? $"{number} is prime."
                : $"{number} is not prime.");
    }

    static bool IsPrime(int number)
    {
        if (number < 2)
        {
            return false;
        }

        for (int divisor = 2; divisor * divisor <= number; divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    // ============================================================
    // 17 - Method to Calculate Factorial
    // ============================================================
    static void Drill17()
    {
        Console.Write("Enter a non-negative integer: ");
        int number = int.Parse(Console.ReadLine()!);

        if (number < 0)
        {
            Console.WriteLine("Factorial is not defined for negative numbers.");
            return;
        }

        Console.WriteLine($"{number}! = {Factorial(number)}");
    }

    static long Factorial(int number)
    {
        long result = 1;

        for (int i = 2; i <= number; i++)
        {
            result *= i;
        }

        return result;
    }

    // ============================================================
    // 18 - Method to Reverse String
    // ============================================================
    static void Drill18()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine() ?? string.Empty;

        Console.WriteLine($"Reversed: {ReverseString(text)}");
    }

    static string ReverseString(string text)
    {
        char[] result = new char[text.Length];

        for (int i = 0; i < text.Length; i++)
        {
            result[i] = text[text.Length - 1 - i];
        }

        return new string(result);
    }

    // ============================================================
    // 19 - Method to Find Maximum in Array
    // ============================================================
    static void Drill19()
    {
        int[] numbers = { 10, 42, 5, 77, 18, 31 };

        Console.WriteLine("Array: " + string.Join(", ", numbers));
        Console.WriteLine($"Maximum: {FindMaximum(numbers)}");
    }

    static int FindMaximum(int[] numbers)
    {
        if (numbers.Length == 0)
        {
            throw new ArgumentException("Array cannot be empty.");
        }

        int max = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }

        return max;
    }

    // ============================================================
    // 20 - Simple Calculator Using Methods
    // ============================================================
    static void Drill20()
    {
        Console.Write("Enter first number: ");
        double first = double.Parse(Console.ReadLine()!);

        Console.Write("Enter second number: ");
        double second = double.Parse(Console.ReadLine()!);

        Console.Write("Choose operation (+, -, *, /): ");
        char operation = char.Parse(Console.ReadLine()!);

        double? result = Calculate(first, second, operation);

        if (result.HasValue)
        {
            Console.WriteLine($"Result: {result.Value}");
        }
    }

    static double? Calculate(double first, double second, char operation)
    {
        switch (operation)
        {
            case '+':
                return Add(first, second);

            case '-':
                return Subtract(first, second);

            case '*':
                return Multiply(first, second);

            case '/':
                if (second == 0)
                {
                    Console.WriteLine("Cannot divide by zero.");
                    return null;
                }

                return Divide(first, second);

            default:
                Console.WriteLine("Invalid operation.");
                return null;
        }
    }

    // ============================================================
    // 21 - Store 10 Numbers in Array + Display
    // ============================================================
    static void Drill21()
    {
        int[] numbers = new int[10];

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write($"Enter number #{i + 1}: ");
            numbers[i] = int.Parse(Console.ReadLine()!);
        }

        Console.WriteLine("Numbers:");

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }

    // ============================================================
    // 22 - Find Maximum and Minimum in Array
    // ============================================================
    static void Drill22()
    {
        int[] numbers = ReadIntegerArray();

        if (numbers.Length == 0)
        {
            Console.WriteLine("Array cannot be empty.");
            return;
        }

        int min = numbers[0];
        int max = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }

            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }

        Console.WriteLine($"Minimum: {min}");
        Console.WriteLine($"Maximum: {max}");
    }

    // ============================================================
    // 23 - Sum and Average of Array Elements
    // ============================================================
    static void Drill23()
    {
        int[] numbers = ReadIntegerArray();

        if (numbers.Length == 0)
        {
            Console.WriteLine("Array cannot be empty.");
            return;
        }

        long sum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        double average = (double)sum / numbers.Length;

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {average:F2}");
    }

    // ============================================================
    // 24 - Search for Number in Array
    // ============================================================
    static void Drill24()
    {
        int[] numbers = ReadIntegerArray();

        Console.Write("Enter number to search for: ");
        int target = int.Parse(Console.ReadLine()!);

        int foundIndex = -1;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == target)
            {
                foundIndex = i;
                break;
            }
        }

        if (foundIndex == -1)
        {
            Console.WriteLine("Number not found.");
        }
        else
        {
            Console.WriteLine($"Number found at index {foundIndex}.");
        }
    }

    // ============================================================
    // 25 - Count Even and Odd Numbers in Array
    // ============================================================
    static void Drill25()
    {
        int[] numbers = ReadIntegerArray();

        int evenCount = 0;
        int oddCount = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] % 2 == 0)
            {
                evenCount++;
            }
            else
            {
                oddCount++;
            }
        }

        Console.WriteLine($"Even Count: {evenCount}");
        Console.WriteLine($"Odd Count: {oddCount}");
    }

    // ============================================================
    // 26 - Reverse Array Without Built-in Reverse
    // ============================================================
    static void Drill26()
    {
        int[] numbers = ReadIntegerArray();

        int left = 0;
        int right = numbers.Length - 1;

        while (left < right)
        {
            int temp = numbers[left];
            numbers[left] = numbers[right];
            numbers[right] = temp;

            left++;
            right--;
        }

        Console.WriteLine("Reversed Array: " + string.Join(", ", numbers));
    }

    // ============================================================
    // 27 - Sort Array Ascending Without Built-in Sort
    // Bubble Sort for training purposes
    // ============================================================
    static void Drill27()
    {
        int[] numbers = ReadIntegerArray();

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            bool swapped = false;

            for (int j = 0; j < numbers.Length - 1 - i; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    int temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;

                    swapped = true;
                }
            }

            if (!swapped)
            {
                break;
            }
        }

        Console.WriteLine("Sorted Array: " + string.Join(", ", numbers));
    }

    // ============================================================
    // 28 - Remove Duplicates From Integer Array
    // Without LINQ / HashSet because this is an Arrays drill
    // ============================================================
    static void Drill28()
    {
        int[] numbers = ReadIntegerArray();

        int[] unique = new int[numbers.Length];
        int uniqueCount = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            bool alreadyExists = false;

            for (int j = 0; j < uniqueCount; j++)
            {
                if (unique[j] == numbers[i])
                {
                    alreadyExists = true;
                    break;
                }
            }

            if (!alreadyExists)
            {
                unique[uniqueCount] = numbers[i];
                uniqueCount++;
            }
        }

        Console.Write("Unique Values: ");

        for (int i = 0; i < uniqueCount; i++)
        {
            Console.Write(unique[i]);

            if (i < uniqueCount - 1)
            {
                Console.Write(", ");
            }
        }

        Console.WriteLine();
    }

    // ============================================================
    // 29 - Student Struct
    // ============================================================
    static void Drill29()
    {
        Student[] students =
        {
            new Student
            {
                Id = 1,
                Name = "Ahmed",
                Age = 21,
                Grade = 88.5
            },
            new Student
            {
                Id = 2,
                Name = "Sara",
                Age = 20,
                Grade = 93.2
            },
            new Student
            {
                Id = 3,
                Name = "Omar",
                Age = 22,
                Grade = 79.8
            }
        };

        foreach (Student student in students)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine($"Id: {student.Id}");
            Console.WriteLine($"Name: {student.Name}");
            Console.WriteLine($"Age: {student.Age}");
            Console.WriteLine($"Grade: {student.Grade}");
        }
    }

    // ============================================================
    // 30 - Simple Text Analyzer
    // ============================================================
    static void Drill30()
    {
        Console.Write("Enter a sentence: ");
        string sentence = Console.ReadLine() ?? string.Empty;

        int characterCount = sentence.Length;
        int vowelCount = CountVowels(sentence);
        int wordCount = CountWords(sentence);
        string reversed = ReverseString(sentence);

        Console.WriteLine($"Word Count: {wordCount}");
        Console.WriteLine($"Vowel Count: {vowelCount}");
        Console.WriteLine($"Character Count: {characterCount}");
        Console.WriteLine($"Reversed Sentence: {reversed}");
    }

    static int CountWords(string sentence)
    {
        string[] words = sentence.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries);

        return words.Length;
    }

    static int CountVowels(string text)
    {
        int count = 0;

        foreach (char character in text)
        {
            char lower = char.ToLower(character);

            if (lower == 'a' ||
                lower == 'e' ||
                lower == 'i' ||
                lower == 'o' ||
                lower == 'u')
            {
                count++;
            }
        }

        return count;
    }

    // ============================================================
    // Shared Helper - Read Integer Array
    // ============================================================
    static int[] ReadIntegerArray()
    {
        Console.Write("Enter array size: ");
        int size = int.Parse(Console.ReadLine()!);

        if (size <= 0)
        {
            return Array.Empty<int>();
        }

        int[] numbers = new int[size];

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write($"Enter element #{i + 1}: ");
            numbers[i] = int.Parse(Console.ReadLine()!);
        }

        return numbers;
    }

    // ============================================================
    // Student Struct - Drill 29
    // ============================================================
    struct Student
    {
        public int Id;
        public string Name;
        public int Age;
        public double Grade;
    }
}