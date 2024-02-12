using Newtonsoft.Json;

namespace seriesWebClient.Models
{
    public class Serie
    {
        [JsonProperty("idSerie")]
        public int IdSerie { get; set; }

        [JsonProperty("nombre")]
        public string? Nombre { get; set; }

        [JsonProperty("imagen")]
        public string? Imagen { get; set; }

        [JsonProperty("puntuacion")]
        public int Puntuacion { get; set; }
        
        [JsonProperty("anyo")]
        public int Anyo { get; set; }
    }
}
