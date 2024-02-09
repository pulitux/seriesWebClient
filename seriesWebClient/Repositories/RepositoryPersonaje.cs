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
    public class RepositoryPersonaje : InterfacePersonaje
    {
        private string uriapi;
        private MediaTypeWithQualityHeaderValue headerjson;
        public RepositoryPersonaje()
        {
            this.uriapi = "https://apiseriespersonajes.azurewebsites.net/";
            this.headerjson = new
                MediaTypeWithQualityHeaderValue("application/json");
        }
        public async Task<List<Personaje>> GetPersonajes()
        {
            using (HttpClient client = new HttpClient())
            {
                string peticion = "api/Personajes";
                client.BaseAddress = new Uri(this.uriapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerjson);
                HttpResponseMessage response = await client.GetAsync(peticion);
                if (response.IsSuccessStatusCode)
                {
                    List<Personaje> personajes =
                    await response.Content.ReadAsAsync<List<Personaje>>();
                    return personajes;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<Personaje?> BuscarPersonaje(int idpersonaje)
        {
            using (HttpClient client = new HttpClient())
            {
                string peticion = "api/Personajes/" + idpersonaje;
                client.BaseAddress = new Uri(this.uriapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerjson);
                HttpResponseMessage response = await
                    client.GetAsync(peticion);
                if (response.IsSuccessStatusCode)
                {
                    Personaje personaje = await response.Content.ReadAsAsync<Personaje>();
                    return personaje;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Personaje?> InsertarPersonaje(int idpersonaje, string nombre, string imagen, int idserie)
        {
            using (HttpClient cliente = new HttpClient())
            {
                string peticion = "api/Personjes/";
                cliente.BaseAddress = new Uri(this.uriapi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Personaje personaje = new Personaje();
                personaje.IdPersonaje = idpersonaje;
                personaje.Nombre = nombre;
                personaje.Imagen = imagen;
                personaje.IdSerie = idserie;
                string json = JsonConvert.SerializeObject(personaje);
                StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await cliente.PostAsync(peticion, content);
                if (response.IsSuccessStatusCode)
                {
                    personaje = await response.Content.ReadAsAsync<Personaje>();
                    return personaje;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Personaje?> ModificarPersonaje(int idpersonaje, string nombre, string imagen, int idserie)
        {
            using (HttpClient cliente = new HttpClient())
            {
                string peticion = "api/Personajes/";
                cliente.BaseAddress = new Uri(this.uriapi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Personaje personaje = new Personaje();
                personaje.IdPersonaje = idpersonaje;
                personaje.Nombre = nombre;
                personaje.Imagen = imagen;
                personaje.IdSerie = idserie;
                string json = JsonConvert.SerializeObject(personaje);
                StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await cliente.PutAsync(peticion, content);
                if (response.IsSuccessStatusCode)
                {
                    personaje = await response.Content.ReadAsAsync<Personaje>();
                    return personaje;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task EliminarPersonaje(int idpersonaje)
        {
            using (HttpClient cliente = new HttpClient())
            {
                string peticion = "api/Doctores/" + idpersonaje;
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
