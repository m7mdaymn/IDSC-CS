using System;

namespace ShopSystem;

internal class Program
{
    private const int MaxProductsPerInvoice = 20;

    static void Main()
    {
        bool programRunning = true;

        do
        {
            Console.Clear();
            Console.WriteLine("========================");
            Console.WriteLine("Simple Shop System");
            Console.WriteLine("========================");
            Console.WriteLine("1. Create New Invoice");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateInvoice();

                    Console.Write("\nDo you want to create another invoice? (Y/N): ");
                    string answer = (Console.ReadLine() ?? string.Empty).Trim().ToUpper();

                    if (answer == "N")
                    {
                        programRunning = false;
                        break;
                    }

                    break;

                case 2:
                    programRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }

        } while (programRunning);

        Console.WriteLine("\nApplication Closed.");
    }

    static void CreateInvoice()
    {
        Console.Clear();
        Console.WriteLine("========================");
        Console.WriteLine("Create New Invoice");
        Console.WriteLine("========================");

        Console.Write("Enter customer name: ");
        string customerName = Console.ReadLine() ?? string.Empty;

        int numberOfProducts;

        do
        {
            Console.Write($"Enter number of products (1-{MaxProductsPerInvoice}): ");
            numberOfProducts = Convert.ToInt32(Console.ReadLine());

            if (numberOfProducts <= 0 || numberOfProducts > MaxProductsPerInvoice)
            {
                Console.WriteLine($"Number of products must be between 1 and {MaxProductsPerInvoice}.");
            }

        } while (numberOfProducts <= 0 || numberOfProducts > MaxProductsPerInvoice);

        string[] productNames = new string[numberOfProducts];
        decimal[] productPrices = new decimal[numberOfProducts];
        int[] productQuantities = new int[numberOfProducts];
        decimal[] productTotals = new decimal[numberOfProducts];

        decimal subTotal = 0;
        decimal totalProductPrices = 0;

        for (int i = 0; i < numberOfProducts; i++)
        {
            Console.WriteLine($"\nProduct #{i + 1}");
            Console.WriteLine("---------------------------");

            Console.Write("Product Name: ");
            productNames[i] = Console.ReadLine() ?? string.Empty;

            decimal price;

            do
            {
                Console.Write("Product Price: ");
                price = Convert.ToDecimal(Console.ReadLine());

                if (price < 0)
                {
                    Console.WriteLine("Product price cannot be negative.");
                }

            } while (price < 0);

            int quantity;

            do
            {
                Console.Write("Product Quantity: ");
                quantity = Convert.ToInt32(Console.ReadLine());

                if (quantity < 0)
                {
                    Console.WriteLine("Product quantity cannot be negative.");
                }

            } while (quantity < 0);

            productPrices[i] = price;
            productQuantities[i] = quantity;
            productTotals[i] = price * quantity;

            subTotal += productTotals[i];
            totalProductPrices += price;
        }

        decimal discountPercentage = 0;

        if (subTotal > 10000)
        {
            discountPercentage = 0.20m;
        }
        else if (subTotal > 5000)
        {
            discountPercentage = 0.10m;
        }

        decimal discountAmount = subTotal * discountPercentage;
        decimal finalTotal = subTotal - discountAmount;
        decimal averageProductPrice = totalProductPrices / numberOfProducts;

        Console.WriteLine("\n========= Invoice =========");
        Console.WriteLine($"Customer Name: {customerName}");
        Console.WriteLine($"Number of Products: {numberOfProducts}");
        Console.WriteLine("---------------------------");

        for (int i = 0; i < numberOfProducts; i++)
        {
            Console.WriteLine($"Product: {productNames[i]}");
            Console.WriteLine($"Price: {productPrices[i]:F2}");
            Console.WriteLine($"Quantity: {productQuantities[i]}");
            Console.WriteLine($"Total: {productTotals[i]:F2}");
            Console.WriteLine("---------------------------");
        }

        Console.WriteLine($"Sub Total: {subTotal:F2}");
        Console.WriteLine($"Discount: {discountAmount:F2}");
        Console.WriteLine($"Final Total: {finalTotal:F2}");
        Console.WriteLine($"Average Product Price: {averageProductPrice:F2}");
        Console.WriteLine("===========================");
    }
}