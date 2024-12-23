using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonMarket
{

    class Program
    {
        static void Main(string[] args)
        {
            IMarketService marketService = new MarketService();

            while (true)
            {
                Console.WriteLine("\nTelephone Market CLI");
                Console.WriteLine("1. Add Smartphone");
                Console.WriteLine("2. Add Feature Phone");
                Console.WriteLine("3. Show All Phones");
                Console.WriteLine("4. Delete Phone");
                Console.WriteLine("5. Update Phone");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddSmartphone(marketService);
                        break;
                    case "2":
                        AddFeaturePhone(marketService);
                        break;
                    case "3":
                        ShowAllPhones(marketService);
                        break;
                    case "4":
                        DeletePhone(marketService);
                        break;
                    case "5":
                        UpdatePhone(marketService);
                        break;
                    case "6":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void AddSmartphone(IMarketService marketService)
        {
            Console.Write("Enter Brand: ");
            string brand = Console.ReadLine();
            Console.Write("Enter Model: ");
            string model = Console.ReadLine();
            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Operating System: ");
            string os = Console.ReadLine();

            var smartphone = new Smartphone(brand, model, price, os);
            marketService.AddTelephone(smartphone);
            Console.WriteLine("Smartphone added successfully!");
        }

        static void AddFeaturePhone(IMarketService marketService)
        {
            Console.Write("Enter Brand: ");
            string brand = Console.ReadLine();
            Console.Write("Enter Model: ");
            string model = Console.ReadLine();
            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Does it have a camera? (yes/no): ");
            bool hasCamera = Console.ReadLine().ToLower() == "yes";

            var featurePhone = new FeaturePhone(brand, model, price, hasCamera);
            marketService.AddTelephone(featurePhone);
            Console.WriteLine("Feature phone added successfully!");
        }

        static void ShowAllPhones(IMarketService marketService)
        {
            var phones = marketService.GetTelephones();

            if (phones.Count == 0)
            {
                Console.WriteLine("No phones available.");
                return;
            }

            Console.WriteLine("\nAvailable Phones:");
            foreach (var phone in phones)
            {
                Console.WriteLine(phone.GetModelDetails());
            }
        }

        static void DeletePhone(IMarketService marketService)
        {
            Console.Write("Enter Model of the phone to delete: ");
            string model = Console.ReadLine();
            marketService.DeleteTelephone(model);
        }

        static void UpdatePhone(IMarketService marketService)
        {
            Console.Write("Enter Model of the phone to update: ");
            string model = Console.ReadLine();

            Console.WriteLine("\nChoose Phone Type:");
            Console.WriteLine("1. Smartphone");
            Console.WriteLine("2. Feature Phone");
            Console.Write("Select an option: ");

            string typeChoice = Console.ReadLine();

            ITelephone updatedPhone = null;

            switch (typeChoice)
            {
                case "1":
                    Console.Write("Enter Brand: ");
                    string smartphoneBrand = Console.ReadLine();
                    Console.Write("Enter Model: ");
                    string smartphoneModel = Console.ReadLine();
                    Console.Write("Enter Price: ");
                    decimal smartphonePrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Operating System: ");
                    string os = Console.ReadLine();

                    updatedPhone = new Smartphone(smartphoneBrand, smartphoneModel, smartphonePrice, os);
                    break;

                case "2":
                    Console.Write("Enter Brand: ");
                    string featurePhoneBrand = Console.ReadLine();
                    Console.Write("Enter Model: ");
                    string featurePhoneModel = Console.ReadLine();
                    Console.Write("Enter Price: ");
                    decimal featurePhonePrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Does it have a camera? (yes/no): ");
                    bool hasCamera = Console.ReadLine().ToLower() == "yes";

                    updatedPhone = new FeaturePhone(featurePhoneBrand, featurePhoneModel, featurePhonePrice, hasCamera);
                    break;

                default:
                    Console.WriteLine("Invalid phone type selected.");
                    return;
            }

            marketService.UpdateTelephone(model, updatedPhone);
        }
    }

}
