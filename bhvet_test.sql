-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: May 14, 2019 at 11:44 PM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bhvet_test`
--
CREATE DATABASE IF NOT EXISTS `bhvet_test` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `bhvet_test`;

-- --------------------------------------------------------

--
-- Table structure for table `appts`
--

CREATE TABLE `appts` (
  `id` int(11) NOT NULL,
  `vet_id` int(11) NOT NULL,
  `patient_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `appts`
--

INSERT INTO `appts` (`id`, `vet_id`, `patient_id`) VALUES
(1, 6, 1),
(2, 6, 2),
(4, 8, 4),
(5, 8, 5),
(6, 9, 6),
(7, 15, 8),
(8, 15, 9),
(10, 17, 11),
(11, 17, 12),
(12, 18, 13),
(13, 24, 15),
(14, 24, 16),
(16, 26, 18),
(17, 26, 19),
(18, 27, 20),
(19, 33, 22),
(20, 33, 23),
(22, 35, 25),
(23, 35, 26),
(24, 36, 27),
(25, 42, 29),
(26, 42, 30),
(28, 44, 32),
(29, 44, 33),
(30, 45, 34),
(31, 51, 36),
(32, 51, 37),
(34, 53, 39),
(35, 53, 40),
(36, 54, 41),
(37, 60, 43),
(38, 60, 44),
(40, 62, 46),
(41, 62, 47),
(42, 63, 48),
(43, 64, 55),
(44, 66, 56),
(45, 72, 57),
(46, 72, 58),
(48, 74, 60),
(49, 74, 61),
(50, 75, 62),
(51, 76, 69),
(52, 78, 70),
(53, 84, 71),
(54, 84, 72),
(56, 86, 74),
(57, 86, 75),
(58, 87, 76),
(59, 88, 83),
(60, 90, 84),
(61, 96, 85),
(62, 96, 86),
(64, 98, 88),
(65, 98, 89),
(66, 99, 90);

-- --------------------------------------------------------

--
-- Table structure for table `patients`
--

CREATE TABLE `patients` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `visit_reason` varchar(255) NOT NULL,
  `type` varchar(255) NOT NULL,
  `dob` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `vets`
--

CREATE TABLE `vets` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `specialty` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='party all the time';

--
-- Indexes for dumped tables
--

--
-- Indexes for table `appts`
--
ALTER TABLE `appts`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `patients`
--
ALTER TABLE `patients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `vets`
--
ALTER TABLE `vets`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `appts`
--
ALTER TABLE `appts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=67;

--
-- AUTO_INCREMENT for table `patients`
--
ALTER TABLE `patients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=92;

--
-- AUTO_INCREMENT for table `vets`
--
ALTER TABLE `vets`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=100;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
