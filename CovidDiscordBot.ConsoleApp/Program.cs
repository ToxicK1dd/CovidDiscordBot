using CovidDiscordBot.ConsoleApp.Discord;
using System.Threading.Tasks;
using System;

namespace CovidDiscordBot.ConsoleApp
{
    public class Program
    {
        public static async Task Main()
        {
            try
            {
                DiscordBot bot = new();

                await bot.RunAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

                Console.ReadLine();
            }
        }
    }
}