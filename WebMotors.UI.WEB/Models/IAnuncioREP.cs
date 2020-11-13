using System.Collections.Generic;

namespace WebMotors.UI.WEB.Models
{
    public interface IAnuncioREP
    {
        IEnumerable<AnuncioMOD> GetAllAnuncios();
        AnuncioMOD GetAnuncio(int? id);
        void AddAnuncio(AnuncioMOD Anuncio);
        void UpdateAnuncio(AnuncioMOD Anuncio);
        void DeleteAnuncio(int? id);
        List<MarcaMOD> GetMarcas();
        List<ModeloMOD> GetModelos(int marca);
        List<VersaoMOD> GetVersoes(int modelo);
    }
}
