using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    class Program
    {
        static List<dynamic> books = new List<dynamic>();
        static int bookIdCounter = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== BOOK LIBRARY MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. User");
                Console.WriteLine("3. Exit");
                Console.Write("Select option: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AdminMenu();
                        break;
                    case 2:
                        UserMenu();
                        break;
                    case 3:
                        Console.WriteLine("Exiting application...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\n----- ADMIN MENU -----");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Update Book");
                Console.WriteLine("3. Delete Book");
                Console.WriteLine("4. View All Books");
                Console.WriteLine("5. Back");
                Console.Write("Select option: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        UpdateBook();
                        break;
                    case 3:
                        DeleteBook();
                        break;
                    case 4:
                        ViewBooks();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        static void UserMenu()
        {
            while (true)
            {
                Console.WriteLine("\n----- USER MENU -----");
                Console.WriteLine("1. Browse Books");
                Console.WriteLine("2. Search Book by Name");
                Console.WriteLine("3. Search Book by Publisher");
                Console.WriteLine("4. View Highest Price Book");
                Console.WriteLine("5. View Lowest Price Book");
                Console.WriteLine("6. Back");
                Console.Write("Select option: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ViewBooks();
                        break;
                    case 2:
                        SearchByName();
                        break;
                    case 3:
                        SearchByPublisher();
                        break;
                    case 4:
                        HighestPriceBook();
                        break;
                    case 5:
                        LowestPriceBook();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        static void AddBook()
        {
            dynamic book = new System.Dynamic.ExpandoObject();

            book.Id = bookIdCounter++;
            Console.Write("Enter Book Name: ");
            book.Name = Console.ReadLine();
            Console.Write("Enter Publisher: ");
            book.Publisher = Console.ReadLine();
            Console.Write("Enter Price: ");
            book.Price = Convert.ToDouble(Console.ReadLine());

            books.Add(book);
            Console.WriteLine("Book added successfully!");
        }

        static void UpdateBook()
        {
            Console.Write("Enter Book ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var book = books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                Console.Write("Enter new Book Name: ");
                book.Name = Console.ReadLine();
                Console.Write("Enter new Publisher: ");
                book.Publisher = Console.ReadLine();
                Console.Write("Enter new Price: ");
                book.Price = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Book updated successfully!");
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }

        static void DeleteBook()
        {
            Console.Write("Enter Book ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var book = books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine("Book deleted successfully!");
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }

        static void ViewBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available!");
                return;
            }

            Console.WriteLine("\n--- BOOK LIST ---");
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}, Name: {book.Name}, Publisher: {book.Publisher}, Price: {book.Price}");
            }
        }

        static void SearchByName()
        {
            Console.Write("Enter book name: ");
            string name = Console.ReadLine();

            var result = books.Where(b => b.Name.ToLower().Contains(name.ToLower())).ToList();

            if (result.Count > 0)
                result.ForEach(b => Console.WriteLine($"{b.Name} - {b.Publisher} - {b.Price}"));
            else
                Console.WriteLine("No matching books found!");
        }

        static void SearchByPublisher()
        {
            Console.Write("Enter publisher name: ");
            string publisher = Console.ReadLine();

            var result = books.Where(b => b.Publisher.ToLower().Contains(publisher.ToLower())).ToList();

            if (result.Count > 0)
                result.ForEach(b => Console.WriteLine($"{b.Name} - {b.Publisher} - {b.Price}"));
            else
                Console.WriteLine("No matching books found!");
        }

        static void HighestPriceBook()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available!");
                return;
            }

            var book = books.OrderByDescending(b => b.Price).First();
            Console.WriteLine($"Highest Price Book: {book.Name} - {book.Price}");
        }

        static void LowestPriceBook()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available!");
                return;
            }

            var book = books.OrderBy(b => b.Price).First();
            Console.WriteLine($"Lowest Price Book: {book.Name} - {book.Price}");
        }
    }
}
