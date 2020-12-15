using CovidDiscordBot.Entities;
using CovidDiscordBot.WebServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CovidDiscordBot.XUnitTests
{
    public class CovidServiceTests
    {
        #region GetGlobalAsync
        [Fact]
        public virtual async Task TestGetGlobalAsync()
        {
            // Arrange
            CovidService service;
            Global globalData;

            // Act
            service = new();
            globalData = await service.GetGlobalAsync();

            // Assert
            Assert.NotNull(globalData);
        }
        #endregion

        #region GetGlobalYesterdayAsync
        [Fact]
        public virtual async Task TestGetGlobalYesterdayAsync()
        {
            // Arrange
            CovidService service;
            Global globalData;

            // Act
            service = new();
            globalData = await service.GetGlobalYesterdayAsync();

            // Assert
            Assert.NotNull(globalData);
        }
        #endregion

        #region GetGlobalTwoDaysAsync
        [Fact]
        public virtual async Task TestGetGlobalTwoDaysAsync()
        {
            // Arrange
            CovidService service;
            Global globalData;

            // Act
            service = new();
            globalData = await service.GetGlobalTwoDaysAsync();

            // Assert
            Assert.NotNull(globalData);
        }
        #endregion

        #region GetAllCountriesAsync
        [Fact]
        public virtual async Task TestGetAllCountriesAsync()
        {
            // Arrange
            CovidService service;
            IEnumerable<Country> countryData;

            // Act
            service = new();
            countryData = await service.GetAllCountriesAsync();

            // Assert
            Assert.NotNull(countryData);
        }
        #endregion

        #region GetByCountryAsync
        [Fact]
        public virtual async Task TestGetByCountryAsync()
        {
            // Arrange
            CovidService service;
            Country countryData;

            // Act
            service = new();
            countryData = await service.GetByCountryAsync("Denmark");

            // Assert
            Assert.NotNull(countryData);
        }
        #endregion

        #region GetByCountryYesterdayAsync
        [Fact]
        public virtual async Task TestGetByCountryYesterdayAsync()
        {
            // Arrange
            CovidService service;
            Country countryData;

            // Act
            service = new();
            countryData = await service.GetByCountryYesterdayAsync("Denmark");

            // Assert
            Assert.NotNull(countryData);
        }
        #endregion

        #region GetByCountryTwoDaysAsync
        [Fact]
        public virtual async Task TestGetByCountryTwoDaysAsync()
        {
            // Arrange
            CovidService service;
            Country countryData;

            // Act
            service = new();
            countryData = await service.GetByCountryTwoDaysAsync("Denmark");

            // Assert
            Assert.NotNull(countryData);
        }
        #endregion

        #region GetAllStatesAsync
        [Fact]
        public virtual async Task TestGetAllStatesAsync()
        {
            // Arrange
            CovidService service;
            IEnumerable<State> stateData;

            // Act
            service = new();
            stateData = await service.GetAllStatesAsync();

            // Assert
            Assert.NotNull(stateData);
        }
        #endregion

        #region GetByStateAsync
        [Fact]
        public virtual async Task TestGetByStateAsync()
        {
            // Arrange
            CovidService service;
            State stateData;

            // Act
            service = new();
            stateData = await service.GetByStateAsync("Alaska");

            // Assert
            Assert.NotNull(stateData);
        }
        #endregion

        #region GetByStateYesterdayAsync
        [Fact]
        public virtual async Task TestGetByStateYesterdayAsync()
        {
            // Arrange
            CovidService service;
            State stateData;

            // Act
            service = new();
            stateData = await service.GetByStateYesterdayAsync("Alaska");

            // Assert
            Assert.NotNull(stateData);
        }
        #endregion

        #region GetAllContinentsAsync
        [Fact]
        public virtual async Task TestGetAllContinentsAsync()
        {
            // Arrange
            CovidService service;
            IEnumerable<Continent> continentData;

            // Act
            service = new();
            continentData = await service.GetAllContinentsAsync();

            // Assert
            Assert.NotNull(continentData);
        }
        #endregion

        #region GetByContinentAsync
        [Fact]
        public virtual async Task TestGetByContinentAsync()
        {
            // Arrange
            CovidService service;
            Continent continentData;

            // Act
            service = new();
            continentData = await service.GetByContinentAsync("Europe");

            // Assert
            Assert.NotNull(continentData);
        }
        #endregion

        #region GetByContinentYesterdayAsync
        [Fact]
        public virtual async Task TestGetByContinentYesterdayAsync()
        {
            // Arrange
            CovidService service;
            Continent continentData;

            // Act
            service = new();
            continentData = await service.GetByContinentYesterdayAsync("Europe");

            // Assert
            Assert.NotNull(continentData);
        }
        #endregion

        #region GetByContinentTwoDaysAsync
        [Fact]
        public virtual async Task TestGetByContinentTwoDaysAsync()
        {
            // Arrange
            CovidService service;
            Continent continentData;

            // Act
            service = new();
            continentData = await service.GetByContinentTwoDaysAsync("Europe");

            // Assert
            Assert.NotNull(continentData);
        }
        #endregion
    }
}