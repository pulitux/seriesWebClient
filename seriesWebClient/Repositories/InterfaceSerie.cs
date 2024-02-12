using seriesWebClient.Models;

namespace seriesWebClient.Repositories
{
        public interface InterfaceSerie
    {
        Task<List<Serie>> GetSeries();
        Task<Serie?> BuscarSerie(int idserie);
        Task<Serie?> InsertarSerie(int idserie, string nombre, string imagen, int puntuacion, int anyo);
        Task<Serie?> ModificarSerie(int idserie, string nombre, string imagen, int puntuacion, int anyo);
        Task EliminarSerie(int idserie);
    }
}

