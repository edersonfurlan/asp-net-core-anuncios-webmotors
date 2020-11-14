using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebMotors.UI.WEB.Models
{
    public sealed class PathStringsMOD
    {
        /// <summary>
        /// Retorna a ConnectionString do arquivo appsettings.json
        /// </summary>
        /// <returns></returns>
        public string ConnectionString()
        {
            var configurationBuilder = new ConfigurationBuilder();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            string conStr = configurationBuilder.Build().GetSection("ConnectionStrings:DefaultConnection").Value;
            return conStr;
        }

        /// <summary>
        /// Retorna o caminho do método marcas
        /// </summary>
        /// <returns></returns>
        public string PathAPIMake()
        {
            var configurationBuilder = new ConfigurationBuilder();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            string PathStr = configurationBuilder.Build().GetSection("PathApis:Make").Value;
            return PathStr;
        }

        /// <summary>
        /// Retorna o caminho do método modelo
        /// </summary>
        /// <returns></returns>
        public string PathAPIModel()
        {
            var configurationBuilder = new ConfigurationBuilder();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            string PathStr = configurationBuilder.Build().GetSection("PathApis:Model").Value;
            return PathStr;
        }

        /// <summary>
        /// Retorna o caminho do método versões
        /// </summary>
        /// <returns></returns>
        public string PathAPIVersion()
        {
            var configurationBuilder = new ConfigurationBuilder();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            string PathStr = configurationBuilder.Build().GetSection("PathApis:Version").Value;
            return PathStr;
        }
    }
}
