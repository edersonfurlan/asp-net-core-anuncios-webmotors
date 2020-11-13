using System.Collections.Generic;
using WebMotors.Model;

namespace WebMotors.Repository
{
    interface IAnuncioREP
    {
        IEnumerable<AnuncioMOD> GetAllAnuncios();
        AnuncioMOD GetAnuncio(int id);
        void AddAnuncio(AnuncioMOD Anuncio);
        void UpdateAnuncio(AnuncioMOD Anuncio);
        void DeleteAnuncio(int id);        
    }
}
