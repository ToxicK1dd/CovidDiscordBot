﻿using CovidDiscordBot.Entities;
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
        protected const string endpoint = "https://disease.sh/v3/covid-19";
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

        #region GetGlobalYesterdaysAsync
        /// <summary>
        /// Get global covid data from yesterday.
        /// </summary>
        /// <returns>Global covid-19 data.</returns>
        public virtual async Task<Global> GetGlobalYesterdayAsync()
        {
            string json = await CallWebApiAsync($"{endpoint}/all?yesterday=true&allowNull=false");

            Global globalData = JsonConvert.DeserializeObject<Global>(json);

            return globalData;
        }
        #endregion

        #region GetGlobalTwoDaysAsync
        /// <summary>
        /// Get global covid data from two days ago.
        /// </summary>
        /// <returns>Global covid-19 data.</returns>
        public virtual async Task<Global> GetGlobalTwoDaysAsync()
        {
            string json = await CallWebApiAsync($"{endpoint}/all?twoDaysAgo=true&allowNull=false");

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
            string json = await CallWebApiAsync($"{endpoint}/countries/{countryName}?strict=false&allowNull=false");

            Country countryData = JsonConvert.DeserializeObject<Country>(json);

            return countryData;
        }
        #endregion

        #region GetByCountryYesterdayAsync
        /// <summary>
        /// Get available covid data from yesterday from a specified country.
        /// </summary>
        /// <param name="countryName">The name of the country</param>
        /// <returns>Covid-19 data from the specified country.</returns>
        public virtual async Task<Country> GetByCountryYesterdayAsync(string countryName)
        {
            string json = await CallWebApiAsync($"{endpoint}/countries/{countryName}?yesterday=true&strict=false&allowNull=false");

            Country countryData = JsonConvert.DeserializeObject<Country>(json);

            return countryData;
        }
        #endregion

        #region GetByCountryTwoDaysAsync
        /// <summary>
        /// Get available covid data from two days ago from a specified country.
        /// </summary>
        /// <param name="countryName">The name of the country</param>
        /// <returns>Covid-19 data from the specified country.</returns>
        public virtual async Task<Country> GetByCountryTwoDaysAsync(string countryName)
        {
            string json = await CallWebApiAsync($"{endpoint}/countries/{countryName}?twoDaysAgo=true&strict=false&allowNull=false");

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

        #region GetByStateYesterdayAsync
        /// <summary>
        /// Get available covid data from a specified US state from yesterday.
        /// </summary>
        /// <param name="stateName">The name of the US state.</param>
        /// <returns>Covid-19 data from the specified US state.</returns>
        public virtual async Task<State> GetByStateYesterdayAsync(string stateName)
        {
            string json = await CallWebApiAsync($"{endpoint}/states/{stateName}?yesterday=true&allowNull=false");

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

        #region GetByContinentYesterdayAsync
        /// <summary>
        /// Get covid data from a specified continent from yesterday.
        /// </summary>
        /// <param name="continent">The name of the continent.</param>
        /// <returns>Covid-19 data from the specified continent.</returns>
        public virtual async Task<Continent> GetByContinentYesterdayAsync(string continent)
        {
            string json = await CallWebApiAsync($"{endpoint}/continents/{continent}?yesterday=true&allowNull=false");

            Continent continentData = JsonConvert.DeserializeObject<Continent>(json);

            return continentData;
        }
        #endregion

        #region GetByContinentTwoDaysAsync
        /// <summary>
        /// Get covid data from a specified continent from two days ago.
        /// </summary>
        /// <param name="continent">The name of the continent.</param>
        /// <returns>Covid-19 data from the specified continent.</returns>
        public virtual async Task<Continent> GetByContinentTwoDaysAsync(string continent)
        {
            string json = await CallWebApiAsync($"{endpoint}/continents/{continent}?twoDaysAgo=true&allowNull=false");

            Continent continentData = JsonConvert.DeserializeObject<Continent>(json);

            return continentData;
        }
        #endregion
    }
}