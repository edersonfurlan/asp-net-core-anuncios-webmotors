using System;
using System.Configuration;

namespace WebMotors.Data
{
    public sealed class AnuncioBD
    {
        public string connectMySQL()
        {
            // Retorna a string de conexão com o MySQL
            string conexao = ConfigurationManager.ConnectionStrings["conectaMySQL"].ToString();
            return conexao;
        }
    }
}
