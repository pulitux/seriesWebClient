using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using seriesWebClient.Models;
using seriesWebClient.Repositories;
using System.Numerics;

namespace seriesWebClient.Controllers
{
    public class SeriesController : Controller
    {
        InterfaceSerie repo;

        public SeriesController(InterfaceSerie repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Serie> series = await this.repo.GetSeries();
            return View(series);
        }

        public async Task<IActionResult> DetallesSerie(int idserie)
        {
            Serie? serie = await this.repo.BuscarSerie(idserie);
            return View(serie);
        }

        [HttpPost]
        public async Task<IActionResult> InsertarSerie(int idserie, string nombre, string imagen, int puntuacion, int anyo)
        {
            RepositorySerie repo = new RepositorySerie();
            await repo.InsertarSerie(idserie, nombre, imagen, puntuacion, anyo);
            return RedirectToAction("DetallesSerie", "Series", new { idserie });
        }
        public async Task<IActionResult> InsSerie()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditarSerie(int idserie, string nombre, string imagen, int puntuacion, int anyo)
        {
            //RepositorySerie repo = new RepositorySerie();
            await repo.ModificarSerie(idserie, nombre, imagen, puntuacion, anyo);
            return RedirectToAction("DetallesSerie", "Series", new { idserie });
        }
        public async Task<IActionResult> ModSerie(int idserie)
        {
            Serie? serie = await repo.BuscarSerie(idserie);
            return View(serie);
        }

        [HttpPost]
        public async Task<IActionResult> BorrarSerie(int idserie)
        {
            await this.repo.BuscarSerie(idserie);
            return RedirectToAction("Index", "Series");
        }
        public async Task<IActionResult> DelSerie(int idserie)
        {
            await repo.EliminarSerie(idserie);
            return RedirectToAction("Index", "Series");
        }
    }
}