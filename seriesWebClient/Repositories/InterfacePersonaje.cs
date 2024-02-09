using seriesWebClient.Models;
using seriesWebClient.Repositories;
using System.Numerics;

namespace seriesWebClient.Repositories
{
    public interface InterfacePersonaje
    {
        Task<List<Personaje>> GetPersonajes();
        Task<Personaje?> BuscarPersonaje(int idpersonaje);
        Task<Personaje?> InsertarPersonaje(int idpersonaje, string nombre, string imagen, int idserie );
        Task<Personaje?> ModificarPersonaje(int idpersonaje, string nombre, string imagen, int idserie );
        Task EliminarPersonaje(int idpersonaje);
    }
}
