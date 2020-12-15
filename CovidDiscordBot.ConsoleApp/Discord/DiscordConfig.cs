using CovidDiscordBot.ConsoleApp.Config;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading.Tasks;
using System;

namespace CovidDiscordBot.ConsoleApp.Discord
{
    /// <summary>
    /// Static configuration class for a <see cref="DiscordBot"/>.
    /// </summary>
    public static class DiscordConfig
    {
        #region Configure
        /// <summary>
        /// Used for configuring the Discord client.
        /// </summary>
        /// <returns></returns>
        public static async Task<DiscordClient> Configure()
        {
            // Initialize the config
            await BotConfig.InitializeAsync();

            // Initialize the client.
            DiscordClient client = new(new()
            {
                Token = BotConfig.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                Intents = DiscordIntents.AllUnprivileged
            });

            // Set the Discord client command config.
            CommandsNextExtension commands = client.UseCommandsNext(new()
            {
                StringPrefixes = new string[] { BotConfig.Prefix },
                EnableDms = false,
                EnableMentionPrefix = true,
                DmHelp = false,
                EnableDefaultHelp = true,
                CaseSensitive = false
            });

            // Register commands.
            commands.RegisterCommands(Assembly.Load("CovidDiscordBot.Commands"));

            // Register event handler.
            commands.CommandErrored += CommandErrored;

            return client;
        }
        #endregion

        #region CommandErrored
        private static Task CommandErrored(CommandsNextExtension extension, CommandErrorEventArgs e)
        {
            try
            {
                if(e.Command != null)
                {
                    // Log error message.
                    extension.Client.Logger.Log(
                        LogLevel.Error,
                        new EventId(101, "CmdError"),
                        $"{e.Context.Member.DisplayName}#{e.Context.Member.Discriminator}/{e.Context.Channel.Id}/{e.Command.Name}");

                    return Task.CompletedTask;
                }

                // Log error message.
                extension.Client.Logger.Log(
                    LogLevel.Error,
                    new EventId(101, "CmdError"),
                    $"{e.Context.Member.DisplayName}#{e.Context.Member.Discriminator}/{e.Context.Channel.Id}/{e.Context.Message.Content}");

                return Task.CompletedTask;
            }
            catch(Exception ex)
            {
                // Log error message.
                extension.Client.Logger.Log(LogLevel.Error, new EventId(101, "CmdError"), ex.Message);

                return Task.CompletedTask;
            }
        }
        #endregion

        #region UpdateActivity
        /// <summary>
        /// Updates the activity for the provided client.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static async Task UpdateActivity(DiscordClient client)
        {
            // Create activity object
            DiscordActivity discordActivity = new DiscordActivity()
            {
                ActivityType = ActivityType.Watching,
                Name = BotConfig.Status
            };
            DiscordActivity activity = discordActivity;

            // Update activity
            await client.UpdateStatusAsync(activity);
        }
        #endregion
    }
}