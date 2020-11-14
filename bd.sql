-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           10.4.13-MariaDB - mariadb.org binary distribution
-- OS do Servidor:               Win64
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Copiando estrutura do banco de dados para teste_webmotors
CREATE DATABASE IF NOT EXISTS `teste_webmotors` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `teste_webmotors`;

-- Copiando estrutura para tabela teste_webmotors.anuncios
CREATE TABLE IF NOT EXISTS `anuncios` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `marca` int(11) NOT NULL DEFAULT 0,
  `modelo` int(11) NOT NULL DEFAULT 0,
  `versao` int(11) NOT NULL DEFAULT 0,
  `ano` int(11) NOT NULL,
  `quilometragem` int(11) NOT NULL,
  `observacao` mediumtext NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4;

-- Copiando dados para a tabela teste_webmotors.anuncios: ~4 rows (aproximadamente)
/*!40000 ALTER TABLE `anuncios` DISABLE KEYS */;
INSERT INTO `anuncios` (`ID`, `marca`, `modelo`, `versao`, `ano`, `quilometragem`, `observacao`) VALUES
	(10, 1, 2, 12, 2010, 10000, 'carro perfeito'),
	(11, 3, 7, 36, 2000, 1500, 'carro super confortável'),
	(12, 2, 5, 27, 2018, 1000, 'excelente SUV'),
	(16, 3, 8, 41, 2005, 1000, 'bom carro'),
	(19, 1, 2, 11, 2020, 1000, 'bom carro');
/*!40000 ALTER TABLE `anuncios` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
