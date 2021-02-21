using CovidDiscordBot.Commands.Base;
using CovidDiscordBot.Entities;
using CovidDiscordBot.WebServices;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using System;

namespace CovidDiscordBot.Commands
{
    /// <summary>
    /// Commands for getting global data.
    /// </summary>
    [Group("global")]
    public class GlobalGroupCommand : CommandBase
    {
        #region GetGlobalAsync - global
        [GroupCommand, Description("Returns global Covid-19 data ."), Cooldown(1, 5, CooldownBucketType.User)]
        public virtual async Task GetGlobalAsync(CommandContext ctx)
        {
            try
            {
                // Create stopwatch, and start it.
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                // Trigger typing.
                await ctx.TriggerTypingAsync();

                // Create service, and get data.
                CovidService service = new();
                Global globalData = await service.GetGlobalAsync();

                // Get date
                DateTime updated = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(globalData.Updated)).DateTime;
                // Format date
                string format = updated.ToString("H:mm', 'dddd dd.", CultureInfo.CreateSpecificCulture("en"));

                // Create new embed.
                DiscordEmbedBuilder embed = new()
                {
                    Title = "COVID-19: Global Stats",
                    Description = $"**Population:** {globalData.Population:N0}\n**Updated:** {format}",
                    Footer = new()
                    {
                        IconUrl = ctx.Message.Author.AvatarUrl,
                        Text = $"{ctx.Message.Author.Username}#{ctx.Message.Author.Discriminator} | Data provided by disease.sh. Request took {stopwatch.ElapsedMilliseconds}ms.",
                    },
                    Color = DiscordColor.Green,
                };

                // Add fields to embed.
                embed.AddField("Cases", $"{globalData.Cases:N0}", true);
                embed.AddField("Cases Today", $"{globalData.TodayCases:N0}", true);
                embed.AddField("Cases per million:", $"{globalData.CasesPerOneMillion:N0}", true);

                embed.AddField("Recovered", $"{globalData.Recovered:N0}", true);
                embed.AddField("Recovered Today", $"{globalData.TodayRecovered:N0}", true);
                embed.AddField("Recovered per million", $"{globalData.RecoveredPerOneMillion}", true);

                embed.AddField("Deaths", $"{globalData.Deaths:N0}", true);
                embed.AddField("Deaths Today", $"{globalData.TodayDeaths:N0}", true);
                embed.AddField("Deaths per million", $"{globalData.DeathsPerOneMillion:N0}", true);

                embed.AddField("Tests", $"{globalData.Tests:N0}", true);
                embed.AddField("Tests per million", $"{globalData.TestsPerOneMillion:N0}", true);
                embed.AddField("_ _", "_ _", true);

                embed.AddField("Critical", $"{globalData.Critical:N0}", true);
                embed.AddField("Critical per million", $"{globalData.CriticalPerOneMillion:N0}", true);
                embed.AddField("_ _", "_ _", true);

                embed.AddField("Active", $"{globalData.Active:N0}", true);
                embed.AddField("Active per million", $"{globalData.ActivePerOneMillion:N0}", true);
                embed.AddField("_ _", "_ _", true);

                await ctx.RespondAsync(embed: embed);
            }
            catch(Exception ex)
            {
                // Handle exception.
                await HandleExceptionAsync(ctx, ex);

                // Rethrow for use elsewhere.
                throw;
            }
        }
        #endregion
    }
}