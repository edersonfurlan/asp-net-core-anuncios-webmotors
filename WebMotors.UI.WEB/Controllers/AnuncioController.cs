using WebMotors.UI.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebMotors.UI.WEB.Controllers
{
    public class AnuncioController : Controller
    {
        private readonly IAnuncioREP ianuncio;
        public AnuncioController(IAnuncioREP anuncio)
        {
            ianuncio = anuncio;
        }

        /// <summary>
        /// lista de anúncios
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            List<AnuncioMOD> listaAnuncios = new List<AnuncioMOD>();
            listaAnuncios = ianuncio.GetAllAnuncios().ToList();

            //recupera os nomes das apis
            foreach (var anuncio in listaAnuncios)
            {
                anuncio.marca_nome = ianuncio.GetMarcas().FirstOrDefault(x => x.ID == anuncio.marca).name;
                anuncio.modelo_nome = ianuncio.GetModelos(anuncio.marca).FirstOrDefault(x => x.ID == anuncio.modelo).name;

                //verifica a versão do veículo
                var versoes = ianuncio.GetVersoes(anuncio.modelo);
                if (versoes.Where(x => x.ID == anuncio.versao).Count() > 0)
                    anuncio.versao_nome = versoes.FirstOrDefault(x => x.ID == anuncio.versao).name;
            }

            return View(listaAnuncios);
        }

        /// <summary>
        /// detalhes de um anúncio
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Detalhes(int? id)
        {
            if (id == null)
                return NotFound();

            AnuncioMOD anuncio = ianuncio.GetAnuncio(id);
            anuncio.marca_nome = ianuncio.GetMarcas().FirstOrDefault(x => x.ID == anuncio.marca).name;
            anuncio.modelo_nome = ianuncio.GetModelos(anuncio.marca).FirstOrDefault(x => x.ID == anuncio.modelo).name;
            //verifica a versão do veículo
            var versoes = ianuncio.GetVersoes(anuncio.modelo);
            if (versoes.Where(x => x.ID == anuncio.versao).Count() > 0)
                anuncio.versao_nome = versoes.FirstOrDefault(x => x.ID == anuncio.versao).name;

            if (anuncio == null)
                return NotFound();

            return View(anuncio);
        }

        /// <summary>
        /// cadastrar um anúncio
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Cadastrar()
        {
            GetMarcas();
            GetModelos(0);
            GetVersoes(0);
            return View();
        }

        /// <summary>
        /// cadastra um anúncio
        /// </summary>
        /// <param name="anuncio"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar([Bind] AnuncioMOD anuncio)
        {
            if (ModelState.IsValid)
            {
                ianuncio.AddAnuncio(anuncio);
                return RedirectToAction("Index");
            }
            return View(anuncio);
        }

        /// <summary>
        /// edita um anúncio
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Editar(int? id)
        {
            if (id == null)
                return NotFound();

            AnuncioMOD anuncio = ianuncio.GetAnuncio(id);

            if (anuncio == null)
                return NotFound();

            GetMarcas();
            GetModelos(anuncio.marca);
            GetVersoes(anuncio.modelo);

            return View(anuncio);
        }

        /// <summary>
        /// edita um anúncio
        /// </summary>
        /// <param name="id"></param>
        /// <param name="anuncio"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, [Bind]AnuncioMOD anuncio)
        {
            if (id != anuncio.ID)
                return NotFound();

            if(ModelState.IsValid)
            {
                ianuncio.UpdateAnuncio(anuncio);
                return RedirectToAction("Index");
            }
            return View(anuncio);
        }

        /// <summary>
        /// exclui um anúncio
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null)
                return NotFound();

            AnuncioMOD anuncio = ianuncio.GetAnuncio(id);

            if (anuncio == null)
                return NotFound();

            return View(anuncio);
        }

        /// <summary>
        /// confirma exclusão
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirConfirmar(int? id)
        {
            ianuncio.DeleteAnuncio(id);
            return RedirectToAction("Index");
        }

        //métodos da API

        /// <summary>
        /// Carregar as marcas
        /// </summary>
        public void GetMarcas()
        {
            ViewBag.Marcas = new SelectList(ianuncio.GetMarcas().Select(m => new SelectListItem
            {
                Text = m.name,
                Value = m.ID.ToString()

            }), "Value", "Text");
        }

        /// <summary>
        /// Carregar os modelos de acordo com a marca
        /// </summary>
        /// <param name="marca"></param>
        public void GetModelos(int marca)
        {
            ViewBag.Modelos = new SelectList(ianuncio.GetModelos(marca).Select(m => new SelectListItem
            {
                Text = m.name,
                Value = m.ID.ToString()

            }), "Value", "Text");
        }

        /// <summary>
        /// Carregar os modelos de acordo com a marca e retorna um JSON
        /// </summary>
        /// <param name="marca"></param>
        /// <returns></returns>
        public JsonResult GetModelosPorMarcaJSON(int marca)
        {
            var ListaModelos = ianuncio.GetModelos(marca);
            return Json(ListaModelos);
        }

        /// <summary>
        /// Carregar as versoes de acordo com o modelo
        /// </summary>
        /// <param name="marca"></param>
        public void GetVersoes(int modelo)
        {
            ViewBag.Versoes = new SelectList(ianuncio.GetVersoes(modelo).Select(m => new SelectListItem
            {
                Text = m.name,
                Value = m.ID.ToString()

            }), "Value", "Text");
        }

        /// <summary>
        /// Carregar as versões de acordo com o modelo e retorna um JSON
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        public JsonResult GetVersoesPorModeloJSON(int modelo)
        {
            var ListaVersoes = ianuncio.GetVersoes(modelo);
            return Json(ListaVersoes);
        }

        /*
        http://desafioonline.webmotors.com.br/api/OnlineChallenge/Make
        http://desafioonline.webmotors.com.br/api/OnlineChallenge/Model?MakeID=1
        http://desafioonline.webmotors.com.br/api/OnlineChallenge/Version?ModelID=1
        http://desafioonline.webmotors.com.br/api/OnlineChallenge/Vehicles?Page=1
        */
    }
}