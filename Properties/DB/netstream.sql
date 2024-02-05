-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Feb 05, 2024 at 11:12 PM
-- Server version: 8.0.31
-- PHP Version: 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `netstream`
--

-- --------------------------------------------------------

--
-- Table structure for table `kategorija`
--

DROP TABLE IF EXISTS `kategorija`;
CREATE TABLE IF NOT EXISTS `kategorija` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Naziv` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `kategorija`
--

INSERT INTO `kategorija` (`ID`, `Naziv`) VALUES
(1, 'Akcija'),
(2, 'Horor'),
(3, 'Komedija'),
(4, 'Dokumentarni'),
(5, 'Triler');

-- --------------------------------------------------------

--
-- Table structure for table `korisnik`
--

DROP TABLE IF EXISTS `korisnik`;
CREATE TABLE IF NOT EXISTS `korisnik` (
  `ID` int NOT NULL,
  `Ime` varchar(255) DEFAULT NULL,
  `Prezime` varchar(255) DEFAULT NULL,
  `Korisnicko_ime` varchar(255) DEFAULT NULL,
  `Lozinka` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Aktivan` tinyint(1) DEFAULT NULL,
  `Razina_ID` int DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `Razina_ID` (`Razina_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `korisnik`
--

INSERT INTO `korisnik` (`ID`, `Ime`, `Prezime`, `Korisnicko_ime`, `Lozinka`, `Email`, `Aktivan`, `Razina_ID`) VALUES
(0, 'John', 'Doe', 'johndoe', 'password1', 'john.doe@example.com', 1, 1),
(1, 'John', 'Doe', 'johndoe', 'password1', 'john.doe@example.com', 1, 1),
(2, 'Jane', 'Smith', 'janesmith', 'password2', 'jane.smith@example.com', 1, 2),
(3, 'Jana', 'Voda', 'jana', 'jana123', 'jana@gmail.com', 1, 2);

-- --------------------------------------------------------

--
-- Table structure for table `razina`
--

DROP TABLE IF EXISTS `razina`;
CREATE TABLE IF NOT EXISTS `razina` (
  `ID` int NOT NULL,
  `Naziv` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `razina`
--

INSERT INTO `razina` (`ID`, `Naziv`) VALUES
(1, 'Administrator'),
(2, 'Korisnik');

-- --------------------------------------------------------

--
-- Table structure for table `video`
--

DROP TABLE IF EXISTS `video`;
CREATE TABLE IF NOT EXISTS `video` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Sifra` varchar(255) DEFAULT NULL,
  `Naziv` varchar(255) DEFAULT NULL,
  `Redatelj` varchar(255) DEFAULT NULL,
  `Godina` int DEFAULT NULL,
  `Trajanje` int DEFAULT NULL,
  `Cijena` decimal(10,2) DEFAULT NULL,
  `Url` varchar(255) DEFAULT NULL,
  `Tip` enum('Film','Serija') DEFAULT NULL,
  `Kategorija_ID` int DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `Kategorija_ID` (`Kategorija_ID`)
) ENGINE=MyISAM AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `video`
--

INSERT INTO `video` (`ID`, `Sifra`, `Naziv`, `Redatelj`, `Godina`, `Trajanje`, `Cijena`, `Url`, `Tip`, `Kategorija_ID`) VALUES
(1, 'ABC123', 'The Dark Knight', 'Christopher Nolan', 2008, 152, '9.99', 'url1', 'Film', 1),
(2, 'DEF456', 'John Wick', 'Chad Stahelski', 2014, 101, '7.99', 'url2', 'Film', 1),
(3, 'GHI789', 'The Avengers', 'Joss Whedon', 2012, 143, '8.99', 'url3', 'Film', 1),
(4, 'JKL012', 'Die Hard', 'John McTiernan', 1988, 132, '6.99', 'url4', 'Film', 1),
(5, 'MNO345', 'The Shining', 'Stanley Kubrick', 1980, 146, '7.99', 'url5', 'Film', 2),
(6, 'PQR678', 'Get Out', 'Jordan Peele', 2017, 104, '6.99', 'url6', 'Film', 2),
(7, 'STU901', 'A Quiet Place', 'John Krasinski', 2018, 90, '8.99', 'url7', 'Film', 2),
(8, 'VWX234', 'Hereditary', 'Ari Aster', 2018, 127, '9.99', 'url8', 'Film', 2),
(9, 'YZA567', 'Superbad', 'Greg Mottola', 2007, 113, '6.99', 'url9', 'Film', 3),
(10, 'BCD890', 'The Hangover', 'Todd Phillips', 2009, 100, '7.99', 'url10', 'Film', 3),
(11, 'EFG123', 'Bridesmaids', 'Paul Feig', 2011, 125, '8.99', 'url11', 'Film', 3),
(12, 'HIJ456', 'Dumb and Dumber', 'Peter Farrelly', 1994, 107, '6.99', 'url12', 'Film', 3),
(13, 'KLM789', 'Planet Earth II', 'Various', 2016, 360, '12.99', 'url13', 'Serija', 4),
(14, 'NOP012', 'Making a Murderer', 'Laura Ricciardi', 2015, 700, '14.99', 'url14', 'Serija', 4),
(15, 'QRS345', 'The Last Dance', 'Jason Hehir', 2020, 500, '13.99', 'url15', 'Serija', 4),
(16, 'TUV678', '13th', 'Ava DuVernay', 2016, 100, '9.99', 'url16', 'Film', 4),
(17, 'WXY901', 'Se7en', 'David Fincher', 1995, 127, '8.99', 'url17', 'Film', 5),
(18, 'ZAB234', 'Gone Girl', 'David Fincher', 2014, 149, '9.99', 'url18', 'Film', 5),
(19, 'BCD567', 'Prisoners', 'Denis Villeneuve', 2013, 153, '10.99', 'url19', 'Film', 5),
(20, 'EFG890', 'You', 'Greg Berlanti', 2018, 400, '11.99', 'url20', 'Serija', 5);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
