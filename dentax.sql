-- phpMyAdmin SQL Dump
-- version 4.7.9
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 24, 2018 at 09:37 PM
-- Server version: 10.1.31-MariaDB
-- PHP Version: 5.6.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dentax`
--

-- --------------------------------------------------------

--
-- Table structure for table `doctors`
--

CREATE TABLE `doctors` (
  `Id` int(255) NOT NULL,
  `Username` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `doctors`
--

INSERT INTO `doctors` (`Id`, `Username`, `Password`) VALUES
(1, 'admin', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `patients`
--

CREATE TABLE `patients` (
  `Id` int(255) NOT NULL,
  `Emri` varchar(255) NOT NULL,
  `Mbiemri` varchar(255) NOT NULL,
  `Vendlindja` varchar(255) NOT NULL,
  `Telefoni` varchar(255) NOT NULL,
  `Regjistruar` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `patients`
--

INSERT INTO `patients` (`Id`, `Emri`, `Mbiemri`, `Vendlindja`, `Telefoni`, `Regjistruar`) VALUES
(1, 'Besart', 'Gashi', 'Prishtinë', '049115023', '2018-05-21'),
(2, 'Granit', 'Ahmeti', 'Pejë', '044852963', '2018-05-21'),
(3, 'Blerta', 'Ternava', 'Gjakovë', '044897456', '2018-05-21'),
(4, 'Genta', 'Haziri', 'Prishtinë', '045874561', '2018-05-21');

-- --------------------------------------------------------

--
-- Table structure for table `sherbimet`
--

CREATE TABLE `sherbimet` (
  `Id` int(255) NOT NULL,
  `Sherbimi` varchar(255) NOT NULL,
  `Aktive` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sherbimet`
--

INSERT INTO `sherbimet` (`Id`, `Sherbimi`, `Aktive`) VALUES
(1, 'Nxjerrje', 1),
(2, 'Mbushje e dhëmbeve', 1),
(3, 'Sherimi i kanaleve', 1),
(4, 'Heqja e gureve', 1),
(5, 'Zbardhimi i dhëmbeve', 1);

-- --------------------------------------------------------

--
-- Table structure for table `trajtimi`
--

CREATE TABLE `trajtimi` (
  `Id` int(255) NOT NULL,
  `Personi` varchar(255) NOT NULL,
  `Sherbimi` varchar(255) NOT NULL,
  `Dhembi` varchar(255) NOT NULL,
  `Shenime` text NOT NULL,
  `Qmimi` decimal(10,2) NOT NULL,
  `Data` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `trajtimi`
--

INSERT INTO `trajtimi` (`Id`, `Personi`, `Sherbimi`, `Dhembi`, `Shenime`, `Qmimi`, `Data`) VALUES
(1, '1 Besart Gashi', 'Nxjerrje', '14', 'Nxjerrje e dhëmbit pasi që riparimi është i pamundshëm', '25.00', '2018-05-21'),
(2, '4 Genta Haziri', 'Nxjerrje', '23', 'Nxjerrje e dhëmbit', '25.00', '2018-05-21'),
(3, '4 Genta Haziri', 'Mbushje e dhëmbeve', '15', 'Mbushje e dhëmbit 15', '30.00', '2018-05-22'),
(4, '2 Granit Ahmeti', 'Zbardhimi i dhëmbeve', '15', 'Zbardhim i dhëmbeve me 5 seanca', '45.00', '2018-05-22');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `doctors`
--
ALTER TABLE `doctors`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `patients`
--
ALTER TABLE `patients`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `sherbimet`
--
ALTER TABLE `sherbimet`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `trajtimi`
--
ALTER TABLE `trajtimi`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `doctors`
--
ALTER TABLE `doctors`
  MODIFY `Id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `patients`
--
ALTER TABLE `patients`
  MODIFY `Id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `sherbimet`
--
ALTER TABLE `sherbimet`
  MODIFY `Id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `trajtimi`
--
ALTER TABLE `trajtimi`
  MODIFY `Id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
