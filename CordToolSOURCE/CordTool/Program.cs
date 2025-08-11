using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace CordTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            { 
            Console.Title = "CordTool";
            Banner();
            Menu();
            ConsoleKeyInfo input = Console.ReadKey();
            char option = input.KeyChar;
            Console.WriteLine(option);
                switch (option)
                {
                    case '1':
                        webhookMessage();
                        Console.Clear();
                        Console.WriteLine("Message sent! Check your Discord client to check if it succeeded.");
                        break;
                    case '4':
                        return;
                    case '2':
                        nukeServer();
                        Console.Clear();
                        Console.WriteLine("Nuked!");
                        break;
                    case '3':
                        loginBot();
                        break;
                }   
            }
        }
    
        static void Banner() {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"


       _..._                                                                                             
    .-'_..._''.                          _______                                                   .---. 
  .' .'      '.\                         \  ___ `'.                                                |   | 
 / .'                                     ' |--.\  \                                               |   | 
. '                 .-''` ''-.    .-,.--. | |    \  '      .|      .-''` ''-.        .-''` ''-.    |   | 
| |               .'          '.  |  .-. || |     |  '   .' |_   .'          '.    .'          '.  |   | 
| |              /              ` | |  | || |     |  | .'     | /              `  /              ` |   | 
. '             '                '| |  | || |     ' .''--.  .-''                ''                '|   | 
 \ '.          .|         .-.    || |  '- | |___.' /'    |  |  |         .-.    ||         .-.    ||   | 
  '. `._____.-'/.        |   |   .| |    /_______.'/     |  |  .        |   |   ..        |   |   .|   | 
    `-.______ /  .       '._.'  / | |    \_______|/      |  '.' .       '._.'  /  .       '._.'  / '---' 
             `    '._         .'  |_|                    |   /   '._         .'    '._         .'  - @Epicinver :)    
                     '-....-'`                           `'-'       '-....-'`         '-....-'`          
");
            Console.ResetColor();
            Console.WriteLine("CordTool - A tool for managing and interacting with Discord webhooks.");
            Console.WriteLine("Developed by: Arran :)");
            Console.WriteLine("Version: 1.0.0");
        }
        static void Menu()
        {
            Console.WriteLine("\n1. Send Webhook Message");
            Console.WriteLine("2. Nuke Server");
            Console.WriteLine("3. Login to a Bot");
            Console.WriteLine("4. Exit");
        }

        static async void webhookMessage()
        {
            Console.Clear();
            Console.Write("Webhook URL: ");
            string webhook = Console.ReadLine();

            Console.Write("Message: ");
            string message = Console.ReadLine();

            string json = $"{{\"content\": \"{message}\"}}";

            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PostAsync(webhook, content);
            }
        }
        static async void nukeServer()
        {
            Console.Clear();
            Console.Write("Webhook URL: ");
            string webhook = Console.ReadLine();

            Console.Write("How many times should the loop go for? Enter: ");
            int looptimes;
            while (!int.TryParse(Console.ReadLine(), out looptimes) || looptimes <= 0)
            {
                Console.Write("Please enter a valid positive number: ");
            }

            Console.Write("What server invite should the webhook spam? [We spam this: RAIDED BY (Your server invite).] Enter: ");
            string serverinv = Console.ReadLine();

            string message = $"RAIDED BY {serverinv} @everyone";

            string json = $"{{\"content\": \"{message}\"}}";

            using (HttpClient client = new HttpClient())
            {
                for (int i = 0; i < looptimes; i++)
                {
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    await client.PostAsync(webhook, content);
                }
            }

        
        }

        static async void loginBot()
        {
            Console.Clear();
            Console.WriteLine("The log into a bot feature is in developement. Maybe try upgrade CordTool? ");
        }
    }
}
