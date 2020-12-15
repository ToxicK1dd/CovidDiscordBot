using CovidDiscordBot.Commands.Base;
using CovidDiscordBot.Entities;
using CovidDiscordBot.WebServices;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using System.Threading.Tasks;
using System;

namespace CovidDiscordBot.Commands
{
    public class CovidCommands : CommandBase
    {
        #region GetCovidInfoAsync - covid
        [Command("covid"), Description("Returns Covid-19 data from a specified country."), Aliases("virus", "corona", "covid19", "covid-19"), Cooldown(1, 5, CooldownBucketType.User)]
        public virtual async Task GetCovidInfoAsync(CommandContext ctx, string country)
        {
            try
            {
                // Trigger typing.
                await ctx.TriggerTypingAsync();

                // Create service, and get data.
                CovidService service = new();
                Country countryData = await service.GetByCountryAsync(country);

                // Convert timestamp from countryData to a datatime.
                DateTime updated = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Math.Round(countryData.Updated / 1000d)).ToLocalTime();

                // Set the format of the embed footer text.
                string format = ((updated.Year + updated.Month + updated.Day) == (DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day)) ? "Today at" : $"{updated:MM/dd}";

                // Create new embed.
                DiscordEmbedBuilder embed = new()
                {
                    Title = $"COVID-19: Stats for {countryData.Name}",
                    Description = $"**Continent:** {countryData.Continent}\n**Population:** {countryData.Population:N0}",
                    Thumbnail = new()
                    {
                        Height = 20,
                        Width = 25,
                        Url = countryData.CountryInfo.Flag,
                    },
                    Footer = new()
                    {
                        Text = $"Last update: {format} {updated:HH:mm} | Requested by {ctx.Message.Author.Username}#{ctx.Message.Author.Discriminator}",
                    },
                    Color = DiscordColor.Green,
                };

                // Add fields to embed.
                embed.AddField("Cases", $"{countryData.Cases:N0}", true);
                embed.AddField("Cases Today", $"{countryData.TodayCases:N0}", true);
                embed.AddField("Cases per million:", $"{countryData.CasesPerOneMillion:N0}", true);

                embed.AddField("Recovered", $"{countryData.Recovered:N0}", true);
                embed.AddField("Recovered Today", $"{countryData.TodayRecovered:N0}", true);
                embed.AddField("Recovered per million", $"{countryData.RecoveredPerOneMillion}", true);

                embed.AddField("Deaths", $"{countryData.Deaths:N0}", true);
                embed.AddField("Deaths Today", $"{countryData.TodayDeaths:N0}", true);
                embed.AddField("Deaths per million", $"{countryData.DeathsPerOneMillion:N0}", true);

                embed.AddField("Tests", $"{countryData.Tests:N0}", true);
                embed.AddField("Tests per million", $"{countryData.TestsPerOneMillion:N0}", true);
                embed.AddField("_ _", $"_ _", true);

                embed.AddField("Critical", $"{countryData.Critical:N0}", true);
                embed.AddField("Critical per million", $"{countryData.CriticalPerOneMillion:N0}", true);
                embed.AddField("_ _", $"_ _", true);

                embed.AddField("Active", $"{countryData.Active:N0}", true);
                embed.AddField("Active per million", $"{countryData.ActivePerOneMillion:N0}", true);
                embed.AddField("_ _", $"_ _", true);

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