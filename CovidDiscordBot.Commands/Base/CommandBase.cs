using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using System.Threading.Tasks;
using System;

namespace CovidDiscordBot.Commands.Base
{
    /// <summary>
    /// Implements <see cref="BaseCommandModule"/> and <see cref="Config"/> for easy use in command classes.
    /// </summary>
    public class CommandBase : BaseCommandModule
    {
        #region HandleExceptionAsync
        /// <summary>
        /// Creates and responds with an embed containing exception data.
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected static async Task HandleExceptionAsync(CommandContext ctx, Exception ex)
        {
            try
            {
                // Create Embed.
                DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
                {
                    Title = $"An exception occurred while executing.",
                    Color = DiscordColor.Green
                };

                // Add fields with useful data.
                embed.AddField("Message", ex.Message, false);
                embed.AddField("Type", ex.GetType().ToString(), false);
                embed.AddField("Stacktrace", "See logs for more details.", false);

                // Respond with the created embed.
                await ctx.RespondAsync(embed: embed);
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion
    }
}