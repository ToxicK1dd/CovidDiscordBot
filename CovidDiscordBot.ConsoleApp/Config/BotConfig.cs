using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System;

namespace CovidDiscordBot.ConsoleApp.Config
{
    /// <summary>
    /// Represents a <see cref="BotConfig"/> object used to store the <see cref="Token"/>, and <see cref="Prefix"/> of a Discord Bot.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public static class BotConfig
    {
        #region Constant paths
        public const string configPath = "configs/BotConfig.json";
        #endregion

        #region Fields
        private static JObject jObject;
        #endregion

        #region Properties
        /// <summary>
        /// The <see cref="Token"/> of the <see cref="BotConfig"/>.
        /// </summary>
        public static string Token { get; set; }

        /// <summary>
        /// The <see cref="Prefix"/> of the <see cref="BotConfig"/>.
        /// </summary>
        public static string Prefix { get; set; }

        /// <summary>
        /// The Status which is displayed on the bot
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public static string Status { get; set; }
        #endregion

        #region Methods

        #region InitializeAsync
        /// <summary>
        /// Loads the configuration file from disk.
        /// </summary>
        /// <returns></returns>
        public static async Task InitializeAsync()
        {
            bool created = await CheckForConfigFilesAsync();

            if(!created)
            {
                // Read the file.
                string config = await File.ReadAllTextAsync(configPath);

                // Parse config into.
                jObject = JObject.Parse(config);

                // Initialize values
                Token = (string)jObject[nameof(Token)];
                Prefix = (string)jObject[nameof(Prefix)];
                Status = (string)jObject[nameof(Status)];
            }
            else
            {
                throw new ArgumentException("The config file did not exist, but has been created. Please fill out the values, and restart.");
            }
        }
        #endregion

        #region CheckForConfigFilesAsync
        public static async Task<bool> CheckForConfigFilesAsync()
        {
            bool fileCreated = false;

            if(!File.Exists("configs"))
            {
                Directory.CreateDirectory("configs");
            }
            // Check if the config exists.
            if(!File.Exists(configPath))
            {
                jObject = new();

                // Set object values
                jObject.Add(nameof(Token), "My_Secret_Token");
                jObject.Add(nameof(Prefix), ".");
                jObject.Add(nameof(Status), "Finding Data...");

                // Serialize object.
                string json = JsonConvert.SerializeObject(jObject, Formatting.Indented);

                // Create file, and write the serialized data to the file.
                await File.WriteAllTextAsync(configPath, json, Encoding.UTF8);

                if(!fileCreated)
                {
                    fileCreated = true;
                }
            }

            // Return true if no condition was met.
            return fileCreated;
        }
        #endregion

        #region RewriteFileAsync
        /// <summary>
        /// Serializes and writes the current <see cref="Config"/> to the configuration file.
        /// </summary>
        /// <returns></returns>
        public static async Task RewriteFileAsync()
        {
            // Add values
            jObject[nameof(Token)] = Token;
            jObject[nameof(Prefix)] = Prefix;
            jObject[nameof(Status)] = Status;

            // Serialize the config.
            string json = JsonConvert.SerializeObject(jObject, Formatting.Indented);

            // Create file, and write the serialized data to the file.
            await File.WriteAllTextAsync(configPath, json, Encoding.UTF8);
        }
        #endregion

        #endregion
    }
}