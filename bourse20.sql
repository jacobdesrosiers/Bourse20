-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  mer. 16 sep. 2020 à 20:55
-- Version du serveur :  5.7.26
-- Version de PHP :  7.3.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `bourse20`
--

DELIMITER $$
--
-- Procédures
--
DROP PROCEDURE IF EXISTS `gap`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `gap` ()  BEGIN
	SELECT * FROM proprietaires;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `proprietaires`
--

DROP TABLE IF EXISTS `proprietaires`;
CREATE TABLE IF NOT EXISTS `proprietaires` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(25) NOT NULL,
  `naissance` datetime NOT NULL,
  `liquidite` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `proprietaires`
--

INSERT INTO `proprietaires` (`ID`, `nom`, `naissance`, `liquidite`) VALUES
(6, 'Vincent', '1998-07-28 00:00:00', 18000),
(8, 'Vincent', '1998-07-28 00:00:00', 18000),
(7, 'Joe Blo', '1908-01-28 00:00:00', 180000),
(9, 'Joe Blo', '1908-01-28 00:00:00', 180000);

-- --------------------------------------------------------

--
-- Structure de la table `societes`
--

DROP TABLE IF EXISTS `societes`;
CREATE TABLE IF NOT EXISTS `societes` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `raisonSociale` varchar(50) NOT NULL,
  `nbActions` int(11) NOT NULL,
  `valeurUnitaire` int(11) NOT NULL,
  `dateCreation` datetime NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `societes`
--

INSERT INTO `societes` (`ID`, `raisonSociale`, `nbActions`, `valeurUnitaire`, `dateCreation`) VALUES
(1, 'Mc Donalds Burger', 1000, 3500, '2020-09-08 12:27:02'),
(2, 'Banque National', 10000, 4500, '1970-01-01 00:00:00');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
