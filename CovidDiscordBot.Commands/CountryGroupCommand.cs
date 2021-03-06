﻿using CovidDiscordBot.Commands.Base;
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
    /// Commands for getting country data.
    /// </summary>
    [Group("country")]
    public class CountryGroupCommand : CommandBase
    {
        #region GetCountryAsync - country
        [GroupCommand, Description("Returns Covid-19 data from a specified country."), Cooldown(1, 5, CooldownBucketType.User)]
        public virtual async Task GetCountryAsync(CommandContext ctx, string country)
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
                Country countryData = await service.GetByCountryAsync(country);

                // Get date
                DateTime updated = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(countryData.Updated)).DateTime;
                // Format date
                string format = updated.ToString("H:mm', 'dddd dd.", CultureInfo.CreateSpecificCulture("en"));

                // Create new embed.
                DiscordEmbedBuilder embed = new()
                {
                    Title = $"COVID-19: Stats from today for {countryData.Name}",
                    Description = $"**Population:** {countryData.Population:N0}\n**Continent:** {countryData.Continent}\n**Updated:** {format}",
                    Thumbnail = new()
                    {
                        Height = 20,
                        Width = 25,
                        Url = countryData.CountryInfo.Flag,
                    },
                    Footer = new()
                    {
                        IconUrl = ctx.Message.Author.AvatarUrl,
                        Text = $"{ctx.Message.Author.Username}#{ctx.Message.Author.Discriminator} | Data provided by disease.sh. Request took {stopwatch.ElapsedMilliseconds}ms.",
                    },
                    Color = DiscordColor.Green,
                };


                // Add fields to embed.
                embed.AddField("Total Cases", $"{countryData.Cases:N0}", true);
                embed.AddField("Daily Cases", $"{countryData.TodayCases:N0}", true);
                embed.AddField("Cases per million:", $"{countryData.CasesPerOneMillion:N0}", true);

                embed.AddField("Total Recovered", $"{countryData.Recovered:N0}", true);
                embed.AddField("Daily Recovered", $"{countryData.TodayRecovered:N0}", true);
                embed.AddField("Recovered per million", $"{countryData.RecoveredPerOneMillion}", true);

                embed.AddField("Total Deaths", $"{countryData.Deaths:N0}", true);
                embed.AddField("Daily Deaths", $"{countryData.TodayDeaths:N0}", true);
                embed.AddField("Deaths per million", $"{countryData.DeathsPerOneMillion:N0}", true);

                embed.AddField("Total Tests", $"{countryData.Tests:N0}", true);
                embed.AddField("Tests per million", $"{countryData.TestsPerOneMillion:N0}", true);
                embed.AddField("_ _", "_ _", true);

                embed.AddField("Total Critical", $"{countryData.Critical:N0}", true);
                embed.AddField("Critical per million", $"{countryData.CriticalPerOneMillion:N0}", true);
                embed.AddField("_ _", "_ _", true);

                embed.AddField("Total Active", $"{countryData.Active:N0}", true);
                embed.AddField("Active per million", $"{countryData.ActivePerOneMillion:N0}", true);
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

        #region GetCountryYesterdayAsync - yesterday
        [Command("yesterday"), Description("Returns Covid-19 data from yesterday from a specified country."), Cooldown(1, 5, CooldownBucketType.User)]
        public virtual async Task GetCountryYesterdayAsync(CommandContext ctx, string country)
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
                Country countryData = await service.GetByCountryYesterdayAsync(country);

                // Get date
                DateTime updated = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(countryData.Updated)).DateTime;
                // Format date
                string format = updated.ToString("H:mm', 'dddd dd.", CultureInfo.CreateSpecificCulture("en"));

                // Create new embed.
                DiscordEmbedBuilder embed = new()
                {
                    Title = $"COVID-19: Stats from yesterday for {countryData.Name}",
                    Description = $"**Population:** {countryData.Population:N0}\n**Continent:** {countryData.Continent}\n**Updated:** {format}",
                    Thumbnail = new()
                    {
                        Height = 20,
                        Width = 25,
                        Url = countryData.CountryInfo.Flag,
                    },
                    Footer = new()
                    {
                        IconUrl = ctx.Message.Author.AvatarUrl,
                        Text = $"{ctx.Message.Author.Username}#{ctx.Message.Author.Discriminator} | Data provided by disease.sh. Request took {stopwatch.ElapsedMilliseconds}ms.",
                    },
                    Color = DiscordColor.Green,
                };

                // Add fields to embed.
                embed.AddField("Total Cases", $"{countryData.Cases:N0}", true);
                embed.AddField("Daily Cases", $"{countryData.TodayCases:N0}", true);
                embed.AddField("Cases per million:", $"{countryData.CasesPerOneMillion:N0}", true);

                embed.AddField("Total Recovered", $"{countryData.Recovered:N0}", true);
                embed.AddField("Daily Recovered", $"{countryData.TodayRecovered:N0}", true);
                embed.AddField("Recovered per million", $"{countryData.RecoveredPerOneMillion}", true);

                embed.AddField("Total Deaths", $"{countryData.Deaths:N0}", true);
                embed.AddField("Daily Deaths", $"{countryData.TodayDeaths:N0}", true);
                embed.AddField("Deaths per million", $"{countryData.DeathsPerOneMillion:N0}", true);

                embed.AddField("Total Tests", $"{countryData.Tests:N0}", true);
                embed.AddField("Tests per million", $"{countryData.TestsPerOneMillion:N0}", true);
                embed.AddField("_ _", "_ _", true);

                embed.AddField("Total Critical", $"{countryData.Critical:N0}", true);
                embed.AddField("Critical per million", $"{countryData.CriticalPerOneMillion:N0}", true);
                embed.AddField("_ _", "_ _", true);

                embed.AddField("Total Active", $"{countryData.Active:N0}", true);
                embed.AddField("Active per million", $"{countryData.ActivePerOneMillion:N0}", true);
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

        #region GetCountryTwoDaysAsync - twodays
        [Command("twodays"), Description("Returns Covid-19 data from two days ago from a specified country."), Cooldown(1, 5, CooldownBucketType.User)]
        public virtual async Task GetCountryTwoDaysAsync(CommandContext ctx, string country)
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
                Country countryData = await service.GetByCountryTwoDaysAsync(country);

                // Get date
                DateTime updated = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(countryData.Updated)).DateTime;
                // Format date
                string format = updated.ToString("H:mm', 'dddd dd.", CultureInfo.CreateSpecificCulture("en"));

                // Create new embed.
                DiscordEmbedBuilder embed = new()
                {
                    Title = $"COVID-19: Stats from two days ago for {countryData.Name}",
                    Description = $"**Population:** {countryData.Population:N0}\n**Continent:** {countryData.Continent}\n**Updated:** {format}",
                    Thumbnail = new()
                    {
                        Height = 20,
                        Width = 25,
                        Url = countryData.CountryInfo.Flag,
                    },
                    Footer = new()
                    {
                        IconUrl = ctx.Message.Author.AvatarUrl,
                        Text = $"{ctx.Message.Author.Username}#{ctx.Message.Author.Discriminator} | Data provided by disease.sh. Request took {stopwatch.ElapsedMilliseconds}ms.",
                    },
                    Color = DiscordColor.Green,
                };

                // Add fields to embed.
                embed.AddField("Total Cases", $"{countryData.Cases:N0}", true);
                embed.AddField("Daily Cases", $"{countryData.TodayCases:N0}", true);
                embed.AddField("Cases per million:", $"{countryData.CasesPerOneMillion:N0}", true);

                embed.AddField("Total Recovered", $"{countryData.Recovered:N0}", true);
                embed.AddField("Daily Recovered", $"{countryData.TodayRecovered:N0}", true);
                embed.AddField("Recovered per million", $"{countryData.RecoveredPerOneMillion}", true);

                embed.AddField("Total Deaths", $"{countryData.Deaths:N0}", true);
                embed.AddField("Daily Deaths", $"{countryData.TodayDeaths:N0}", true);
                embed.AddField("Deaths per million", $"{countryData.DeathsPerOneMillion:N0}", true);

                embed.AddField("Total Tests", $"{countryData.Tests:N0}", true);
                embed.AddField("Tests per million", $"{countryData.TestsPerOneMillion:N0}", true);
                embed.AddField("_ _", "_ _", true);

                embed.AddField("Total Critical", $"{countryData.Critical:N0}", true);
                embed.AddField("Critical per million", $"{countryData.CriticalPerOneMillion:N0}", true);
                embed.AddField("_ _", "_ _", true);

                embed.AddField("Total Active", $"{countryData.Active:N0}", true);
                embed.AddField("Active per million", $"{countryData.ActivePerOneMillion:N0}", true);
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