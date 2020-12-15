using Newtonsoft.Json;

namespace CovidDiscordBot.Entities
{
    /// <summary>
    /// Represents a US state containing covid-19 data.
    /// </summary>
    public class State
    {
        [JsonProperty("state")]
        public virtual string Name { get; set; }

        public virtual double Updated { get; set; }

        public virtual double Cases { get; set; }

        public virtual double TodayCases { get; set; }

        public virtual double Deaths { get; set; }

        public virtual double TodayDeaths { get; set; }

        public virtual double Recovered { get; set; }

        public virtual double Active { get; set; }

        public virtual double CasesPerOneMillion { get; set; }

        public virtual double DeathsPerOneMillion { get; set; }

        public virtual double Tests { get; set; }

        public virtual double TestsPerOneMillion { get; set; }

        public virtual double Population { get; set; }
    }
}