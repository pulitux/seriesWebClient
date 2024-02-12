using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using seriesWebClient.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace seriesWebClient.Repositories
{
    public class RepositorySerie : InterfaceSerie
    {
        private string uriapi;
        private MediaTypeWithQualityHeaderValue headerjson;
        public RepositorySerie()
        {
            this.uriapi = "https://apiseriespersonajes.azurewebsites.net/";
            this.headerjson = new
                MediaTypeWithQualityHeaderValue("application/json");
        }
        public async Task<List<Serie>> GetSeries()
        {
            using (HttpClient client = new HttpClient())
            {
                string peticion = "api/Series";
                client.BaseAddress = new Uri(this.uriapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerjson);
                HttpResponseMessage response = await client.GetAsync(peticion);
                if (response.IsSuccessStatusCode)
                {
                    List<Serie> series =
                    await response.Content.ReadAsAsync<List<Serie>>();
                    return series;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<Serie?> BuscarSerie(int idserie)
        {
            using (HttpClient client = new HttpClient())
            {
                string peticion = "api/Series/" + idserie;
                client.BaseAddress = new Uri(this.uriapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerjson);
                HttpResponseMessage response = await
                    client.GetAsync(peticion);
                if (response.IsSuccessStatusCode)
                {
                    Serie serie = await response.Content.ReadAsAsync<Serie>();
                    return serie;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Serie?> InsertarSerie(int idserie, string nombre, string imagen, int puntuacion, int anyo)
        {
            using (HttpClient cliente = new HttpClient())
            {
                string peticion = "api/Series/";
                cliente.BaseAddress = new Uri(this.uriapi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Serie serie = new Serie();
                serie.IdSerie = idserie;
                serie.Nombre = nombre;
                serie.Imagen = imagen;
                serie.Puntuacion = puntuacion;
                serie.Anyo = anyo;
                string json = JsonConvert.SerializeObject(serie);
                StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await cliente.PostAsync(peticion, content);
                if (response.IsSuccessStatusCode)
                {
                    //serie = await response.Content.ReadAsAsync<Serie>();
                    return serie;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Serie?> ModificarSerie(int idserie, string nombre, string imagen, int puntuacion, int anyo)
        {
            using (HttpClient cliente = new HttpClient())
            {
                string peticion = "api/Series/";
                cliente.BaseAddress = new Uri(this.uriapi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Serie serie = new Serie();
                serie.IdSerie = idserie;
                serie.Nombre = nombre;
                serie.Imagen = imagen;
                serie.Puntuacion = puntuacion;
                serie.Anyo = anyo;
                string json = JsonConvert.SerializeObject(serie);
                StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await cliente.PutAsync(peticion, content);
                if (response.IsSuccessStatusCode)
                {
                    serie = await response.Content.ReadAsAsync<Serie>();
                    return serie;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task EliminarSerie(int idserie)
        {
            using (HttpClient cliente = new HttpClient())
            {
                string peticion = "api/Series/" + idserie;
                cliente.BaseAddress = new Uri(this.uriapi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response =
                    await cliente.DeleteAsync(peticion);
                //if (response.IsSuccessStatusCode)
                //{
                //    //return 0;
                //}
                //else
                //{
                //    return null;
                //}
            }
        }

    }
}

