using DSharpPlus.EventArgs;
using DSharpPlus;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

namespace CovidDiscordBot.ConsoleApp.Discord
{
    /// <summary>
    /// The "brain" of the <see cref="DiscordBot"/>.
    /// </summary>
    public class DiscordBot
    {
        #region Fields
        protected DiscordClient client; 
        #endregion

        #region RunAsync
        /// <summary>
        /// The task keeping the Discord bot running
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public virtual async Task RunAsync()
        {
            try
            {
                // Configure the client.
                client = await DiscordConfig.Configure();

                // Register event handlers .
                client.ClientErrored += ClientErrored;
                client.Ready += OnClientReadyAsync;

                // Log Configuration.
                client.Logger.Log(LogLevel.Information, new EventId(101, "Startup"), "Configuration Complete");

                // Log Connection Attempt.
                client.Logger.Log(LogLevel.Information, new EventId(101, "Startup"), "Attempting Connection");
                
                // Connect bot to Discord.
                await client.ConnectAsync();

                // Keep this task running forever, thereby keeping the bot running.
                await Task.Delay(-1);
            }
            catch(Exception ex)
            {
                if(client is not null)
                {
                    // Log error message.
                    client.Logger.Log(LogLevel.Error, new EventId(101, "Startup"), ex.Message);
                }
                else
                {
                    // Lets hope something handles this.
                    throw;
                }
            }
        }
        #endregion

        #region OnClientReady
        protected virtual async Task OnClientReadyAsync(DiscordClient client, ReadyEventArgs e)
        {
            try
            {
                client.Logger.Log(LogLevel.Information, new EventId(101, "Ready"), "Connection Established");

                // Set the client activity
                await DiscordConfig.UpdateActivity(client);

                client.Logger.Log(LogLevel.Information, new EventId(101, "Ready"), "Status Updated");
            }
            catch(Exception ex)
            {
                // Log error message
                client.Logger.Log(LogLevel.Error, new EventId(101, "Ready"), ex.Message);
            }
        }
        #endregion

        #region ClientErrored
        public virtual Task ClientErrored(DiscordClient client, ClientErrorEventArgs e)
        {
            client.Logger.Log(LogLevel.Critical, new EventId(101, "ClientError"), e.Exception.Message);

            return Task.CompletedTask;
        }
        #endregion
    }
}