using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TelefonMarketStorage
{
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
        private const string FilePath = "telephones.json";

        public MarketService()
        {
            LoadData();
        }

        public void AddTelephone(ITelephone telephone)
        {
            _telephones.Add(telephone);
            SaveData();
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
                SaveData();
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
                    SaveData();
                    Console.WriteLine($"Telephone with model '{model}' updated successfully.");
                    return;
                }
            }
            Console.WriteLine($"Telephone with model '{model}' not found.");
        }

        private void SaveData()
        {
            var json = JsonConvert.SerializeObject(_telephones, Formatting.Indented,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            File.WriteAllText(FilePath, json);
        }

        private void LoadData()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                var loadedTelephones = JsonConvert.DeserializeObject<List<ITelephone>>(json,
                    new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                if (loadedTelephones != null)
                {
                    _telephones.AddRange(loadedTelephones);
                }
            }
        }
    }
}