using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace seriesWebClient.Models
{
    public class Personaje
    {
        [JsonProperty("idPersonaje")]
        public int IdPersonaje { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("imagen")]
        public string Imagen { get; set; }

        [JsonProperty("idSerie")]
        public int IdSerie { get; set; }
    }
}
