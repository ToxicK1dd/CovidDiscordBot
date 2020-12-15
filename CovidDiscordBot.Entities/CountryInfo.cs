using Newtonsoft.Json;

namespace CovidDiscordBot.Entities
{
    /// <summary>
    /// Contains ekstra information about a <see cref="Country"/>
    /// </summary>
    public class CountryInfo
    {
        public virtual int Id { get; set; }

        public virtual string Iso2 { get; set; }

        public virtual string Iso3 { get; set; }

        [JsonProperty("lat")]
        public virtual double Latitude { get; set; }

        [JsonProperty("long")]
        public virtual double Longitude { get; set; }

        public virtual string Flag { get; set; }
    }
}