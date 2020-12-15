using CovidDiscordBot.Entities;
using CovidDiscordBot.WebServices.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovidDiscordBot.WebServices
{
    /// <summary>
    /// Provides methods for getting Covid-19 data.
    /// </summary>
    public class CovidService : WebServiceBase
    {
        #region Endpoint URL
        protected const string endpoint = "https://corona.lmao.ninja/v2";
        #endregion

        #region GetGlobalAsync
        /// <summary>
        /// Get global covid data.
        /// </summary>
        /// <returns>Global covid-19 data.</returns>
        public virtual async Task<Global> GetGlobalAsync()
        {
            string json = await CallWebApiAsync($"{endpoint}/all?allowNull=false");

            Global globalData = JsonConvert.DeserializeObject<Global>(json);

            return globalData;
        }
        #endregion

        #region GetAllCountriesAsync
        /// <summary>
        /// Get all available covid data.
        /// </summary>
        /// <returns>Covid-19 data from all available countries.</returns>
        public virtual async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            string json = await CallWebApiAsync($"{endpoint}/countries?allowNull=false");

            IEnumerable<Country> countryData = JsonConvert.DeserializeObject<IEnumerable<Country>>(json);

            return countryData;
        }
        #endregion

        #region GetByCountryAsync
        /// <summary>
        /// Get available covid data from a specified country.
        /// </summary>
        /// <param name="countryName">The name of the country</param>
        /// <returns>Covid-19 data from the specified country.</returns>
        public virtual async Task<Country> GetByCountryAsync(string countryName)
        {
            string json = await CallWebApiAsync($"{endpoint}/countries/{countryName}?allowNull=false");

            Country countryData = JsonConvert.DeserializeObject<Country>(json);

            return countryData;
        }
        #endregion

        #region GetAllStatesAsync
        /// <summary>
        /// Get covid data from all available US states.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<State>> GetAllStatesAsync()
        {
            string json = await CallWebApiAsync($"{endpoint}/states?allowNull=false");

            List<State> stateData = JsonConvert.DeserializeObject<List<State>>(json);

            return stateData;
        }
        #endregion

        #region GetByStateAsync
        /// <summary>
        /// Get available covid data from a specified US state.
        /// </summary>
        /// <param name="stateName">The name of the US state.</param>
        /// <returns>Covid-19 data from the specified US state.</returns>
        public virtual async Task<State> GetByStateAsync(string stateName)
        {
            string json = await CallWebApiAsync($"{endpoint}/states/{stateName}?allowNull=false");

            State stateData = JsonConvert.DeserializeObject<State>(json);

            return stateData;
        }

        #endregion

        #region GetAllContinentsAsync
        /// <summary>
        /// Get covid data from all available continents.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<Continent>> GetAllContinentsAsync()
        {
            string json = await CallWebApiAsync($"{endpoint}/continents?allowNull=false");

            List<Continent> continentData = JsonConvert.DeserializeObject<List<Continent>>(json);

            return continentData;
        }
        #endregion

        #region GetByContinentAsync
        /// <summary>
        /// Get covid data from a specified continent.
        /// </summary>
        /// <param name="continent">The name of the continent.</param>
        /// <returns>Covid-19 data from the specified continent.</returns>
        public virtual async Task<Continent> GetByContinentAsync(string continent)
        {
            string json = await CallWebApiAsync($"{endpoint}/continents/{continent}?allowNull=false");

            Continent continentData = JsonConvert.DeserializeObject<Continent>(json);

            return continentData;
        }
        #endregion
    }
}