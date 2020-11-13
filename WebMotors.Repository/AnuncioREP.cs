using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebMotors.Model;

namespace WebMotors.Repository
{
    public sealed class AnuncioREP : IAnuncioREP
    {
        string connectionString = @"Data Source=localhost;Initial Catalog=teste_webmotors;Integrated Security=True;";

        public IEnumerable<AnuncioMOD> GetAllAnuncios()
        {
            List<AnuncioMOD> lstAnuncios = new List<AnuncioMOD>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

            }
        }
    }
}
