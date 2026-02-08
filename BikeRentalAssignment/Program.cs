using System;
using System.Collections.Generic;

namespace BikeRentalApp
{
    class Program
    {
        public static SortedDictionary<int, Bike> bikeDetails = new SortedDictionary<int, Bike>();

        static void Main()
        {
            BikeUtility utility = new BikeUtility();

            while (true)
            {
                Console.WriteLine("1. Add Bike Details");
                Console.WriteLine("2. Group Bikes By Brand");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.Write("Enter your choice ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.Write("Enter the model: ");
                    string model = Console.ReadLine();

                    Console.Write("Enter the brand: ");
                    string brand = Console.ReadLine();

                    Console.Write("Enter the price per day: ");
                    int price = Convert.ToInt32(Console.ReadLine());

                    utility.AddBikeDetails(model, brand, price);

                    Console.WriteLine();
                    Console.WriteLine("Bike details added successfully");
                    Console.WriteLine();
                }
                else if (choice == 2)
                {
                    var grouped = utility.GroupBikesByBrand();
                    Console.WriteLine();

                    foreach (var brand in grouped)
                    {
                        foreach (var bike in brand.Value)
                        {
                            Console.WriteLine(brand.Key + " " + bike.Model);
                        }
                    }

                    Console.WriteLine();
                }
                else if (choice == 3)
                {
                    break;
                }
            }
        }
    }
}
