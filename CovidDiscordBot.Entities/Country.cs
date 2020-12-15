using Newtonsoft.Json;

namespace CovidDiscordBot.Entities
{
    /// <summary>
    /// Represents a country containing covid-19 data.
    /// </summary>
    public class Country
    {
        public virtual double Updated { get; set; }

        [JsonProperty("country")]
        public virtual string Name { get; set; }

        public virtual CountryInfo CountryInfo { get; set; }

        public virtual double Cases { get; set; }

        public virtual double TodayCases { get; set; }

        public virtual double Deaths { get; set; }

        public virtual double TodayDeaths { get; set; }

        public virtual double Recovered { get; set; }

        public virtual double TodayRecovered { get; set; }

        public virtual double Active { get; set; }

        public virtual double Critical { get; set; }

        public virtual double CasesPerOneMillion { get; set; }

        public virtual double DeathsPerOneMillion { get; set; }

        public virtual double Tests { get; set; }

        public virtual double TestsPerOneMillion { get; set; }

        public virtual double Population { get; set; }

        public virtual string Continent { get; set; }

        public virtual double OneCasePerPeople { get; set; }

        public virtual double OneDeathPerPeople { get; set; }

        public virtual double OneTestPerPeople { get; set; }

        public virtual double ActivePerOneMillion { get; set; }

        public virtual double RecoveredPerOneMillion { get; set; }

        public virtual double CriticalPerOneMillion { get; set; }
    }
}