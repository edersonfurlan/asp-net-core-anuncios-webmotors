using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using MySql.Data.MySqlClient;

namespace WebMotors.UI.WEB.Models
{
    public sealed class AnuncioREP : IAnuncioREP
    {
        //recuperamos a ConnectionString
        string connectionString = new PathStringsMOD().ConnectionString();

        /// <summary>
        /// recupera todos os anúncios
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AnuncioMOD> GetAllAnuncios()
        {
            List<AnuncioMOD> listaAnuncios = new List<AnuncioMOD>();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT ID, marca, modelo, versao, ano, quilometragem, observacao from anuncios", con);
                cmd.CommandType = CommandType.Text;                
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        AnuncioMOD anuncio = new AnuncioMOD();

                        if (!rdr.IsDBNull(0))
                            anuncio.ID = Convert.ToInt32(rdr["ID"]);

                        if (!rdr.IsDBNull(1))
                            anuncio.marca = Convert.ToInt32(rdr["marca"]);

                        if (!rdr.IsDBNull(2))
                            anuncio.modelo = Convert.ToInt32(rdr["modelo"]);

                        if (!rdr.IsDBNull(3))
                            anuncio.versao = Convert.ToInt32(rdr["versao"]);

                        if (!rdr.IsDBNull(4))
                            anuncio.ano = Convert.ToInt32(rdr["ano"]);

                        if (!rdr.IsDBNull(5))
                            anuncio.quilometragem = Convert.ToInt32(rdr["quilometragem"]);

                        if (!rdr.IsDBNull(6))
                            anuncio.observacao = rdr["observacao"].ToString();

                        listaAnuncios.Add(anuncio);
                    }
                    con.Close();
                }
                return listaAnuncios;
            }
        }

        /// <summary>
        /// adiciona um anúncio
        /// </summary>
        /// <param name="anuncio"></param>
        public void AddAnuncio(AnuncioMOD anuncio)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string comandoSQL = @"Insert into anuncios(marca, modelo, versao, ano, quilometragem, observacao) 
                                      values (?marca, ?modelo, ?versao, ?ano, ?quilometragem, ?observacao)";
                MySqlCommand cmd = new MySqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("?marca", anuncio.marca);
                cmd.Parameters.AddWithValue("?modelo", anuncio.modelo);
                cmd.Parameters.AddWithValue("?versao", anuncio.versao);
                cmd.Parameters.AddWithValue("?ano", anuncio.ano);
                cmd.Parameters.AddWithValue("?quilometragem", anuncio.quilometragem);
                cmd.Parameters.AddWithValue("?observacao", anuncio.observacao);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        /// <summary>
        /// atualiza um anúncio
        /// </summary>
        /// <param name="anuncio"></param>
        public void UpdateAnuncio(AnuncioMOD anuncio)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string comandoSQL = @"Update anuncios set marca = ?marca, 
                                                          modelo = ?modelo, 
                                                          versao = ?versao, 
                                                          ano = ?ano, 
                                                          quilometragem = ?quilometragem, 
                                                          observacao = ?observacao
                                                          where ID = ?id";
                MySqlCommand cmd = new MySqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("?marca", anuncio.marca);
                cmd.Parameters.AddWithValue("?modelo", anuncio.modelo);
                cmd.Parameters.AddWithValue("?versao", anuncio.versao);
                cmd.Parameters.AddWithValue("?ano", anuncio.ano);
                cmd.Parameters.AddWithValue("?quilometragem", anuncio.quilometragem);
                cmd.Parameters.AddWithValue("?observacao", anuncio.observacao);
                cmd.Parameters.AddWithValue("?id", anuncio.ID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        /// <summary>
        /// recupera um anúncio
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AnuncioMOD GetAnuncio(int? id)
        {
            AnuncioMOD anuncio = new AnuncioMOD();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string comandoSQL = "SELECT ID, marca, modelo, versao, ano, quilometragem, observacao from anuncios where ID = " + id;
                MySqlCommand cmd = new MySqlCommand(comandoSQL, con);

                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    rdr.Read();
                    
                    if (!rdr.IsDBNull(0))
                        anuncio.ID = Convert.ToInt32(rdr["ID"]);

                    if (!rdr.IsDBNull(1))
                        anuncio.marca = Convert.ToInt32(rdr["marca"]);

                    if (!rdr.IsDBNull(2))
                        anuncio.modelo = Convert.ToInt32(rdr["modelo"]);

                    if (!rdr.IsDBNull(3))
                        anuncio.versao = Convert.ToInt32(rdr["versao"]);

                    if (!rdr.IsDBNull(4))
                        anuncio.ano = Convert.ToInt32(rdr["ano"]);

                    if (!rdr.IsDBNull(5))
                        anuncio.quilometragem = Convert.ToInt32(rdr["quilometragem"]);

                    if (!rdr.IsDBNull(6))
                        anuncio.observacao = rdr["observacao"].ToString();

                    con.Close();
                }
            }
            return anuncio;
        }

        /// <summary>
        /// apaga um anúncio
        /// </summary>
        /// <param name="id"></param>
        public void DeleteAnuncio(int? id)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string comandoSQL = "Delete from anuncios where ID = ?codigo";
                MySqlCommand cmd = new MySqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("?codigo", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //CONSUMINDO A API DA WEBMOTORS

        /// <summary>
        /// recupera as marcas da API
        /// </summary>
        /// <returns></returns>
        public List<MarcaMOD> GetMarcas()
        {
            List<MarcaMOD> listaMarcas = new List<MarcaMOD>();
            string url = new PathStringsMOD().PathAPIMake();

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                    listaMarcas = response.Content.ReadAsAsync<List<MarcaMOD>>().Result;
            }
            return listaMarcas;
        }

        /// <summary>
        /// recupera os modelos da API
        /// </summary>
        /// <param name="marca"></param>
        /// <returns></returns>
        public List<ModeloMOD> GetModelos(int marca)
        {
            List<ModeloMOD> listaModelos = new List<ModeloMOD>();
            string url = String.Format("{0}{1}", new PathStringsMOD().PathAPIModel(), marca);

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                    listaModelos = response.Content.ReadAsAsync<List<ModeloMOD>>().Result;
            }
            return listaModelos;
        }

        /// <summary>
        /// recupera as versões da API
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        public List<VersaoMOD> GetVersoes(int modelo)
        {
            List<VersaoMOD> listaVersoes = new List<VersaoMOD>();
            string url = String.Format("{0}{1}", new PathStringsMOD().PathAPIVersion(), modelo);

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                    listaVersoes = response.Content.ReadAsAsync<List<VersaoMOD>>().Result;
            }
            return listaVersoes;
        }
    }
}
