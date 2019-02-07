using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace discobot.Core.Command
{
   public class Helloworld : ModuleBase<SocketCommandContext>
    {
        [Command("hello"),Alias("Helloworld "),Summary("hello napocska")]
        public async Task valami()
        {
            await Context.Channel.SendMessageAsync("nem hello world");
        }

    }
}
