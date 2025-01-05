using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonMarketStorage
{
    public interface IUserInterface
    {
        string GetInput(string prompt);
        void ShowMessage(string message);
    }

    public class ConsoleUserInterface : IUserInterface
    {
        public string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
