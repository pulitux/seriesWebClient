using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using seriesWebClient.Models;
using seriesWebClient.Repositories;
using System.Numerics;

namespace seriesWebClient.Controllers
{
    public class PersonajesController : Controller
    {
        InterfacePersonaje repo ;

        public PersonajesController(InterfacePersonaje repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Personaje> personajes = await this.repo.GetPersonajes();
            return View(personajes);
        }

        public async Task<IActionResult> DetallesPersonaje(int idpersonaje)
        {
            Personaje? personaje = await this.repo.BuscarPersonaje(idpersonaje);
            return View(personaje);
        }

        [HttpPost]
        public async Task<IActionResult> InsertarPersonaje(int IdPersonaje, string Nombre, string Imagen, int IdSerie)
        {
            RepositoryPersonaje repo = new RepositoryPersonaje();
            await repo.InsertarPersonaje(IdPersonaje, Nombre, Imagen, IdSerie);
            return RedirectToAction("DetallesPersonaje", "Personajes", new { IdPersonaje });
        }
        public async Task<IActionResult> InsPersonaje()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditarPersonaje(int IdPersonaje, string Nombre, string Imagen, int IdSerie)
        {
            //RepositoryPersonaje repo = new RepositoryPersonaje();
            await repo.ModificarPersonaje(IdPersonaje, Nombre, Imagen, IdSerie);
            return RedirectToAction("DetallesPersonaje", "Personajes", new { IdPersonaje });
        }
        public async Task<IActionResult> ModPersonaje(int idpersonaje)
        {
            Personaje? personaje = await repo.BuscarPersonaje(idpersonaje);
            return View(personaje);
        }

        [HttpPost]
        public async Task<IActionResult> BorrarPersonaje(int idpersonaje)
        {
            await this.repo.BuscarPersonaje(idpersonaje);
            return RedirectToAction("Index", "Personajes");
        }
    }
}
