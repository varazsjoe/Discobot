using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace discobot.Core.Command
{
    public class kocka : ModuleBase<SocketCommandContext>
    {
        [Command("roll"), Alias("roll"), Summary("1szám a dobások száma,2szám a kocka oldalának száma Pl:2d6 = 2darab6oldalú kockával történő dobás.")]
        public async Task Dobas([Remainder]string message)
        {
            //kiszedjük a parancsból a számot
            string kockakszama = "" + message[0];
            string kockatipusa = "" + message[2]+message[3];

            int dobasokszama = Int32.Parse(kockakszama);
            int szam = Int32.Parse(kockatipusa);

            string szoveg="";


            for (int i = 0; i < dobasokszama; i++)
            {
                //random szám generálása
                Random rand = new Random();
                int randomszam = rand.Next(1, szam+1);

                szoveg += Convert.ToString(randomszam)+ "," ;
            }

            


            
           //eredmény kirakása
            await Context.Channel.SendMessageAsync(szoveg);
          
        }

    }
}
