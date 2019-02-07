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
    class mentes : ModuleBase<SocketCommandContext>
    {
       static string szoveg;
       // static string nev;
        [Command("mentes")]
        public async Task Save([Remainder]string message)
        {

            //kiszedjük a parancsból a számot
            var user = Context.User.Username;
           
            szoveg = "" + message;
            await Context.Channel.SendMessageAsync("az alábbi szöveg elmentve"+user+"által:"+""+szoveg);
            string doksi = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // return szoveg;
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(doksi, user+".txt"), true))
            {
                outputFile.WriteLine(szoveg);
            }
           
            
           
        }
        string mentetszoveg = szoveg;
        [Command("mond")]
        public async Task Say()
        {
            
            await Context.Channel.SendMessageAsync(mentetszoveg);
        }

    }
}
