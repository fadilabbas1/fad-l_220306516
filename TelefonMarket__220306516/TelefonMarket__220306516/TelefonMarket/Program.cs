using System;
using System.Collections.Generic;
using TelefonMarketStorage;

namespace TelefonMarket
{
    public enum MenuOption
    {
        AddSmartphone = 1,
        AddFeaturePhone,
        ShowAllPhones,
        DeletePhone,
        UpdatePhone,
        Exit
    }

    class Program
    {
        private readonly MarketService _marketService;
        private readonly ConsoleUserInterface _userInterface;

        public Program()
        {
            _marketService = new MarketService();
            _userInterface = new ConsoleUserInterface();
        }

        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        public void Run()
        {
            while (true)
            {
                _userInterface.ShowMessage("\nTelephone Market CLI");
                _userInterface.ShowMessage("1. Add Smartphone");
                _userInterface.ShowMessage("2. Add Feature Phone");
                _userInterface.ShowMessage("3. Show All Phones");
                _userInterface.ShowMessage("4. Delete Phone");
                _userInterface.ShowMessage("5. Update Phone");
                _userInterface.ShowMessage("6. Exit");

                string choice = _userInterface.GetInput("Select an option: ");

                if (Enum.TryParse(choice, out MenuOption option) && Enum.IsDefined(typeof(MenuOption), option))
                {
                    switch (option)
                    {
                        case MenuOption.AddSmartphone:
                            AddSmartphone();
                            break;
                        case MenuOption.AddFeaturePhone:
                            AddFeaturePhone();
                            break;
                        case MenuOption.ShowAllPhones:
                            ShowAllPhones();
                            break;
                        case MenuOption.DeletePhone:
                            DeletePhone();
                            break;
                        case MenuOption.UpdatePhone:
                            UpdatePhone();
                            break;
                        case MenuOption.Exit:
                            _userInterface.ShowMessage("Goodbye!");
                            return;
                        default:
                            _userInterface.ShowMessage("Invalid option. Try again.");
                            break;
                    }
                }
                else
                {
                    _userInterface.ShowMessage("Invalid option. Try again.");
                }
            }
        }

        private void AddSmartphone()
        {
            string brand = _userInterface.GetInput("Enter Brand: ");
            string model = _userInterface.GetInput("Enter Model: ");
            decimal price = decimal.Parse(_userInterface.GetInput("Enter Price: "));
            string os = _userInterface.GetInput("Enter Operating System: ");

            var smartphone = new Smartphone(brand, model, price, os);
            _marketService.AddTelephone(smartphone);
            _userInterface.ShowMessage("Smartphone added successfully!");
        }

        private void AddFeaturePhone()
        {
            string brand = _userInterface.GetInput("Enter Brand: ");
            string model = _userInterface.GetInput("Enter Model: ");
            decimal price = decimal.Parse(_userInterface.GetInput("Enter Price: "));
            bool hasCamera = _userInterface.GetInput("Does it have a camera? (yes/no): ").ToLower() == "yes";

            var featurePhone = new FeaturePhone(brand, model, price, hasCamera);
            _marketService.AddTelephone(featurePhone);
            _userInterface.ShowMessage("Feature phone added successfully!");
        }

        private void ShowAllPhones()
        {
            var phones = _marketService.GetTelephones();

            if (phones.Count == 0)
            {
                _userInterface.ShowMessage("No phones available.");
                return;
            }

            _userInterface.ShowMessage("\nAvailable Phones:");
            foreach (var phone in phones)
            {
                _userInterface.ShowMessage(phone.GetModelDetails());
            }
        }

        private void DeletePhone()
        {
            string model = _userInterface.GetInput("Enter Model of the phone to delete: ");
            _marketService.DeleteTelephone(model);
        }

        private void UpdatePhone()
        {
            string model = _userInterface.GetInput("Enter Model of the phone to update: ");

            _userInterface.ShowMessage("\nChoose Phone Type:");
            _userInterface.ShowMessage("1. Smartphone");
            _userInterface.ShowMessage("2. Feature Phone");
            string typeChoice = _userInterface.GetInput("Select an option: ");

            ITelephone updatedPhone = null;

            switch (typeChoice)
            {
                case "1":
                    string brand = _userInterface.GetInput("Enter Brand: ");
                    string updatedModel = _userInterface.GetInput("Enter Model: ");
                    decimal price = decimal.Parse(_userInterface.GetInput("Enter Price: "));
                    string os = _userInterface.GetInput("Enter Operating System: ");
                    updatedPhone = new Smartphone(brand, updatedModel, price, os);
                    break;

                case "2":
                    brand = _userInterface.GetInput("Enter Brand: ");
                    updatedModel = _userInterface.GetInput("Enter Model: ");
                    price = decimal.Parse(_userInterface.GetInput("Enter Price: "));
                    bool hasCamera = _userInterface.GetInput("Does it have a camera? (yes/no): ").ToLower() == "yes";
                    updatedPhone = new FeaturePhone(brand, updatedModel, price, hasCamera);
                    break;

                default:
                    _userInterface.ShowMessage("Invalid phone type selected.");
                    return;
            }

            _marketService.UpdateTelephone(model, updatedPhone);
        }
    }
}
