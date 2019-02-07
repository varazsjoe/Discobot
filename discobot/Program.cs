using System;
using System.Reflection;
using System.Threading.Tasks;

using Discord;
using Discord.WebSocket;
using Discord.Commands;
using discobot.Core.Command;

namespace discobot
{
    class Program
    {
        private DiscordSocketClient Client;
        private CommandService Command;

        static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();
        private async Task MainAsync()
        {
            Client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Debug


            });

            Command = new CommandService(new CommandServiceConfig
            {
                CaseSensitiveCommands = true,
                DefaultRunMode = RunMode.Async,
                LogLevel = LogSeverity.Debug
            });

            Client.MessageReceived += Client_MessageReceived;
            await Command.AddModuleAsync(typeof(Helloworld));
            await Command.AddModuleAsync(typeof(kocka));
            await Command.AddModuleAsync(typeof(mentes));
            await Command.AddModuleAsync(typeof(szabad));

            Client.Ready += Client_Ready;
            Client.Log += Client_Log;

            string Token = "NTM5MDI3MDM4MDE1NzE3Mzk1.Dy8kDw.SLBNqOlq1M4BiDo96qstGCeJ3x8";
            await Client.LoginAsync(TokenType.Bot, Token);
            await Client.StartAsync();

            await Task.Delay(-1);
        }
        
        private async Task Client_Log(LogMessage Message)
        {
            Console.WriteLine($"{DateTime.Now}at{Message.Source}{Message.Message}");
        }
        private async Task Client_Ready()
        {
            await Client.SetGameAsync("AllRound Bot - Tutorial!","",StreamType.NotStreaming);
        }
        private async Task Client_MessageReceived(SocketMessage MessageParam)
        {
            //configure all commands
            var Message = MessageParam as SocketUserMessage;
            var Context = new SocketCommandContext(Client, Message);

            if (Context.Message == null || Context.Message.Content == "") return;
            if (Context.User.IsBot) return;

            int ArgPos = 0;
            if (!(Message.HasStringPrefix("a!", ref ArgPos) || Message.HasMentionPrefix(Client.CurrentUser, ref ArgPos))) return;
            var Result = await Command.ExecuteAsync(Context, ArgPos);
            if (!Result.IsSuccess)
            {
                Console.WriteLine($"{DateTime.Now} at Commands something went wrong");
            }
        }

    }
}
// woooooo :D
//ez itt egy szép komment vikinek ..ez tök jó nem kell teamviewer :D
// jaja és mindketten tudunk kódolni a programba
//csak ne h ugy járjak mint a kincs ami nincsben h szépen el megyek aludni és megváltozik a kodom mire felkelek :D