using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using System.IO;

namespace discobot
{
    class szabad : ModuleBase<SocketCommandContext>
    {
        
        static string szoveg;
        static string user;
        [Command("napok")]
        public async Task Save([Remainder]string message)
        {

            //az üzenet készitőjét kimentjük egy változóba.
            var user = Context.User.Username;
           //az általa be irt szöveget belerakjuk a szöveg változóba.
            szoveg = "" + message;
            
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\disco\"+user+".txt", true))
            {
                file.WriteLine(szoveg);
            }


        }
        string mentetszoveg = szoveg;
        [Command("szabad")]
        public async Task Say([Remainder]string message)
        {
            string targetuser = "" + message;

            string[] lines = System.IO.File.ReadAllLines(@"C:\disco\"+targetuser+".txt");
          //  System.Console.WriteLine("Contents of WriteLines.txt = ");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                await Context.Channel.SendMessageAsync("\t" + line);
            }
            //await Context.Channel.SendMessageAsync(mentetszoveg);
        }

    }
}
