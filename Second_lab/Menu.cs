using System;
using System.Globalization;

namespace Second_lab
{
    class Menu
    {
        private static bool isWorking = true;
        public static Discount_journal journal;

        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME to the World of Discounts!\n");
            journal = new Discount_journal("My Discount journal to go shopping");

            Console.WriteLine("Enter the number of action and press[Enter].Then follow instructions.");
            while (isWorking)
            {
                Console.WriteLine("Menu:\n\t" +
                    "1. Add new discount\n\t" +
                    "2. Delete a discount\n\t" +
                    "3. View available discounts\n\t" +
                    "4. Save the list of discounts into file\n\t" +
                    "5. Load the list of discounts from file\n\t" +
                    "6. Exit");
                HandleCommand(ReadFromConsole("> "));
            }
        }

        static string ReadFromConsole(string input)
        {
            Console.Write(input);
            return Console.ReadLine();
        }

        static void HandleCommand(string command)
        {
            switch (command)
            {
                case "1":
                    AddDiscount();
                    break;

                case "2":
                    RemoveDiscount();
                    break;

                case "3":
                    ShowAvailableDiscounts();
                    break;

                case "4":
                    SaveInFile();
                    break;

                case "5":
                    journal = LoadFromFile();
                    break;

                case "6":
                    isWorking = false;
                    break;

                default:
                    break;
            }
        }

        private static void AddDiscount()
        {
            Console.WriteLine("Enter information about a discount:");
            string shop1 = ReadFromConsole("\tName of the shop: ");

            int sizeOfDiscount1;
            while (!(int.TryParse(ReadFromConsole("\tSize of the discount (%): "), out sizeOfDiscount1) && sizeOfDiscount1 > 0 && sizeOfDiscount1 < 100))
            {
                Console.WriteLine("\tAn error: you need to input integer number of percentage (from 1 to 100).");
            }

            DateTime expirationDate1;
            while (!DateTime.TryParseExact(ReadFromConsole("\tExpiration date (dd mm yyyy): "), "dd MM yyyy", new CultureInfo("ru-Ru"), DateTimeStyles.None, out expirationDate1))
            {
                Console.WriteLine("\tAn error: you need to input date properly (dd MM yyyy).");
            }

            if (journal.AddNewDiscount(shop1, sizeOfDiscount1, expirationDate1)) Console.WriteLine("The discount was succesfuuly added.");
            else Console.WriteLine("You have already got a discount in this shop.");
        }

        private static void RemoveDiscount()
        {
            Console.WriteLine("Enter the name of the shop where you want to delete the discount:");
            string shop1 = ReadFromConsole("\tName of the shop: ");

            if (journal.DeleteDiscount(shop1)) Console.WriteLine("The discount was succesfuuly removed.");
            else Console.WriteLine("Unfortunately, you haven't got a discount in this shop.");
        }

        private static void ShowAvailableDiscounts()
        {
            int dcounter = 1;
            string response = "";

            foreach (Discount d in journal.GetSortList())
            {
                if (d.ExpirationDate < DateTime.Now) continue;
                else
                {
                    response += $"\t{dcounter}. The name of shop: {d.Shop}\n" +
                    $"\t   Size of discount: {d.SizeOfDiscount}\n" +
                    $"\t   Expiration date: {d.ExpirationDate:d};\n";
                    dcounter++;
                }
            }

            if (response.Length == 0) Console.WriteLine("\tUnfortunately, there are no available discounts in your list.");
            else Console.WriteLine("A list of available discounts: \n" + response);
        }

        private static void SaveInFile()
        {
            Console.WriteLine("Enter path and file name to save:");
            try
            {
                XML_selector.SaveXML(Console.ReadLine(), journal);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static Discount_journal LoadFromFile()
        {
            Console.WriteLine("Enter path and file name to load:");
            try
            {
                return XML_selector.LoadXML(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Discount_journal();
            }
        }
    }
}