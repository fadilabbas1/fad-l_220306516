using System;
using System.Collections.Generic;

public interface ITelephone
{
    string GetModelDetails();
    decimal GetPrice();
}

public abstract class Telephone : ITelephone
{
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public decimal Price { get; private set; }

    protected Telephone(string brand, string model, decimal price)
    {
        Brand = brand;
        Model = model;
        Price = price;
    }

    public abstract string GetModelDetails();

    public decimal GetPrice()
    {
        return Price;
    }
}

public class Smartphone : Telephone
{
    public string OperatingSystem { get; private set; }

    public Smartphone(string brand, string model, decimal price, string operatingSystem)
        : base(brand, model, price)
    {
        OperatingSystem = operatingSystem;
    }

    public override string GetModelDetails()
    {
        return $"Brand: {Brand}, Model: {Model}, OS: {OperatingSystem}, Price: {Price:C}";
    }
}

public class FeaturePhone : Telephone
{
    public bool HasCamera { get; private set; }

    public FeaturePhone(string brand, string model, decimal price, bool hasCamera)
        : base(brand, model, price)
    {
        HasCamera = hasCamera;
    }

    public override string GetModelDetails()
    {
        return $"Brand: {Brand}, Model: {Model}, Camera: {(HasCamera ? "Yes" : "No")}, Price: {Price:C}";
    }
}

public interface IMarketService
{
    void AddTelephone(ITelephone telephone);
    List<ITelephone> GetTelephones();
    void DeleteTelephone(string model);
    void UpdateTelephone(string model, ITelephone updatedTelephone);
}

public class MarketService : IMarketService
{
    private readonly List<ITelephone> _telephones = new List<ITelephone>();

    public void AddTelephone(ITelephone telephone)
    {
        _telephones.Add(telephone);
    }

    public List<ITelephone> GetTelephones()
    {
        return _telephones;
    }

    public void DeleteTelephone(string model)
    {
        var telephone = _telephones.Find(t => t is Telephone tel && tel.Model == model);
        if (telephone != null)
        {
            _telephones.Remove(telephone);
            Console.WriteLine($"Telephone with model '{model}' deleted successfully.");
        }
        else
        {
            Console.WriteLine($"Telephone with model '{model}' not found.");
        }
    }

    public void UpdateTelephone(string model, ITelephone updatedTelephone)
    {
        for (int i = 0; i < _telephones.Count; i++)
        {
            if (_telephones[i] is Telephone tel && tel.Model == model)
            {
                _telephones[i] = updatedTelephone;
                Console.WriteLine($"Telephone with model '{model}' updated successfully.");
                return;
            }
        }
        Console.WriteLine($"Telephone with model '{model}' not found.");
    }
}