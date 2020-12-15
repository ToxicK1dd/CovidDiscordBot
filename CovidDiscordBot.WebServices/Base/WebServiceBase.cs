using System.IO;
using System.Net;
using System.Threading.Tasks;
using System;

namespace CovidDiscordBot.WebServices.Base
{
    /// <summary>
    /// Implements the <see cref="CallWebApiAsync(string)"/> method for use in concreate classes.
    /// </summary>
    public abstract class WebServiceBase
    {
        #region CallWebApiAsync
        /// <summary>
        /// Calls a given endpoint and returns a string with the retrieved json data
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        protected virtual async Task<string> CallWebApiAsync(string url)
        {
            try
            {
                // Create a HttpWebRequest.
                HttpWebRequest httpWebRequest = WebRequest.CreateHttp(url);
                // Set method to get.
                httpWebRequest.Method = WebRequestMethods.Http.Get;
                // Set accept headers.
                httpWebRequest.Accept = "application/json";

                // String for storing the json data retrieved from the endpoint.
                string result;

                // Get response from the website.
                using(HttpWebResponse response = await httpWebRequest.GetResponseAsync() as HttpWebResponse)
                {
                    // Read the response.
                    using StreamReader sr = new StreamReader(response.GetResponseStream());
                    // Assign the response data to the result variable.
                    result = await sr.ReadToEndAsync();
                };

                // Return the retrieved JSON data.
                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion
    }
}