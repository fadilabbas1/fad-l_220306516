# TelefonMarket Application

## Overview

TelefonMarket is a console-based application designed to manage a telephone marketplace. It empowers users to:

*   Add smartphones or feature phones.
*   View all phones within the inventory.
*   Update existing phone details.
*   Delete phones from the marketplace.
*   Persist data using a JSON file for long-term storage.

The application leverages C# while emphasizing object-oriented programming (OOP) principles and adheres to the Dependency Inversion Principle (DIP) for maintainability and future scalability.

## Features

*   Add Smartphone or Feature Phone
*   View All Phones
*   Update Phone Details
*   Delete a Phone
*   Persistent Storage using telephones.json

## Prerequisites

*   .NET SDK (version 6.0 or higher)
*   Newtonsoft.Json for JSON serialization

To install Newtonsoft.Json, run the following command:

```dotnet add package Newtonsoft.Json```

## Running the Application

1.  Clone the repository.
2.  Build the solution.
3.  Run the program from the terminal:

```dotnet run```

## OOP Principles Applied

1.  **Encapsulation**

    *   **Definition:** Bundling data and methods that operate on the data within a single unit (class) and restricting direct access to some of the object's components.
    *   **Usage in TelefonMarket:**
        *   Classes like Smartphone, FeaturePhone, and MarketService encapsulate their properties and methods.
        *   **Example:**

```
public class Smartphone : ITelephone
{
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public decimal Price { get; private set; }
    public string OperatingSystem { get; private set; }

    public Smartphone(string brand, string model, decimal price, string operatingSystem)
    {
        Brand = brand;
        Model = model;
        Price = price;
        OperatingSystem = operatingSystem;
    }
}
```

2.  **Inheritance**

    *   **Definition:** Creating a hierarchy where child classes inherit from a base class.
    *   **Usage in TelefonMarket:**
        *   Smartphone and FeaturePhone inherit from the Telephone class (via the ITelephone interface).
        *   **Example:**

```
public class Smartphone : ITelephone { ... }
```
```
public class FeaturePhone : ITelephone { ... }
```

3.  **Polymorphism**

    *   **Definition:** Ability to process objects differently based on their data type or class.
    *   **Usage in TelefonMarket:**
        *   The MarketService class operates on the ITelephone interface, allowing it to handle both Smartphone and FeaturePhone objects polymorphically.
        *   **Example:**

```
public void AddTelephone(ITelephone telephone)
{
    _telephones.Add(telephone);
    SaveData();
}
```

4.  **Abstraction**

    *   **Definition:** Hiding implementation details and showing only the essential features of an object.
    *   **Usage in TelefonMarket:**
        *   The ITelephone interface abstracts the common functionality of different types of telephones.
        *   **Example:**

```
public interface ITelephone
{
    string Brand { get; }
    string Model { get; }
    decimal Price { get; }
    string GetModelDetails();
}
```

## Dependency Inversion Principle (DIP)

**Principle:**

*   High-level modules should not depend on low-level modules. Both should depend on abstractions.
*   Abstractions should not depend on details. Details should depend on abstractions.

**Application in TelefonMarket:**

*   The Program class does not depend on concrete implementations like MarketService or ConsoleUserInterface.
*   Instead, it depends on the IMarketService and IUserInterface abstractions, ensuring that the underlying implementations can be swapped or extended without affecting the rest of the code.

**Example:**

```
public class Program
{
    private readonly IMarketService _marketService;
    private readonly IUserInterface _userInterface;

    public Program(IMarketService marketService, IUserInterface userInterface)
    {
        _marketService = marketService;
        _userInterface = userInterface;
    }
}
```

By injecting IMarketService and IUserInterface into the Program class, the application adheres to DIP. For example:

*   MarketService is injected to handle data management.
*   ConsoleUserInterface is injected to handle user interactions
